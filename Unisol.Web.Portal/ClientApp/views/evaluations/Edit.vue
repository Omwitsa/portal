<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}} <small-spinner :loading="loading"> </small-spinner></h5>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <div id="wizardc">
                            <section>
                                <form class="wizard-form wizard clearfix" id="design-wizard" action="#" role="application">
                                    <div class="steps clearfix">
                                        <ul role="tablist">
                                            <li role="tab" :class="step == 1 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
                                                <a>
                                                    <span v-if="step==1" class="current-info audible">current step: </span>
                                                    <span class="number" style="font-size:10px;">1.Evaluation.</span>
                                                </a>
                                            </li>

                                            <li role="tab" :class="step == 2 ? 'current last' : 'done last'" aria-disabled="true">
                                                <a>
                                                    <span v-if="step==2" class="current-info audible">current step: </span>
                                                    <span class="number" style="font-size:10px;">2.Sections</span>
                                                </a>
                                            </li>
                                            <li role="tab" :class="step == 3 ? 'current last' : 'done last'" aria-disabled="true">
                                                <a>
                                                    <span v-if="step==3" class="current-info audible">current step: </span>
                                                    <span class="number" style="font-size:10px;">3.Questions</span>
                                                </a>
                                            </li>
                                            <li role="tab" :class="step == 4 ? 'current last' : 'done last'" aria-disabled="true">
                                                <a>
                                                    <span v-if="step==2" class="current-info audible">current step: </span>
                                                    <span class="number" style="font-size:10px;">4.Preview</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    
                                    <div class=" clearfix">
                                        <div v-show="step==1">
                                            <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                <fg-input type="text"  v-bind:class="[ { 'form-control-danger' : error.evaluationStatus }]"
                                                label="Evaluation Name"
                                                placeholder="Evaluation Name"
                                                v-model="evaluation.evaluationName" />
                                                <span v-if="error.evaluationStatus" v-bind:class="[ { 'form-control-danger' : error.evaluationStatus }]">
                                                    {{error.evaluationMessage}}
                                                </span>
                                                <fg-input type="text"
                                                label="Description"
                                                placeholder="Name"
                                                v-model="evaluation.evaluationDesc" />
                                            </fieldset>
                                        </div>
                                        <div v-show="step==2">
                                            <h5>{{evaluation.evaluationName}}</h5>
                                            <span class="" style="font-size:14px;color:darkgray;">{{evaluation.evaluationDesc}}</span>
                                            <div class="panel content">
                                                <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                    <fg-input type="text" v-bind:class="['col-md-6', { 'form-control-danger' : error.sectionStatus }]"
                                                    label="Section Name"
                                                    placeholder="Section Name"
                                                    v-model="sections.sectionName" />

                                                    <fg-input type="text"
                                                    label="Description" v-bind:class="['col-md-6']"
                                                    placeholder="Evaluation Desc"
                                                    v-model="sections.sectionDesc" />

                                                    <div v-bind:class="['col-md-6']">
                                                        <div class="btn  btn-primary" @click="pushSection(sections)">Add Section</div>
                                                    </div>

                                                </fieldset>
                                                <span v-if="error.sectionStatus" v-bind:class="[ 'col-md-12', { 'form-control-danger' : error.sectionStatus }]">
                                                    {{error.sectionMessage}}
                                                </span>
                                                <br />
                                            </div>
                                            <div class="table-responsive">
                                                <table class="table">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Section Name</th>
                                                            <th>No. Of Questions</th>
                                                            <th>Description</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody v-if="sectionsArray">
                                                        <tr v-for="(sec, index) in sectionsArray" :key="index">
                                                            <th scope="row">{{index+1}}</th>
                                                            <td>{{sec.sectionName}}</td>
                                                            <td>{{sec.evaluationQuestions.length}}</td>
                                                            <td>
                                                                {{sec.sectionDesc}}
                                                            </td>
                                                            <td>
                                                                <div class="col-xs-12">
                                                                    <div class="btn btn-primary " @click="removeSection(index)">Remove</div>
                                                                    <div class="btn btn-primary  " @click="addQuestion(sec,index)">Add question</div>
                                                                </div>
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div v-show="step==3">
                                            <h5>{{currentSection.sectionName}}</h5>
                                            <span class="" style="font-size:14px;color:darkgray;">{{currentSection.sectionDesc}}</span>
                                            <div class="">
                                                <div class="col-md-12 form-group">
                                                    <label>Question</label>
                                                    <textarea class="form-control" v-model="questions.question">Type your questions</textarea>
                                                </div>
                                                <div class="col-md-12 form-group">
													<label>Question type</label>
													<v-select v-model="questions.questionType" :options=questionTypes></v-select>
												</div>
                                                <div class="col-md-12 form-group">
                                                    <label></label>
                                                    <div class="btn  btn-primary" @click="pushSectionQuestions(questions)">Add Question</div>
                                                </div>
                                            </div>
                                            
                                            <div class="table-responsive">
                                                <table class="table">
                                                    <thead>
                                                        <tr>
															<th>#</th>
															<th>Question</th>
															<th>Question Type</th>
															<th></th>
														</tr>
                                                    </thead>
                                                    <tbody v-if="currentSection.evaluationQuestions">
                                                        <tr v-for="(quiz, index) in currentSection.evaluationQuestions" :key="index">
															<td>{{index+1}}</td>
															<td>{{quiz.question}}</td>
															<td>{{quiz.questionType}}</td>
															<td><div class="btn btn-primary " @click="currentSection.evaluationQuestions.splice(index,1)">Remove</div></td>
														</tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div v-show="step==4">
                                            <div class="col-xl-12">
                                                <div class="card">
                                                    <div class="card-header">
                                                        <h5>{{evaluation.evaluationName}}</h5>
                                                        <span>{{evaluation.evaluationDesc}}</span>
                                                    </div>
                                                    <div class="card-block" v-for="(section,index) in sectionsArray" :key="index">
                                                        <div class="col-md-12 row" style="border-bottom:1px lightgrey solid;padding-bottom:4px;">
                                                            <label class="float-label">
                                                                <b>{{section.sectionName}}</b>
                                                                <br /><small>{{section.sectionName}}</small>
                                                            </label>
                                                        </div>

                                                        <section id="task-container">
                                                            <ul id="task-list">
																<li class="col-md-12" v-for="(quiz,index) in section.questions" :key="index">
																	<p>{{quiz.question}} </p>
																	<p class="col-md-6">
																		<b>Question Type:</b>
																		{{quiz.questionType}}
																	</p>
																</li>
															</ul>
															<div>
																<div class="btn  btn-danger pull-right" @click="sectionsArray.splice(index,1)">remove</div>
															</div>
                                                        </section>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                <div class="actions clearfix">
                                    <ul role="menu" aria-label="Pagination">

                                        <li class="btn btn-inverse btn-round waves-effect waves-light " @click="previous()">Previous</li>

                                        <li v-if="step<4" class="btn btn-primary btn-round waves-effect waves-light " @click="next()">Next</li>
                                        <li v-if="step==4">
                                            <submit-button :title="buttonText" :loading="loading"
                                             styling="btn btn-primary btn-round waves-effect waves-light "
                                             v-on:submit="save"></submit-button>
                                        </li>
                                        <li v-if="step==4">
                                            <a class="btn btn-inverse btn-round waves-effect waves-light " @click="save()">Cancel</a>
                                        </li>
                                    </ul>
                                </div>
                            </form>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import END_POINTS from '../../components/constants/EndPoints';
export default {
  data() {
    return {
        loading: false,
        evaluation: {},
        sections: {},
        questionTypes: [],
        questions: {},
        questionOptionName: {},
        preview: {},
        error: {
            evaluationStatus: false,
            evaluationMessage: '',
            sectionStatus: false,
            sectionMessage: '',

        },
        sectionsArray: [],
        questionOptions : [],
        edit: false,
        subTitle: "",
        assignText: "Select User Group",
        step: 1,
        currentSection: {},
        privileges: []
    };
  },
  created() {
    this.GetQutstionTypes();
    if (this.$route.params.id) {
        this.edit = true;
        this.getEvaluationInfo(this.$route.params.id);
    }
  },
  methods: {
    GetQutstionTypes(){
        this.$http
        .get("evaluations/getevaluations/?itemsPerPage=" + 3 + "&offset=" + 0)
        .then(result => {
            this.questionTypes = result.data.data.questionTypes;
        })
        .catch(error => {
        this.$toastr("error", error.message);
        });
    },
    save() {
        var prevs = []
        var evaluation = {
            id: this.$route.params.id,
            evaluation: this.evaluation,
            sections :this.sectionsArray
        }
        this.loading = true
        this.$http
            .post("evaluations/addevaluation", evaluation)
            .then(response => {
                this.loading = false;
                if (response.data.success) {
                    
                    this.$router.push({ name: "evaluations" });
                    this.$toastr('success', response.data.message);
                } else {
                    this.$toastr('Error', response.data.message);
                }
            })
            .catch(e => {
                this.loading = false
                this.$toastr('Error', "Server error occured,please try again");
            })
        },
      getEvaluationInfo: function (id) {
        this.loading = true
        var offset = 0
        this.$http.get(
        END_POINTS.GETEVALUATIONINFO+"/?id="+id)
        .then(result => {
            this.loading = false
            this.createEvaluationStructure(result.data.data)
        })
        .catch(error => {

            this.$toastr("error", error.message)
        })
      },
      createEvaluationStructure: function (returnInfo) {
        this.loading = false
        this.evaluation = {
            evaluationName: returnInfo.evaluationName,
            evaluationDesc: returnInfo.evaluationDesc
        }
        returnInfo.evaluationSections.forEach(s => {
            s.evaluationQuestions.forEach(q => {
                q.question = q.questionDesc
                q.questionType = this.convertType(q.questionType)
            })
        })
        this.sectionsArray = returnInfo.evaluationSections
      },
      convertType(questionType){
        if(questionType === 3)
            return "Text"
        if(questionType === 2)
            return "YesNo"
        return "MultipleOptions"
      },
      pushSectionQuestions: function () {
        var question = {
            question: this.questions.question,
            questionType: this.questions.questionType
        }
        if (question.question == '' || !question.question) {
            this.$toastr('error', 'Question cannot be blank or');
            return;
        }
        this.sectionsArray[this.currentSection.index].evaluationQuestions.push(question);
        this.questions = {};
        this.$toastr('success', 'Question added successfully');
      },
      pushQuestionOptions: function () {
          this.questionOptions.push(this.questionOptionName)
          this.questionOptionName = {};
      },
      pushSection: function () {
        if (!this.checkStringEmpty(this.sections.sectionName)) {
            this.sections.evaluationQuestions = [];
            this.sectionsArray.push(this.sections);
            this.sections = {};
            return true;
        } 
        this.$toastr('error', 'Section name can not be empty!');
      },
      removeSection: function (index) {
          this.sectionsArray.splice(index, 1);
      },
      addQuestion: function (sec, index) {
          sec.index = index;
          this.currentSection = sec;
          this.step += 1;
      },
      next: function () {
          var error = false;
        if (this.step == 1) {
            this.error.evaluationStatus = false;
            if (this.checkStringEmpty(this.evaluation.evaluationName)) {
                this.error.evaluationStatus = true;
                this.error.evaluationMessage = 'Evaluation Name cannot be empty';
                this.$toastr('error', this.error.evaluationMessage)
                error= true;
            }
          }
          
          if (this.step == 2 || this.step == 3) {
            this.error.sectionStatus = false;
            if (this.sectionsArray.length == 0) {
                this.error.sectionStatus = true;
                this.error.sectionMessage = 'You have not added any section';
                error= true;
            } else {
                this.sectionsArray.forEach(element => {
                    element.questions = element.evaluationQuestions
                    if (element.questions.length == 0) {
                        this.error.sectionStatus = true;
                        this.error.sectionMessage = 'On of the section does not have questions,please remove it or add questions';
                        
                        error = true;
                    }
                })
            }
            if (error) {
                this.step = 2;
                this.$toastr('error', this.error.sectionMessage)
            }
        }
        if (!error) this.step += 1
      },
      checkStringEmpty: function (name) {
          if (!name|| name=='')
              return true;
      },
    previous: function(){
        if(this.step >= 0){
            this.step -= 1
        }
    },
    contains(arrayData, id) {
        var i = arrayData.length;
        while (i--) {
            if (parseInt(arrayData[i]) === id) {
                return true;
            }
        }
        return false;
    }
  },
  computed: {
    title() {
        if (this.edit) {
            if (this.step == 1) {
                return "Edit Evaluation";
            }

            if (this.step == 2) {
                return "Edit Section";
            }

            if (this.step == 3) {
                return "Edit Questions";
            }

            if (this.step == 4) {
                return "Preview Evaluation";
            }
        }

        //if its adding the results
        if(!this.edit){
             if(this.step == 1){
                return "Add Evaluation";
            }

            if(this.step == 2){
                return "Add Section";
            }

            if (this.step == 3) {
                return "Add Questions";
            }

            if (this.step == 4) {
                return "Preview Evaluation";
            }
        }
    },
    buttonText() {
      if (this.edit) {
        return "Save Changes";
      }
      return "Save";
    }
  }
};
</script>

<style>
.wizard {
  display: block;
  width: 100%;
  overflow: hidden;
}
.roleBtn{color:#fff}
/* Accessibility */
.wizard > .steps .current-info,
.tabcontrol > .steps .current-info {
  position: absolute;
  left: -999em;
}

.wizard > .content > .title,
.tabcontrol > .content > .title {
  position: absolute;
  left: -999em;
}

.wizard > .steps .number {
  font-size: 1.429em;
}

.wizard > .steps > ul > li {
  width: 50%;
}

.wizard > .steps > ul > li,
.wizard > .actions > ul > li {
  float: left;
}

.wizard > .steps a,
.wizard > .steps a:hover,
.wizard > .steps a:active {
  display: block;
  width: auto;
  margin: 0 0.5em 0.5em;
  padding: 1em 1em;
  text-decoration: none;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .steps .current a,
.wizard > .steps .current a:hover,
.wizard > .steps .current a:active {
  background: #2184be;
  color: #fff;
  cursor: default;
}

.wizard > .steps .done a,
.wizard > .steps .done a:hover,
.wizard > .steps .done a:active {
  background: #9dc8e2;
  color: #fff;
}

.wizard > .steps .error a,
.wizard > .steps .error a:hover,
.wizard > .steps .error a:active {
  background: #ff3111;
  color: #fff;
}

.wizard > .content {
  background: #fff;
  display: block;
  margin: 0.5em;
  min-height: 20em;
  overflow: hidden;
  position: relative;
  width: auto;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .content > .body {
  float: left;
  position: absolute;
  width: 95%;
  height: 95%;
  padding: 2.5%;
}

.wizard > .actions {
  position: relative;
  display: block;
  text-align: right;
  width: 100%;
}

.wizard > .actions > ul {
  display: inline-block;
  text-align: right;
}

.wizard > .actions > ul > li {
  margin: 0 0.5em;
}
</style>
