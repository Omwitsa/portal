<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="card" v-if="settings.initials === 'UOEM'">
                    <div class="card-header">
                        <h6>NOTE: To be filled at least two days before the date of travel for out of the county trips and four (4) hours for local running except for emergencies.
                        </h6>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-2">
                        Department
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.department" type="text" class="form-control" disabled>
                    </div>
                </div> <br>
                
               <div class="row">
                    <div class="col-md-2">
                        Employment No.
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.empNo" type="text" class="form-control" disabled/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Requested By
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.names" type="text" class="form-control" disabled/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Departure Date
                    </div>
                    <div class="col-md-3">
                        <date-picker v-model="userFleet.dDate" :config="options"></date-picker>
                    </div>
                    <!-- <div class="col-md-2">
                        Departure Time
                    </div>
                    <div class="col-md-3">
                        <input v-model="userFleet.dTime" type="text" class="form-control"/>
                    </div> -->
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Return Date
                    </div>
                    <div class="col-md-3">
                        <date-picker v-model="userFleet.retDate" :config="options"></date-picker>
                    </div>
                    <!-- <div class="col-md-2">
                        Return Time
                    </div>
                    <div class="col-md-3">
                        <input v-model="userFleet.retTime" type="text" class="form-control"/>
                    </div> -->
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Purpose
                    </div>
                    <div class="col-md-8">
                        <textarea v-model="userFleet.purpose" type="text" rows="3" class="form-control"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Vehicle type
                    </div>
                    <div class="col-md-3">
                        <v-select
                            :options="vehicleType"
                            v-model="userFleet.vehicleType"
                            ></v-select>
                       <!-- <input v-model="userFleet.vehicleType" type="text" class="form-control"/> -->
                    </div>
                    <div class="col-md-2">
                        No. of occupants
                    </div>
                    <div class="col-md-3">
                        <input v-model="userFleet.passengers" type="number" class="form-control" min="0" oninput="validity.valid||(value='');"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Pick up location
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.location" type="text" class="form-control"/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Destination
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.destination" type="text" class="form-control"/>
                    </div>
                </div> <br>

                <div class="card" v-if="settings.initials === 'UOEM'">
                    <div class="card-header">
                        <h6>NB: Strictly adhere to time allocated to avoid inconveniencing other applicants. Polling of staff will be undertaken where it is found necessary
                        </h6>
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
            subTitle: "Online Vehicle Booking",
            title: "Fleet",
            submitting: false,
            settings : JSON.parse(localStorage.getItem("settings")),
            vehicleType: [],
            loading: false,
            user: this.$baseRead("user"),
            options: {
                format: 'DD/MM/YYYY',
                useCurrent: false,
            }, 
            userFleet : {
                department: "",
                empNo: "",
                names: ""
            }
        }
    },
    watch: {
        "userFleet.retDate"(){
            if(this.toDate(this.userFleet.dDate) >  this.toDate(this.userFleet.retDate)){
                this.$toastr("error", "Departure date can't be greater than return date");
                this.userFleet.retDate = ""
            }
        }
    },
    methods: {
        GetUserFleetDetails(){
            this.loading = true;
            this.$http.get("fleet/getUserFleetDetails/?usercode=" + this.user.username)
            .then(result => {
            if (result.data.success) {
               this.userFleet.department = result.data.data.userDetails.department
               this.userFleet.empNo = result.data.data.userDetails.empNo
               this.userFleet.names = result.data.data.userDetails.names
               this.vehicleType = result.data.data.vehicleTypes
            } 
            else {
                this.$toastr("error", result.data.message);
                if (result.data.notAuthenticated) {
                    this.$router.replace({ name: "401-forbidden" });
                }
            }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        save(){
            this.submitting = true
            this.userFleet.dDate = this.toDate(this.userFleet.dDate)
            this.userFleet.retDate = this.toDate(this.userFleet.retDate)
            this.$http.post("fleet/bookVehicle", this.userFleet)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.userFleet.dDate = ""
                    this.userFleet.retDate = ""
                    this.userFleet.dTime = ""
                    this.userFleet.retTime = ""
                    this.userFleet.purpose = ""
                    this.userFleet.vehicleType = ""
                    this.userFleet.passengers = ""
                    this.userFleet.location = ""
                    this.userFleet.destination = ""
                    this.$router.replace({ name: "fleet-bookings" });
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
            this.$toastr("error", e.message)
            })
        },
        toDate(date) {
            var from = date.split("/")
            return new Date(from[2], from[1] - 1, from[0])
        },
    },
    created(){
        this.GetUserFleetDetails()
    }
}
</script>
<style>

</style>

