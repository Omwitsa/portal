<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}} <small-spinner :loading="loading"></small-spinner></h5>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                            <div class="form-group">
                                <label for="">Evaluation Name</label>
                                <input class="form-control border-input" v-model="currentEvaluation.currentEvaluationName"
                                       placeholder="Evaluation Name" />
                            </div>
                            <div class="form-group">
                                <label for="">Select Target Level </label><br>
                                <a @click="setLevel(level)" v-for="(level, Index) in departmentLevels" :key="Index"
                                   class="btn  waves-effect waves-light btn-info btn-outline-primary ml-1">
                                    <i :class="clickedLevel.value == level.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                                    {{level.name}}
                                </a>
                            </div>

                            <div class="form-group">
                                <label>
                                    Select Evaluation
                                </label>
                                
                                <select placeholder="Name"  class="form-control border-input" v-model="currentEvaluation.evaluationId">
                                    <option v-for="(evaluation ,index) in evaluations" :value="evaluation.id" :key="index">{{evaluation.evaluationName}}</option>
                                </select>
                            </div>

                            <div class="form-group" v-show="clickedLevel.value>=1">
                                <label>
                                    Select Academic Year
                                </label>
                                <select placeholder="Name" class="form-control border-input" v-model="currentEvaluation.yearOfStudy">
                                    <option v-for="(year ,index) in studyYears" :value="year.stage" :key="index">{{year.stage}}</option>
                                </select>
                            </div>
                            <div class="form-group" v-show="clickedLevel.value>=1">
                                <label>
                                    Select Academic Semester
                                </label>
                                <select placeholder="Name" class="form-control border-input" v-model="currentEvaluation.semester">
                                    <option v-for="(sem ,index) in evaluationSemester" :value="sem.term" :key="index">{{sem.term}}</option>
                                </select>
                            </div>

                            <div class="form-group" v-show="clickedLevel.value>1&&!showAdded">
                                <label>
                                    Search For {{clickedLevel.name}}<br />
                                </label>

                                <div class="col-md-12 row" style="margin-bottom:5px;">
                                    <div class="col-md-8 row">
                                        <input @keyup="SearchEvaluationTarget()" 
                                               placeholder="please search  here"
                                               v-model="searchString" 
                                               class="form-control border-input">
                                    </div>
                                    <div class="col-md-3">
                                        <small-spinner :loading="loading" class="text-center"> </small-spinner>
                                        <div v-if="addedLevel.length>0"
                                             @click="showAddedLevels(true)" class=" btn   btn-info btn-outline-primary ml-1">
                                            {{addedLevel.length }} {{clickedLevel.name}}'s Added,Finish

                                        </div>
                                    </div>
                                </div>

                                <table class="table table-hover table-sm">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>{{clickedLevel.name}} name</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(target,index) in searchLevels" :key="index">
                                            <td>{{index+1}}</td>
                                            <td>{{target.names}}</td>
                                            <td>
                                                <div class="btn btn-primary " v-if="!checkIfAdded(target)"
                                                     @click="addSearchLevel(target)">
                                                    add {{clickedLevel.name}}
                                                </div>
                                                <div class="btn btn-danger " v-if="checkIfAdded(target)"
                                                     @click="removeSearchLevel(target)">
                                                    remove {{clickedLevel.name}}
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                            <div v-if="showAdded" class="col-md-12">
                                <div class="com-xs-12">
                                    <div @click="showAddedLevels(false)" class="btn  waves-effect  waves-light btn-info btn-outline-primary ml-2">
                                        {{addedLevel.length }} {{clickedLevel.name}}'s Added
                                    </div>
                                    <div class="btn  waves-effect   btn-primary" @click="showAddedLevels(false)">
                                        Continue adding
                                    </div>
                                    <br />
                                </div>
                                <table class="table table-hover table-sm">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>{{clickedLevel.name}} name</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(target,index) in addedLevel" :key="index">
                                            <td>{{index+1}}</td>
                                            <td>{{target.names}}</td>
                                            <td>

                                                <div class="btn btn-danger "
                                                     @click="removeSearchLevel(target)">
                                                    remove {{clickedLevel.name}}
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label>Start Date</label> 
                                    <date-picker v-model="currentEvaluation.startDate" :value="currentEvaluation.startDate"></date-picker>
                                </div>
                                <div class="col-md-6">
                                    <label>End Date</label>
                                    <date-picker v-model="currentEvaluation.endDate" :value="currentEvaluation.endDate"></date-picker>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="checkbox-color checkbox-primary">
                                    <input type="checkbox" id="checkbox18" checked v-model="currentEvaluation.status">
                                    <label for="checkbox18"><b>Activate Evaluation</b></label><br>
                                    <input type="checkbox" id="mandatory" checked v-model="currentEvaluation.isMandatory">
                                    <label for="mandatory"><b>Make Evaluation Mandatory</b></label><br>
                                    <input type="checkbox" id="elearning" checked v-model="currentEvaluation.isElearnigEvaluation">
                                    <label for="elearning"><b>E-Learning evaluation</b></label>
                                </div>
                            </div>

                        </fieldset>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="pull-right">
                        <submit-button :class="[ { 'disabled' : submitting }]"
                        :loading="submitting" 
                        :title="buttonText" 
                        v-on:submit="save" 
                        styling="btn btn-primary btn-round waves-effect waves-light "/>

                        <submit-button
                        title="Cancel" 
                        v-on:submit="cancel" 
                        styling="btn btn-inverse btn-round waves-effect waves-light "/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import END_POINTS from '../../../components/constants/EndPoints';
    export default {
        data() {
            return {
                usergroup: {},
                edit: false,
                submitting: false,
                showAdded: false,
                subTitle: "",
                assignText: "Select User Group",
                searchString: "",
                currentEvaluation: {
                    startDate: new Date(),
                    endDate: new Date()
                },
                studyYears: [],
                departmentLevels: END_POINTS.DEPARTMENTLEVELS,
                clickedLevel: {},
                addedLevel: [],
                academicYears:[],
                evaluationSemester: [],
                semesters:[],
                evaluations:[],
                submitting: false,
                loading: false,
                searchLevels: {},
                state: {
                    date: new Date()
                },
            }
        },
        created() {
            if (this.$route.params.id) {
                this.edit = true
                this.fetch(this.$route.params.id)
            }
            this.getAcademicYears();
            this.getEvaluations();
            this.getYeayOfStudy()
            this.getStudentSemister()
        },
        methods: {
            fetch(id){
                this.loading = true
                this.$http.get("currentevaluations/GetCurrentEvaluationInfo/?id="+id)
                .then(result => {
                    if(result.data.success){
                        this.currentEvaluation = result.data.data
                        this.currentEvaluation.evaluationsCurrentActive.forEach(e => {
                            this.currentEvaluation.isMandatory = e.isMandatory
                            this.currentEvaluation.isElearnigEvaluation = e.isElearnigEvaluation
                        })
                        var targetGroup = []
                        this.currentEvaluation.evaluationsCurrentActive.forEach(element => {
                            targetGroup = element.evaluationTargetGroups
                        });

                        var targetGroupTypes = []
                        targetGroup.forEach(element => {
                            targetGroupTypes.push(element.targetType)
                        });

                        this.departmentLevels.forEach(element => {
                            if(targetGroupTypes.includes(element.value)) this.clickedLevel.value = element.value
                        });
                    }
                })
                .catch(error => {
                    this.$toastr("error", error.message)
                })
                this.loading = false
            },
            cancel(){

            },
            getYeayOfStudy(){
                this.loading = true
                this.$http.get("currentevaluations/GetStudentYearsOfStudy")
                .then(result => {
                    this.studyYears = result.data.data
                })
                .catch(error => {
                    this.$toastr("error", error.message)
                })
                this.loading = false
            },
            getStudentSemister(){
                this.loading = true
                this.$http.get("currentevaluations/GetStudentAcademicSemstersOfStudy")
                .then(result => {
                    this.evaluationSemester = result.data.data
                })
                .catch(error => {
                    this.$toastr("error", error.message)
                })
                this.loading = false
            },
            setLevel(level) {
                this.clickedLevel = level
                this.searchString = "";
                this.searchLevels = {};
                this.addedLevel = [];
            },
            showAddedLevels: function (status) {
                this.showAdded = status;
            },
            getEvaluations : function() {
                this.loading = true
                var offset = 0

                this.evaluations = [];
                this.$http
                    .get(
                    "evaluations/getevaluations/?itemsPerPage=" +1000 + "&offset=0"
                    )
                    .then(result => {
                        this.evaluations = result.data.data.data;
                    })
                    .catch(error => {
                        this.$toastr("error", error.message)
                    })
                this.loading = false
            },
           
            SearchEvaluationTarget: function () {
                this.loading = true;
                if (!this.searchString)
                    return;
                var searchModel = {
                    searchString: this.searchString,
                    targetType: this.clickedLevel.value
                };
                this.searchLevels = {}
                this.$http.post(END_POINTS.GETSEARCHLEVELS, searchModel)
                .then(result => {
                    this.loading = false;
                    if (result.data.success)
                        this.searchLevels = result.data.data
                    else
                        this.$toastr("error", result.data.message)
                })
                .catch(error => {
                    this.loading = false;
                    this.$toastr("error", "We could not find what you searching for")
                })
            },
            addSearchLevel: function (level) {
                level.level = this.clickedLevel.value;
                this.addedLevel.push(level)
            },
            checkIfAdded: function (target) {
                var exist = false;
                this.addedLevel.forEach(aL => {
                    if (aL.names == target.names) {
                        exist = true;
                        return true;
                    }
                })
                return exist;

            },
            removeSearchLevel: function (target) {
                var index = 0;
                this.addedLevel.forEach(aL => {
                    index++;
                    if (aL.names == target.names) {
                        index--;
                    }
                })
                this.addedLevel.splice(index,1)
            },

            save() {
                var error = false; var message = '';
                this.currentEvaluation.level = this.clickedLevel.value;
                
                if(this.currentEvaluation.currentEvaluationName == '' || !this.currentEvaluation.currentEvaluationName) {
                    message = 'Please fill current evaluation name';
                    error = true;
                }

                else if (this.clickedLevel.value == undefined) {
                    error = true;
                    message = 'Please  select the target level';
                }

                if (error) {
                    this.$toastr("error", message)
                    return;
                }
               
                var currentEval = this.currentEvaluation;
                currentEval.levels = this.addedLevel;
                var url = END_POINTS.SAVECURRENTEVALUATIONS
                if(this.edit) url = "currentevaluations/editcurrentevaluation/?id="+this.$route.params.id
                this.$http
                    .post(url, currentEval)
                    .then(response => {
                        if (response.data.success) {
                            this.$toastr("success", "Success")
                            this.submitting = true
                            this.$router.replace({ name: "current-evaluations" })
                        } else {
                            this.$toastr("error", response.data.message)
                        }
                    })
                    .catch(e => { })
            },

            contains(arrayData, id) {
                var i = arrayData.length
                while (i--) {
                    if (parseInt(arrayData[i]) === id) {
                        return true
                    }
                }
                return false
            },
            getAcademicYears: function () {
                this.loading = true;

                this.academicYears = []
                this.$http
                    .get(END_POINTS.GETACADEMICYEARS)
                    .then(result => {
                        this.loading = false;
                        if (result.data.success)
                            this.academicYears = result.data.data
                        else
                            this.$toastr("error", result.data.message)
                    })
                    .catch(error => {
                        this.loading = false;
                        this.$toastr("error", "We could not find what you searching for")
                    })
            },
            getAcademicSemesters: function () {
                this.loading = true;

                this.semesters = []
                this.$http
                    .get(END_POINTS.GETSEMESTERS + "?yearId=" + this.currentEvaluation.yearId)
                    .then(result => {
                        this.loading = false;
                        if (result.data.success)
                            this.semesters = result.data.data
                        else
                            this.$toastr("error", result.data.message)
                    })
                    .catch(error => {
                        this.loading = false;
                        this.$toastr("error", "We could not find what you searching for")
                    })
            }
        },
        computed: {
            title() {
                if (this.edit) {
                    return "Edit Current Evaluation" 
                }
                if (!this.edit) {
                    return "Add Current Evaluation"
                }
            },
            buttonText() {
                if (this.edit) {
                    return "Save Changes"
                }
                return "Save"
            }
        }
    }
</script>





