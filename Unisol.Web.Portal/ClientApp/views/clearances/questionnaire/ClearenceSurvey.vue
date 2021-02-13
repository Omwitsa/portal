<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">

            </div>

            <div class="card-block">
                <input v-model="survey.name" placeholder="Survey Name" type="text" class="form-control"/><br>
                <v-select
                    :options="templateNames"
                    v-model="survey.templeteName"
                    placeholder="Select Template"
                    ></v-select>
                <div class="form-group row">
                    <div class="col-md-6">
                        <label>Start Date</label>
                        <date-picker v-model="survey.startTime"></date-picker>
                    </div>
                    <div class="col-md-6">
                        <label>End Date</label>
                        <date-picker v-model="survey.endTime" :value="survey.endTime" :disabled="!survey.startTime"></date-picker>
                    </div>
                </div>

                <!-- <div class="form-group row">
                    <div class="col-md-6">
                        <v-select
                        :options="surveyStatus"
                        v-model="survey.status"
                        placeholder="Select Status"
                        ></v-select>
                    </div>
                </div> -->

                <table class="table" v-if="surveys">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Name</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(survey, index) in surveys" :key="index">
                            <td>{{index+1}}</td>
                            <td>{{survey.name}}</td>
                            <td>{{survey.startTime}}</td>
                            <td>{{survey.endTime}}</td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="saveSurvey"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    watch: {
        "survey.endTime"(ends){
            if((new Date(this.survey.startTime) > new Date(ends))){
                // this.$toastr('error', "End date must be grater than start date")
                return
            }
        }
    },
    data() {
        return {
            subTitle: "Create Questionnaires",
            title: "Questionnaires",
            templateNames: [],
            submitting: false,
            survey: {},
            surveyStatus: [],
            surveys: [],
        }
    },
    methods: {
        getSurveyTemplates(){
			this.$http.get("clearances/getSurveyTemplates")
			.then(result => {
                this.surveys = result.data.data.surveys
                this.surveyStatus = result.data.data.surveyStatus
                result.data.data.surveyTemplates.forEach(element => {
                    this.templateNames.push(element.name);
                });
			})
			.catch(error => {
			    this.$toastr("error", error.message);
			});
        },
        saveSurvey(){
            this.submitting = true
            this.survey.status = "Clearance before graduation"
            this.$http.post("clearances/createSurvey", this.survey)
			.then(response => {
                this.submitting = false
				if (response.data.success) {
                    this.survey = {}
					this.$toastr('success', response.data.message);
				} else {
					this.$toastr('error', response.data.message);
				}
			})
			.catch(e => {
                this.submitting = false
				this.$toastr('error', "Server error occured,please try again");
			})
        },
    },
    created() {
		this.getSurveyTemplates();
	}
}
</script>

<style>

</style>
