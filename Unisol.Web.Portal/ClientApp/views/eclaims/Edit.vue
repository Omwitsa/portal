<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-2">Qty
                            </div>
                            
                            <div class="col-md-8">
                                <input class="form-control border-input" v-model="eclaims.qty" type="number" min="0" oninput="validity.valid||(value='');"><br>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">Cost
                            </div>
                            <div class="col-md-8">
                                <input class="form-control border-input" v-model="eclaims.rate" type="number" min="0" oninput="validity.valid||(value='');"><br>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">Description</div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <textarea v-model="description" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2">Amount</div>
                            <div class="col-md-8">
                                <button disabled="disabled" type="button" class="btn btn-secondary btn-block">{{totalAmount}}</button>
                            </div>
                        </div><br>

                        <div class="row">
                            <div class="col-md-2">UoM</div>
                            <div class="col-md-8">
                            <div class="form-group">
                                <v-select v-model="eclaims.units" :options=uom></v-select>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            subTitle: "Expense Claims",
            title: "Claims",
            description: "",
            uom: [],
            submitting: false,
            user: this.$baseRead("user"),
            eclaims: {}
        }
    },
   methods: {
        save(){
            this.submitting = true
            this.$http.post("eClaims/addEClaim?userCode="+ this.user.username + "&description="+ this.description, this.eclaims)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
            this.$toastr("error", e.message)
            })
        },
        getUnitOfMeasure(){
            this.$http.get("eClaims/getUnitOfMeasure")
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.uom = response.data.data
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
            this.$toastr("error", e.message)
            })
        }
    },
    computed : {
        totalAmount: function () {
            return this.eclaims.amount = this.eclaims.qty * this.eclaims.rate 
        },
    },
    created() {
        this.getUnitOfMeasure();
    }
}
</script>
<style>

</style>
