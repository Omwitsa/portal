<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>

    <data-table
      v-if="!loading"
      :data="applications"
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
      applications: [],
      user: {},
      eligibleMessage: "",
      loading: true,
      title: "Clearances",
      subTitle: "View Clearance Requests.",
      tableActions: [],
      headerActions: [
        {
          name: "Apply Clearance",
          icon: "plus",
          type: "link",
          path: "/clearances/apply",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Ref",
          type: "currency"
        },
        {
          name: "Date",
          type: "code"
        },
        {
          name: "Notes",
          type: "story"
        },
        {
          name: "Comments",
          type: "story"
        },
        {
          name: "Status",
          type: "badge"
        }
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
      this.$http.get(`clearances/gethistory?admnNo=${this.user.username}&role=${this.user.role}`)
        .then(result => {
          this.applications = [];
          if (result.data.success) {
            var info = result.data.data;
            this.eligibleMessage = result.data.message;
            if (info != null) {
              info.forEach(element => {
                var item = {
                  ref: element.admnNo,
                  date: DateFomatter.ReturnDate(element.rdate),
                  notes: element.notes,
                  status: element.status,
                  comments: element.comments ? element.comments : ""
                };
                this.applications.push(item);
              });
            }
            this.pagination.total = this.applications.length;
            this.pagination.current = pageNumber;
          } else {
            this.$toastr("error", result.data.message);
            // if (result.data.notAuthenticated) {
            //   this.$router.replace({ name: "401-forbidden" });
            // }
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loading = false;
    },
    buttonEvent(item, action) {}
  },
  created() {
    this.user = this.$baseRead("user");
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
