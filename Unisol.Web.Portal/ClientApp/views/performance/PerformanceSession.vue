<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <label>Name</label>
                        <input v-model="performance.name" placeholder="Name" type="text" class="form-control"/>
                        <label>Template Name</label>
                        <v-select v-model="performance.templateName" :options=templates ></v-select>
                        <label>Start Date</label>
                        <date-picker v-model="performance.startDate" :config="options"></date-picker>
                        <label>End Date</label>
                        <date-picker v-model="performance.endDate" :config="options"></date-picker>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data(){
        return{
            loading: true,
            title: "Performance",
            subTitle: "",
            templates: [],
            dateFomatter: DateFomatter,
            performance: {},
            submitting: false,
            options: {
                format: 'DD/MM/YYYY',
                useCurrent: false,
            }, 
        }
    },
    methods: {
        toDate(date) {
            date = `${date}`
            var from = date.split("/")
            if(from.length < 2){
                from = new Date(from)
                from.setDate(from.getDate()-1)
                return from
            }
            
            return new Date(from[2], from[1] - 1, from[0])
        },
        getTemplates(){
            this.loading = true;
            this.$http.get("performance/getPerformanceTemplate")
            .then(result => {
                if (result.data.success) {
                    this.loading = false;
                    result.data.data.forEach(element => {
                        this.templates.push(element.name)
                    });
                } 
                else {
                    this.$toastr("error", result.data.message);
                    if (result.data.notAuthenticated) {
                    this.$router.replace({ name: "401-forbidden" });
                }
            }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        save(){
            this.performance.templatename = this.performance.templateName
            this.performance.startDate = this.toDate(this.performance.startDate)
            this.performance.endDate = this.toDate(this.performance.endDate)
            this.performance.startdate = this.performance.startDate
            this.performance.enddate = this.performance.endDate
            this.submitting = true
            this.$http.post("performance/addPerformance", this.performance)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.$router.replace({ name: "performance-list" });
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.submitting = false
                this.$toastr("error", e.message)
            })
        },
    },
    created(){
        if(this.$route.params.id){
            this.performance = this.$route.params
            this.performance.startDate = new Date(this.performance.startDate)
            this.performance.endDate = new Date(this.performance.endDate)
        }
        this.getTemplates()
    }
}
</script>

<style>

</style>
