<template>
    <div class="page-body"><br>
        <div class="row">
            <div class="col-lg-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/portal-evaluations/take-evaluation"> Evaluations

                            </router-link>
                            <div class="slide"></div>
                        </li>
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/portal-evaluations/evaluation-history">
                                Evaluations History
                            </router-link>
                            <div class="slide"></div>
                        </li>
                    </ul>
                </div>
                <div class="tab-content" >
                    <router-view>

                    </router-view>
                </div>
                <div class="tab-content page-body" v-if="false">
                    <div class="card">
                        <div class="card-block" v-if="!allowedOnlineBooking">
                            <div class="text-center text-danger">
                                <div class="btn  btn-danger"
                                     style="border-radius: 100%;height: 140px;width: 140px;">
                                    <div class="clearfix">&nbsp;</div>

                                    <div class="h2">
                                        <i class="fa fa-exclamation fa-2x"></i>
                                    </div>
                                </div>
                                <br>{{statusMessage}}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  data() {
    return {
      allowedOnlineBooking: false,
      checkingBookingHttp: false,
      statusMessage: ""
    };
  },
  methods: {
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to });
      }
    },
    checkonlineBookingStatus: function() {
      this.allowedOnlineBooking = false;
      this.checkingBookingHttp = true;
      this.$http
        .get("hostelbooking/checkhostelbookingstatus")
        .then(result => {
          this.checkingBookingHttp = false;

          if (result.data.success) {
            this.allowedOnlineBooking = true;
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
    // this.checkonlineBookingStatus();
  }
};
</script>

<style>
</style>
