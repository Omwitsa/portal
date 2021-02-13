<template>
    <div class="page-body navbar-page">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Institution Events</h5>
                        <span>Events Calendar.</span>
                        <!-- <div class="card-header-right">
                            <span class="badge badge-primary">{{totalItems}}</span>
                        </div> -->
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                                 <div class="input-group" v-if="events.length">
                                    <input type="text"
                                           v-model="searchText" @keyup="searchEvent"
                                           placeholder="Search here" class="form-control">
                                    <span class="input-group-append">
                                         <label class="input-group-text">Search</label>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">

                        </div>

                        <div class="text-center text-danger" v-if="!events.length && !eventHttp">
                            <div class="btn  btn-danger"
                                style="border-radius: 100%;height: 140px;width: 140px;">
                                <div class="clearfix">&nbsp;</div>

                                <div class="h2">
                                    <i class="fa fa-exclamation fa-2x"></i>
                                </div>
                            </div>
                            <p style="color:red">Events not found</p>
                        </div>
                    </div>

                    <loading-spinner :loading="eventHttp"></loading-spinner>

                    <div class="card-block">
                        <div class=" table-card review-card">
                            <div class="review-block">
                                <div class=" " v-for="(eventItem, nIndex) in events" :key="nIndex"
                                     style="border-bottom: 1px solid lightgrey;">
                                     <div class="col col-xs-12">
                                         <h6 class="col-md-12 col-xs-12">{{eventItem.eventTitle}} <span
                                                class="float-right f-13 text-muted"> {{eventItem.dateCreated}}</span>
                                        </h6>

                                         <p class="col-md-12 col-xs-12 col-lg-12 "
                                           style="width: 100%!important;">
                                            {{stripContent(eventItem.eventDesc)}}
                                        </p>
                                        <div class="m-r-30 badge badge-primary">{{eventItem.eventTitle}}
                                            <!-- {{eventItem.portaleventType.eventTypeName}} -->
                                        </div>
                                        <router-link
                                                class="btn btn-info  btn-round btn-outline-primary pull-right"
                                                :to="{ name: 'events-details', params: { id: eventItem.id }}">Read
                                            More
                                        </router-link>
                                     </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
import fullCalendar from 'vue-fullcalendar'
import END_POINTS from "../../components/constants/EndPoints"
import DateFomatter from "../../components/constants/DateFomatter"
    export default {
        components: { 
            'full-calendar': require('vue-fullcalendar')
        },
        data() {
            return {
                evaluations: [],
                calenderEvents : [
                    {
                    title : 'Foo',
                    start : '2018-07-20',
                    end : '2018-07-24'
                    }
                ],
                clickedIndex: null,
                loading: true,
                eventHttp: false,
                title: 'Evaluations',
                subTitle: 'List of Evaluations.',
                pageSize: 15,
                itemsPerPage: 3,
                offset: 0,
                user: {},
                totalPages: 0,
                totalItems: 0,
                events: [],
                searchText: '',
                pagination: {
                    total: 0
                }
            }
        },

        methods: {
            loadData() {
                this.eventHttp = true;
                this.$http
                    .post(END_POINTS.GETEVENTS + this.itemsPerPage + "&offset=" + this.offset + "&role="+this.user.role)
                    .then(result => {
                        this.eventHttp = false
                        if (result.data.success) {
                            this.totalItems = result.data.totalItems;
                            this.totalPages = Math.ceil(result.data.totalItems / this.itemsPerPage);
                            var result = result.data.data
                            result.forEach(element => {
                                var item = {
                                    id: element.id,
                                    createdBy: element.createdBy,
                                    dateCreated: DateFomatter.ReturnDate(element.dateCreated),
                                    eventDesc: this.stripContent(element.eventDesc).substr(0,140) + '...',
                                    eventEndDate: DateFomatter.ReturnDate(element.eventEndDate),
                                    eventStartDate: DateFomatter.ReturnDate(element.eventStartDate),
                                    eventTitle: element.eventTitle,
                                    portalEventTypeId: element.portalEventTypeId,
                                    sendEmailFlag: element.sendEmailFlag,
                                    targetAudience: element.targetAudience,
                                    portalEventType: element.portalEventType
                                }
                            this.events.push(item)
                            })
                        } else {
                            this.$toastr("error", result.data.message)
                        }
                    })
                    .catch(error => {
                        this.eventHttp = false
                        this.$toastr("error", error.message)
                    })

            },
            nextPage: function () {
                if (Math.abs(this.offset) + 1 <= this.totalPages) {
                    this.offset++;
                    this.loadData();
                }
            },
            stripContent(content) {
                let regex = /(<([^>]+)>)/ig
                return content.replace(regex, "") + "..."
            },
            previousPage: function () {
                if (Math.abs(this.offset) - 1 >= 0) {
                    this.offset--;
                    this.loadData();
                }
            },
            searchEvent: function () {
                this.events = [];
                this.totalPages = 0;
                this.totalItems = 0;
                this.offset = 0;
                this.loadData();

            },
            deleteEvaluation: function (id, index) {
                this.evaluations.splice(index, 1);
            },
            buttonEvent(item, action) {
                switch (action) {
                    case 'delete':
                        break
                    case 'status':
                        var activity = 'disabled'
                        if (item.status)
                            activity = 'activated'
                        break
                    default:
                        break
                }
            },
        },

        created() {
            this.user = this.$baseRead('user')
            this.loadData(10, 1)
        }
    }
</script>

<style>
</style>
