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
                        <input v-model="grade.range" placeholder="Grade range" type="text" class="form-control"/><br>
                        <input v-model="grade.description" placeholder="Description" type="text" class="form-control"/>
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
export default {
    data(){
        return{
            title: "Performance Grades",
            subTitle: "",
            submitting: false,
            grade: {},
            isEdit: false
        }
    },
    methods:{
        save(){
            this.submitting = true
            this.$http.post("performance/addGrade", this.grade)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.$router.replace({ name: "performance-grades" });
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
            })
        },
    },
    created(){
        if(this.$route.params.id){
            this.grade = this.$route.params
        }
    }
}
</script>

<style>

</style>
