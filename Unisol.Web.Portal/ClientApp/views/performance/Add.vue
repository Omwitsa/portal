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
                                                        <span class="number" style="font-size:10px;">1.Performance</span>
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
                                                        <span v-if="step==2" class="current-info audible">current step: </span>
                                                        <span class="number" style="font-size:10px;">3.Questionnaire</span>
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

                                        <div class="clearfix">
                                            <div v-show="step==1">
                                                <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                    <input v-model="performanceTemplate.name" placeholder="Performance Template Name" type="text" class="form-control"/><br>
                                                    <input v-model="performanceTemplate.notes" placeholder="Notes" type="text" class="form-control"/>
                                                </fieldset>
                                            </div>

                                            <div v-show="step==2">
                                                <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                    <h5>{{performanceTemplate.name}}</h5>
                                                    <input v-model="section.name" placeholder="Section Name" type="text" class="form-control"/><br>
                                                    <input v-model="section.notes" placeholder="Notes" type="text" class="form-control"/><br>
                                                    
                                                    <div class="table-responsive" v-if="performanceTemplate.performanceSections.length">
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Section Name</th>
                                                                    <th>Notes</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr v-for="(performanceSection, index) in performanceTemplate.performanceSections" :key="index">
                                                                    <th scope="row">{{index+1}}</th>
                                                                    <td>{{performanceSection.name}}</td>
                                                                    <td>
                                                                        {{performanceSection.notes}}
                                                                    </td>
                                                                    <td>
                                                                        <div class="col-xs-12">
                                                                            <div class="btn btn-primary " @click="removeSection(index)">Remove</div>
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
                                                <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                    <h5>Questinnaire</h5>
                                                    <input v-model="questionnaire.question" placeholder="Type Question" type="text" class="form-control"/><br>
                                                    
                                                    <div class="table-responsive" v-if="performanceTemplate.performanceQuestionnaire.length">
                                                        <table class="table">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Question</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr v-for="(questionnaire, index) in performanceTemplate.performanceQuestionnaire" :key="index">
                                                                    <th scope="row">{{index+1}}</th>
                                                                    <td>{{questionnaire.question}}</td>
                                                                    <td></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>

                                                    <div v-bind:class="['col-md-6']">
                                                        <div class="btn  btn-primary" @click="pushQuestion()">Add Question</div>
                                                    </div>
                                                </fieldset>
                                            </div>

                                            <div v-show="step==4">
                                                <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                                    <div>
                                                        <h4>{{performanceTemplate.name}}</h4>
                                                        <p>{{performanceTemplate.notes}}</p>
                                                        <div v-for="(section, index) in performanceTemplate.performanceSections" :key="index">
                                                            <h5>{{section.name}}</h5>
                                                            <p>{{section.notes}}</p>
                                                            <ol>
                                                                <li v-for="(activity, index1) in section.perfomanceActivities" :key="index1">
                                                                    <h6>Activity: {{activity.activity}}</h6>
                                                                    <p><b>Target: </b>{{activity.target}}</p>
                                                                    <p><b>Indicator: </b>{{activity.indicator}}</p>
                                                                    <p><b>Achievement: </b>{{activity.achievement}}</p>
                                                                    <p><b>Weight: </b>{{activity.weight}}</p>
                                                                    <p><b>Self Score: </b>{{activity.selfScore}}</p>
                                                                    <p><b>Final Score: </b>{{activity.finalScore}}</p>
                                                                </li>
                                                            </ol>
                                                        </div>

                                                        <div>
                                                            <h5>Questionnnaire</h5>
                                                            <ol>
                                                                <li v-for="(questionnaire, index) in performanceTemplate.performanceQuestionnaire" :key="index">
                                                                    {{questionnaire.question}}
                                                                </li>
                                                            </ol>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>

                                        <div class="actions clearfix"><br>
                                            <ul role="menu" aria-label="Pagination">
                                                <li v-if="stepsEnded" class="btn btn-primary btn-round waves-effect waves-light " @click="saveTemplate()">Save</li>
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
export default {
    data(){
        return{
            step: 1,
            performanceTemplate: {
                performanceSections: [],
                performanceQuestionnaire: []
            },
            stepsEnded: false,
            section: {},
            questionnaire: {},
            activity: {}
        }
    },
    methods: {
        removeSection(index){
			this.performanceTemplate.performanceSections.splice(index, 1);
        },
        pushQuestion(){
            if (!this.questionnaire.question) {
				this.$toastr('error', "Kindly provide the question")
				return;
			}

            this.performanceTemplate.performanceQuestionnaire.push(this.questionnaire)
            this.questionnaire = {}
        },
        pushActivity(){
			if (!this.activity.activity) {
				this.$toastr('error', "Kindly, provide the activity")
				return;
			}
			
			this.performanceTemplate.performanceSections[this.section.index].perfomanceActivities.push(this.activity) 
			this.performanceTemplate.performanceSections[this.section.index].size = this.performanceTemplate.performanceSections[this.section.index].perfomanceActivities.length
			this.activity = {}
		},
        pushSection(){
			if (!this.section.name) {
				this.$toastr('error', "Sorry, section name cannot be empty")
				return;
			}

			var nameExists = false
			this.performanceTemplate.performanceSections.filter(section => {
				if(section.name === this.section.name){
					nameExists = true
					this.$toastr('error', "Sorry, section name already exist")
					return;
				}
			})

			if(!nameExists){
				this.section.perfomanceActivities = []
				this.section.size = 0
				this.section.notes = this.section.notes ? this.section.notes : ""
				this.performanceTemplate.performanceSections.push(this.section)
				this.section = {}
			}
		}, 
        previous(){
			if (this.step > 0) {
				this.step -= 1
				this.step = this.step < 1 ? 1 : this.step
			}
		},
        saveTemplate(){
			this.$http.post("performance/addTemplate", this.performanceTemplate)
			.then(response => {
				if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: "performance" })
				} else {
					this.$toastr('Error', response.data.message);
				}
			})
			.catch(e => {
				this.$toastr('Error', "Server error occured,please try again");
			})
        },
        next(){ 
			if(this.step == 1){
				if(!this.performanceTemplate.name){
                    this.$toastr('error', "Sorry, Template name cannot be empty")
					return
				}
				
				this.performanceTemplate.notes = this.performanceTemplate.notes ? this.performanceTemplate.notes : ""
            }
            
            this.performanceTemplate.performanceSections = this.performanceTemplate.performanceSections ? this.performanceTemplate.performanceSections : []
			if(!this.performanceTemplate.performanceSections.length && this.step == 2){
				this.$toastr('error', "Sorry, Kindly add atleast one section")
				return
            }
            
			this.step = this.stepsEnded ? this.step : this.step += 1
			this.stepsEnded = this.step > 3
        },
        getTemplate(){
            this.loading = true;
            this.$http.get(`performance/getTemplateById?id=${this.$route.params.id}`)
            .then(result => {
                this.performanceTemplate = result.data.data
            })
            .catch(error => {
                this.loading = false;
            });
        }
    },
    created(){
        if(this.$route.params.id){
            this.getTemplate()
        }
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

