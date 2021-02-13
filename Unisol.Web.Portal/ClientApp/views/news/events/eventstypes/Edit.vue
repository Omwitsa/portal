<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="">Events category<i v-if="httpStatus" class="fa fa-spin fa-circle-o-notch"></i></label><br>
                            <input type="text" class="form-control"
                                @keyup="checkeventsTypeExists()"
                                label="Category Name"
                                placeholder="  "
                                addon="user"
                                v-model="eventsType.eventTypeName" />
                            <span v-if="typeNameExists">Please use a different type name</span>
                        </div>

                        <!-- <div class="checkbox-color checkbox-primary col-md-12">
                            <input type="checkbox" id="checkbox18" v-model="eventsType.status">
                            <label for="checkbox18">
                                <span v-if="eventsType.status">News type is active</span>
                                <span v-if="!eventsType.status">News type is inactive</span>
                            </label>
                        </div> -->
                    </div>
                </div>
            </div>
           
            <div class="card-footer">
                <div class="pull-right">
                    <submit-button :title="buttonText" 
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                    <button class="btn btn-inverse btn-round waves-effect waves-light " >Cancel</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import END_POINTS from "../../../../components/constants/EndPoints"
import DateFomatter from "../../../../components/constants/DateFomatter"
export default {
  data() {
    return {
      eventsType: {},
      edit: false,
      typeNameExists: false,
      httpStatus: false,
      submitting: false,

      subTitle: ""
    }
  },
  created() {
    if (this.$route.params.id){
      this.edit = true
      this.getEventsTypeDetails(this.$route.params.id)
    } 
  },
  methods: {
    getEventsTypeDetails(id){
      this.$http
        .get("events/getEventTypeDetails/?id=" + id)
        .then(response => {
          if (response.data.success) {
            this.eventsType = response.data.data
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
          this.$toastr("error", e.message)
        })
    },
    save() {
      this.httpStatus = true
      var url = "events/addeventstypes"
      if(this.edit) url = "events/editEventsType"
      this.$http
        .post(url, this.eventsType)
        .then(response => {
          if (response.data.success) {
            this.$router.replace({ name: "event-categories" })
            this.$toastr("success", response.data.message)
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
          this.$toastr("error", e.message)
        })
      this.httpStatus = false
    },
    checkeventsTypeExists() {
        // this.typeNameExists = false
        // this.httpStatus = true
        // this.$http
        // .get(END_POINTS.CHECKNEWSTYPE + "/?name=" + this.eventsType.eventsTypeName)
        // .then(response => {
        // this.httpStatus = false
        // if (response.data.success) {
        //     this.typeNameExists = response.data.data
        // } else {
        //     this.$toastr("error", response.data.message)
        // }
        // })
        // .catch(e => {
        // this.httpStatus = false
        // })
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return "Edit Category "
      }
      return "Add Category"
    },
    buttonText() {
      if (this.edit) {
        return "Save Changes"
      }
      return "Save"
    }
  }
}
</script>

<style>
</style>
