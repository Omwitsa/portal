<template>
  <div class="row justify-content-md-center">
    <div class="col-md-4 col-lg-4">
      <div class="mainContentArea">
        <div class="row">
          <div class="col-md-12 card">
            <div class>
              <img :src="settings.LogoImageUrl" :alt="settings.Initials" width="30%" />
              <br />
              <div class="col">
                <h4 class>Recover Password</h4>
                <p class>A reset link will be sent to mail.</p>
              </div>
              <br />
              <form>
                <div class="form-group">
                  <div class="col-12">
                    <div class="form-group">
                      <label class="pull-left">Username</label>
                      <input
                        type="text"
                        class="form-control"
                        name="text"
                        placeholder="Enter Employee No | Registration No"
                        v-model="resetVal.regNumber"
                        required
                        autofocus
                      />
                    </div>
                  </div>
                  <br />
                  <submit-button
                    :loading="submitting"
                    title="Reset Password"
                    v-on:submit="reset"
                    styling="btn btn-primary btn-round waves-effect waves-light "
                  />
                </div>
              </form>
              <submit-button
                title="Return to Login"
                v-on:submit="returnToLogin"
                styling="btn btn-link "
              />
               <br>
              <br>
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
      resetVal: {},
      submitting: false,
    };
  },
  methods: {
    reset() {
      if (!this.resetVal.regNumber) {
        this.$toastr("error", "provide registration number");
      } else {
        this.submitting = true;
        this.resetVal.portalUrl = window.location.origin
        this.$http.post(`users/reset`, this.resetVal)
          .then(response => {
            if (response.data.success) {
              this.submitting = false;
              this.$toastr("success", response.data.message);
              this.$router.replace("reset-confirmation");
            } else {
              this.submitting = false;
              this.$toastr("error", response.data.message);
            }
          })
          .catch(e => {
            this.submitting = false;
            this.$toastr("error", e.message);
          });
      }
    },
    returnToLogin() {
      this.$router.replace({ name: "login" });
    }
  },
  created() {
    this.settings = JSON.parse(localStorage.getItem("settings"));
  }
};
</script>
<style scoped>
</style>
