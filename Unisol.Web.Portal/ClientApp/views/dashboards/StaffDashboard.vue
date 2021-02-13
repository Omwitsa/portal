<template>
    <div class="row">
        <div class="col-lg-7 col-md-12">
            <div class="card table-card latest-activity-card">
                <div class="card-header borderless">
                    <h5>Leave Days</h5>
                    <div class="card-header-right">
                        <ul class="list-unstyled card-option">
                            <li class="first-opt"><i class="fa fa-chevron-left open-card-option"></i></li>
                            <li><i class="fa fa-maximize full-card"></i></li>
                            <li><i class="fa fa-minus minimize-card"></i></li>
                            <li><i class="fa fa-refresh-cw reload-card"></i></li>
                            <li><i class="fa fa-trash close-card"></i></li>
                            <li><i class="fa fa-chevron-left open-card-option"></i></li>
                        </ul>
                    </div>
                </div>

                <div class="card-block">
                    <loading-spinner :loading="loading"></loading-spinner>
                    <div class="table-responsive">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Leave Type</th>
                                    <th>Leave Period</th>
                                    <th class="text-right">Status</th>
                                </tr>
                            </thead>
                            <tbody v-for="(leaveDay, Index) in leaveDays" :key="Index">
                                <tr>
                                    <td>{{leaveDay.leaveType}}</td>
                                    <td>{{leaveDay.leaveDays}}</td>
                                    <td class="text-right"><label class="label label-primary">{{leaveDay.status}}</label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-5 col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            Employment Category
                        </div>
                        <div class="card-block">
                            <small-spinner :loading="loading"> </small-spinner>
                            <div class="row align-items-center">
                                <div class="col-md-12">
                                    <h4 class="text-muted m-b-0">{{employee.jobTitle}}</h4>
                                    <h6 class="text-muted m-b-0">{{employee.jobCat}}</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6 col-md-12">
            <div class="card table-card review-card">
                <div class="card-header borderless ">
                    <h5>Latest News</h5>
                </div>
                <div class="card-block">
                    <div class="review-block">
                        <div class="row" v-for="(newsItem, nIndex) in news" :key="nIndex">
                            <div class="col">
                                <h6 class="m-b-15">{{newsItem.title}} <span class="float-right f-13 text-muted"> {{newsItem.posted}}</span></h6>
                                <p class="m-t-15 m-b-15 text-muted">{{newsItem.body}}</p>
                                <!-- <div class="m-r-30 badge badge-primary">{{newsItem.type}}</div> -->
                                <router-link class="btn btn-info btn-sm btn-round btn-outline-primary pull-right" :to="{ name: 'news-details', params: { id: newsItem.id }}">Read More</router-link>
                            </div>
                        </div>
                    </div>

                    <div class="text-right  m-r-20">
                        <a @click="routeTo('portal-news')" class="b-b-primary text-primary">View all News</a>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6 col-md-12">
            <div class="card table-card review-card">
                <div class="text-center"> <small-spinner :loading="loading"> </small-spinner></div>
                <div class="card-header borderless ">
                    <h5>Latest Event</h5>
                </div>  
                <div v-if="isEventResults" class="card-block">
                    <div class="review-block">
                        <div class="row" v-for="(EventItem, Index) in events" :key="Index">
                            <div class="col">
                                <h6 class="m-b-15">{{EventItem.title}} <span class="float-right f-13 text-muted"> {{EventItem.startdate}}</span></h6>
                                <p class="m-t-15 m-b-15 text-muted">{{EventItem.description}}</p>
                                <router-link class="btn btn-info btn-sm btn-round btn-outline-primary pull-right" :to="{ name: 'events-details', params: { id: EventItem.id }}">Read More</router-link>
                            </div>
                        </div>
                    </div>
                    <div class="text-right  m-r-20">
                        <a @click="routeTo('portal-events')" class="b-b-primary text-primary">View all Events</a>
                    </div>
                </div>

                <div style="color:red" v-if="!isEventResults" class="card-block">
                    <div class="review-block">
                        <div class="row">
                            <div class="col">
                                There is no current event entry
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import END_POINTS from "../../components/constants/EndPoints"
import DateFomatter from "../../components/constants/DateFomatter"
export default {
    data(){
        return{
            loading: false,
            user: {},
            employee: {},
            news: [],
            newsCount: 0,
            events: [],
            eventsCount: 0,
            isEventResults: true,
            employmentStatusTitle: "",
            leaveDays: []
        }
    },
    created(){
        this.user = this.$baseRead('user')
        // this.getDashboardContent()
        this.fetchNews()
        this.fetchEvents()
        this.fetchEmpInfo()
        this.getEmpLeaveDays()
        this.getInstitutionInfo()
    },
    methods: {
        getInstitutionInfo() {
            this.$http.get("commonutilities/GetInstitutionInfo")
                .then(response => {
                localStorage.setItem("institutionInfo", null);
                var institutionInfo = JSON.stringify(response.data.data);
                localStorage.setItem("institutionInfo", institutionInfo);
                })
                .catch(error => {
                this.$toastr("error", error.message);
            });
        },
        getDashboardContent(){
            this.$http.get("dashboard/getDashboardContent")
            .then(result => {
            })
            .catch(error => {
                this.$toastr("error", error.message)
            })
        },
        fetchNews() {
            this.loading = true
            this.$http
            .get("news/GetNews?searchText=&offset=0&userCode="+this.user.username)
            .then(result => {
                this.news = []
                var info = result.data.data
                this.newsCount = result.data.totalItems
                info.forEach(element => {
                    var item = {
                    id: element.id,
                    title: element.newsTitle,
                    body: this.stripContent(element.newsBody).substr(0,140) + '...',
                    type: element.portalNewsType.newsTypeName,
                    posted: DateFomatter.ReturnDate(element.dateCreated),
                    status: element.newsStatus == 1 ? "Active" : "Inactive"
                    }
                    this.news.push(item)
                    this.loading = false
                })
            })
            .catch(error => {
            this.$toastr("error", error.message)
            this.loading = false
            })
        },
        fetchEvents(){
            this.loading = true
            this.$http
                .get(END_POINTS.GETEVENTS + 3 + "&offset=0&tokenString=" + this.user.token + "&userCode="+this.user.username)
                .then(result => {
                this.events = []
                if(result.data.success){
                    var info = result.data.data
                    this.eventsCount = result.data.totalItems
                    if(info == ""){
                    this.isEventResults = false
                    }
                    else{
                        info.forEach(element => {
                        var item = {     
                        id: element.id,
                        title: element.eventTitle,
                        description: this.stripContent(element.eventDesc).substr(0,140) + '...',
                        startdate: DateFomatter.ReturnDate(element.eventStartDate),
                        enddate: DateFomatter.ReturnDate(element.eventEndDate),
                        }
                        this.events.push(item)
                        this.loading = false
                        })
                    }
                }
                })
                .catch(error => {
                this.$toastr("error", error.message)
                this.loading = false
                })
        },
        fetchEmpInfo(){
            this.loading = true
            this.$http.get("profile/getStaffData?userCode="+ this.user.username)
            .then(result => {
               if(result.data.success){
                   this.employee =  result.data.data 
                   this.employmentStatusTitle = this.employee.terminated ? "Terminated" : "Employed"
                   this.loading = false
               }
            }).catch(error => {
                this.$toastr("error", error.message)
                this.loading = false
            })
        },
       getEmpLeaveDays(){
           this.loading = true
            this.$http.get("leave/getByEmployee?empNo="+ this.user.username)
            .then(result => {
               if(result.data.success){
                   this.leaveDays =  result.data.data
                   this.loading = false
               }
            }).catch(error => {
                this.$toastr("error", error.message)
                this.loading = false
            })
        },
        stripContent(content) {
            let regex = /(<([^>]+)>)/ig
            return content.replace(regex, "")
        },
        routeTo(to) {
            if (to) {
                this.$router.replace({ name: to })
            }
        },
    }
}
</script>
<style>

</style>
