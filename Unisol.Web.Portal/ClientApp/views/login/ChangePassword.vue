<template>
  <div class="container">
    <div class="row justify-content-md-center align-middle ">
      <div class="col-md-5 ">
        <div class="contentArea justify-content-md-center">
          <img :src="settings.LogoImageUrl" :alt="settings.Initials" width="30%"/>
          <br>
          <h3>Change Account Password</h3>
          <br>
          <div class="col-12">
            <input 
            type="Password" 
            class="form-control" 
            name="oldPassword" 
            v-model="password.oldPassword"
            placeholder="Enter Old Password"><br>

            <input 
            type="Password" 
            class="form-control" 
            name="Password" 
            v-model="password.newPassword"
            placeholder="Enter new password"><br>

          <input
            type="Password" 
            class="form-control"
            v-model="password.newPassword2"
            name="Password" 
            placeholder="Confirm new password">
          </div><br>

            <submit-button 
            :loading="submitting" 
            title="Change Password" 
            v-on:submit="changePassword" 
            styling="btn btn-primary btn-round waves-effect waves-light "/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      password: {},
      user: this.$baseRead('user'),
      submitting: false
    }
  },
  methods: {
    changePassword() {
      if(this.password.newPassword != this.password.newPassword2){
        this.$toastr("error", "entered passwords do not match")
        return
      }
      this.submitting = true
      this.$http
        .get("users/ChangePassword/?newPassword="+this.password.newPassword+"&oldPassword="+this.password.oldPassword+"&userName="+this.user.username)
        .then(response => {
          this.submitting = false
          if (response.data.success) {
            this.$toastr("success", response.data.message)
            this.$router.push({ name: "login" })
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(error => {
          this.submitting = false
            this.$toastr("error", error.message)
        })
    }
  },
  created() {
    this.settings = JSON.parse(localStorage.getItem('settings'))
  }
}
</script>
<style>
.contentArea{
  background-color: white;
  display: block;
  margin: auto 0;
  border-radius: 0.25rem;
  text-align: center;
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 30px;
  margin-top: 20%;
  -webkit-box-shadow: 10px 10px 5px -8px rgba(0,0,0,0.75);
  -moz-box-shadow: 10px 10px 5px -8px rgba(0,0,0,0.75);
  box-shadow: 10px 10px 5px -8px rgba(0,0,0,0.75);
}
.contentArea img{
  width: 200px;
  height: auto;
}
.pcoded-content {
    margin-left: 1px !important;
} 
</style>
