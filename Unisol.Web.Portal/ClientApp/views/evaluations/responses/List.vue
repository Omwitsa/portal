<template>
    <div class="page-body navbar-page">
        <div class="row">
            <div class="col-sm-12">
                <!-- Custom Light Colors card start -->
                <div class="card">
                    <div class="card-header">
                        <h5>Evaluation Responses</h5>
                        <span>List Of Evaluations Responses.</span>
                        <!-- <div class="card-header-right">
                            <span class="badge badge-primary">{{pagination.total}}</span>
                        </div> -->
                    </div>

                    <div class="card-block" >
                        <div class="form-group row">
                            <div class="col-md-3">
                                <div class="input-group">
                                    <input type="text" v-model="filter.searchText" @keyup="searchByText" class="form-control" placeholder="Enter evaluation name">
                                    <span class="input-group-append">
                                        <label class="input-group-text">Search</label>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <date-picker placeholder="Select Start Date" v-model="filter.startdate" :value="filter.startdate"></date-picker>
                            </div>
                            <div class="col-md-4">
                                <date-picker placeholder="Select End Date" v-model="filter.endDate" :value="filter.endDate"></date-picker>
                            </div>
                            <div class="col-md-1">
                                <button class="btn btn-primary btn-round waves-effect waves-light btn-sm"  @click="filterEvaluations()" >
                                    <small-spinner :loading="evaluationsHttp"></small-spinner>
                                    Apply
                                </button>
                            </div>
                        </div>
                        <loading-spinner :loading="evaluationsHttp"></loading-spinner>
                        <div>
                            <div class="" v-show="activeDiv==='evaluations'">
                                <div class="card-block table-border-style" v-if="!evaluationsHttp">
                                    <div class="table-responsive">
                                        <table class="table table-hover table-sm">
                                            <thead class="table-primary text-white">
                                                <tr>
                                                    <th>#</th>
                                                    <th>Names</th>
                                                    <th>Start Date</th>
                                                    <th>End Date</th>
                                                    <th>View</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            <tr v-for="(evaluation,index) in evaluations" :key="index">
                                                <td>{{index+1}}</td>
                                                <td>For : {{evaluation.names}}</td>
                                                <td>{{DateFormatter.ReturnDate(evaluation.startDate)}}</td>
                                                <td>{{DateFormatter.ReturnDate(evaluation.endDate)}}</td>
                                                <td>
                                                    <!-- <router-link :to="'/evaluations/respondedUnits/'+evaluation.id" @click="filterEvaluations(evaluation)" -->
                                                    <router-link :to="'/evaluations/respondedUnits/'+evaluation.id"
                                                            class="btn btn-primary btn-sm">
                                                        <small-spinner :loading="false"></small-spinner>
                                                        View response
                                                        <!-- {{evaluation.totalUnits}} Subjects -->
                                                    </router-link>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </table>
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
    import END_POINTS from '../../../components/constants/EndPoints';
    import DateFormatter from '../../../components/constants/DateFomatter';
    export default {
        data() {
            return {
                evaluations: [],
                clickedIndex: null,
                loading: true,
                evaluationsHttp: false,
                title: 'Evaluations',
                subTitle: 'List of Evaluations Responses.',
                pageSize: 15,
                DateFormatter:DateFormatter,
                filter: {},
                activeDiv:'evaluations',
                pagination: {
                    total: 0,
                }
            }
        },

        methods: {
            searchByText(){
                this.filterEvaluations()
            },
            filterEvaluations() {
                this.loading = true;
                this.evaluationsHttp = true;
                this.$http.post("AdminEvaluationsResponse/GetCurrentActiveEvaluations",this.filter)
                .then(result => {
                    this.evaluationsHttp = false
                    if (result.data.success) {
                        this.evaluations = result.data.data;
                    } else {
                        this.$toastr("error", result.data.message)
                    }
                })
                .catch(error => {
                    this.evaluationsHttp = false
                    this.$toastr("error", error.message)
                })
            },

            buttonEvent(item, action) {
                switch (action) {
                    case 'delete':
                        alert('deleted')
                        break
                    case 'status':
                        var activity = 'disabled'
                        if (item.status)
                            activity = 'activated'
                        alert(activity)
                        break
                    default:
                        break
                }
            },
        },

        created() {

        }
    }
</script>

<style>
  
</style>
