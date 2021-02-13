<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2" v-if="complaints">
                        <button class="btn btn-primary btn-sm" @click="print()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2" v-if="user.role == 3">
                        <button class="btn btn-primary btn-round waves-effect waves-light">
                            <router-link to="add-complaint" style="color:white">
                                Create
                            </router-link>
                        </button>
                    </div>
                </div>
                <div class="row" v-if="user.role == 1">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-1">
                                From
                            </div>
                            <div class="col-md-3">
                                <date-picker v-model="from"></date-picker>
                            </div>

                            <div class="col-md-1">
                                To
                            </div>

                            <div class="col-md-3">
                                <date-picker v-model="to"></date-picker>
                            </div>

                            <div class="col-md-2">
                                <div class="pull-right">
                                    <button
                                        class="btn btn-primary btn-round waves-effect waves-light" 
                                        :loading="submitting"
                                        @click.prevent="generate"
                                    >Generate</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> <br>

                <div class="row" v-if="complaints">
                    <div class="col-md-12">
                        <div class="table-responsive" id="complaint">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>User Name</th>
                                    <th>Complaint</th>
                                    <th>Hostel</th>
                                    <th>Date</th>
                                    <th>Action Date</th>
                                    <th>Status</th>
                                    <th>Assignee</th>
                                    <th>Action Status</th>
                                    <th>Remarks</th>
                                    <th v-if="user.role != 3">Action</th>
                                </thead>

                                <tbody>
                                    <tr v-for="(complaint, index) in complaints" :key="index">
                                        <td>{{complaint.username}}</td> 
                                        <td>{{complaint.complaint}}</td>
                                        <td>{{complaint.hostel}}</td>
                                        <td>{{complaint.date}}</td>
                                        <td>{{complaint.actionDate}}</td>
                                        <td>{{complaint.status}}</td>
                                        <td>{{complaint.assignee}}</td>
                                        <td>{{complaint.action}}</td>
                                        <td>{{complaint.remarks}}</td>
                                        <td v-if="user.role != 3"><list-button :item="complaint" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data() {
        return {
            complaints: null,
            submitting: false,
            tableActions: [],
            subTitle: "",
            item : [],
            title: "Complaints",
            user: this.$baseRead("user"),
            searchText: "",
            from : null,
            to : null,
            headerActions: [],
        }
    },
    methods: {
        searchByText(enteredText) {
            // this.searchText = enteredText;
            // this.loadData(10, 1);
        },
        print(){
            this.$htmlToPaper("complaint");
        },
        stripContent(content) {
            let regex = /(<([^>]+)>)/ig
            return content.replace(regex, "")
        },
        generate(){
            this.submitting = true;
            this.from = DateFomatter.ReturnDate(this.from);
            this.to = DateFomatter.ReturnDate(this.to);
            this.$http.get(`complaint/getComplaints/?usercode=${this.user.username}&role=${this.user.role}&from=${this.from}&to=${this.to}`)
            .then(result => {
                this.submitting = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.date = DateFomatter.ReturnDate(element.createdDate)
                        element.complaint = this.stripContent(element.reason).substr(0,30) + '...'
                    });
                   this.complaints = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.submitting = false;
            });
        },
        getHeaderActions(){
           if(this.user.role != 1){
               this.headerActions = [
                    {
                        name: "Add",
                        icon: "plus",
                        type: "link",
                        path: "add-complaint",
                        design: "primary"
                    }
                ]
           }
        },

        getTableActions(){
            if(this.user.role != 3){
                this.tableActions = [
                    {
                        name: "Details",
                        type: "button",
                        icon: "trash",
                        path: "details",
                        design: "danger"
                    }
                ]
            }
        },
        buttonEvent(item, action) {
            switch (action) {
                case "details":
                    this.$router.replace({ name: 'add-complaint', params: item});
                break;
                default:
                break;
            }
        }
    },
    created(){
        if(this.user.role != 1){
            this.generate()
        }
        this.getHeaderActions()
        this.getTableActions()
    }
}
</script>

<style>

</style>
