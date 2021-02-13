<template>
   <div class="page-body"> 
       <div class="card">
           <div class="card-header">
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2" v-if="publications">
                        <button class="btn btn-primary btn-sm" @click="print()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2" v-if="user.role == 2 && publications">
                        <button class="btn btn-primary btn-round waves-effect waves-light">
                            <router-link to="add-publication" style="color:white">
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
                                <v-select
                                    :options="types"
                                    v-model="type"
                                ></v-select>
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

                <div class="row" v-if="publications">
                    <div class="col-md-12">
                        <div class="table-responsive" id="publications">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>Name</th>
                                    <th>Title</th>
                                    <th>Year</th>
                                    <th>Type</th>
                                    <th>Link</th>
                                    <th>Date</th>
                                    <th>Action</th>
                                </thead>

                                <tbody>
                                    <tr v-for="(publication, index) in publications" :key="index">
                                        <td>{{publication.name}}</td> 
                                        <td>{{publication.title}}</td>
                                        <td>{{publication.year}}</td>
                                        <td>{{publication.type}}</td>
                                        <td>{{publication.url}}</td>
                                        <td>{{publication.date}}</td>
                                        <td><list-button :item="publication" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
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
            publications: null,
            from : null,
            submitting: false,
            type: "",
            types: ['Book', 'Book chapter', 'Article', 'Journal', 'Autography'],
            to : null,
            tableActions: [{
                name: "Details",
                type: "button",
                icon: "trash",
                path: "details",
                design: "danger"
            }],
            subTitle: "",
            title: "Publications and Dissemination",
            user: this.$baseRead("user"),
            searchText: "",
            headerActions: [],
        }
    },
    methods : {
        searchByText(enteredText) {
            // this.searchText = enteredText;
        },
        print(){
            this.$htmlToPaper("publications");
        },
        getHeaderActions(){
            if(this.user.role == 2){
                this.headerActions = [
                    {
                        name: "Add",
                        icon: "plus",
                        type: "link",
                        path: "add-publication",
                        design: "primary"
                    }
                ]
            }
        },
        generate(){
            this.submitting = true;
            this.from = DateFomatter.ReturnDate(this.from);
            this.to = DateFomatter.ReturnDate(this.to);
            this.$http.get(`research/getPublications/?usercode=${this.user.username}&role=${this.user.role}&from=${this.from}&to=${this.to}&type=${this.type}`)
            .then(result => {
                this.submitting = false;
                if (result.data.success) {
                     result.data.data.forEach(element => {
                        element.link = element.url ? element.url : ""
                        element.date = DateFomatter.ReturnDate(element.createdDate)
                    });
                   this.publications = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.submitting = false;
            });
        },
        buttonEvent(item, action) {
            switch (action) {
                case "details":
                    this.$router.replace({ name: 'add-publication', params: item });
                break;
                case "delete":
                    // swal({
                    //     title: "Are you sure you want to delete?",
                    //     icon: "warning",
                    //     buttons: true,
                    //     dangerMode: false
                    // }).then(action => {
                    //     if(action){
                    //         this.deleteProject(item.id)
                    //     }
                    // })
                break;
                default:
                break;
            }
        }
    },
    created(){
        if(this.user.role == 2){
            this.generate();
        }
        this.getHeaderActions()
    }
}
</script>

<style>

</style>
