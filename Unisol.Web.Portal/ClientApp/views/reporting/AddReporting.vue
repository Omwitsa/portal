<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span v-if="subTitle">{{subTitle}}</span>
      </div>
      <div class="card-block">
        <div
          class="alert"
          :class="[{ 'alert-info' : !reportStatus.reported },{ 'alert-success' : reportStatus.reported }]"
        >
          <i class="fa fa-check fa-2x" v-if="!reportingHttp && reportStatus.reported"></i>
          <i class="fa fa-exclamation-circle fa-2x" v-if="!reportingHttp && !reportStatus.reported"></i>
          &nbsp; {{statusReportMessage}}
          <small-spinner :loading="reportingHttp"></small-spinner>
        </div>

        <div class="card-block text-center" v-if="termHttp"></div>
      </div>

      <div class="card-footer">
        <div class="text-center">
          <div v-if="!termHttp && !reportStatus.reported && !savingHttp">
            <div
              class="btn btn-primary btn-round waves-effect waves-light"
              @click="saveReported"
            >Report</div>
            <button class="btn btn-inverse btn-round waves-effect waves-light">Cancel</button>
          </div>
        </div>
        <div v-if="savingHttp" class="text-center">
          <small-spinner :loading="savingHttp"></small-spinner>saving ...
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";

export default {
  data() {
    return {
      user: this.$baseRead("user"),
      clickedIndex: null,
      termHttp: false,
      reportingHttp: false,
      savingHttp: false,
      title: "Reporting",
      subTitle: "Online Reporting",
      studentCurrentTerm: "",
      activeCurrentTerm: "",
      statusReportMessage: "",
      searchText: "",
      reportStatus: {
        reported: false
      },
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    getCurrentSemester() {
      this.termHttp = true;
      this.$http
        .get(
          "commonutilities/getStudentcurrentTerm?usercode=" + this.user.username
        )
        .then(result => {
          this.termHttp = false;
          if (result.data.success) {
            this.studentCurrentTerm = result.data.data;
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.termHttp = false;
          this.$toastr("error", error.message);
        });
    },
    checkIfReported() {
      this.activeCurrentTerm = "";
      this.reportingHttp = true;
      this.$http.get("commonutilities/CheckReportStatus?usercode=" + this.user.username)
        .then(result => {
          this.reportingHttp = false;
          this.activeCurrentTerm = result.data.data;
          this.statusReportMessage = result.data.message;
          this.reportStatus.reported = result.data.success;
          if (result.data.notAuthenticated) {
            this.$router.replace({ name: "401-forbidden" });
          }
        })
        .catch(error => {
          this.termHttp = false;
          this.$toastr("error", error.message);
        });
    },

    getActiveCurrentSemester: function() {
      this.termHttp = true;
      this.$http
        .get("commonutilities/CurrectActiveTerm?usercode=" + this.user.username)
        .then(result => {
          this.termHttp = false;
          if (result.data.success) {
            this.activeCurrentTerm = result.data.data;
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.termHttp = false;
          this.$toastr("error", error.message);
        });
    },
    saveReported: function() {
      this.savingHttp = true;
      var data = { userCode: this.user.username };
      this.$http
        .post("onlinereporting/report", data)
        .then(result => {
          this.savingHttp = false;
          if (result.data.success) {
            this.checkIfReported();
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.termHttp = false;
          this.$toastr("error", error.message);
        });
    }
  },

  created() {
    this.checkIfReported();
    this.getCurrentSemester();
  }
};
</script>
<style>
</style>
