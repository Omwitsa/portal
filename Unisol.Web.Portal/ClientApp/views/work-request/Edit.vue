<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        Department
                    </div>
                    <div class="col-md-8">
                        <input v-model="workRequest.department" type="text" class="form-control" disabled>
                    </div>
                </div> <br>
                
               <div class="row">
                    <div class="col-md-2">
                        Employment No.
                    </div>
                    <div class="col-md-8">
                        <input v-model="workRequest.empNo" type="text" class="form-control" disabled/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Requested By
                    </div>
                    <div class="col-md-8">
                        <input v-model="workRequest.names" type="text" class="form-control" disabled/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Subject
                    </div>
                    <div class="col-md-8">
                        <input v-model="workRequest.subject" type="text" rows="3" class="form-control"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Description
                    </div>
                    <div class="col-md-8">
                        <textarea v-model="workRequest.description" type="text" rows="3" class="form-control"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Project
                    </div>
                    <div class="col-md-8">
                        <v-select
                            :options="projects"
                            v-model="workRequest.project"
                            ></v-select>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Unit
                    </div>
                    <div class="col-md-8">
                        <textarea v-model="workRequest.unit" type="text" rows="3" class="form-control"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Location
                    </div>
                    <div class="col-md-8">
                        <v-select
                            :options="locations"
                            v-model="workRequest.location"
                            ></v-select>
                    </div>
                </div><br>
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
            subTitle: "Request",
            title: "Work Request",
            submitting: false,
            projects: [],
            locations: [],
            loading: false,
            user: this.$baseRead("user"),
            workRequest : {
                department: "",
                empNo: "",
                names: ""
            }
        }
    },
    methods:{
        getUserDetails(){
            this.loading = true;
            this.$http.get("workRequest/getUserWorkRequestDetails?usercode=" + this.user.username)
            .then(result => {
            if (result.data.success) {
               this.workRequest.department = result.data.data.userDetails.department
               this.workRequest.empNo = result.data.data.userDetails.empNo
               this.workRequest.names = result.data.data.userDetails.names
               this.projects = result.data.data.projectNames
               this.locations = result.data.data.locationNames
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
        populateFields(){
            var request = JSON.parse(localStorage.getItem('workRequests'))
            if(request){
                this.workRequest.subject = request.subject
                this.workRequest.description = request.description
                this.workRequest.project = request.project
                this.workRequest.unit = request.unit
                this.workRequest.location = request.location
            }
        },
        save(){
            this.submitting = true
            this.$http.post("workRequest/orderWork", this.workRequest)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.workRequest.subject = ""
                    this.workRequest.description = ""
                    this.workRequest.project = ""
                    this.workRequest.unit = ""
                    this.workRequest.location = ""
                    this.$router.replace({ name: "work-request" });
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
            this.$toastr("error", e.message)
            })
        },
    },
    created(){
        this.populateFields()
        this.getUserDetails()
    }
}
</script>
<style>

</style>
