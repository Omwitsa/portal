<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>Current Evaluations</h5>
        <span>List of current Evaluations.</span>
      </div>
      <div v-if="evaluationsHttp" class="text-center card-block">
        <i class="fa fa-spin fa-spinner"></i> Loading. Please wait ...
      </div>
      <div class v-show="activeDiv==='evaluations'">
        <div class="card-block" v-if="!evaluationPresent">
          <div class="alert alert-warning" v-if="!evaluationsHttp">
            <i class="fa fa-exclamation-circle"></i> We could not find an active evaluation
          </div>
        </div>
        <div class="card-block table-responsive" v-if="!evaluationsHttp && evaluationPresent">
          <div class="alert alert-info" v-if="zeroUnitsMsg.length>0">
            <i class="fa fa-exclamation-circle"></i>
            {{zeroUnitsMsg}}
          </div>
          <table class="table table-sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Level</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>Take Evaluation</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(evaluation,index) in activeEvaluations" :key="index">
                <td>{{index+1}}</td>
                <td>For : {{evaluation.names}}</td>
                <td>{{DateFormatter.ReturnDate(evaluation.startDate)}}</td>
                <td>{{DateFormatter.ReturnDate(evaluation.endDate)}}</td>
                <td>
                  <button
                    @click="createCurrentClickedEvaluation(evaluation)"
                    class="btn btn-primary btn-sm btn-round waves-effect waves-light"
                    :disabled="regUnits.length==0"
                  >
                    <small-spinner :loading="regUnitHttp"></small-spinner>Start Evaluation
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div class="col-md-12" v-if="activeDiv==='subjects'">
        <div class="card-header">
          <h4 style="font-weight: bold">
            <i class="fa fa-chevron-left" @click="activeDiv='evaluations'"></i>
            {{currentClickedEvaluation.names}}
          </h4>
          <span>
            {{DateFormatter.ReturnDate(currentClickedEvaluation.startDate)}} To
            {{DateFormatter.ReturnDate(currentClickedEvaluation.endDate)}}
          </span>
        </div>

        <div class="card" v-for="(unit,motherIndex) in regUnits" :key="motherIndex"> 
          <div
            class="card-header"
            v-bind:class="{ 'bg-success': unit.takenEvaluation, 'bg-danger': !unit.takenEvaluation }"
            @click="expandClickedunit(motherIndex)"
          >
            {{unit.code}} {{unit.names}}
            <b v-if="!unit.takenEvaluation">
              [Unanswered]
              <i class="fa fa-remove"></i>
            </b>
            <b v-if="unit.takenEvaluation">
              [Answered]
              <i class="fa fa-check"></i>
            </b>
            <br />
            <div class="card-header-right">
              <i
                class="fa fa-3x fa-chevron-down"
                v-if="clickedIndex!=motherIndex"
                style="color:white;"
              ></i>
              <i
                class="fa fa-3x fa-chevron-up"
                v-if="clickedIndex==motherIndex"
                style="color:white;"
              ></i>
            </div>
          </div>
          <div class v-if="clickedIndex===motherIndex&&unit.takenEvaluation">
            <div class="col-md-12">
              <br />
              <p class="lead">
                <i class="fa fa-thumbs-up"></i>
                Thank You For Taking Time To Answer {{unit.code}} Evaluation
              </p>
            </div>
          </div>
          <div class v-if="clickedIndex===motherIndex&&!unit.takenEvaluation">
            <div class="col-md-12">
              <div class>
                <div class="card-header">
                  <div class="row">
                    <div class="col-md-2" style="text-align: right">Lecturer's Name:</div>
                    <div class="col-md-3">
                      <v-select v-model="unit.lecturer" :options=unit.lecturers></v-select>
                    </div>
                  </div>
                  <a class="card-title" @click="clickedIndex=index">
                    <b>{{unit.evaluationQuestions.data.evaluationName}}</b>
                    <br />
                    {{unit.evaluationQuestions.data.evaluationDesc}}
                  </a>
                  <span
                    class="label label-default float-right"
                  >{{unit.evaluationQuestions.data.dateCreated}}</span>
                </div>
                <div class="card-block">
                  <div class="row">
                    <div class="col-sm-12">
                      <div
                        class="task-detail"
                        v-for="(sec,indexSection) in unit.evaluationQuestions.data.evaluationSections"
                        :key="indexSection">
                        <div
                          style="border-bottom:1px lightgrey solid;margin-bottom:8px;padding-bottom:8px;">
                          <div>
                            <b>{{indexSection+1}}. {{sec.sectionName}}</b>
                          </div>
                          <div class style="color:grey;margin-left:15px;">{{sec.sectionDesc}}</div>
                        </div>
                        <div class="col-md-12">
                          <div class="h-25 col-md-12" style="font-weight:bold;color:darkgrey;">Questions</div>
                          <div
                            v-for="(quiz,questionIndex) in sec.evaluationQuestions" :key="questionIndex">
                            {{questionIndex+1}}. {{quiz.questionDesc}}
                            <div class="col-md-12" v-if="quiz.questionType != 3">
                              <ul class="col-md-12 list-unstyled form-check-inline table-responsive">
                                <li v-for="(option,index) in quiz.options" :key="index">
                                  <label class="customcheck">
                                    {{option.options}} &nbsp;&nbsp;
                                      <input :type="GetType(quiz.questionType)" :value="option" :name="quiz.id" v-model="option.checked" class="" :id="'checkbox_'+index">
                                    <span class="checkmark"></span>
                                  </label>
                                </li>
                              </ul>
                            </div>
                            <div class v-if="quiz.questionType == 3">
                              <textarea class="form-control" v-model="quiz.questionResponse"></textarea>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="card-footer">
                  <div class="pull-right">
                    <div class="btn btn-primary btn-round waves-effect waves-light btn-sm"
                      @click="saveEvaluation(unit.evaluationQuestions.data,unit)">
                      <small-spinner :loading="savingHttp"></small-spinner>Save and proceed
                    </div>
                  </div>
                  <div class="clearfix">&nbsp;</div>
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
import END_POINTS from "../../components/constants/EndPoints";
import DateFormatter from "../../components/constants/DateFomatter";

export default {
  data() {
    return {
      evaluations: [],
      activeDiv: "evaluations",
      evaluationPresent: false,
      clickedIndex: 0,
      allQuestionFilled: true,
      loading: true,
      regUnitHttp: false,
      savingHttp: false,
      evaluationsHttp: false,
      pageSize: 15,
      DateFormatter: DateFormatter,
      itemsPerPage: 3,
      offset: 0,
      totalPages: 0,
      totalItems: 0,
      regUnits: [],
      zeroUnitsMsg: "",
      evaluationQuestions: {},
      evaluationQuestionHttp: false,
      activeEvaluations: [],
      searchText: "",
      currentClickedEvaluation: {},
      user: this.$baseRead("user"),
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    GetType(type){
      return type == 4? "checkbox" : "radio"
    },
    GetEvaluationSubjects() {
      this.regUnitHttp = true;
      this.$http.get("portalevaluations/GetRegisteredUnits?userCode=" + this.user.username)
        .then(result => {
          this.regUnitHttp = false;
          if (result.data.success) {
            result.data.data.forEach(element => {
              element.evaluationQuestions = [];
            });
            debugger
            this.regUnits = result.data.data;
          } else {
            this.zeroUnitsMsg = result.data.message;
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.regUnitHttp = false;
          this.$toastr("error", error.message);
        });
    },
    GetActiveEvaluations() {
      this.evaluationsHttp = true;
      this.$http
        .get("portalevaluations/getPortalActiveEvaluations?userCode=" + this.user.username)
        .then(result => {
          this.evaluationsHttp = false;
          if (result.data.success) {
            this.activeEvaluations = result.data.data;
            this.evaluationPresent = true;
            this.GetEvaluationSubjects();
          } else {
            this.evaluationPresent = false;
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.evaluationsHttp = false;
          this.$toastr("error", error.message);
        });
    },
    createCurrentClickedEvaluation(evaluation) {
      this.currentClickedEvaluation = evaluation;
      this.activeDiv = "subjects";
      this.getEvaluationQuestions();
    },
    getEvaluationQuestions: function() {
      this.evaluationQuestionHttp = true;
      this.$http
        .get("portalevaluations/getEvaluationQuestions?evaluationsId=" + this.currentClickedEvaluation.evaluationsId)
        .then(result => {
          this.evaluationQuestionHttp = false;
          if (result.data.success) {
            var alteredQuestions = this.createdAlteredQuestions(
              result.data.data
            );
            this.regUnits.forEach(element => {
              element.evaluationQuestions = alteredQuestions;
            });
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.evaluationQuestionHttp = false;
          this.$toastr("error", error.message);
        });
    },
    createdAlteredQuestions: function(evalQuestions) {
      evalQuestions.data.evaluationSections.forEach(section => {
        section.evaluationQuestions.forEach(question => {
          var multiQuestions = question.multiAnswers.split(")*(")
          question.options = []
          multiQuestions.forEach(m => {
            var response = {}
            response.options = m
            response.checked = false

            question.options.push(response);
          })
        });
      });

      return evalQuestions;
    },
    expandClickedunit: function(index) {
      this.clickedIndex = index;
    },
    saveEvaluation: function(evalResponse, unit) {
      var data = {
        unitCode: unit.code,
        LecturerName: unit.lecturer ? unit.lecturer : "",
        currentActiveEvaluationId: this.currentClickedEvaluation.id,
        Evaluation: evalResponse,
        currentEvaluationId: this.currentClickedEvaluation.evaluationsCurrentId,
        userCode: this.user.username
      };
      this.savingHttp = true;
      this.allQuestionFilled = true
      data.Evaluation.evaluationDesc = data.Evaluation.evaluationDesc ? data.Evaluation.evaluationDesc : ""
      data.Evaluation.evaluationSections.forEach(section => {
        section.sectionDesc = section.sectionDesc ?  section.sectionDesc : ""
        section.evaluationQuestions.forEach(questions => {
          var selectedStatus = []
          questions.options.forEach(o => {
            if(o.checked) selectedStatus.push(o.options)
          })
          questions.options = null
          questions.questionResponse = questions.questionType == 3 ? questions.questionResponse : selectedStatus.join()
          if(!questions.questionResponse){
             this.allQuestionFilled = false
             return
          }
        })
      })
      if(!this.allQuestionFilled){
        this.$toastr("error", "Kindly, Fill all the questions");
        this.savingHttp = false;
      }
      else{
        this.$http.post("portalevaluations/SaveStudentSubjectResponse", data)
        .then(result => {
          this.savingHttp = false;
          if (result.data.success) {
            unit.takenEvaluation = true;
            this.$toastr("success", result.data.message);
            this.moveNextUnit(unit);
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.savingHttp = false;
          this.$toastr("error", error.message);
        });
      }
    },
    moveNextUnit: function(unit) {
      if (Math.abs(this.clickedIndex) + 1 <= this.regUnits.length - 1) {
        this.clickedIndex++;
      }
      this.regUnits[this.clickedIndex].evaluationQuestions.data.evaluationSections.forEach(section => {
        section.evaluationQuestions.forEach(question => {
          question.questionResponse = "";
        });
      });
    },
    nextPage: function() {
      if (Math.abs(this.offset) + 1 <= this.totalPages) {
        this.offset++;
        this.loadData();
      }
    },
    stripContent(content) {
      let regex = /(<([^>]+)>)/gi;
      return content.replace(regex, "") + "...";
    },
    previousPage: function() {
      if (Math.abs(this.offset) - 1 >= 0) {
        this.offset--;
        this.loadData();
      }
    }
  },

  created() {
    this.GetActiveEvaluations();
  }
};
</script>

<style>
/* The customcheck */
.customcheck {
  display: block;
  position: relative;
  padding-left: 35px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 14px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default checkbox */
.customcheck input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

/* Create a custom checkbox */
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: #eee;
  border-radius: 0px;
}

/* On mouse-over, add a grey background color */
.customcheck:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.customcheck input:checked ~ .checkmark {
  background-color: #005cbf;
  border-radius: 0px;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the checkmark when checked */
.customcheck input:checked ~ .checkmark:after {
  display: block;
}

/* Style the checkmark/indicator */
.customcheck .checkmark:after {
  left: 9px;
  top: 5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
}
</style>