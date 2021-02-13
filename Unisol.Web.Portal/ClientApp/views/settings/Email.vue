<template>
<div class="tab-pane active" role="tabpanel">
    <div class="card">
        <div class="card-header">
            <h5 class="card-header-text">Email </h5>
        </div>
        <div class="card-block">
            <div class="row">
                <div class="col-md-12">        
                    <fg-input 
                    type="email"
                    label="Email UserName" 
                    v-model="settings.emailUserName" 
                    placeholder="Email UserName" 
                    />
                    <fg-input 
                    type="text"
                    label="SmtpClient" 
                    v-model="settings.smtpClient" 
                    placeholder="Smtp Client" 
                    />
                    <fg-input 
                    type="password"
                    label="SMTP Password" 
                    v-model="settings.password" 
                    placeholder="Password" 
                    />
                    <fg-input 
                    type="number"
                    label="Port" 
                    v-model="settings.port" 
                    placeholder="Port" 
                    />
                    <div>
                      <label for="">Select Secure Socket Options</label>
                      <v-select
                      :options="socketOptions"
                      v-model="settings.socketOption"
                    ></v-select>
                    </div>
                    <div class="card-block text-right">
                      <submit-button :title="buttonText"
                      styling="btn btn-primary btn-round waves-effect waves-light "
                      :loading="updating" v-on:submit="update"></submit-button>
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
      settings: {},
      buttonText: "Update",
      updating: false,
      socketOptions: ['None', 'SslOnConnect', 'StartTls']
    }
  },
  methods: {
    fetch () {
        this.$http
        .get("settings/get/")
        .then(result => {
          if(result.data.success){
            this.settings = result.data.data
            var message = result.data.message
          }else{
            this.$toastr("error", result.data.message)
          }
        })
        .catch(error => {
          this.$toastr("error", error.message)
        })
      },
      update(){
        this.updating = true
        this.$http.post("settings/updateSettings/", this.settings)
        .then(result => {
          if (result.data.success) {
            this.$toastr("success", result.data.message)
          }
          else{
            this.$toastr("error", result.data.message)
          }
          this.updating = false
        })
        .catch(error => {
          this.$toastr("error", error.message)
          this.updating = false
        })
      }
  },
  created () {
    this.fetch()
  }
}
</script>
<style>
</style>


