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
export default {
  data() {
    return {
      applications: null,
      employee: {},
      loading: true,
      title: "Leave Days",
      subTitle: "Leave Balance.",
      tableActions: [],
      headerActions: [],
      columns: [
        {
          name: "Id",
          type: "currency"
        },
        {
          name: "Code",
          type: "currency"
        },
        {
          name: "Leave Type",
          type: "numeric"
        },
        {
          name: "Leave Group",
          type: "text"
        },
        {
          name: "Leave Days",
          type: "text"
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

      this.$http
        .get("leave/getLeaveDaysCredit?empNo=" + this.employee.username)
        .then(result => {
          this.applications = [];
          if (result.data.success) {
            var id = 1;
            result.data.data.leave.forEach(element => {
              element.leavetype = element.leaveType,
              element.code = element.code,
              element.id = id++,
              element.leavedays = element.leaveDays,
              element.leavegroup = element.leaveGroup
            });
            this.applications = result.data.data.leave
            this.pagination.total = this.applications.length;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
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
    this.employee = this.$baseRead("user");
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
