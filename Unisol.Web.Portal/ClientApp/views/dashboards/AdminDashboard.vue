<template>
 
    <div class="row">
        <div class="col-lg-7 col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>Quick Launch</h5>
                        </div>
                        <div class="card-block">
                            <button class="btn btn-primary btn-round waves-effect waves-light btn-sm" @click="launch('users')">Add New User</button>
                            <button class="btn btn-primary btn-round waves-effect waves-light btn-sm" v-if="!user.genesisUser" @click="launch('evaluations')">Create Evaluation</button>
                            <button class="btn btn-primary btn-round waves-effect waves-light btn-sm" @click="launch('events')">Create Event</button>
                            <button class="btn btn-primary btn-round waves-effect waves-light btn-sm" @click="launch('news')">Add News / Post</button>
                            <button class="btn btn-primary btn-round waves-effect waves-light btn-sm" v-if="!user.genesisUser" @click="launch('settings')">System Settings</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>Users</h5>
                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <table class="table table-hover table-sm">
                                    <thead class="table-primary text-white">
                                        <th v-for="(column, index) in usersColumns" :key="index"
                                            @click="sortTable.sort(concatenateHeader(column.name))">
                                            {{column.name}}
                                            <span class="arrow" :class="sortTable.currentSortDir"></span>
                                        </th>
                                        <!-- <th v-if="tableActions.length > 0">Actions</th> -->
                                    </thead>
                                    <tbody>
                                        <tr v-for="(item,index) in userData" :key="index">
                                            <td v-for="(column,index) in usersColumns" :key="index" v-if="hasValue(item, column)" v-html="itemValue(item, column)">
                                            </td>
                                            <!-- <td v-if="tableActions.length > 0">
                                                <list-button 
                                                    :item="item" 
                                                    :index="index" 
                                                    :actions="tableActions"
                                                    v-on:listButtonEvent="userEvents"
                                                ></list-button>
                                            </td> -->
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                            <div style="text-align: center" v-if="userData">
                                <button class="btn btn-link " @click="viewUsers()">View More</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>News</h5>
                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <table class="table table-hover table-sm">
                                    <thead class="table-primary text-white">
                                        <th v-for="(column, index) in newsColumns" :key="index"
                                            @click="sortTable.sort(concatenateHeader(column.name))">
                                            {{column.name}}
                                            <span class="arrow" :class="sortTable.currentSortDir"></span>
                                        </th>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(item,index) in newsData" :key="index">
                                            <td v-for="(column,index) in newsColumns" :key="index" v-if="hasValue(item, column)" v-html="itemValue(item, column)">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div style="text-align: center" v-if="newsData">
                                <button class="btn btn-link" @click="viewNews()">View More</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>Events</h5>
                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <table class="table table-hover table-sm">
                                    <thead class="table-primary text-white">
                                        <th v-for="(column, index) in eventsColumns" :key="index"
                                            @click="sortTable.sort(concatenateHeader(column.name))">
                                            {{column.name}}
                                            <span class="arrow" :class="sortTable.currentSortDir"></span>
                                        </th>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(item,index) in eventData" :key="index">
                                            <td v-for="(column,index) in eventsColumns" :key="index" v-if="hasValue(item, column)" v-html="itemValue(item, column)">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div> 
                            <div style="text-align: center" v-if="eventData">
                                <button class="btn btn-link" @click="viewEvents()">View More</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col-lg-5 col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5>File Directory</h5>
                </div>
                <div class="card-block">
                    <div style="text-align: center">
                        <button class="btn btn-link" @click="viewFolders()">View Folder</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
 
</template>

<script>
import SortTable from "../../components/constants/SortTable"
import DateFomatter from "../../components/constants/DateFomatter"
export default {
    computed: {
        sortedItems:function() {
            var data = this.userData
            if(data){
                return data.sort((a,b) => {
                    let modifier = 1;
                    if(this.sortTable.currentSortDir === 'dsc') modifier = -1;
                    if(a[this.sortTable.currentSort] < b[this.sortTable.currentSort]) return -1 * modifier;
                    if(a[this.sortTable.currentSort] > b[this.sortTable.currentSort]) return 1 * modifier;
                    return 0;
                });
            }
        }
    },
    data () {
        return {
            userData: null,
            newsData: null,
            eventData: null,
            sortTable: SortTable,
            submitting: false,
            loading: false,
            users: null,
            user: {},
            subTitle: "",
            title: "Users",
            headerActions: [],
            usersColumns: [
                {
                    name: "Username",
                    type:"currency"
                },
                {
                    name: "Email",
                    type:"centered"
                },
                {
                    name: "Group",
                    type:"text"
                },
                {
                    name: "Status",
                    type:"text"
                }
            ],
            newsColumns: [
                {
                name: "News Title"
                },
                {
                name: "Category"
                },
                {
                name: "Expiry Date"
                },
                {
                name: "Status"
                }
            ],
            eventsColumns: [
                {
                name: "Events Title"
                },
                {
                name: "Start Date"
                },
                {
                name: "End Date"
                }
            ],
            tableActions: [
                {
                    name: "Confirm account",
                    icon: "edit",
                    type: "button",
                    path: "confirm",
                    design: "success"
                },
                {
                    name: "Reset Password",
                    icon: "edit",
                    type: "link",
                    path: "reset-password",
                    design: "success"
                },
                {
                    name: "Activate/diactivate",
                    icon: "edit",
                    type: "button",
                    path: "updateStatus",
                    design: "success"
                },
                {
                    name: "Delete",
                    type: "button",
                    icon: "trash",
                    path: "delete",
                    design: "danger"
                }
            ],
            pagination: {
                total: 0
            }
        }
    },
    created(){
        this.user = this.$baseRead('user')
        // this.getDashboardContent()
        this.getUsers(3)
        this.getNews()
        this.getEvents(3)
    },
  methods: {
      getDashboardContent(){
        this.$http.get("dashboard/getDashboardContent")
        .then(result => {
            
        })
        .catch(error => {
            this.$toastr("error", error.message)
        })
      },
      getEvents(items){
          this.$http.get("events/getevents/?itemsPerPage="+items+"&userCode="+this.user.username)
            .then(result => {
                if(result.data.success){
                    this.eventData= []
                    result.data.data.forEach(element => {
                        var item = {
                            id: element.id,
                            eventstitle: element.eventTitle,
                            startdate: DateFomatter.ReturnDate(element.eventStartDate),
                            enddate: DateFomatter.ReturnDate(element.eventEndDate),
                        }
                        this.eventData.push(item)
                    });
                }
            })
            .catch(error => {
                this.$toastr("error", error.message)
            })
      },
      getNews(){
            this.$http.get("news/GetNews?userCode="+this.user.username)
            .then(result => {
                    if(result.data.success){
                        this.newsData= []
                        result.data.data.forEach(element => {
                            var item = {
                                id: element.id,
                                newstitle: element.newsTitle,
                                category: element.portalNewsType.newsTypeName,
                                expirydate: DateFomatter.ReturnDate(element.expiryDate),
                                status: element.newsStatus == 1 ? "Active" : "Inactive"
                            }
                            this.newsData.push(item)
                        });
                    }
            })
            .catch(error => {
                this.$toastr("error", error.message)
            })
        },
      getUsers(items){
            this.$http.get("users/pages/?itemsPerPage=" + items)
            .then(result => {
                    if(result.data.success){
                        this.userData= []
                        result.data.data.forEach(element => {
                            var item = {
                                username: element.userName,
                                email: element.email,
                                group: element.userGroup,
                                status: element.status ? "Active" : "Disabled"
                            }
                            this.userData.push(item)
                        });
                    }
                }
            )
            .catch(error => {
                this.$toastr("error", error.message)
            })
      },
      launch(val){
           switch(val){
                case 'users':
                    this.$router.replace({name: "add-users"})
                break
                case 'evaluations':
                    this.$router.replace({name: "add-current"})
                break
                case 'events':
                    this.$router.replace({name: "add-events"})
                break
                case 'news':
                    this.$router.replace({name: "add-news"})
                break
                case 'settings':
                    this.$router.replace({name: "other-settings"})
                break
                default:
                break
           }
        },
        fetchUsers(){

        },
        userEvents(item, action){
            switch (action) {
                
                case "":
                break
            }
        },
        viewFolders(){
            this.$router.replace({name: "repository"})
        },
        viewUsers(){
            this.$router.replace({name: "users-list"})
        },
        viewNews(){
            this.$router.replace({name: "news-list"})
        },
        viewEvents(){
            this.$router.replace({name: "events"})
        },
        hasValue (item, column) {
            return item[this.concatenateHeader(column.name)] !== 'undefined'
        },
        concatenateHeader (column) {
            var columnArray = column.split(' ')
            if(columnArray.length > 1) column = columnArray.join("")
            return column.toLowerCase()
        },
        itemValue (item, column) {
            var value = item[this.concatenateHeader(column.name)]
            var display = ''
            switch (column.type) {
                case 'text':
                display = value 
                break;
                
                case 'currency':
                display = '<span class="text-right">'+value+'</span>' 
                break;

                case 'centered':
                display = '<span class="text-center">'+value+'</span>' 
                break;

                case 'numeric':
                display = '<span class="text-center">'+value+'</span>' 
                break;

                case 'badge':
                display = '<label class="label label-primary">'+value+'</label>' 
                break;
                
                case 'code':
                display = '<code>'+value+'</code>' 
                break;
            
                default:
                display =  value 
                    break;
            }
            return display
        },
    }
}
</script>

<style>
</style>
