<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="col-md-12" v-for="(section, index) in survey.questionSections" :key="index">
                    <div >
                        <h5>{{section.name}}</h5>
                        <ol>
                            <li v-for="(question, index1) in section.questions" :key="index1"> 
                                <label>{{question.question}}</label><br> 
                                <input v-model="question.response" v-if="!question.options.length && (question.type != '5')" type="text" :name="question.id" class="form-control">
                                
                                <ul v-if="question.options.length" class="col-md-12 list-unstyled form-check-inline table-responsive">
                                    <li v-for="(option, optIndex) in question.options" :key="optIndex">
                                        <label class="customcheck">
                                            <input v-model="option.checked" :value="option" :type="getType(question.type)" :name="question.id" class="">
                                            <!-- <input :type="getType(question.type)" :value="option.checked" :name="question.id" v-model="option.checked" class="" :id="'checkbox_'+optIndex"> -->
                                            {{option.option}}
                                            <span class="checkmark"></span>
                                        </label>
                                    </li>
                                </ul>
                            </li>
                        </ol>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="submitResponse"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
            subTitle: "",
            title: "Clearence Survey",
            survey: [],
            response: {},
            questionOptions: [],
            submitting: false,
            user: this.$baseRead('user'),
            settings : JSON.parse(localStorage.getItem("settings"))
        };
    },
    methods: {
        splitOptions(options){
            options = options ? options : ""
            this.questionOptions = options.split(",")
            return this.questionOptions
        },
        getClass(type){
            return type == '3' ? "form-control" : ""
        },
        getType(type){
            if(type == '1' || type == '2'){
                return "radio"
            }
            else if(type == '4'){
                return "checkbox"
            }
           else{
               return "text"
           }
        },
        submitResponse(){
            this.response.admnno = this.user.username
            this.response.surveyName = this.subTitle
            this.response.clearanceSurveyResponseRefs = []
            var answeredAll = true
            var message = ""
            this.survey.questionSections.forEach(section => {
                section.questions.forEach(question => {
                    if(!question.options.length && question.type != '5'){
                       if(!question.response){
                           message = `Kindly, answer this question (${question.question})`
                           answeredAll = false
                       }
                    }
                    else if(question.options.length){
                        var selectedOptions = []
                        var surveyRef = {}
                        question.options.forEach(option => {
                            debugger
                            if(option.checked){
                                selectedOptions.push(option.option)
                                debugger
                                // option = {}
                            }
                        });

                        if(!selectedOptions.length){
                            message = `Kindly, answer this question (${question.question})`
                            answeredAll = false
                        }

                        question.response = selectedOptions.join();
                        if(question.type != '5'){
                            this.response.clearanceSurveyResponseRefs.push({
                                sectionName: section.name,
                                question: question.question,
                                response: question.response
                            })
                        }
                    }
                    // var val = question.options
                    // debugger
                });
            });

            if(!answeredAll){
                this.$toastr('error', message)
                return
            }
            this.$http.post("clearances/responseToSurvey", this.response)
			.then(response => {
				if (response.data.success) {
                    this.$router.replace({ name: "apply-clearance" });
					this.$toastr('success', response.data.message);
				} else {
					this.$toastr('error', response.data.message);
				}
			})
			.catch(e => {
				this.$toastr('Error', "Server error occured,please try again");
			})
        },
        getSurveyResponse(){
            if(this.settings.initials === 'KIBU'){
            this.$http.get("clearances/getSurveyResponse?usercode="+this.user.username)
            .then(result => {
                if(result.data.success){
                    this.$router.replace({ name: "apply-clearance" });
                }
                else{
                    this.getSurveys()
                }
            })
            .catch(error => {
                this.$toastr("error", error.message);
            });
            }
        },
        getSurveys(){
			this.$http.get("clearances/getSurveys")
			.then(result => {
                if (result.data.success) {
                    this.subTitle = result.data.data.name
                    result.data.data.surveyTemplate.questionSections.forEach(section => {
                        section.questions.forEach(question => {
                            var options = question.options ? question.options.split(",") : []
                            question.options = []
                            options.forEach(option => {
                                question.options.push({
                                    option: option,
                                    checked: false
                                })
                            });

                            // question.options = question.options ? question.options.split(",") : []
                            // question.options.forEach(option => {
                            //     if(question.options.length){
                            //         option.checked = false
                            //     }
                            // });
                        });
                    });

                    this.survey = result.data.data.surveyTemplate
                }
			})
			.catch(error => {
			    this.$toastr("error", error.message);
			});
        },
    },
    created() {
        if(this.settings.initials === "KIBU" && this.user.role === 3){
            this.getSurveyResponse();
        }
        else{
            this.$router.replace({ name: "apply-clearance" });
        }
    },
}
</script>

<style>

</style>
