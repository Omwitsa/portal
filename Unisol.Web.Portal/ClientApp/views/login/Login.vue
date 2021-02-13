<template>
  <div class="row justify-content-md-center">
    <div class="col-md-4 col-lg-4">
      <div class="mainContentArea">
        <loading-spinner :loading="loading"></loading-spinner>
        <div class="row" v-if="!loading">
          <div class="col-md-12 card">
            <div class>
              <img v-if="!isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="30%" />
              <img v-if="isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="70%" style="margin:3rem;" />  
              <br />
              <div class>
                <h4 class>Welcome</h4>
                <p>{{message}}</p>
              </div>
              <form>
                <div class="form-group">
                  <div class="col-12">
                    <div class="form-group">
                      <label class="pull-left">Username</label>
                      <input
                        class="form-control"
                        type="text"
                        :placeholder="usernamePlaceholder"
                        v-model="user.username"
                        @keyup.enter="focusToPassword"
                      />
                    </div>
                    <div class="form-group">
                      <label class="pull-left">Password</label>
                      <input
                        class="form-control"
                        type="password"
                        placeholder="Enter Password"
                        ref="password"
                        v-model="user.password"
                        @keyup.enter="login"
                      />
                    </div>
                  </div>
                  <submit-button
                    :class="[ { 'disabled' : submitting }]"
                    :loading="submitting"
                    title="Login"
                    v-on:submit="login"
                    styling="btn btn-primary btn-round waves-effect waves-light "
                  />
                </div>
              </form>
              <router-link to="reset" class="btn btn-link">Forgot password?</router-link>
              <button class="btn btn-link" @click="register">Create an account</button>
              <br />
              <br />
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
      user: {},
      submitting: false,
      isLaikipia: false,
      settings: {},
      loading: true,
      message: "",
      usernamePlaceholder: ""
    };
  },
  mixins: {},
  methods: {
    register() {
      this.$router.replace({ name: "register" });
    },
    focusToPassword() {
      this.$refs.password.focus();
    },
    login() {
      this.submitting = true;
      this.$http.post("login/user", this.user)
        .then(response => {
          this.submitting = false;
          var results = response.data.data;
          if (response.data.success) {
            this.$baseStore("user", response.data.data);
            this.$toastr("success", response.data.message);
            window.location.href = "/";
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(error => {
          localStorage.removeItem("user");
          this.submitting = false;
          this.$toastr("error", error.message);
        });
    },
    getSettings() {
      this.loading = true;
      this.$http.get("login/getSettings")
        .then(result => {
          this.settings = result.data.data.settings
          this.loading = false;
          this.isLaikipia = this.settings.initials == 'LU' ? true : false;
          this.message = this.settings.isGenesis? "To login enter Employee Number and Password" : "To login enter your Student Admission No. / Employee Number and Password"
          this.usernamePlaceholder = this.settings.isGenesis? "Enter Username" : "Enter Student No. / Employee No."
          localStorage.setItem("settings", JSON.stringify(this.settings));
        })
        .catch(error => {});
    }
  }, 
  created() {
    this.getSettings();
  }
};
</script>
<style>
</style>
