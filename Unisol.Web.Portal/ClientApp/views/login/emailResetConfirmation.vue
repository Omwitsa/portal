<template>
<div class="container">
    <div class="row justify-content-md-center align-middle ">
        <div class="col-md-5 ">
            <div class="contentArea justify-content-md-center">
                <img :src="settings.LogoImageUrl" :alt="settings.Initials" width="30%"/>
                <br>
                <h4>Password Reset Successful</h4>
               Please check your email to set up a new password <br><br>

            <submit-button 
                :loading="submitting" 
                title="Ok"
                 v-on:submit="checkForConfirmation" 
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
      
    }
  },
  methods: {
    checkForConfirmation(){
        this.$router.replace({name: "login"})
    }
  },
  created() {
   this.settings = JSON.parse(localStorage.getItem('settings'))
  },
}
</script>
<style scoped>
.contentArea{
  background-color: white;
  display: block;
  border-radius: 0.25rem;
  margin: auto 0;
  text-align: center;
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 30px;
  margin-top: 20%;
  border: 1px solid rgba(0,0,0,.125);
}
.contentArea img{
  width: 200px;
  height: auto;
}
.pcoded-content {
    margin-left: 1px !important;
} 
</style>
