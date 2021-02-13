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
            <div class="form-group" :class="[ { 'form-control-danger' : typeNameExists }]">
              <label for>
                News Category
                <i v-if="httpStatus" class="fa fa-spin fa-circle-o-notch"></i>
              </label>
              <br />
              <input
                type="text"
                :class="['form-control', { 'form-control-danger' : typeNameExists }]"
                @keyup="checkNewsTypeExists()"
                label="Category Name"
                placeholder="  "
                addon="user"
                v-model="newsType.newsTypeName"
              />
              <span v-if="typeNameExists">Please use a different type name</span>
            </div>
            <div class="row">
              <div class="col-md-3">
                <div class="form-group">
                  <label class="switch">
                    <input type="checkbox" :id="index" v-model="newsType.status" />
                    <span class="slider round"></span>
                  </label>
                </div>
              </div>
              <div class="col-md-8">
                <label :for="index">Set Active</label>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="card-footer">
        <div class="pull-right">
          <button
            class="btn btn-primary btn-round waves-effect waves-light"
            :disabled="typeNameExists"
            @click.prevent="save"
          >{{buttonText}}</button>
          <button class="btn btn-inverse btn-round waves-effect waves-light">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../../components/constants/EndPoints";
export default {
  data() {
    return {
      newsType: {
        status: true
      },
      edit: false,
      typeNameExists: false,
      httpStatus: false,
      submitting: false,

      subTitle: ""
    };
  },
  created() {
    if (this.$route.params.id) {
      this.edit = true;
      this.getNewTypeDetails(this.$route.params.id);
    }
  },
  methods: {
    getNewTypeDetails(id) {
      this.$http
        .get("news/getNewTypeDetails/?id=" + id)
        .then(response => {
          if (response.data.success) {
            this.newsType = response.data.data;
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.$toastr("error", e.message);
        });
    },
    save() {
      this.httpStatus = true;
      var url = END_POINTS.ADDNEWSTYPES;
      if (this.edit) url = "news/editNewsType";
      this.$http
        .post(url, this.newsType)
        .then(response => {
          if (response.data.success) {
            this.$router.replace({ name: "categories" });
            this.$toastr("success", "Success");
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.$toastr("error", e.message);
        });
      this.httpStatus = false;
    },
    checkNewsTypeExists() {
      this.typeNameExists = false;
      this.httpStatus = true;
      this.$http
        .get(END_POINTS.CHECKNEWSTYPE + "/?name=" + this.newsType.newsTypeName)
        .then(response => {
          this.httpStatus = false;
          if (response.data.success) {
            this.typeNameExists = response.data.data;
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.httpStatus = false;
        });
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return "Edit Category ";
      }
      return "Add Category";
    },
    buttonText() {
      if (this.edit) {
        return "Save Changes";
      }
      return "Save";
    }
  }
};
</script>

<style>
</style>
