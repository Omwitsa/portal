<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2" v-if="projects">
                        <button class="btn btn-primary btn-sm" @click="print()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2" v-if="user.role == 2 && projects">
                        <button class="btn btn-primary btn-round waves-effect waves-light">
                            <router-link to="add-project" style="color:white">
                                Add
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

                <div class="row" v-if="projects">
                    <div class="col-md-12">
                        <div class="table-responsive" id="projects">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>Name</th>
                                    <th>Title</th>
                                    <th>Period</th>
                                    <th>Cost</th>
                                    <th>Status</th>
                                    <th>Sponsor</th>
                                    <th>Contact Person</th>
                                    <th>Created Date</th>
                                    <th>Action</th>
                                </thead>

                                <tbody>
                                    <tr v-for="(project, index) in projects" :key="index">
                                        <td>{{project.name}}</td>
                                        <td>{{project.title}}</td> 
                                        <td>{{project.period}}</td>
                                        <td>{{project.cost}}</td>
                                        <td>{{project.status}}</td>
                                        <td>{{project.sponsor}}</td>
                                        <td>{{project.contactPerson}}</td>
                                        <td>{{project.createdDate}}</td>
                                        <td><list-button :item="project" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
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
    data(){
        return {
            loading: true,
            projects: null,
            submitting: false,
            tableActions: [
                {
                    name: "Details",
                    type: "button",
                    icon: "trash",
                    path: "details",
                    design: "danger"
                },
                {
                    name: "Delete",
                    type: "button",
                    icon: "trash",
                    path: "delete",
                    design: "danger"
                }
            ],
            subTitle: "",
            from : null,
            to: null,
            title: "Projects",
            searchText: "",
            user: this.$baseRead("user"),
            headerActions: [],
        }
    },
    methods: {
        print(){
            // this.$htmlToPaper("projects");
        },
        searchByText(enteredText) {
            // this.searchText = enteredText;
        },
        generate(){
            this.submitting = true;
            this.from = DateFomatter.ReturnDate(this.from);
            this.to = DateFomatter.ReturnDate(this.to);
            this.$http.get(`research/getProjects/?usercode=${this.user.username}&role=${this.user.role}&from=${this.from}&to=${this.to}`)
            .then(result => {
               if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.startDate = DateFomatter.ReturnDate(element.startDate),
                        element.endDate = DateFomatter.ReturnDate(element.endDate),
                        element.createdDate = DateFomatter.ReturnDate(element.createdDate)
                    });
                   this.projects = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.submitting = false;
            });
        },
        getHeaderActions(){
            if(this.user.role === 2){
                this.headerActions = [
                    {
                        name: "Add",
                        icon: "plus",
                        type: "link",
                        path: "add-project",
                        design: "primary"
                    }
                ]

                this.generate()
            }
        },
        deleteProject(id){
            this.loading = true;
            this.$http.get(`research/deleteProject/?id=${id}`)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    this.$toastr("success", result.data.message);
                    this.generate()
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        buttonEvent(item, action) {
            switch (action) {
                case "details":
                    this.$router.replace({ name: 'add-project', params: {id: item.id} });
                break;
                case "delete":
                    swal({
                        title: "Are you sure you want to delete?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: false
                    }).then(action => {
                        if(action){
                            this.deleteProject(item.id)
                        }
                    })
                break;
                default:
                break;
            }
        }
    },
    created(){
        if(this.user.role == 2){
            this.generate()
        }
        // this.getHeaderActions()
    }
}
</script>

<style>

</style>
