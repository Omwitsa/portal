<template>
  <div class="page-body">
    <div class="card"></div>
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="sorData"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:buttonEvent="buttonEvent"
    ></data-table>
  </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      sorData: null,
      loading: true,
      dateFomatter: DateFomatter,
      user: [],
      title: "Specification of Requirements",
      subTitle: "SOR",
      tableActions: [
        {
          name: "View",
          type: "button",
          icon: "trash",
          path: "view",
          design: "danger"
        }
      ],
      headerActions: [
        {
          name: "Add",
          icon: "plus",
          type: "link",
          path: "sor/Add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Reference"
        },
        {
          name: "Created Date"
        },
        {
          name: "Action/Feedback"
        },
        {
          name: "Reacted By"
        },
        {
          name: "Date Reacted"
        },
        {
          name: "Notes",
          type: "badge"
        },
        {
          name: "Status"
        },
        {
          name: "Reason"
        },
      ],
      pagination: {
        total: 0
      }
    };
  },
  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;

      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http.get("Sor/getraised/?usercode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            result.data.data.sors.forEach(element => {
              element.reference = element.reqRef
              element.createddate = this.dateFomatter.ReturnDate(element.rdate)
              element.actionfeedback = element.reaction
              element.reactedby = element.reactby
              element.datereacted = element.reactDate ? this.dateFomatter.ReturnDate(element.reactDate) : ""
            });
            
            this.sorData = result.data.data.sors
            this.pagination.total = result.data.totalItems;
            this.pagination.current = pageNumber;
            this.loading = false;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.loading = false;
        });
    },
    buttonEvent(item, action) {
      localStorage.setItem("raisedSor", null);
      switch (action) {
        case "view":
          item.component = "view";
          localStorage.setItem("raisedsor", JSON.stringify(item));
          this.$router.replace({ name: "specification-of-requirement-items" });
          break;
        default:
          break;
      }
    }
  },
  created() {
    this.user = this.$baseRead("user");
    var item = {};
    item.component = "add";
    localStorage.setItem("raisedsor", JSON.stringify(item));
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
