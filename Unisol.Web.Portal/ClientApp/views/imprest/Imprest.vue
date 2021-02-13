<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span>{{subTitle}}</span>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="input-group">
              <input
                type="text"
                v-model="searchImprest"
                placeholder="Search here"
                class="form-control"
              >
              <span class="input-group-append" @click="searchImprestOnUi(searchImprest)">
                <label class="input-group-text">Search</label>
              </span>
            </div>
          </div>
          <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <router-link
              to="/imprest/Add"
              class="btn btn-primary btn-round pull-right waves-effect waves-light"
            >Add</router-link>
          </div>
        </div>
      </div>
      <div class="card-block col-md-12">
        <div class="text-center">
          <small-spinner :loading="httpStatus"></small-spinner>
        </div>
        <div class="row table-responsive" v-if="imprestSummary">
          <table class="table table-sm">
            <thead>
              <tr>
                <td>#</td>
                <td>Description</td>
                <td>Date</td>
                <td></td>
              </tr>
            </thead>
            <tbody
              class="table-sm"
              id="requestClaimUnits"
              v-for="(imprest ,index) in imprestSummary"
              :key="index"
            >
              <tr style="max-height: 30px!important;">
                <td>{{index+1}}</td>
                <td>{{imprest.description}}</td>
                <td>{{imprest.rdate}}</td>
                <td>
                  <button
                    class="btn btn-primary"
                    v-if="currentClickedImprest.id!=imprest.id"
                    @click="currentClickedImprest=imprest"
                  >
                    view
                    <i class="fa fa-chevron-down"></i>
                  </button>
                  <button
                    class="btn btn-primary"
                    v-if="currentClickedImprest.id==imprest.id"
                    @click="currentClickedImprest={}"
                  >
                    hide
                    <i class="fa fa-chevron-up"></i>
                  </button>
                </td>
              </tr>
              <tr v-if="currentClickedImprest.id==imprest.id"> 
                <td></td>
                <td colspan="3">
                  <div class="col-12">
                    <strong class="col-md-3">Date Raised :</strong>
                    <span>{{currentClickedImprest.rdate}}</span>
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Description :</strong>
                    {{currentClickedImprest.description}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">itinerary :</strong>
                    {{currentClickedImprest.itinerary}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Amount :</strong>
                    {{currentClickedImprest.amount.toLocaleString('en')}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Date Expected :</strong>
                    {{currentClickedImprest.edate}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Surrender Date :</strong>
                    {{currentClickedImprest.sdate}}
                    <span>Days :</span>
                    {{currentClickedImprest.impDays}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Status :</strong>
                    {{currentClickedImprest.status}}
                  </div>
                  <div class="col-12">
                    <strong class="col-md-3">Reason :</strong>
                    {{currentClickedImprest.reason}}
                  </div>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import SmallSpinner from "../../components/data/SmallSpinner";
export default {
  components: {
    SmallSpinner
  },
  data() {
    return {
      leave: {},
      imprestSummary: [],
      currentClickedImprest: {},
      endPoints: END_POINTS,
      searchImprest: "",
      httpStatus: false,
      subTitle: "Imprest",
      title: "Imprest Summary",
      user: this.$baseRead("user"),
      buttonText: "Submit"
    };
  },
  created() {
    this.getImprestSummary();
  },
  methods: {
    getImprestSummary: function() {
      this.httpStatus = true;
      this.$http
        .get(END_POINTS.GETIMPREST + "?userCode=" + this.user.username)
        .then(result => {
          this.httpStatus = false;
          if (result.data.success) {
            result.data.data.forEach(element => {
              element.amount = element.amount ? element.amount : ""
              element.edate = element.edate ? this.endPoints.ReturnDate(element.edate) : ""
              element.impDays = element.impDays ? element.impDays : ""
              element.itinerary = element.itinerary ? element.itinerary : ""
              element.reactDate =  element.reactDate ? element.reactDate : ""
              element.reactby = element.reactby ? element.reactby : ""
              element.reaction = element.reaction ? element.reaction : ""
              element.sdate = element.sdate ? this.endPoints.ReturnDate(element.sdate) : ""
              element.rdate = element.rdate ? this.endPoints.ReturnDate(element.rdate) : ""
            });
            
            this.imprestSummary = result.data.data;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.httpStatus = false;
          this.$toastr("error", error.message);
        });
    },
    searchImprestOnUi: function(search) {
      this.httpStatus = true;
      this.$http
        .get(
          END_POINTS.GETIMPREST +
            "?userCode=" +
            this.user.username +
            "&searchString=" +
            search
        )
        .then(result => {
          this.httpStatus = false;
          if (result.data.success) {
            this.imprestSummary = result.data.data;
            return;
          }
          this.imprestSummary = [];
          this.$toastr("error", result.data.message);
        })
        .catch(error => {
          this.httpStatus = false;
          this.$toastr("error", error.message);
        });
    }
  },
  computed: {}
};
</script>

<style>
</style>
