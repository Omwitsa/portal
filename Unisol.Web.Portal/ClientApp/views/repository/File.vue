<template>
  <div class="social-timeline-left">
    <div class="card">
      <div class="card-block">
        <div>
          <label>
            Upload File
            <small style="color:#721c24" v-if="!canUpload()">*No folder selected</small>
          </label>
          <hr />
          <div class="form-group">
            <input class="form-control" type="file" @change="fileChanged" />
          </div>

          <submit-button
            v-if="canUpload()"
            icon="upload"
            styling="btn btn-primary btn-sm btn-block waves-effect"
            title="Upload"
            :loading="submitting"
            v-on:submit="upload"
          ></submit-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { EventBus } from "../../app.js";
export default {
  props: {
    uploadUrl: String
  },
  data() {
    return {
      file: null,
      categoryName: "",
      submitting: false,
      uploadStatus: false,
      clickCount: 0
    };
  },
  methods: {
    canUpload() {
      if (this.file && this.uploadUrl) return true;
      return false;
    },

    upload() {
      this.submitting = true;
      const formData = new FormData();
      formData.append("file", this.file, this.file.name);
      this.$http.post(this.uploadUrl, formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(response => {
          this.submitting = false;
          if (response.data.success) {
            this.url = response.data.data;
            this.$toastr("success", "Success");
            EventBus.$emit("fileUpload", this.clickCount);
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.submitting = false;
          this.$toastr("error", e.message);
        });
    },
    fileChanged(event) {
      this.file = event.target.files[0];
      this.canUpload();
    }
  }
};
</script>

<style scoped>
.logo-text {
  font-size: 2em;
  text-align: center;
}
</style>
