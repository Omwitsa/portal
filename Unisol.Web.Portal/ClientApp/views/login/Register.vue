<template>
  <div class="row justify-content-md-center">
    <div class="col-md-4 col-lg-4">
      <div class="mainContentArea">
        <div class="row">
          <div class="col-md-12 card"> <br><br>
            <div class>
              <img v-if="!isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="30%" />
              <img v-if="isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="70%" style="margin:3rem;" />
              <br />
              <div class="col">
                <h4 class>Account Registration</h4>
                <p class>To register for an Account, kindly fill the form bellow</p>
              </div>
              <br />
              <form>
                <div v-if="!settings.isGenesis">
                  <label style="font-weight: bold">Select Role: &nbsp;&nbsp;&nbsp;</label>
                  <input
                    type="radio"
                    name="userType"
                    aria-label="Student"
                    @change="getPlaceholder"
                    id="student"
                    v-model="registry.role"
                    value="3"
                  />
                  <label for="student">Student</label> &nbsp;&nbsp;&nbsp;
                  <input
                    type="radio"
                    name="userType"
                    @change="getPlaceholder"
                    v-model="registry.role"
                    aria-label="Employee"
                    id="employee"
                    value="2"
                  />
                  <label for="employee">Employee</label>
                </div>

                <div class="form-group">
                  <div class="col-12">
                    <div class="form-group">
                      <input
                        type="text"
                        class="form-control"
                        v-model="registry.regNumber"
                        name="text"
                        :placeholder="regNoPlaceHolder"
                        required
                        autofocus /> <br>
                      <input 
                        type="Password" 
                        class="form-control" 
                        name="Password" 
                        v-model="registry.password"
                        placeholder="Enter Your Password" /> <br>
                       <input
                        type="Password" 
                        class="form-control"
                        v-model="registry.passwordConfirm"
                        name="Password" 
                        placeholder="Confirm Your Password" />
                    </div>
                  </div>
                  <br />
                  <submit-button
                    :loading="submitting"
                    title="Submit"
                    v-on:submit="register"
                    styling="btn btn-primary btn-round waves-effect waves-light  account-create-submit"
                  />
                </div>
              </form>
              <submit-button
                title="Return to Login"
                v-on:submit="returnToLogin"
                styling="btn btn-link"
              />
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
      isLaikipia: false,
      regNoPlaceHolder: "Student Admission No. / Employee No.",
      submitting: false,
      registry: {
        role: 2,
        portalUrl: window.location.origin
      }
    };
  },
  methods: {
    getPlaceholder() {
      this.regNoPlaceHolder = this.registry.role == 3 ? "Enter your student Admission No." : "Enter your Employee No.";
    },
    returnToLogin() {
      this.$router.replace({ name: "login" });
    },
    register() {
      if (!this.registry.role) {
        this.$toastr("error", "Please select role");
      } else if (!this.registry.regNumber) {
        this.$toastr("error", "Please provide your registration number");
      } else {
        this.submitting = true;
        this.$http.post(`users/register`, this.registry)
          .then(response => {
            if (response.data.success) {
              this.$router.replace("email-confirmation");
            } else {
              this.$toastr("error", response.data.message);
            }
            this.submitting = false;
          })
          .catch(e => {
            this.$toastr("error", e.message);
            this.submitting = false;
          });
      } 
    }
  },
  created() {
    this.settings = JSON.parse(localStorage.getItem("settings"));
    this.isLaikipia = this.settings.initials == 'LU' ? true : false;
  }
};
</script>
<style scoped>
.contentArea {
  background-color: white;
  display: block;
  border-radius: 0.25rem;
  margin: auto 0;
  text-align: center;
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 30px;
  margin-top: 20%;
  border: 1px solid rgba(0, 0, 0, 0.125);
}
.contentArea img {
  width: 200px;
  height: auto;
}
.pcoded-content {
  margin-left: 1px !important;
}
.account-create-submit {
  padding-left: 3em;
  padding-right: 3em;
}
</style>
