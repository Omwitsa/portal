<template>
    <div class="page-body">
        <div class="card">
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
													<span class="number" style="font-size:10px;">1.Survey</span>
												</a>
											</li>
                                            
                                            <li role="tab" :class="step == 2 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
												<a>
													<span v-if="step==1" class="current-info audible">current step: </span>
													<span class="number" style="font-size:10px;">2.Section</span>
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
												<input v-model="surveyTemplate.name" placeholder="Survey Template Name" type="text" class="form-control"/><br>
                                                <input v-model="surveyTemplate.description" placeholder="Description" type="text" class="form-control"/>
											
												<div class="table-responsive" v-if="getSurveyTemplates() && !isEdit"><br>
													<table class="table">
														<thead>
															<tr>
																<th>#</th>
																<th>Survey Name</th>
																<th>Description</th>
																<th>Date</th>
																<th>Action</th>
															</tr>
														</thead>
														<tbody>
															<tr v-for="(survey, index) in surveys" :key="index">
																<th scope="row">{{index+1}}</th>
																<td>{{survey.name}}</td>
																<td>
																	{{survey.description}}
																</td>
																<td>{{survey.dateCreated}}</td>
																<td><list-button :item="survey" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
															</tr>
														</tbody>
													</table>
												</div>
											</fieldset>
										</div>

                                        <div v-show="step==2">
											<fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
												<h5>{{surveyTemplate.name}}</h5>
												<input v-model="section.name" placeholder="Section Name" type="text" class="form-control"/><br>
                                                <input v-model="section.description" placeholder="Description" type="text" class="form-control"/><br>
												
												<div class="table-responsive" v-if="surveyTemplate.questionSections.length">
													<table class="table">
														<thead>
															<tr>
																<th>#</th>
																<th>Section Name</th>
																<th>Description</th>
																<th>No. Of Questions</th>
																<th></th>
															</tr>
														</thead>
														<tbody>
															<tr v-for="(questionSection, index) in surveyTemplate.questionSections" :key="index">
																<th scope="row">{{index+1}}</th>
																<td>{{questionSection.name}}</td>
																<td>
																	{{questionSection.description}}
																</td>
																<td>{{questionSection.size}}</td>
																<td>
																	<div class="col-xs-12">
																		<div class="btn btn-primary " @click="removeSection(index)">Remove</div>
																		<div class="btn btn-primary  " @click="addQuestion(questionSection,index)">Add question</div>
																	</div>
																</td>
															</tr>
														</tbody>
													</table>
												</div>

												<div v-bind:class="['col-md-6']">
													<div class="btn  btn-primary" @click="pushSection()">Add Section</div>
												</div>
											</fieldset>
										</div>

										<div v-show="step==3">
											<h6>{{section.name}}</h6>
											<fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
												<div class="col-md-12 form-group">
													<label>Question</label>
													<textarea class="form-control" v-model="question.question">Type your questions</textarea>
												</div>

												<div class="col-md-12 form-group"> 
													<label>Question type</label> 
													<v-select v-model="question.type" :options=questionTypes></v-select>
												</div>
												<div v-if="(question.type != 'Text') && (question.type != 'Info') && question.type" class="col-md-12 form-group">
													<ol v-if="options">
														<li v-for="(option, index) in options" :key="index">
															<input :type="getType(question.type)" class="" />
															<label>{{option}}</label>
														</li>
													</ol>
													<input v-model="question.option" placeholder="Enter option" type="text" class="form-control"/><br>
													<div>
														<div class="btn  btn-primary" @click="pushOption(question.option)">Add Option</div>
													</div>
												</div><br>

												<table class="table" v-if="section.questions">
													<thead>
														<tr>
															<th>#</th>
															<th>Question</th>
															<th>Question Type</th>
															<th></th>
														</tr>
													</thead>
													<tbody>
														<tr v-for="(question, index) in section.questions" :key="index">
															<td>{{index+1}}</td>
															<td>{{question.question}}</td>
															<td>{{question.type}}</td>
															<!-- <td><div class="btn btn-primary " @click="removeQuestion(index)">Remove</div></td> -->
														</tr>
													</tbody>
												</table>

												<div class="col-md-12 form-group">
													<div class="btn  btn-primary" @click="pushQuestion()">Add Question</div>
												</div>
											</fieldset>
										</div>

										<div v-show="step==4">
											<fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
												<div>
													<h4>{{surveyTemplate.name}}</h4>
													<p>{{surveyTemplate.description}}</p>
													<div v-for="(section, index) in surveyTemplate.questionSections" :key="index">
														<h5>{{section.name}}</h5>
														<p>{{section.description}}</p>
														<ol>
															<li v-for="(question, index1) in section.questions" :key="index1">
																<h6>{{question.question}}</h6>
																<p>{{question.type}}</p>
															</li>
														</ol>
													</div>
												</div>
											</fieldset>
										</div>
                                    </div>

                                    <div class="actions clearfix"><br>
                                        <ul role="menu" aria-label="Pagination">
											<li v-if="stepsEnded" class="btn btn-primary btn-round waves-effect waves-light " @click="saveSurvey()">Save</li>
											<li v-if="!stepsEnded" class="btn btn-primary btn-round waves-effect waves-light " @click="next()">Next</li>
                                            <li class="btn btn-inverse btn-round waves-effect waves-light " @click="previous()">Previous</li>
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
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
    data() {
        return {
            subTitle: "Create Questionnaires",
            title: "Questionnaires",
            step: 1,
			stepsEnded: false,
			surveyTemplate: {
				questionSections: []
			},
			surveys: [],
			options: [],
			isEdit: false,
			section: {},
			question: {},
			questionTypes: [],
			tableActions: [
                {
                    name: "Edit",
                    type: "button",
                    icon: "trash",
                    path: "edit",
                    design: "danger"
                }
            ]
        }
	},
	methods: {
		pushOption(option){
			this.options.push(option)
			this.question.option = ""
			this.question.options = this.options.join(",")
		},
		addQuestion(questionSection, index){
			questionSection.index = index
			this.section = questionSection
			this.step += 1;
		}, 
		removeSection(index){
			this.surveyTemplate.questionSections.splice(index, 1);
		},
		removeQuestion(index){
			var val = this.surveyTemplate.questionSections
		},
		getType(type){
            if(type == "MultipleOptions" || type == "YesNo"){
                return "radio"
            }
            else if(type == 'MultipleAnswers'){
                return "checkbox"
            }
           else{
               return "text"
           }
        },
		next(){ 
			if(this.step == 1){
				if(!this.surveyTemplate.name){
					this.$toastr('error', "Sorry, survey name cannot be empty")
					return
				}
				var nameExists = false
				this.surveys.filter(survey => {
					if(survey.name === this.surveyTemplate.name && !this.isEdit){
						this.$toastr('error', "Sorry, survey name already exist")
						nameExists = true
					}
				})
				if(nameExists){
					return
				}

				this.surveyTemplate.description = this.surveyTemplate.description ? this.surveyTemplate.description : ""
			}

			if(!this.surveyTemplate.questionSections.length && this.step == 2){
				this.$toastr('error', "Sorry, Kindly add atleast one section")
				return
			}

			var moveToNext = true
			this.surveyTemplate.questionSections.filter(section => {
				if(!section.questions.length){
					moveToNext = false
					this.$toastr('error', `Kindly add atleast one question to section: ${section.name}`)
				}
			})

			if(!moveToNext){
				return
			}

			this.step = this.stepsEnded ? this.step : this.step += 1
			this.stepsEnded = this.step > 3
		},
		previous(){
			if (this.step > 0) {
				this.step -= 1
				this.step = this.step < 1 ? 1 : this.step
			}
		},
		getSurveyTemplates(){
			this.$http.get("clearances/getSurveyTemplates")
			.then(result => {
				result.data.data.surveyTemplates.forEach(element => {
					element.dateCreated = DateFomatter.ReturnDate(element.dateCreated)
				});
				this.surveys = result.data.data.surveyTemplates
			})
			.catch(error => {
				this.$toastr("error", error.message);
			});

			return this.surveys;
		},
		saveSurvey(){
			this.$http.post("clearances/createQuestionnaireTemplate", this.surveyTemplate)
			.then(response => {
				if (response.data.success) {
					this.step = 1
					this.isEdit = false
					this.$toastr('success', response.data.message);
				} else {
					this.$toastr('Error', response.data.message);
				}
			})
			.catch(e => {
				this.$toastr('Error', "Server error occured,please try again");
			})
		},
		pushSection(){
			if (!this.section.name) {
				this.$toastr('error', "Sorry, section name cannot be empty")
				return;
			}

			var nameExists = false
			this.surveyTemplate.questionSections.filter(section => {
				if(section.name === this.section.name){
					nameExists = true
					this.$toastr('error', "Sorry, section name already exist")
					return;
				}
			})

			if(!nameExists){
				this.section.questions = []
				this.section.size = 0
				this.section.description = this.section.description ? this.section.description : ""
				this.surveyTemplate.questionSections.push(this.section)
				this.section = {}
			}
		}, 
		pushQuestion(){
			if (!this.question.question) {
				this.$toastr('error', "Sorry, Question cannot be empty")
				return;
			}
			if (!this.question.type) {
				this.$toastr('error', "Sorry, Kindly select question type")
				return;
			}

			this.options = []
			this.surveyTemplate.questionSections[this.section.index].questions.push(this.question) 
			this.surveyTemplate.questionSections[this.section.index].size = this.surveyTemplate.questionSections[this.section.index].questions.length
			this.question = {}
		},
		getSelectedTemplateDetails(item){
			this.$http.get(`clearances/getSelectedTemplateDetails?id=${item.id}`)
			.then(result => {
				this.surveyTemplate = result.data.data
				// this.questionTypes = result.data.data.questionTypes;
			})
			.catch(error => {
				this.$toastr("error", error.message);
			});
		},
		buttonEvent(item, action) {
			item.questionSections = item.questionSections ? item.questionSections : []
            switch (action) {
                case "edit":
					this.getSelectedTemplateDetails(item)
					this.isEdit = true
                break;
                default:
                break;
            }
        },
		getQuestionTypes(){
			this.$http.get("evaluations/getevaluations/?itemsPerPage=" + 4 + "&offset=" + 0)
			.then(result => {
				this.questionTypes = result.data.data.questionTypes;
			})
			.catch(error => {
				this.$toastr("error", error.message);
			});
		}
	},
	created() {
		this.getQuestionTypes();
	}
}
</script>

<style>
	.wizard {
		display: block;
		width: 100%;
		overflow: hidden;
	}

	.roleBtn {
		color: #fff
	}

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
