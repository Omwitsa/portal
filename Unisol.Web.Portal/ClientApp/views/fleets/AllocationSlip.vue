<template>
    <div class="page-body">
        <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-10">
                    <h5>{{title}}</h5>
                    <span v-if="subTitle">{{subTitle}}</span>
                </div>
                <div class="col-md-2">
                    <button class="btn btn-primary btn-sm" @click="print()">
                        <i class="fa fa-print" style="color:white;"></i> print
                    </button>
                </div>
            </div>
        </div>

        <div class="card-block" id="vehicleAllocationSlip">
            <div class="row">
                <di4 class="col-md-4"></di4>
                <div class="col-md-4 text-center">
                    <img :src="settings.logoImageUrl" :alt="settings.initials" width="40%" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 text-center">
                    <h4>{{title}}</h4>
                    <p><b>Name of applicant:</b> {{slip.applicantName}} ({{user.username}})</p>
                    <p><b>Lead Passenger:</b> {{slip.leadPassenger}}</p>
                    <p><b>Destination:</b> {{slip.destination}}</p>
                    <p><b>Driver:</b> {{slip.driverName}} ({{slip.driverNo}}) </p>
                    <p><b>Vehicle:</b> {{slip.plateNo}} {{slip.makemodel}}</p>
                    <p><b>Personnel:</b> {{slip.personnel}}</p><br><br>
                    <p><b>Transport office stamp</b></p>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
export default {
    data(){
        return {
            slip: null,
            title: "Vehicle allocation Slip",
            subTitle: "",
            user: this.$baseRead("user"),
            settings : JSON.parse(localStorage.getItem("settings")),
        }
    },
    methods:{
        print(){
            this.$htmlToPaper("vehicleAllocationSlip");
        }
    },
    created(){
        this.slip = this.$route.params
        this.slip.makemodel = this.slip.makemodel ? `(${this.slip.makemodel})` : "";
    }
}
</script>

<style>

</style>
