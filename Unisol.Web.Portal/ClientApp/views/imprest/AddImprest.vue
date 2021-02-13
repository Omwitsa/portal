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
                        <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0"
                                  class="body current" aria-hidden="false">
                            <div class="form-group row">
                                <div class="col-md-12" v-if="settings.isGenesis">
                                    <label>Memo Reference</label>
                                    <input class="form-control border-input" v-model="imprestModel.memoRef"/>
                                </div>
                                <div class="col-md-12">
                                    <label>nature of Duty</label>
                                    <textarea
                                            class="form-control border-input"
                                            v-model="imprestModel.description"
                                            placeholder="Description ">
                                    </textarea>
                                </div>
                                <div class="col-md-12">
                                    <label>Itinerary</label>
                                    <textarea
                                            class="form-control border-input"
                                            v-model="imprestModel.itinerary"
                                            placeholder="Itinerary ">
                                    </textarea>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label>Start date</label>
                                    <date-picker v-model="imprestModel.eDate" ></date-picker>
                                </div>
                                <div class="col-md-6">
                                    <label>End date</label>
                                    <date-picker v-model="imprestModel.sDate" ></date-picker>                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label>Estimated number of days away</label>
                                    <input type="number" min="1"
                                           class="form-control border-input"
                                           v-model="imprestModel.impDays"
                                           placeholder="Imprest days ">

                                </div>
                                <div class="col-md-6">
                                    <label> Amount </label>
                                    <input type="number"
                                           class="form-control border-input "

                                           v-model="imprestModel.amount"
                                           placeholder="total amount">
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="card-footer text-right">
                <button class=" btn btn-primary btn-round waves-effect waves-light " @click="cancelClaim()">cancel</button>
                <button class="btn btn-inverse btn-round waves-effect waves-light "
                        @click="submitImprest()">
                    <small-spinner :loading="saveImprestHttp"></small-spinner>
                    Save Imprest
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
            SmallSpinner,
        },
        data() {
            return {
                imprestHistory: [],
                imprestModel: {},
                saveImprestHttp: false,
                subTitle: "Raise Imprest",
                title: "Raise Imprest",
                user: this.$baseRead('user'),
                buttonText: "Submit",
                settings: {}
            };
        },
        methods: {
            getClaimsSummary: function () {
                this.httpStatus = true;
                this.$http
                    .get(END_POINTS.GETCLAIMSUMMARY + "?userCode=" + this.user.username)
                    .then(result => {
                        this.httpStatus = false;
                        this.imprestSummary = result.data.data;
                    })
                    .catch(error => {
                        this.httpStatus = false;
                        this.$toastr("error", error.message)
                    })
            },
            submitImprest: function () {
                if (!this.imprestModel.description) {
                    this.$toastr("error", "Please fill description");
                    return;
                }
                if (!this.imprestModel.itinerary) {
                    this.$toastr("error", "Please fill Itinerary");
                    return;
                }

                if (!this.imprestModel.eDate) {
                    this.$toastr("error", "Please fill estimated date");
                    return;
                }
                if (!this.imprestModel.sDate) {
                    this.$toastr("error", "Please fill surrender date");
                    return;
                }

                // if (!this.imprestModel.impDays) {
                //     this.$toastr("error", "Please fill estimated days way");
                //     return;
                // }
                if (!this.imprestModel.amount) {
                    this.$toastr("error", "Please fill estimated amount");
                    return;
                }
                try {
                    this.saveImprestHttp = true;
                    this.imprestModel.empNo=this.user.username;
                    this.$http
                        .post(END_POINTS.ADDIMPREST, this.imprestModel)
                        .then(result => {
                            this.saveImprestHttp = false;
                            var res = result.data;
                            if (res.success) {
                                this.$toastr("success", res.message);
                                this.$router.replace({ name: 'imprest'});
                            } else {
                                this.$toastr("error", res.message)
                            }
                        })
                        .catch(error => {
                            this.saveImprestHttp = false;
                            this.$toastr("error", error.message)
                        })
                } catch (ex) {
                }
            },
        },
        created() {
            this.settings = JSON.parse(localStorage.getItem("settings"));
        }
    };
</script>

<style>
</style>
