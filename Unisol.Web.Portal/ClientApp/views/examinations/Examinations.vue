<template>
  <div class="page-body"> <br>
    <div class="row">
      <div class="col-lg-12">
        <div class="tab-header card">
          <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/examinations/view-examcard">
                Exam Card
                <small-spinner :loading="checkingBookingHttp"></small-spinner>
              </router-link>
              <div class="slide"></div>
            </li>

            <!-- <li class="nav-item" v-if="settings.initials !='UOEM' && settings.initials !='KBNP'">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/examinations/previous-examCard">
                ({{previousSemister}}) Exam Card
                <small-spinner :loading="checkingBookingHttp"></small-spinner>
              </router-link>
              <div class="slide"></div>
            </li> -->

            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/examinations/provisional-transcripts"
              >{{transcriptMessage}}</router-link>
              <div class="slide"></div>
            </li>

            <li class="nav-item">
              <router-link exact-active-class="active" class="nav-link" to="/examinations/retake">Retake
              </router-link>
              <div class="slide"></div>
            </li>

            <li class="nav-item" v-show="false">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/examinations/exam-history"
              >Examination History</router-link>
              <div class="slide"></div>
            </li>
          </ul>
        </div>
        <div class="tab-content">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      checkingBookingHttp: false,
      transcriptMessage: "Provisional Transcripts / Result Slip",
      previousSemister: "",
      loading: true,
      settings: JSON.parse(localStorage.getItem("settings")),
      user: this.$baseRead("user"),
      val: null
    };
  },
  methods: {
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to });
      }
    },
    previousResults: function() {
      this.$http.get("transcript/GetStudentPreviousAcademicYears?userCode=" + this.user.username)
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            this.previousSemister = result.data.data.data[0].previousSemister ? result.data.data.data[0].previousSemister : ""
            this.transcriptMessage = result.data.data.tabTitle;
          } else {
            this.$toastr("error", error.message);
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    },
    linkClass(to) {
      if (to) {
        var styling = "nav-link";
        const { name } = this.$route;

        if (name.startsWith(to)) styling = styling + " active";
        return styling;
      }
    }
  },
  created: function() {
    this.previousResults();
  }
};
</script>

<style>
</style>