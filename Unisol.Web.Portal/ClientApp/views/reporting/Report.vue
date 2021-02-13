<template>
  <div class="page-body"> <br>
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span v-if="subTitle">{{subTitle}}</span>
      </div>
      <div class="card-block">
        <div class>
          <div class="page-body col-md-12 h2 text-center" v-if="checkingReportingHttp">
            <small-spinner :loading="checkingReportingHttp"></small-spinner>
          </div>
          <div class="page-body col-md-12" v-if="!checkingReportingHttp">
            <div class="card-block" v-if="!allowedOnlineReporting">
              <div class="col-md-12 alert-warning">
                <div v-if="!isParentfolderPresent">
                  &nbsp;
                  <h5 class="text-center">
                    <i class="fa fa-exclamation-circle fa-5x"></i>
                    <br>
                    {{statusMessage}}
                  </h5>&nbsp;
                </div>
              </div>
            </div>
          </div>
          <div class="page-body col-md-12" v-if="!checkingReportingHttp">
            <div class="pull-right">
              <router-link
                class="btn btn-primary btn-round waves-effect waves-light"
                to="/reporting/report"
                v-if="allowedOnlineReporting"
              >
                <icon icon="plus"/>&nbsp; Report Now
              </router-link>
            </div>
            <br>
            <br>
            <br>
            <div class="table-responsive">
              <table class="table table-bordered table-sm">
                <thead>
                  <tr>
                    <td>#</td>
                    <td>Semester</td>
                    <td>Date Reported</td>
                    <td>Type</td>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(report,index) in reportingHistory" :key="index">
                    <td>{{index+1}}</td>
                    <td>{{report.term}}</td>
                    <td>{{report.rdate}}</td>
                    <td>{{report.type}}</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div class="card-block text-center">
              <div
                class="btn btn-sm btn-primary"
                @click="previousPage()"
                v-if="totalPages >0&& offset< totalPages&&!reportingHistoryHttp&&offset>0"
              >Load previous</div>
              <div
                class="btn btn-sm btn-primary"
                v-if="totalPages >0"
              >{{offset+1}} of {{totalPages}}</div>
              <div
                class="btn btn-sm btn-primary"
                @click="nextPage()"
                v-if="totalPages >0&& offset+1< totalPages&&!reportingHistoryHttp"
              >Load next</div>
            </div>

            <div class="card-block text-center" v-if="reportingHistoryHttp">
              <small-spinner :loading="reportingHistoryHttp"></small-spinner>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      evaluations: [],
      clickedIndex: null,
      loading: true,
      reportingHistoryHttp: false,
      title: "Reporting",
      subTitle: "My Reporting History",
      pageSize: 15,
      itemsPerPage: 3,
      user: this.$baseRead("user"),
      offset: 0,
      totalPages: 0,
      totalItems: 0,
      allowedOnlineReporting: false,
      checkingReportingHttp: false,
      statusMessage: "",
      reportingHistory: [],
      searchText: "",
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    checkOnlineBookingStatus: function() {
      this.allowedOnlineReporting = false;
      this.checkingReportingHttp = true;
      this.$http
        .get("commonutilities/settingstatus?settingCode=006")
        .then(result => {
          this.checkingReportingHttp = false;

          if (result.data.success) {
            this.allowedOnlineReporting = true;
          } else {
            this.statusMessage = result.data.message;
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.checkingBookingHttp = false;
          this.$toastr("error", error.message);
        });
    },
    loadData() {
      this.reportingHistoryHttp = true;
      this.$http
        .get(
          "onlinereporting/OnlineReporting?usercode=" +
            this.user.username +
            "&searchText=" +
            this.searchText +
            "&offset=" +
            this.offset
        )
        .then(result => {
          this.reportingHistoryHttp = false;
          var info = result.data; 
          if (info.success) {
            this.reportingHistory = [];
            var array = result.data.data;
            array.forEach(element => {
              var item = {
                admnNo: element.admnNo,
                term: element.term,
                rdate: DateFomatter.ReturnDate(element.rdate),
                rtime: element.rtime,
                personnel: element.personnel,
                type: element.type
              };
              this.reportingHistory.push(item);
            });

            this.totalItems = result.data.totalItems;
            this.totalPages = Math.ceil(
              result.data.totalItems / this.itemsPerPage
            );
          } else {
            this.$toastr("error", result.data.message);
            if (info.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.reportingHistoryHttp = false;
          this.$toastr("error", error.message);
        });
    },
    nextPage: function() {
      if (Math.abs(this.offset) + 1 <= this.totalPages) {
        this.offset++;
        this.loadData();
      }
    },
    stripContent(content) {
      let regex = /(<([^>]+)>)/gi;
      return content.replace(regex, "") + "...";
    },
    previousPage: function() {
      if (Math.abs(this.offset) - 1 >= 0) {
        this.offset--;
        this.loadData();
      }
    },
    searchReporting: function() {
      this.reportingHistory = [];
      this.totalPages = 0;
      this.totalItems = 0;
      this.offset = 0;
      this.loadData();
    },
    deleteEvaluation: function(id, index) {
      this.evaluations.splice(index, 1);
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          alert("deleted");
          break;
        case "status":
          var activity = "disabled";
          if (item.status) activity = "activated";
          alert(activity);
          break;
        default:
          break;
      }
    }
  },

  created() {
    this.checkOnlineBookingStatus();
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
