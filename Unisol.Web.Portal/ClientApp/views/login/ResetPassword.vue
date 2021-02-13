<template>
  <div class="container">
    <div class="row justify-content-md-center align-middle ">
      <div class="col-md-5 ">
        <div class="contentArea justify-content-md-center">
          <img :src="settings.LogoImageUrl" :alt="settings.Initials" width="30%"/>
          <br>
          <h3>{{headerInfo}}</h3>
          <br>
          <div class="col-12">
            <input 
            type="Password" 
            class="form-control" 
            name="Password" 
            v-model="confirm.password"
            placeholder="Enter Your Password">
          <br>
          <input
            type="Password" 
            class="form-control"
            v-model="confirm.password2"
            name="Password" 
            placeholder="Confirm Your Password">
          </div>
            <br>

            <submit-button 
              :loading="submitting" 
              :title="buttonText" 
              v-on:submit="confirmDetails" 
              styling="btn btn-primary btn-round waves-effect waves-light "/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  computed:{
    headerInfo() {
      if (this.reset) {
        return "Reset Account Password"
      }
      return "Enter Account Password"
    },
    buttonText(){
      if (this.reset) {
        return "Reset Password"
      }
      return "Submit"
    }
  },
  data() {
    return {
      confirm: {},
      code: "",
      submitting: false,
      user: this.$baseRead('user'),
      reset: false
    }
  },
  methods: {
    confirmDetails() {
      var password = this.confirm.password
      if(this.confirm.password != this.confirm.password2){
       this.$toastr("error", "Confirm password field can't be empty")
      }
      else if(this.reset){
        this.submitting = true
        var user = {}
        if(this.user){
          user = {
            RegNumber: this.$route.params.code,
            Role: this.user.role,
            Password: this.confirm.password
          }
        }
        else{
          user = {
            RegNumber: this.$route.params.code,
            Role: 9,
            Password: this.confirm.password
          }
        }
         
        this.$http.post("users/reset", user)
        .then(response => {
          this.submitting = false
            if (response.data.success) {
              this.$toastr("success", response.data.message)
              if(this.user)
                this.$router.push({ name: "users" });
              else
                this.$router.push({ name: "login" });
            } else {
                this.$toastr("error", response.data.message)
            }
        })
        .catch(e => {
            this.$toastr("error", "Server error occured")
        })
      }
      else{
        this.submitting = true
        this.confirm.code = this.code
        var url = "users/reset"
        var message = ""
        var userName = JSON.parse(localStorage.getItem("regNum"))
        if(userName){
          this.confirm = {}
          this.confirm = {
            RegNumber: userName,
            Role: this.user.role,
            Password: password
          }
          localStorage.removeItem("regNum");
        } 
        message = "You password has been reset successfully"
        this.$http.post(url, this.confirm)
        .then(response => {
          this.submitting = false
          if (response.data.success) {
            if(this.user.role == 1){
              message= "Password set successfully"
              this.$router.push({ name: "users" });
            }
            else{
              this.$router.push({ name: "login" });
            }
            this.$toastr("success", message);
            
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
          this.submitting = false
            this.$toastr("error", e.message);
        })
      }
    }
  },
  created() {
    this.settings = JSON.parse(localStorage.getItem('settings'))
    if (this.$route.params.code) {
      this.reset = true
      if(!this.user)
        this.reset = true
   
      this.code = this.$route.params.code
    } else {
      // error
    }
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
