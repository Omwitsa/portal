<template>
  <div class="container">
    <div class="row justify-content-md-center align-middle ">
      <div class="col-md-5 ">
        <!-- <div class="contentArea justify-content-md-center">
          <img :src="settings.LogoImageUrl" :alt="settings.Initials" width="30%"/>
          <br>
          <h3>Create Account Password</h3>
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
              title="Set Password" 
              v-on:submit="confirmDetails" 
              styling="btn btn-primary btn-round waves-effect waves-light "/>
        </div> -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      submitting: false
    }
  },
  methods: {
    confirm(code) {
      this.submitting = true
      this.$http.get(`users/confirm/?code=${code}`)
        .then(response => {
          this.submitting = false
          if (response.data.success) {
            this.$toastr("success", response.data.message);
            this.$router.push({ name: "login" });
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
    this.confirm(this.$route.params.code)
  }
}
</script>
<style scoped>
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
