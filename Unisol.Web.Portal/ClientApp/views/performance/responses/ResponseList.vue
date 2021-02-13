<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <!-- <h5>{{performance.performance.name}}</h5>
                <span v-if="subTitle">{{subTitle}}</span> -->
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-4">
                        <label>Department</label>
                        <v-select v-model="performance.department" :options=filterData.departments ></v-select>
                    </div>
                    <div class="col-md-4">
                        <label>Category</label>
                        <v-select v-model="performance.jobCat" :options=filterData.categories ></v-select>
                    </div>
                    <div class="col-md-4">
                        <label>Title</label>
                        <v-select v-model="performance.jobTitle" :options=filterData.titles ></v-select>
                    </div>
                </div><br>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-sm table-bordered" v-if="response">
                                <thead>
                                    <th>Section</th>
                                    <th>SelfScore</th>
                                    <th>FinalScore</th>
                                </thead>

                                <tbody>
                                    <tr v-for="(section, index) in response.scores.sectionResponses" :key="index">
                                        <td>{{section.sectionName}}</td>
                                        <td>{{section.sectionSelfScore}}</td>
                                        <td>{{section.sectionFinalScore}}</td>
                                    </tr>
                                    <tr>
                                        <td>Totals</td>
                                        <td>{{response.scores.totals.selfScoreTotal}}</td>
                                        <td>{{response.scores.totals.finalScoreTotal}}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" :title="buttonText" v-on:submit="getResponse"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            submitting: false,
            buttonText: "Generate",
            performance: {},
            filterData: {},
            response: null
        }
    },
    methods: {
        getResponse(){
            this.loading = true;
            this.$http.post(`performance/getResponse`, this.performance)
            .then(response => {
                this.loading = false;
                if (response.data.success) {
                    this.response = response.data.data
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        getFilterData(){
            this.loading = true;
            this.$http.get(`performance/getFilterData`)
            .then(response => {
                this.loading = false;
                if (response.data.success) {
                    this.filterData = response.data.data
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(error => {
                this.loading = false;
            });
        }
    },
    created(){
        this.getFilterData()
    }
}
</script>

<style>

</style>
