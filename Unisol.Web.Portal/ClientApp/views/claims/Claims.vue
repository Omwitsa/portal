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
                v-model="searchClaim"
                placeholder="Search here"
                class="form-control"
              >
              <span class="input-group-append" @click="searchClaimOnUi(searchClaim)">
                <label class="input-group-text">Search</label>
              </span>
            </div>
          </div>
          <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <router-link
              to="/claims/Add"
              class="btn btn-primary btn-round btn-sm pull-right waves-effect waves-light"
            >Add</router-link>
          </div>
        </div>
      </div>
      <div class="card-block" v-if="!this.claimSummary.length">
        <div class="col-md-12 alert-warning">
          <div>
            &nbsp;
            <h5 class="text-center">
              <i class="fa fa-exclamation-circle fa-5x"></i>
              <br>
              {{eligibleMessage}}
            </h5>&nbsp;
          </div>
        </div>
      </div>
      <div class="card-block" v-if="this.claimSummary.length">
        <div class="text-center col-12">
          <small-spinner :loading="httpStatus"></small-spinner>
        </div>
        <div class="row table-responsive" v-if="claimSummary">
          <table class="table table-sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Ref No.</th>
                <th>Term</th>
                <th>Date Raised</th>
                <th>Amount</th>
                <th>Status</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(claim,index) in claimSummary" :key="index">
                <td>{{index+1}}</td>
                <td>{{claim.pcref}}</td>
                <td>{{claim.term}}</td>
                <td>{{endPoints.ReturnDate(claim.rdate)}}</td>
                <td>{{claim.amount.toLocaleString('en')}}</td>
                <td>{{claim.status}}</td>
                <td>
                  <button class="btn btn-primary btn-sm" @click="getClaimDetails(claim)">
                    <i class="fa fa-eye"></i>
                    <small-spinner
                      :loading="httpClaimStatus&&claim.pcref==currentClickedClaim.pcref"
                    ></small-spinner>view
                  </button>
                </td>
              </tr>
            </tbody>
            <tbody>
              <tr>
                <td colspan="6" class="text-right">
                  <h3>
                    <b>Total</b>
                  </h3>
                </td>
                <td class="text-right">{{totalClaimAmount}}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div class="modal fade" id="claimDetails" role="dialog">
        <div class="modal-dialog modal-lg" style="width: 75%!important;">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header btn-primary">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title text-left">Claim Details</h4>
            </div>
            <div class="modal-body" id="claimDetailsPrint">
              <div class>
                <div class="col-md-12" id="userInfo">
                  <b>Ref Number :</b>
                  <label class="label label-danger">{{currentClickedClaim.pcref}}</label>

                  <small class="pull-right">
                    Status :
                    <b>{{ currentClickedClaim.status }}</b>
                  </small>
                  <br>
                  <b>Identification number :</b>
                  {{ currentClickedClaim.payeeRef }}
                  <br>
                  <b>Names :</b>
                  {{ currentClickedClaim.names }}
                  <br>
                  <b>Semester :</b>
                  {{currentClickedClaim.term }}
                  <small class="pull-right">
                    Date :
                    <b>{{ currentClickedClaim.rdate}}</b>
                  </small>
                  <br>
                </div>
              </div>

              <div>
                <table class="table">
                  <thead>
                    <tr>
                      <td>#</td>
                      <td>Claim Ref</td>
                      <td>Account</td>
                      <td>Unit Code</td>
                      <td>Rate</td>
                      <td>Quantity</td>
                      <td>Amount</td>
                    </tr>
                  </thead>
                  <tbody class="table-sm" id="requestClaimUnits">
                    <tr
                      v-for="(claim ,index) in claimDetails"
                      :key="index"
                      style="max-height: 30px!important;"
                    >
                      <td>{{index+1}}</td>
                      <td>{{claim.pcref}}</td>
                      <td>{{claim.payAccount}}</td>
                      <td>{{claim.code}}</td>
                      <td>{{claim.rate}}</td>
                      <td>{{claim.qty}}</td>
                      <td>{{claim.amount.toLocaleString('en')}}</td>
                    </tr>
                  </tbody>
                  <tbody>
                    <tr style="background: darkgray; color: white;">
                      <td colspan="6" class="text-right">
                        <h3>
                          <b>Total</b>
                        </h3>
                      </td>
                      <td class="text-right" id="totalAmountDetails">{{totalDetailAmount}}</td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
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
      eligibleMessage: "",
      claimSummary: [],
      claimDetails: [],
      endPoints: END_POINTS,
      claimRates: [],
      claimTerms: [],
      claimUnits: [],
      searchUnit: [],
      searchClaim: "",
      totalDetailAmount: null,
      totalClaimAmount: null,
      currentClickedClaim: {},
      httpClaimStatus: false,
      submitting: false,
      httpStatus: false,
      subTitle: "Claims",
      title: "Claims Section",
      user: this.$baseRead("user"),
      buttonText: "Submit"
    };
  },
  created() {
    this.getClaimsSummary();
  },
  methods: {
    getClaimsSummary: function() {
      this.httpStatus = true;
      this.$http
        .get(
          END_POINTS.GETCLAIMSUMMARY +
            "?userCode=" +
            this.user.username +
            "&searchString=" +
            this.searchClaim
        )
        .then(result => {
          this.httpStatus = false;
          if (result.data.success) {
            this.claimSummary = result.data.data;
            this.totalClaimAmount = this.returnGetTotal(
              this.claimSummary
            ).toLocaleString("en");
            return;
          } else {
            this.eligibleMessage = result.data.message;
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
          this.claimSummary = [];
          this.totalClaimAmount = 0;
          this.$toastr("error", result.data.message);
        })
        .catch(error => {
          this.httpStatus = false;
          this.$toastr("error", error.message);
        });
    },
    searchClaimOnUi: function(search) {
      this.getClaimsSummary();
    },
    getClaimRates: function() {
      this.$http
        .get(END_POINTS.GETCLAIMRATES)
        .then(result => {
          this.claimRates = result.data.data;
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
    },
    getClaimDetails: function(claim) {
      this.currentClickedClaim = claim;
      this.claimDetails = [];
      this.httpClaimStatus = true;
      this.$http
        .get(END_POINTS.GETCLAIMDETAILS + "?pcref=" + claim.pcref)
        .then(result => {
          $("#claimDetails").modal("show");

          this.httpClaimStatus = false;
          this.claimDetails = result.data.data;
          this.totalDetailAmount = this.returnGetTotal(
            this.claimDetails
          ).toLocaleString("en");
        })
        .catch(error => {
          this.httpClaimStatus = false;
          this.$toastr("error", error.message);
        });
    },

    getClaimTerms: function() {
      this.$http
        .get(END_POINTS.GETCLAIMTERMS)
        .then(result => {
          this.claimDetails = result.data.data;
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
    },

    getClaimUnits: function() {
      this.$http
        .get(END_POINTS.GETCLAIMUNITS + "?unitNameCode=" + this.searchUnit)
        .then(result => {
          this.claimUnits = result.data.data;
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
    },

    returnGetTotal: function(totalArray) {
      var totalAmount = 0;
      if (totalArray) {
        totalArray.forEach(element => {
          totalAmount += element.amount;
        });
      }
      return totalAmount;
    }
  },
  computed: {}
};
</script>

<style>
</style>
