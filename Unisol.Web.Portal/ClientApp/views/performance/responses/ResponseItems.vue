<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{performance.performance.name}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block" v-if="!loading">
                <div class="row">
                    <div class="col-md-12">
                        	<div class="table-responsive">
                                <table class="table table-sm table-bordered">
                                    <tbody>
                                        <tr>
                                            <td><strong>NAME</strong>: {{performance.employeeDetails.names}}</td>
                                            <td><strong>TITLE:</strong> {{performance.employeeDetails.jobTitle}}</td>
                                        </tr>
                                        <tr>
                                            <td><strong>STAFF NO:</strong> {{performance.employeeDetails.empNo}}</td>
                                            <td><strong>DEPARTMENT:</strong> {{performance.employeeDetails.department}}</td>
                                        </tr>
                                        <tr>
                                            <td><strong>SUPERVISOR:</strong> {{performance.employeeDetails.supervisorName}}</td>
                                            <td><strong>APPRAISAL PERIOD:</strong> {{performance.performance.startDate}} - {{ performance.performance.endDate}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        <div v-if="!modifyActivity" class="table-responsive" v-for="(section, sIndex) in performance.template.performanceSections" :key="sIndex">
                            <h5>{{section.name}}</h5>
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>Activities</th>
                                    <th>Target</th>
                                    <th>Performance Indicator</th>
                                    <th>Weight (%)</th>
                                    <th>Achievements</th>
                                    <th>Self score (%)</th>
                                    <th>Final score (%)</th>
                                    <th v-if="(!isFinalScores || isSupervisor) && !scoresAccepted">Action</th>
                                </thead>
                                <tbody>
                                    <tr v-for="(activity, aIndex) in section.perfomanceActivities" :key="aIndex">
                                        <td>{{activity.activity}}</td>
                                        <td>{{activity.target}}</td>
                                        <td>{{activity.indicator}}</td>
                                        <td>{{activity.weight}}</td>
                                        <td>{{activity.achievement}}</td>
                                        <td>{{activity.selfScore}}</td>
                                        <td>{{activity.finalScore}}</td>
                                        <td v-if="(!isFinalScores || isSupervisor) && !scoresAccepted"><list-button :item="activity" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="col-md-12 form-group" v-if="modifyActivity">
                            <input :disabled='activityDisabled' v-model="activity.activity" placeholder="Activity" type="text" class="form-control"/><br>
                            <input :disabled='activityDisabled' v-model="activity.target" placeholder="Target" type="text" class="form-control"/><br>
                            <input :disabled='activityDisabled' v-model="activity.indicator" placeholder="Indicator" type="text" class="form-control"/><br>
                            <input :disabled='activityDisabled' v-model="activity.achievement" placeholder="Achievement" type="text" class="form-control"/><br>
                            <input :disabled='activityDisabled' v-model="activity.weight" placeholder="Weight" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>
                            <input :disabled='isSupervisor || isFinalScores || scoresAccepted' v-model="activity.selfScore" placeholder="Self Score" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>
                            <input :disabled='!isSupervisor || !activity.selfScore || scoresAccepted' v-model="activity.finalScore" placeholder="Final Score" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>

                            <div v-if="(!isFinalScores || isSupervisor) && !scoresAccepted" class="btn  btn-primary" @click="editActivity()">Done</div>
                        </div>

                        <hr>
                        <div class="row">
                            <div class="col-md-3 table-responsive"><br><br>
                                <table class="table table-sm table-bordered">
                                    <tbody>
                                        <tr>
                                            <td>Total Self Score (%)</td>
                                            <td>{{performance.scores.totals.selfScoreTotal}}</td>
                                        </tr>
                                        <tr>
                                            <td>Total Final Score (%)</td>
                                            <td>{{performance.scores.totals.finalScoreTotal}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="col-md-9 table-responsive">
                                <h5>Key:</h5>
                                <table class="table table-sm table-bordered">
                                    <tbody>
                                        <tr v-for="(grade, index) in grades" :key="index">
                                            <td>{{grade.range}}</td>
                                            <td>{{grade.description}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div> <hr>

                        <div>
                            <h5>QUESTIONNAIRE</h5>
                            <div v-for="(question, qIndex) in performance.template.performanceQuestionnaire" :key="qIndex"><br>
                                <label>{{question.question}}</label>
                                <input :disabled='isFinalScores || scoresAccepted' v-model="question.response" type="text" class="form-control"/>
                            </div>
                        </div><br> <hr>

                        <div class="table-responsive">
                            <h5>TRAINING EVALUATION REPORT (Evaluation done by the supervisor)</h5>
                            <table class="table table-sm table-bordered" v-if="performance.performanceResponse.performanceTraining.length && !isNewTrainig">
                                <thead>
                                    <th>Training attended</th>
                                    <th>Training Objectives</th>
                                    <th>Results</th>
                                    <th>Recommendations</th>
                                    <th v-if="!isFinalScores && !scoresAccepted">Remove</th>
                                </thead>
                                <tbody>
                                    <tr v-for="(training, tIndex) in performance.performanceResponse.performanceTraining" :key="tIndex">
                                        <td>{{training.training}}</td>
                                        <td>{{training.objectives}}</td>
                                        <td>{{training.results}}</td>
                                        <td>{{training.recommendations}}</td>
                                        <td v-if="!isFinalScores && !scoresAccepted"><div class="btn btn-primary " @click="removeTraininng(tIndex)">Remove</div></td>
                                    </tr>
                                </tbody>
                            </table>

                            <div v-if="isNewTrainig">
                                <input v-model="training.training" placeholder="Training attended" type="text" class="form-control"/><br>
                                <input v-model="training.objectives" placeholder="Training Objectives" type="text" class="form-control"/><br>
                                <input v-model="training.results" placeholder="Results" type="text" class="form-control"/><br>
                                <input v-model="training.recommendations" placeholder="Recommendations" type="text" class="form-control"/><br>

                                <div class="btn  btn-primary" @click="pushTraining()">Done</div>
                                <div class="btn  btn-primary" @click="closeTraining()">Close</div>
                            </div>

                            <div class="btn  btn-primary" @click="newTraining()" v-if="!isNewTrainig && !isFinalScores && !scoresAccepted">Add Training</div>
                        </div><hr>

                        <h5 class="text-center">Minimum weight to be observed by different levels of staff</h5>
                        <div class="row" v-if="gradeLevel.sections.length">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table class="table table-sm table-bordered">
                                        <thead>
                                            <th></th>
                                            <th v-for="(section, index) in gradeLevel.sections" :key="index">{{section.name}}</th>
                                        </thead>

                                        <tbody>
                                            <tr v-for="(level, index) in gradeLevel.levelGradings" :key="index">
                                                <td>{{level.grade}}</td>
                                                <td v-for="(section, index) in gradeLevel.sections" :key="index">{{level[`000${index + 1}`]}}</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right" v-if="!scoresAccepted && !loading">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" :title="buttonText" v-on:submit="save"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
    data(){
        return{
            title: "",
            subTitle: "",
            modifyActivity: false,
            activityDisabled: true,
            loading: false,
            buttonText: "Save",
            dateFomatter: DateFomatter,
            isSupervisor: false,
            isFinalScores: false,
            scoresAccepted: false,
            performance: {
                totals: {},
                performance:{}, 
                employeeDetails: {},
                template: {
                    performanceSections: []
                },
                performanceResponse: {
                    performanceTraining: []
                }
            },
            gradeLevel: {
                levelGradings: [],
                sections: [],
            },
            activity: {},
            submitting: false,
            user: this.$baseRead("user"),
            tableActions: [
                {
                    name: "Respond",
                    type: "button",
                    icon: "trash",
                    path: "respond",
                    design: "danger"
                }
            ],
            training: {},
            isNewTrainig: false,
            reporter: {},
            grades: {},
            supervisorApproval: false
        }
    },
    methods: {
        removeTraininng(index){
			this.performance.performanceResponse.performanceTraining.splice(index, 1);
        },
        getPerformance(){
            this.loading = true;
            var username = this.reporter.empNo ? this.reporter.empNo : this.user.username
            this.$http.get(`performance/getPerformance?usercode=${username}`)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    if(!result.data.data.target){
                        this.$toastr('error', "Kindly fill in performance targets");
                        this.$router.replace({ name: "performance-targets" })
                        return
                    }
                    result.data.data.performance.startDate = this.dateFomatter.ReturnDate(result.data.data.performance.startDate)
                    result.data.data.performance.endDate = this.dateFomatter.ReturnDate(result.data.data.performance.endDate)
                    result.data.data.target = result.data.data.target ? result.data.data.target : {}
                    result.data.data.target.status = result.data.data.target.status ? result.data.data.target.status : "Pending"
                    this.supervisorApproval = result.data.data.target.status != "Pending"
                    this.isFinalScores = result.data.data.target.status === "FinalEntry"
                    this.scoresAccepted = result.data.data.target.status === "Accepted"
                    this.isSupervisor = result.data.data.target.supervisor === this.user.username
                    this.buttonText = this.isFinalScores && !this.isSupervisor ? "Accept" : "Save"

                    if(!this.supervisorApproval){
                        this.$toastr('error', "Your supervisor has not yet approved your targets");
                        this.$router.replace({ name: "performance-targets" })
                        return
                    }
                    if(!result.data.data.target.performanceTargetDetail){
                        result.data.data.target.performanceTargetDetail = []
                    }
                    if(!result.data.data.performanceResponse){
                        result.data.data.performanceResponse =  {}
                    }
                    if(!result.data.data.performanceResponse.performanceTraining){
                        result.data.data.performanceResponse.performanceTraining = []
                    }
                    if(!result.data.data.performanceResponse.performanceQuestionnaireResponse){
                        result.data.data.performanceResponse.performanceQuestionnaireResponse = []
                    }
                    if(!result.data.data.performanceResponse.performanceActivityResponse){
                        result.data.data.performanceResponse.performanceActivityResponse = []
                    }

                    result.data.data.template.performanceSections.forEach(element => {
                        element.perfomanceActivities = result.data.data.target.performanceTargetDetail.filter(d => {
                            return element.id == d.performanceSectionId
                        })
                    });

                    result.data.data.template.performanceQuestionnaire.forEach(q => {
                        if(result.data.data.performanceResponse.performanceQuestionnaireResponse.length){
                            result.data.data.performanceResponse.performanceQuestionnaireResponse.forEach(r => {
                                if(q.id == r.performanceQuestionnaireId){
                                    q.response = r.response
                                }
                            });
                        }
                    });

                    result.data.data.template.performanceSections.forEach(s => {
                        s.perfomanceActivities.forEach(a => {
                            result.data.data.performanceResponse.performanceActivityResponse.forEach(r => {
                                if(a.id == r.perfomanceActivityId){
                                    a.selfScore = r.selfScore ? r.selfScore : a.selfScore
                                    a.finalScore = r.finalScore ? r.finalScore : a.finalScore
                                }
                            });
                        });
                    });

                    if(result.data.data.scores.totals.finalScoreTotal === "NaN"){
                        result.data.data.scores.totals.finalScoreTotal = ""
                    }
                    if(result.data.data.scores.totals.selfScoreTotal === "NaN"){
                        result.data.data.scores.totals.selfScoreTotal = ""
                    }

                    this.performance = result.data.data
                } 
                else{
                    this.$toastr("error", result.data.message)
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        newTraining(){
            this.isNewTrainig = true
        },
        closeTraining(){
            this.isNewTrainig = false
        },
        editActivity(){
            this.modifyActivity = false
        },
        buttonEvent(item, action) {
            switch (action) {
                case "respond":
                    this.activity = item
                    this.modifyActivity = true
                break;
                default:
                break;
            }
        },
        save(){
            this.submitting = true
            this.performance.IsSupervisor = this.isSupervisor
            this.performance.TargetId =  this.performance.target.id
            this.performance.PerformanceTraining = this.performance.performanceResponse.performanceTraining
            this.$http.post("performance/response", this.performance)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.getPerformance()
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
                this.submitting = false
            })
        },
        pushTraining(){
            if(!this.training.training){
                this.$toastr('error', "Kindly provide the training")
				return;
            }
            if(!this.training.objectives){
                this.$toastr('error', "Kindly provide the objectives")
				return;
            }
            var nameExists = false
            this.performance.performanceResponse.performanceTraining.forEach(element => {
                if(element.training === this.training.training){
					nameExists = true
					this.$toastr('error', "Sorry, the training already exist")
					return;
				}
            });

            if(!nameExists){
                this.isNewTrainig = false
                this.performance.performanceResponse.performanceTraining.push(this.training)
            }
            this.training = {}
        },
        getGrades(){
            this.loading = true;
            this.$http.get("performance/getGrades")
            .then(result => {
                if (result.data.success) {
                    this.grades = result.data.data;
                } else {
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
        getGradeLevel(){
            this.loading = true;
            this.$http.get(`performance/getGradeLevel`)
            .then(result => {
                this.gradeLevel = result.data.data
            })
            .catch(error => {
                this.loading = false;
            });
        }
    },
    created(){
        this.reporter = this.$route.params
        this.getGradeLevel() 
        this.getGrades()
        this.getPerformance()
    }
}
</script>

<style>

</style>
