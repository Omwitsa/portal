<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span>{{subTitle}}</span>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="form-group">
              <label for>Reason for Clearance</label> 
              <br />
              <textarea v-if="settings.initials === 'KIBU'" class="form-control" v-model="clearance.notes" placeholder="Notes"></textarea>
              <v-select v-if="settings.initials != 'KIBU'" v-model="clearance.notes" :options=reasons></v-select>
            </div>
          </div>
        </div>
      </div>
      <div class="card-footer">
        <div class="pull-right">
          <button
            class="btn btn-primary btn-round waves-effect waves-light" 
            :loading="submitting"
            :disabled="submitting||clearance.notes.length==0"
            @click.prevent="save"
          >Submit</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      submitting: false,
      subTitle: "Apply for Clearance",
      title: "Apply",
      buttonText: "Submit",
      reasons: [],
      clearance: {
        admnNo: "",
        notes: ""
      },
      user: {},
      settings : JSON.parse(localStorage.getItem("settings")),
    };
  },
  created() {
    this.user = this.$baseRead("user");
    this.getSurveyResponse()
    this.getReasons()
  },

  watch: {},

  methods: {
    initLeaveProps() {
      this.clearance.admnNo = this.user.username;
    },

    save() {
      if (this.clearance.notes.length == 0) {
        this.$toastr("error", "Please add the reason for clearance");
        return;
      }
      this.clearance.admnNo = this.user.username;
      this.submitting = true;
      this.$http.post("clearances/apply?role="+this.user.role, this.clearance)
        .then(response => {
          if (response.data.success) {
            this.$toastr("success", "Success");
            this.$router.replace({ name: "clearances-history" });
          } else {
            this.$toastr("error", response.data.message);
          }
          this.submitting = false;
        })
        .catch(e => {
          this.submitting = true;
          this.$toastr(
            "error",
            "An error occured,please contact administrator"
          );
        });
      },
      getReasons(){
        this.$http.get("clearances/GetReasons")
          .then(result => {
            if(result.data.success){
              var val = result.data.data
              result.data.data.forEach(element => {
                this.reasons.push(element.reason)
              });
            }
          })
          .catch(error => {
            this.$toastr("error", error.message);
          });
      },
      getSurveyResponse(){
        if(this.settings.initials === 'KIBU' && this.user.role === 3){
          this.$http.get("clearances/getSurveyResponse?usercode="+this.user.username)
          .then(result => {
            if(!result.data.success){
              this.$router.replace({ name: "survey" });
              this.$toastr("error", result.data.message);
            }
            else{
              this.subTitle = result.data.data ? result.data.data : this.subTitle
            }
          })
          .catch(error => {
            this.$toastr("error", error.message);
          });
        }
      }
    },
  computed: {}
};
</script>

<style>
</style>
