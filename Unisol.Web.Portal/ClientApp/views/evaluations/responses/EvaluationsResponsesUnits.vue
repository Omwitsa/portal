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
                            <div class="col-md-4">
                                <label>From Date</label>
                                <date-picker v-model="filter.startdate" :value="filter.startdate"></date-picker>
                            </div>
                            <div class="col-md-4">
                                <label>To Date</label>
                                <date-picker v-model="filter.endDate" :value="filter.endDate"></date-picker>
                            </div>
                            <div class="col-md-2">
                                <label>&nbsp;</label>
                                <button class="btn btn-primary btn-sm form-control"  @click="filterEvaluations()" >
                                    <small-spinner :loading="evaluationsHttp"></small-spinner>
                                    Apply
                                </button>
                            </div>
                        </div>
                        <loading-spinner :loading="evaluationsHttp"></loading-spinner>
                        <div>
                            <div class="" v-show="activeDiv==='evaluations'">
                                <div class="card-block" v-if="!evaluationsHttp">
                                    <table class="table  table-sm">
                                        <thead>
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
                                                <router-link to="'/evaluations/responsedUnits'+evaluation.Id" @click="filterEvaluations(evaluation)"
                                                        class="btn btn-primary btn-sm">
                                                    <small-spinner :loading="false"></small-spinner>
                                                    {{evaluation.totalUnits}} Subjects
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
            filterEvaluations(evaluation) {


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
    .disabled{
        /*cursor: none;*/
    }
</style>
