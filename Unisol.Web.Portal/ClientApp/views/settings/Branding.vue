<template>
<div class="tab-pane active" role="tabpanel">
    <div class="card">
        <div class="card-header">
            <h5 class="card-header-text">Branding</h5>
        </div>
        <div class="card-block">
            <div class="row">
                <div class="col-xl-3 col-lg-4 col-md-4 col-xs-12">
                    <logo-section :url="logoImageUrl" :imageName="logoImage"></logo-section>
                    <logo-section :url="loginImageUrl" :imageName="loginImage"></logo-section>
                </div>
                <div class="col-xl-9 col-lg-8 col-md-8 col-xs-12 card ">
                    <h3>Details</h3>
                    <fg-input 
                    type="text"
                    label="Name" 
                    v-model="settings.name" 
                    placeholder="Name" 
                    />
                    <div class="form-group">
                        <label for="">Address</label>
                        <textarea placeholder="Address"  v-model="settings.address" cols="30" class="form-control" rows="5"></textarea>
                    </div>

                    <fg-input 
                    type="text"
                    label="Initials" 
                    v-model="settings.initials" 
                    placeholder="Initials" 
                    />

                    <div class="form-group">
                        <label for="">Theme Colour</label><br>
                        <input v-model="settings.themeColor" type="color">
                    </div>

                    <div class="form-group">
                        <label for="">Secondary Colour</label><br>
                        <input v-model="settings.secondaryColor" type="color">
                    </div>

                    <fg-input 
                    type="text"
                    label="Modules" 
                    v-model="settings.modules" 
                    placeholder="Module" 
                    />

                    <fg-input 
                    type="text"
                    label="Login Message Title" 
                    v-model="settings.loginMessageTitle" 
                    placeholder="Login Message Title" 
                    />

                    <fg-input 
                    type="text"
                    label="Login Message" 
                    v-model="settings.loginMessage" 
                    placeholder="Login Message" 
                    />
                </div>
            </div>
        </div>
        <div class="card-footer">
            <div class="pull-right">
             <submit-button :loading="submitting"
             styling="btn btn-primary btn-round waves-effect waves-light "
              v-on:submit="save"></submit-button>
             <button class="btn btn-inverse btn-round waves-effect waves-light " >Cancel</button>
            </div>
        </div>
    </div>
</div>
    
</template>
<script>
import LogoSection from "./Logo"
export default {
  data() {
    return {
      settings: {},
      loginImage: "loginImage", 
      logoImage: "logoImage",
      logo: null,
      submitting: false
    }
  },
  components: {
    LogoSection
  },
  computed: {
    logoImageUrl() {
      if (this.settings) return this.settings.logoImageUrl
      return null
    },
    loginImageUrl(){
       if (this.settings) return this.settings.loginImageUrl
       return null
    }
  },
  methods: {
    fetch() {
      this.$http.get("settings/get/")
        .then(result => {
          if (result.data.data) {
            this.settings = result.data.data
          } else {
            this.settings = {}
          }
        })
        .catch(error => {
          this.$toastr("error", error)
        })
    },
    save() {
        this.submitting = true
      this.$http
        .post("settings/add/", this.settings)
        .then(response => {
          if (response.data.success) {
            this.submitting = false
            window.location.reload()
          } else {
              this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
            this.submitting = false
          this.$toastr("error", e.message)
        })
    }
  },
  created() {
    this.fetch()
  }
}
</script>
<style>
</style>


