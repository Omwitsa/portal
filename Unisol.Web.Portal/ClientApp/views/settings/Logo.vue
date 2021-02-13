<template>
    <div class="social-timeline-left">
        <div class="card">
            <div class="social-profile">
                <img v-if="url" class="img-fluid width-100" :src="src">
            </div>
            <span v-if="!url" class="text-center logo-text img-thumbnail">Logo not set</span>
            <div class="card-block ">
                <div>
                    <div class="form-group">
                        <input class="form-control" type="file"  @change="fileChanged">
                    </div>

                    <submit-button v-if="logo"
                    icon="upload" 
                    styling="btn btn-outline-primary waves-effect btn-block" 
                    title="Upload" 
                    :loading="submitting" 
                    v-on:submit="upload"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  data() {
    return {
      logo: null,
      submitting: false
    }
  },
  props: {
    url: null,
    imageName: null
  },
  computed: {
    src() {
      return "../" + this.url
    }
  },
  methods: {
    upload() {
      this.submitting = true
        const formData = new FormData()
        formData.append("logo", this.logo, this.logo.name)
      this.$http.post(`settings/uploadContent/?imageName=`+this.imageName, formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(response => {
          this.submitting = false
          if (response.data.success) {
            this.url = response.data.data
            this.$toastr("success", "Success")
            window.location.reload()
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
          this.submitting = false
          this.$toastr("error", e.message)
        })
    },
    fileChanged(event) {
      this.logo = event.target.files[0]
    }
  }
}
</script>

<style scoped>
.logo-text {
  font-size: 2em;
  text-align: center;
}
</style>
