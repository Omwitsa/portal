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

    <!-- <div class="card-block" v-if="!applications.length">
          <div class="col-md-12 alert-warning">
            <div > &nbsp;
              <h5 class="text-center"> <i class="fa fa-exclamation-circle fa-5x"></i><br>{{eligibleMessage}} </h5> 
              &nbsp;
            </div>
          </div>
    </div>-->
  </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      applications: [],
      employee: {},
      eligibleMessage: "",
      loading: true,
      title: "Applications",
      subTitle: "Leave Requests.",
      tableActions: [],
      headerActions: [
        {
          name: "Apply Leave",
          icon: "plus",
          type: "link",
          path: "applications/add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Ref",
          type: "currency"
        },
        {
          name: "Leave Type",
          type: "numeric"
        },
        {
          name: "Start Date",
          type: "code"
        },
        {
          name: "End Date",
          type: "code"
        },
        {
          name: "Date Created",
          type: "code"
        },
        {
          name: "Notes",
          type: "story"
        },
        {
          name: "Status",
          type: "badge"
        },
        {
          name: "Reason",
          type: "badge"
        },
        {
          name: "Reliver Approval",
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
      this.$http.get("leave/getByEmployee?empNo=" + this.employee.username)
        .then(result => {
          this.applications = [];
          if (result.data.success) {
            this.eligibleMessage = result.data.message;
            result.data.data.forEach(element => {
              element.startdate = DateFomatter.ReturnDate(element.sdate)
              element.enddate = DateFomatter.ReturnDate(element.edate)
              element.datecreated = DateFomatter.ReturnDate(element.rdate)
              element.reason = element.reason ? element.reason : ""
              element.leavetype = element.leaveType
              element.reliverapproval = element.reliverApproval ? element.reliverApproval : ""
            });
           
            this.applications = result.data.data
            this.pagination.total = this.applications.length;
            this.pagination.current = pageNumber;
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
