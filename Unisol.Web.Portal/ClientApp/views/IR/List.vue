<template>
  <div class="page-body">
    <div class="card"></div>
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="IRResults"
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
      loading: true,
      IRResults: null,
      dateFomatter: DateFomatter,
      title: "Internal Requisition",
      subTitle: "IR",
      user: this.$baseRead("user"),
      pagination: {
        total: 0
      },
      tableActions: [
        {
          name: "View",
          type: "button",
          icon: "trash",
          path: "view",
          design: "danger"
        }
      ],
      headerActions: [],
      columns: [
        {
          name: "Reference"
        },
        {
          name: "Created Date"
        },
        {
          name: "Action/Feedback "
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
      ]
    };
  },
  created() {
    var item = {};
    item.component = "add";
    localStorage.setItem("raisedIr", JSON.stringify(item))
    this.loadData(10, 1);
  },
  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;

      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);

      this.$http.get("ir/getIR/?usercode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.headerActions.push({
              name: "Add",
              icon: "plus",
              type: "link",
              path: "IR/add",
              design: "primary"
            })

            result.data.data.requisitions.forEach(element => {
              element.reference = element.reqRef
              element.createddate = this.dateFomatter.ReturnDate(element.rdate)
              element.actionfeedback = element.reaction
              element.reactedby = element.reactby
              element.datereacted = element.reactDate ? this.dateFomatter.ReturnDate(element.reactDate) : ""
            });
            
            this.IRResults = result.data.data.requisitions
            this.pagination.total = result.data.totalItems;
            this.pagination.current = pageNumber;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
          this.loading = false;
        })
        .catch(error => {
          this.loading = false;
        });
    },
    buttonEvent(item, action) {
      localStorage.setItem("raisedIr", null);
      switch (action) {
        case "view":
          item.component = "view";
          localStorage.setItem("raisedIr", JSON.stringify(item));
          this.$router.replace({ name: "IR-create" });
          break;
        default:
          break;
      }
    }
  }
};
</script>
<style>
</style>