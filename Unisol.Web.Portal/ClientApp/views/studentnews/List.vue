<template>
    <div class="page-body navbar-page">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Portal News</h5>
                        <span>List Of Portal News.</span>
                        <div class="card-header-right">
                            <!-- <span class="badge badge-primary">{{totalItems}}</span> -->
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                                <div class="input-group" v-if="news.length">
                                    <input type="text"
                                           v-model="searchText" @keyup="searchNews"
                                           placeholder="Search here" class="form-control">
                                    <span class="input-group-append">
                                         <label class="input-group-text">Search</label>
                                    </span>
                                </div>
                            </div>

                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            </div>
                        </div>

                        <div class="text-center text-danger" v-if="!news.length && !newsHttp">
                            <div class="btn  btn-danger"
                                style="border-radius: 100%;height: 140px;width: 140px;">
                                <div class="clearfix">&nbsp;</div>

                                <div class="h2">
                                    <i class="fa fa-exclamation fa-2x"></i>
                                </div>
                            </div>
                            <p style="color:red">News not found</p>
                        </div>
                    </div>
                    <loading-spinner :loading="newsHttp"></loading-spinner>
                    <div class="card-block">
                        <div class=" table-card review-card">
                            <div class="review-block">
                                <div class=" " v-for="(newsItem, nIndex) in news" :key="nIndex"
                                     style="border-bottom: 1px solid lightgrey;">
                                    <div class="col col-xs-12">
                                        <h6 class="col-md-12 col-xs-12">{{newsItem.newsTitle}} <span
                                                class="float-right f-13 text-muted"> {{newsItem.dateCreated}}</span>
                                        </h6>
                                        <p class="col-md-12 col-xs-12 col-lg-12 "
                                           style="width: 100%!important;">
                                            {{stripContent(newsItem.newsBody)}}
                                        </p>
                                        <div class="m-r-30 badge badge-primary">
                                            {{newsItem.portalNewsType.newsTypeName}}
                                        </div>
                                        <router-link
                                                class="btn btn-info btn-sm btn-round btn-outline-primary pull-right"
                                                :to="{ name: 'portal-News-Details', params: { id: newsItem.id }}">Read
                                            More
                                        </router-link>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-block text-center">
                        <div class="btn btn-sm btn-primary" @click="previousPage()"
                             v-if="totalPages >0&& offset< totalPages&&!newsHttp&&offset>0">
                            Load previous
                        </div>
                        <div class="btn btn-sm btn-primary" v-if="totalPages >0">
                            {{offset+1}} of {{totalPages}}
                        </div>
                        <div class="btn btn-sm btn-primary " @click="nextPage()"
                             v-if="totalPages >0&& offset+1< totalPages&&!newsHttp">
                            Load next
                        </div>
                    </div>
                    <div class="card-block text-center" v-if="newsHttp">
                        <small-spinner :loading="newsHttp"></small-spinner>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import END_POINTS from '../../components/constants/EndPoints';
    import DateFomatter from "../../components/constants/DateFomatter"
    export default {
        data() {
            return {
                evaluations: [],
                clickedIndex: null,
                loading: true,
                newsHttp: false,
                title: 'Evaluations',
                subTitle: 'List of Evaluations.',
                pageSize: 15,
                itemsPerPage: 3,
                offset: 0,
                totalPages: 0,
                totalItems: 0,
                dateCreated: "",
                news: [],
                user:{},
                searchText: '',
                pagination: {
                    total: 0
                }
            }
        },
        methods: {
            loadData() {
                this.newsHttp = true;
                this.$http
                .get("news/GetNews?searchText="+this.searchText+"&offset=0&role="+this.user.role)
                .then(result => {
                    this.newsHttp = false
                    if (result.data.success) {
                        var result = result.data.data
                        result.forEach(element => {
                            var item = {
                                id: element.id,
                                newsBody: this.stripContent(element.newsBody).substr(0,140) + '...', 
                                newsStatus: element.newsStatus,
                                newsTitle: element.newsTitle,
                                portalNewsType: element.portalNewsType,
                                portalNewsTypeId: element.portalNewsTypeId,
                                portalNewsViews: element.portalNewsViews,
                                sendEmailFlag: element.sendEmailFlag,
                                targetAudience: element.targetAudience,
                                dateCreated: DateFomatter.ReturnDate(element.dateCreated),
                                expiryDate: DateFomatter.ReturnDate(element.expiryDate),
                            }
                        this.news.push(item)
                        })
                    } else {
                        this.$toastr("error", result.data.message)
                    }
                })
                .catch(error => {
                    this.newsHttp = false
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
                return content.replace(regex, "")+ "..."
            },
            previousPage: function () {
                if (Math.abs(this.offset) - 1 >= 0) {
                    this.offset--;
                    this.loadData();
                }
            },
            searchNews: function () {
                this.news = [];
                this.totalPages =0;
                this.totalItems =0;
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
