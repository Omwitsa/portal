<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{ title }}</h5>
                <span v-if="subTitle">{{ subTitle }}</span>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        Title
                    </div>
                    <div class="col-md-4">
                        <input :disabled="project.needApproval" v-model="project.title" type="text" class="form-control"/>
                    </div>

                    <div class="col-md-2">
                        Funding Agency
                    </div>
                    <div class="col-md-4">
                        <input :disabled="project.needApproval" v-model="project.fundingAgency" type="text" class="form-control"/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Sponsor
                    </div>
                    <div class="col-md-4">
                        <input :disabled="project.needApproval" v-model="project.sponsor" type="text" class="form-control"/>
                    </div>

                    <div class="col-md-2">
                        Contact Person
                    </div>
                    <div class="col-md-4">
                        <input :disabled="project.needApproval" v-model="project.contactPerson" type="text" class="form-control"/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2">
                        Start Date
                    </div>
                    <div class="col-md-4">
                        <date-picker v-model="project.startDate"></date-picker>
                    </div>

                    <div class="col-md-2">
                        End Date
                    </div>
                    <div class="col-md-4">
                        <date-picker v-model="project.endDate"></date-picker>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                        Code
                    </div>
                    <div class="col-md-4">
                        <input :disabled="!isEdit" v-model="project.code" type="text" class="form-control"/>
                    </div>

                    <div class="col-md-2">
                        Cost
                    </div>
                    <div class="col-md-4">
                        <input :disabled="!isEdit" v-model="project.cost" type="text" class="form-control"/>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-2" v-if="user.role == 2">
                        Upload File
                    </div>
                    <div class="col-md-4" v-if="user.role == 2">
                        <div class="form-group">
                            <input class="form-control" type="file"  @change="fileChanged">
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <button v-if="project.fileUrl" @click="download()">Download Document</button>
                        </div>
                    </div>
                </div> <br>
            </div> <hr>

            <div class="card-block">
                <h5>Co-Reseachers</h5>
                <div class="row" v-if="!project.needApproval">
                    <div class="col-md-8">
                        <v-select
                            :options="coReseachers"
                            v-model="coReseacher.empNo"
                        ></v-select>
                    </div>
                </div> <br>

                <div v-if="project.projectCoReseachers">
                    <div class="table-responsive">
                        <table class="table table-sm table-bordered">
                            <thead>
                                <th>EmpNo</th>
                                <th>Action</th>
                            </thead>

                            <tbody>
                                <tr v-for="(researcher, index) in project.projectCoReseachers" :key="index">
                                    <td>{{researcher.empNo}}</td>
                                    <td><button :disabled="project.needApproval" @click="removeResearcher(index)">Remove</button></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div> <br>

                <button v-if="!project.needApproval"
                    class="btn btn-primary btn-round waves-effect waves-light" 
                    @click.prevent="addCoResearcher"
                >Add Co-Reseachers</button>
            </div> <hr>

            <div class="card-block">
                <h5>Reporting Schedule</h5><br>
                <div class="row" v-if="!project.needApproval">
                    <div class="col-md-2">
                        Start Date
                    </div>
                    <div class="col-md-4">
                        <date-picker v-model="reportingSchedule.startDate"></date-picker>
                    </div>

                    <div class="col-md-2">
                        End Date
                    </div>
                    <div class="col-md-4">
                        <date-picker v-model="reportingSchedule.endDate"></date-picker>
                    </div>
                </div> <br>

                <div v-if="project.projectReports">
                    <div class="table-responsive">
                        <table class="table table-sm table-bordered">
                            <thead>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Action</th>
                            </thead>

                            <tbody>
                                <tr v-for="(reporting, index) in project.projectReports" :key="index">
                                    <td>{{reporting.startDate}}</td>
                                    <td>{{reporting.endDate}}</td>
                                    <td><button :disabled="project.needApproval" @click="removeSchedule(index)">Remove</button></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div> <br>

                <button v-if="!project.needApproval"
                    class="btn btn-primary btn-round waves-effect waves-light" 
                    @click.prevent="addReportingSchedule"
                >Add Reporting Schedule</button>
            </div> <hr>

            <div class="card-block">
                <h5>Project Disbursements</h5> <br>
                <div class="row" v-if="isEdit">
                    <div class="col-md-2">
                        Amount
                    </div>
                    <div class="col-md-4">
                        <input :disabled="!isEdit" v-model="disbursement.amount" placeholder="Amount" type="text" class="form-control"/>
                    </div>

                    <div class="col-md-2">
                        Date
                    </div>
                    <div class="col-md-4">
                        <date-picker v-model="disbursement.date"></date-picker>
                    </div>
                </div> <br>

                <div v-if="project.projectDisbursements">
                    <div class="table-responsive">
                        <table class="table table-sm table-bordered">
                            <thead>
                                <th>Amount</th>
                                <th>Date</th>
                                <th>Action</th>
                            </thead>

                            <tbody>
                                <tr v-for="(disbursement, index) in project.projectDisbursements" :key="index">
                                    <td>{{disbursement.amount}}</td>
                                    <td>{{disbursement.date}}</td>
                                    <td><button :disabled="!isEdit" @click="removeDisbursement(index)">Remove</button></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div> <br>

                <button v-if="isEdit"
                    class="btn btn-primary btn-round waves-effect waves-light" 
                    @click.prevent="addProjectDisbursement"
                >Add Project Disbursement</button>
            </div> <hr>

            <div class="card-block" v-if="user.role === 1">
                <h5>Approval / Decline</h5>
                <div class="row">
                    <div class="col-md-2">
                        Select status
                    </div>
                    <div class="col-md-8">
                        <v-select
                            :options="statuses"
                            v-model="project.status"
                        ></v-select>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-12">
                        <textarea class="form-control" v-model="project.reason" placeholder="Reason"></textarea>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right" v-if="!project.needApproval">
                    <button 
                        class="btn btn-primary btn-round waves-effect waves-light" 
                        :loading="submitting"
                        @click.prevent="save"
                    >Save</button>

                    <button 
                        class="btn btn-primary btn-round waves-effect waves-light" 
                        :loading="submitting"
                        @click.prevent="sendForApproval"
                    >Send for approval</button>
                </div>

                <div class="pull-right" v-if="user.role === 1">
                    <button 
                        class="btn btn-primary btn-round waves-effect waves-light" 
                        :loading="submitting"
                        @click.prevent="approve"
                    >Save</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data(){
        return { 
            title : "Add Project",
            subTitle : "",
            submitting: false,
            isEdit: false,
            project: {},
            statuses: ['Approved', 'Declined'],
            coReseachers: [],
            coReseacher: {},
            reportingSchedule: {},
            disbursement: {},
            submitting: false,
            user: this.$baseRead('user'),
            disabled: false
        }
    },
    methods: {
        download(){
            var url = `${window.location.origin}/${this.project.fileUrl}`
            window.open(url, "_blank");
        },
        fileChanged(event) {
            this.project.documents = event.target.files[0]
        },
        uploadDocument(){
            const formData = new FormData()
            formData.append("publication", this.project.documents, this.project.documents.name)
            this.$http.post(`research/uploadDocument?usercode=${this.user.username}&operation=project`, formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }})
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                } else {
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.submitting = false
                this.$toastr("error", e.message)
            })
        },
        removeResearcher(index){
            this.project.projectCoReseachers.splice(index, 1);
        },
        removeSchedule(index){
            this.project.projectReports.splice(index, 1);
        },
        removeDisbursement(index){
            this.project.projectDisbursements.splice(index, 1);
        },
        addCoResearcher(){
            if(!this.coReseacher.empNo){
                this.$toastr('error', "Kindly enter co-researcher PFNo.");
                return
            }
            if(!this.project.projectCoReseachers){
                this.project.projectCoReseachers = []
                this.project.projectCoReseachers.push(this.coReseacher);

                this.coReseacher = {}
            }
            else{
                this.project.projectCoReseachers.forEach(element => {
                    if(element.empNo === this.coReseacher.empNo){
                        this.$toastr('error', "Sorry, Co-Reseacher already exists");
                    }
                    else{
                        this.project.projectCoReseachers.push(this.coReseacher);
                        this.coReseacher = {}
                    }
                });
            }
        },
        addReportingSchedule(){
            if(!this.reportingSchedule.startDate){
                this.$toastr('error', "Kindly, provide schedule start date");
                return
            }
            if(!this.reportingSchedule.endDate){
                this.$toastr('error', "Kindly, provide schedule end date");
                return
            }
            if(!this.project.projectReports){
                this.project.projectReports = []
            }

            this.reportingSchedule.startDate = DateFomatter.ReturnDate(this.reportingSchedule.startDate)
            this.reportingSchedule.endDate = DateFomatter.ReturnDate(this.reportingSchedule.endDate)
            this.project.projectReports.push(this.reportingSchedule)
            this.reportingSchedule = {}
        },
        addProjectDisbursement(){
            if(!this.disbursement.amount){
                this.$toastr('error', "Kindly, provide amount");
                return
            }
            if(!this.disbursement.date){
                this.$toastr('error', "Kindly, provide disbursement date");
                return
            }
            if(!this.project.projectDisbursements){
                this.project.projectDisbursements = []
            }

            this.disbursement.date = DateFomatter.ReturnDate(this.disbursement.date)
            this.project.projectDisbursements.push(this.disbursement)
            this.disbursement = {}
        },
        save(){
            this.submitting = true;
            this.project.empNo = this.user.username
            this.$http.post("research/createProjects", this.project)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    if(this.project.documents){
                        this.uploadDocument()
                    }
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'projects' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
        sendForApproval(){
            this.project.needApproval = true
            this.submitting = true;
            this.project.empNo = this.user.username
            this.$http.post("research/createProjects", this.project)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'projects' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
        approve(){
            this.submitting = true;
            this.$http.post("research/approveDeclineProject", this.project)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'projects' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
        getProjectDetails(id){
            this.loading = true;
            this.$http.get("research/getProjectDetails/?id=" + id)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.startDate = new Date(result.data.data.startDate) 
                    result.data.data.endDate = new Date(result.data.data.endDate) 
                    result.data.data.projectDisbursements.forEach(element => {
                        element.date = DateFomatter.ReturnDate(element.date)
                    });

                    result.data.data.projectReports.forEach(element => {
                        element.startDate = DateFomatter.ReturnDate(element.startDate)
                        element.endDate = DateFomatter.ReturnDate(element.endDate)
                    });

                   this.project = result.data.data
                   this.isEdit = this.isAdmin || !this.project.needApproval
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        getCoResearcher() {
            this.$http.get("complaint/getEmployees")
                .then(result => {
                this.coReseachers = [];
                if (result.data.success) {
                    result.data.data.forEach(element => {
                    this.coReseachers.push(`${element.names}-(${element.empNo})`)
                    });
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.assignText = "Error fetching User leave types";
            });
        },
    },
    created(){
        this.project.needApproval = this.user.role === 1 ? true : this.project.needApproval
        this.isAdmin = this.user.role == 1
        if(this.$route.params.id){
            this.project.id = this.$route.params.id
            this.getProjectDetails(this.$route.params.id)
        }
        
        this.isEdit = this.isAdmin || !this.project.needApproval
        if(!this.$route.params.id && this.user.role === 1){
            this.$router.replace({ name: 'projects' });
        }
        this.getCoResearcher()
    }
}
</script>

<style>

</style>
