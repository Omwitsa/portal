<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <div class="card" v-if="!loading">
      <div class="card-header">
        <h5>Job Details</h5>
      </div>
      <div class="card-block">
        <ul class="list-group">
          <li class="list-group-item">
            <div class="row col-md-12">
              <div class="col-md-3">TITLE</div>
              <div class="col-md-6">
                <strong>{{ ": "+ jData.names}}</strong>
              </div>
            </div>
          </li>
          <li class="list-group-item">
            <div class="row col-md-12">
              <div class="col-md-3">DESCRIPTION</div>
              <div class="col-md-6">
                :
                <span v-html="jData.description"></span>
              </div>
            </div>
          </li>
          <li class="list-group-item" v-show="false">
            <div class="row col-md-12">
              <div class="col-md-3">DUTIES</div>
              <div class="col-md-6">{{ ": "+ jData.duties}}</div>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
  data() {
    return {
      user: {},
      jData: {},
      loading: false
    };
  },
  methods: {
    loadEnrollment() {
      this.loading = true;
      this.$http
        .get("profile/getJobTitle?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            var data = result.data.data;
            this.jData.names = data.names;
            this.jData.description = data.description.replace(/(?:\r\n|\r|\n)/g, '<br>');;
            this.jData.duties = data.duties.replace("\r\n", "<br>"); 
          } else {
            this.$toastr("error", result.data.message);
          }
          this.loading = false;
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.user = this.$baseRead("user");
    this.loadEnrollment();
  }
};
</script>
<style scoped>
.list-group-item {
  border-left: none !important;
  border-right: none !important;
}
.col-md-3 {
  font-weight: bold;
}
</style>
