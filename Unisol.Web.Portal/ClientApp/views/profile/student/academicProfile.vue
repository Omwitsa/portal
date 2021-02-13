<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <div class="card" v-if="!loading">
      <div class="card-header">
        <h5>Enrolment</h5>
      </div>

      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">CLASS</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.class}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">REGISTRATION NUMBER</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.admnNo}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">STAY</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.stay}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">NOTES</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.notes}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">PERSONNEL</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.personnel}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">HOSTEL</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.hostel}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">START DATE</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.sdate}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">END DATE</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.edate}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">CREATED DATE</div>
          <div class="col-md-6">{{ ": "+ enrollmentData.rdate}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="!loading">
      <div class="card-header">
        <h5>Institution Attended</h5>
      </div>

      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">NAME</div>
          <div class="col-md-6">{{ ": "+ schools.names}}</div>
        </div>

        <div class="row col-md-12">
          <div class="col-md-3">Start</div>
          <div class="col-md-6">{{ ": "+ schools.startYear}}</div>
        </div>

        <div class="row col-md-12">
          <div class="col-md-3">End</div>
          <div class="col-md-6">{{ ": "+ schools.endYear}}</div>
        </div>

        <div class="row col-md-12">
          <div class="col-md-3">Qualification</div>
          <div class="col-md-6">{{ ": "+ schools.qualification}}</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
  data() {
    return {
      user: {},
      enrollmentData: {},
      schools: {},
      loading: false
    };
  },
  methods: {
    loadEnrollment() {
      this.loading = true;
      this.$http
        .get("profile/getStudentEnrollment?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.enrollmentData = result.data.data.studEnrolment;
            this.schools = result.data.data.school;
            this.enrollmentData.sdate = DateFomatter.ReturnDate(
              this.enrollmentData.sdate
            );
            this.enrollmentData.edate = DateFomatter.ReturnDate(
              this.enrollmentData.edate
            );
            this.enrollmentData.rdate = DateFomatter.ReturnDate(
              this.enrollmentData.rdate
            );
          } else {
            this.$toastr("error", result.data.message);
          }
          this.loading = false;
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.user = this.$baseRead("user");
    this.loadEnrollment();
  }
};
</script>
<style scoped>
.list-group-item {
  border-left: none !important;
  border-right: none !important;
}
.col-md-3 {
  font-weight: bold;
}
</style>
