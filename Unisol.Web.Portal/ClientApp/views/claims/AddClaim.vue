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
            <fieldset
              id="design-wizard-p-0"
              role="tabpanel"
              aria-labelledby="design-wizard-h-0"
              class="body current"
              aria-hidden="false"
            >
              <div class="form-group row">
                <div class="col-md-6">
                  <label>
                    Claim Type
                    <small-spinner :loading="fetchRatesHttp"></small-spinner>
                  </label>
                  <select
                    class="form-control border-input"
                    @change="createClickedRate(claimsModel.claimRates)"
                    v-model="claimsModel.claimRates"
                    placeholder="Select Claim Type"
                  >
                    <option
                      v-for="(rate,rateIndex) in claimRates"
                      :value="rate"
                      :key="rateIndex"
                    >{{rate.payAccount}}({{rate.certType}})</option>
                  </select>
                </div>
                <div class="col-md-6">
                  <label>
                    Semester
                    <small-spinner :loading="fetchTermsHttp"></small-spinner>
                  </label>
                  <select
                    class="form-control border-input"
                    v-model="claimsModel.semester"
                    placeholder="Semester"
                  >
                    <option disabled selected>--Select Semester--</option>
                    <option
                      v-for="(semester,index) in claimTerms"
                      :key="index"
                    >{{semester.names}}({{semester.academicYear}})</option>
                  </select>
                </div>
              </div>

              <div class="form-group row">
                <div class="col-md-6">
                  <label>
                    Quantity
                    <b>({{currentClickedRate.units}}@{{currentClickedRate.rate}})</b>
                  </label>
                  <input
                    type="number"
                    min="1"
                    @keyup="calculateTotalAmount(claimsModel.qty)"
                    class="form-control border-input"
                    v-model="claimsModel.qty"
                    :disabled="!currentClickedRate.unitNotRequired"
                    placeholder="total "
                  >
                </div>
                <div class="col-md-6">
                  <label>Total Amount</label>
                  <input
                    type="number"
                    class="form-control border-input"
                    readonly
                    v-model="claimsModel.totalAmount"
                    placeholder="total amount"
                  >
                </div>
              </div>
              <div class="col-md-12" v-if="!currentClickedRate.unitNotRequired">
                <div class="form-group row">
                  <div class="col-md-6 row">
                    <label>
                      Add Units
                      <small-spinner :loading="searchUnitHttp"></small-spinner>
                    </label>
                    <input
                      type="text"
                      class="form-control border-input"
                      @keyup="getClaimUnits()"
                      v-model="searchUnit"
                      v-if="!showAdded"
                      placeholder="search Units"
                    >
                  </div>
                  <div class="col-md-6">
                    <label>&nbsp;</label>
                    <div class="text-right col-md-12 row">
                      <div
                        class="col-md-6 btn pull-left text-left text-primary"
                        @click="showAdded=true"
                        style="border-left: 6px solid blue;"
                      >You have added {{claimAddedUnits.length}} Unit(s) to this claim</div>
                    </div>
                  </div>
                </div>
                <div class="col-md-12">
                  <div v-if="showAdded">
                    <ul class="list-group">
                      <li
                        class="list-group-item"
                        style="border-left: none;border-right: none;"
                        v-for="(unit,index) in claimAddedUnits"
                        :key="index"
                      >
                        <div class="col-md-2 pull-left">{{unit.code}}</div>

                        <!--rate: this.currentClickedRate.units,-->
                        <!--rateAmount: this.currentClickedRate.rate,-->
                        <div class="col-md-2 pull-left">
                          {{unit.quantity}} x
                          {{unit.rateAmount.toLocaleString('en')}}@{{unit.rate.toLocaleString('en')}}
                        </div>
                        <div
                          class="col-md-2 pull-left"
                        >{{(unit.quantity*unit.rateAmount).toLocaleString('en')}}</div>

                        <div class="col-md-2 pull-left">
                          <input
                            type="number"
                            min="1"
                            @keyup="calculateTotalQuantity()"
                            v-model="unit.quantity"
                            class="form-control"
                          >
                          <span class="text-danger" v-show="unit.quantity<=0">quantity should be > 0</span>
                        </div>
                        <div class="col-md-2 pull-left">
                          <button class="btn btn-danger" @click="removeAddedUnit(unit.code)">remove</button>
                        </div>
                      </li>
                    </ul>
                    <div class="text-right">
                      <div
                        class="text-primary btn btn-default"
                        @click="showAdded=false"
                      >Continue Adding units..</div>
                    </div>
                  </div>

                  <div v-if="!showAdded">
                    <ul class="list-group">
                      <li
                        class="list-group-item"
                        style="border-left: none;border-right: none;"
                        v-for="(unit,index) in claimUnits"
                        :key="index"
                      >
                        <div class="col-md-2 pull-left">{{unit.code}}</div>
                        <div class="col-md-5 pull-left">{{unit.names}}</div>
                        <div class="col-md-2 pull-left">
                          <input
                            type="number"
                            min="1"
                            :bind="returnQuantityAdded(unit)"
                            :disabled="checkIfUnitAdded(unit.code)"
                            v-model="unit.quantity"
                            class="form-control"
                          >
                          <span
                            class="text-danger"
                            v-show="unit.quantity==0"
                          >quantity is not allowed to be 0</span>
                        </div>
                        <div class="col-md-2 pull-left">
                          <button
                            class="btn btn-primary"
                            v-if="!checkIfUnitAdded(unit.code)"
                            @click="addClaimUnit(unit)"
                          >Add</button>
                          <button class="btn btn-success" v-if="checkIfUnitAdded(unit.code)">Added</button>
                        </div>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </fieldset>
          </div>

          <div class="text-right col-md-12">
            <div
              class="col-md-6 btn pull-left text-left text-primary"
              @click="showAddedClaims=true"
              style="border-left: 6px solid blue;"
            >You have added {{addedClaims.length}} Claims</div>
          </div>
          <div v-if="showAddedClaims" class="col-md-12">
            <ul class="list-group">
              <li
                v-for="(claim,index) in addedClaims"
                :key="index"
                class="list-group-item"
                style="border-left: none;border-right: none;"
              >
                <div class="col-md-2 pull-left">@{{claim.rateAmount}}</div>
                <div class="col-md-3 pull-left">{{claim.payAccount}}</div>
                <div class="col-md-3 pull-left">{{claim.semester}}</div>

                <div class="col-md-1 pull-left">{{claim.quantity}}</div>
                <div class="col-md-2 pull-left">{{claim.totalAmount}}</div>
              </li>
            </ul>

            <div class="text-right">
              <div
                class="text-primary btn btn-default"
                @click="showAddedClaims=false"
              >Continue Adding ..</div>
            </div>
          </div>
          <div class="text-right col-md-12">
            <div class="btn btn-success" @click="addClaim()">
              Add {{currentClickedRate.payAccount}}
              @{{currentClickedRate.rate}} Claim
            </div>
          </div>
        </div>
      </div>
      <div class="card-footer text-right">
        <button class="btn btn-default" @click="cancelClaim()">cancel</button>
        <button class="btn btn-primary" :disabled="addedClaims.length==0" @click="submitClaims()">
          <small-spinner :loading="saveClaimsHttp"></small-spinner>
          Save {{addedClaims.length}} Claim(s)
        </button>
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
      claimSummary: [],
      claimDetails: [],
      claimRates: [],
      claimTerms: [],
      claimUnits: [],
      addedClaims: [],
      claimAddedUnits: [],
      searchUnit: "",
      searchClaim: "",
      claimsModel: {
        totalAmount: 0,
        qty: 0
      },
      showAdded: false,
      showAddedClaims: false,
      totalDetailAmount: null,
      totalClaimAmount: null,
      currentClickedRate: {
        unitNotRequired: true
      },

      httpClaimStatus: false,
      fetchRatesHttp: false,
      fetchTermsHttp: false,
      searchUnitHttp: false,
      saveClaimsHttp: false,
      submitting: false,
      httpStatus: false,
      subTitle: "Raise Claims",
      title: "Raise Claims",
      user: this.$baseRead("user"),
      buttonText: "Submit"
    };
  },
  created() {
    this.getClaimRates();
    this.getClaimTerms();
  },

  methods: {
    getClaimsSummary: function() {
      this.httpStatus = true;
      this.$http
        .get(END_POINTS.GETCLAIMSUMMARY + "?userCode=" + this.user.username)
        .then(result => {
          this.httpStatus = false;
          this.claimSummary = result.data.data;
          this.totalClaimAmount = this.returnGetTotal(
            this.claimSummary
          ).toLocaleString("en");
        })
        .catch(error => {
          this.httpStatus = false;
          this.$toastr("error", error.message);
        });
    },
    createClickedRate: function(rate) {
      this.currentClickedRate = rate;
      this.claimsModel.totalAmount = 0;
      this.claimsModel.qty = 0;
    },
    calculateTotalAmount: function(qty) {
      this.claimsModel.totalAmount = 0;
      if (qty > 0)
        this.claimsModel.totalAmount = qty * this.currentClickedRate.rate;
      else this.claimsModel.totalAmount = 0;
    },
    calculateTotalQuantity: function() {
      var totalUnits = 0;
      var totalAmount = 0;
      for (let i = 0; i < this.claimAddedUnits.length; i++) {
        totalUnits += Math.abs(this.claimAddedUnits[i].quantity);
        totalAmount +=
          Math.abs(this.claimAddedUnits[i].quantity) *
          Math.abs(this.claimAddedUnits[i].rateAmount);
      }
      this.claimsModel.qty = totalUnits;
      this.claimsModel.totalAmount = totalAmount;
      return totalUnits;
    },
    addClaimUnit: function(unit) {
      if (unit.quantity > 0) {
        this.claimAddedUnits.push({
          quantity: unit.quantity,
          code: unit.code,
          rate: this.currentClickedRate.units,
          rateAmount: this.currentClickedRate.rate,
          total: this.currentClickedRate.rate * unit.quantity
        });
        this.calculateTotalQuantity();
        return;
      }
      this.$toastr("error", "Please fill the number of quantity you claiming");
    },
    checkIfUnitAdded: function(code) {
      for (let i = 0; i < this.claimAddedUnits.length; i++) {
        if (this.claimAddedUnits[i].code === code) {
          return true;
        }
      }
      return false;
    },
    addClaim: function() {
      if (!this.claimsModel.claimRates) {
        this.$toastr("error", "Please select a rate");
        return;
      }
      if (!this.claimsModel.semester) {
        this.$toastr("error", "Please select a semester");
        return;
      }
      if (!this.claimsModel.claimRates.unitNotRequired) {
        if (this.claimAddedUnits.length == 0) {
          this.$toastr("error", "You claim type requires atleast one unit");
          return;
        }
      }
      if (this.claimsModel.qty <= 0) {
        this.$toastr("error", "Quantity should be greater than 0");
        return;
      }

      var claim = {
        totalAmount: this.claimsModel.totalAmount,
        quantity: this.claimsModel.qty,
        claimId: 0,
        semester: this.claimsModel.semester,
        claimRates: 1,
        notes: "Online raise claim",
        payAccount: this.claimsModel.claimRates.payAccount,
        userCode: this.user.username,
        requireUnit: !this.claimsModel.claimRates.unitNotRequired,
        rateAmount: this.claimsModel.claimRates.rate,
        claimRequestUnits: this.claimAddedUnits
      };

      this.addedClaims.push(claim);
      this.claimAddedUnits = [];
      this.claimsModel = {
        totalAmount: 0,
        qty: 0
      };
      this.currentClickedRate = {};
      this.searchClaim = "";
      this.claimUnits = [];
      this.$toastr("success", "1 claim has been added to the list");
    },
    cancelClaim: function() {
      this.$router.push({ name: "claims" });
    },
    submitClaims: function() {
      if (this.addedClaims.length == 0) {
        this.$toastr("error", "Please add atleast one claim");
        return;
      }
      try {
        this.saveClaimsHttp = true;
        this.$http
          .post(END_POINTS.ADDCLAIM, this.addedClaims)
          .then(result => {
            this.saveClaimsHttp = false;

            var res = result.data;
            if (res.success) {
              this.$toastr("success", res.message);
              this.addedClaims = [];
              this.showAddedClaims = false;
              this.searchClaim = "";
            } else {
              this.$toastr("error", res.message);
            }
          })
          .catch(error => {
            this.saveClaimsHttp = false;
            this.$toastr("error", error.message);
          });
      } catch (ex) {}
    },
    removeAddedUnit: function(code) {
      for (let i = 0; i < this.claimAddedUnits.length; i++) {
        if (this.claimAddedUnits[i].code === code) {
          this.claimAddedUnits.splice(i, 1);
          break;
        }
      }
      this.calculateTotalQuantity();
    },
    returnQuantityAdded: function(unit) {
      for (let i = 0; i < this.claimAddedUnits.length; i++) {
        if (this.claimAddedUnits[i].code === unit.code) {
          unit.quantity = this.claimAddedUnits[i].quantity;
          return;
        }
      }
      unit.quantity = 1;
    },
    getClaimRates: function() {
      this.fetchRatesHttp = true;
      this.$http
        .get(END_POINTS.GETCLAIMRATES)
        .then(result => {
          var info = result.data;
          if (info.success) {
            this.claimRates = result.data.data;
          } else {
            this.$toastr("error", info.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
          this.fetchRatesHttp = false;
        })
        .catch(error => {
          this.fetchRatesHttp = false;
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
      this.fetchTermsHttp = true;
      this.$http
        .get(END_POINTS.GETCLAIMTERMS)
        .then(result => {
          this.fetchTermsHttp = false;
          this.claimTerms = result.data.data;
        })
        .catch(error => {
          this.fetchTermsHttp = false;
          this.$toastr("error", error.message);
        });
    },

    getClaimUnits: function() {
      this.searchUnitHttp = true;
      this.$http
        .get(END_POINTS.GETCLAIMUNITS + "?unitNameCode=" + this.searchUnit)
        .then(result => {
          this.searchUnitHttp = false;
          this.claimUnits = result.data.data;
        })
        .catch(error => {
          this.searchUnitHttp = false;
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
