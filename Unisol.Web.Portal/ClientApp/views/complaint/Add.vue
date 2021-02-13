<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{ title }}</h5>
                <span v-if="subTitle">{{ subTitle }}</span>
            </div>

            <div class="card-block" v-if="user.role == 3">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                        <label for>Enter your complaint</label> 
                        <br />
                        <textarea class="form-control" v-model="complaint.reason" placeholder="Reason"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-block" v-if="user.role != 3">
                <div class="card">
                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-4"><p><strong>Admission Number: </strong>{{complaint.username}}</p></div>
                            <div class="col-md-4"><p><strong>Hostel: </strong>{{complaint.hostel}}</p></div>
                            <div class="col-md-4"><p><strong>Creation Date: </strong>{{complaint.createdDate}}</p></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <p><strong>Remarks: </strong> {{complaint.remarks}}</p>
                                <p><strong>Reason: </strong> {{complaint.reason}}</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6" v-if="user.role === 1">
                        <label for>Assign Task</label>
                        <v-select
                            :options="assignees"
                            v-model="complaint.assignee"
                        ></v-select>
                    </div>

                    <div class="col-md-6">
                        <label for>Status</label>
                        <v-select v-if="user.role === 1"
                            :options="statuses"
                            v-model="complaint.status"
                        ></v-select>
                        <v-select v-if="user.role === 2"
                            :options="statuses"
                            v-model="complaint.action"
                        ></v-select>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-12" v-if="user.role != 2">
                        <div class="form-group">
                        <label for>Remarks</label> 
                        <br />
                        <textarea class="form-control" v-model="complaint.remarks" placeholder="Remarks"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                <button
                    class="btn btn-primary btn-round waves-effect waves-light" 
                    :loading="submitting"
                    @click.prevent="save"
                >Submit</button>
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
            title : "Complaints",
            subTitle : "",
            complaint : {},
            submitting: false,
            user: this.$baseRead('user'),
            assignees: [],
            statuses: ['Pending', 'Approved', 'Declined']
        }
    },
    methods: {
        save(){
            this.submitting = true;
            this.complaint.username = this.user.username
            this.$http.post(`complaint/createComplaint?role=${this.user.role}`, this.complaint)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'complaint' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
            this.submitting = false;
            this.$toastr('error', e.message);
            });
        },
        getAssignees() {
            this.$http.get("complaint/getEmployees")
                .then(result => {
                this.assignees = [];
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        this.assignees.push(`${element.names}-(${element.empNo})`)
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
        if(this.$route.params.id){ 
            this.complaint = this.$route.params
            this.complaint.createdDate = DateFomatter.ReturnDate(this.complaint.createdDate)
        }
        if(!this.$route.params.id && this.user.role != 3){
            this.$router.replace({ name: 'complaint' })
        }
        if(this.user.role == 2){
            this.complaint.status = ""
            this.statuses =  ['Active','Closed'] 
        }

        this.getAssignees()
    }
}
</script>

<style>

</style>
