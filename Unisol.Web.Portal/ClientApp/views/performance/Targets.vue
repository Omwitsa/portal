<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <!-- <h5>{{performance.performance.name}}</h5>
                <span v-if="subTitle">{{subTitle}}</span> -->
            </div>

            <div class="card-block">
                <div id="wizardc">
                    <section>
                        <form class="wizard-form wizard clearfix" id="design-wizard" action="#" role="application">
                            <div class="steps clearfix">
                                <ul role="tablist">
                                    <li role="tab" :class="step == 1 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
                                        <a>
                                            <span v-if="step==1" class="current-info audible">current step: </span>
                                            <span class="number" style="font-size:10px;">1.Sections</span>
                                        </a>
                                    </li>
                                    <li role="tab" :class="step == 2 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
                                        <a>
                                            <span v-if="step==1" class="current-info audible">current step: </span>
                                            <span class="number" style="font-size:10px;">2.Targets</span>
                                        </a>
                                    </li>
                                    <li role="tab" :class="step == 3 ? 'current last' : 'done last'" aria-disabled="true">
                                        <a>
                                            <span v-if="step==2" class="current-info audible">current step: </span>
                                            <span class="number" style="font-size:10px;">3.Preview</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <div class="clearfix">
                                <div v-show="step==1">
                                    <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                        <div class="table-responsive">
                                            <table class="table table-sm table-bordered">
                                                <thead>
                                                    <th>Section Name</th>
                                                    <th>Notes</th>
                                                    <th>No. of targets</th>
                                                    <th v-if="!supervisorApproval">Action</th>
                                                </thead>
                                                <tbody>
                                                    <tr v-for="(section, index) in templates.template.performanceSections" :key="index">
                                                        <td>{{section.name}}</td>
                                                        <td>{{section.notes}}</td>
                                                        <td>{{section.size}}</td>
                                                        <td v-if="!supervisorApproval"><list-button :item="section" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </fieldset>
                                </div>

                                <div v-show="step==2">
                                    <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                        <h5>{{section.name}}</h5> 
                                        <div class="row">
                                            <div class="col-md-12">
                                                <input :disabled='supervisorApproval' v-model="performanceTarget.activity" placeholder="Activity" type="text" class="form-control"/><br>
                                                <input :disabled='supervisorApproval' v-model="performanceTarget.target" placeholder="Target" type="text" class="form-control"/><br>
                                                <input :disabled='supervisorApproval' v-model="performanceTarget.indicator" placeholder="Indicator" type="text" class="form-control"/><br>
                                                <input :disabled='supervisorApproval' v-model="performanceTarget.achievement" placeholder="Achievement" type="text" class="form-control"/><br>
                                                <input :disabled='supervisorApproval' v-model="performanceTarget.weight" placeholder="Weight" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>
                                                <input :disabled='true' v-model="performanceTarget.selfScore" placeholder="Self Score" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>
                                                <input :disabled='!isSupervisor || !performanceTarget.selfScore' v-model="performanceTarget.finalScore" placeholder="Final Score" type="number" min="0" oninput="validity.valid||(value='');" class="form-control"/><br>
                                                <input :disabled='!isSupervisor || !performanceTarget.selfScore' v-model="performanceTarget.notes" placeholder="Notes" type="text" class="form-control"/><br>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12 table-responsive">
                                                <table class="table table-sm table-bordered" v-if="section.performanceTargets">
                                                    <thead>
                                                        <th>#</th>
                                                        <th>Activity</th>
                                                        <th>Target</th>
                                                        <th>Indicator</th>
                                                        <th>Achievement</th>
                                                        <th>Weight</th>
                                                        <th>Self Score</th>
                                                        <th>Final Score</th>
                                                        <th>Notes</th>
                                                        <th></th>
                                                    </thead>
                                                    <tbody>
                                                        <tr v-for="(target, index) in section.performanceTargets" :key="index">
                                                            <td>{{++index}}</td>
                                                            <td>{{target.activity}}</td>
                                                            <td>{{target.target}}</td>
                                                            <td>{{target.indicator}}</td>
                                                            <td>{{target.achievement}}</td>
                                                            <td>{{target.weight}}</td>
                                                            <td>{{target.selfScore}}</td>
                                                            <td>{{target.finalScore}}</td>
                                                            <td>{{target.notes}}</td>
                                                            <td><div class="btn btn-primary" v-if="!supervisorApproval" @click="removeTarget(index)">Remove</div></td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                <div class="col-md-12 form-group" v-if="!supervisorApproval">
                                                    <button :disabled='disableTargetBtn' class="btn btn-primary" @click.prevent="pushTarget()">Add Target</button>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>

                                <div v-show="step==3">
                                    <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
                                        <div v-for="(section, index) in templates.template.performanceSections" :key="index">
                                            <h5>{{section.name}}</h5>
                                            <ol v-for="(target, tIndex) in section.performanceTargets" :key="tIndex">
                                                <li>Activity: {{target.activity}}</li>
                                                <li>Target: {{target.target}}</li>
                                                <li>Indicator: {{target.indicator}}</li>
                                                <li>Achievement: {{target.achievement}}</li>
                                                <li>Weight: {{target.weight}}</li>
                                                <li>Self Score: {{target.selfScore}}</li>
                                                <li>Final Score: {{target.finalScore}}</li>
                                                <li>Notes: {{target.notes}}</li>
                                            </ol>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>

                            <div class="actions clearfix"><br>
                            <!-- :disabled='disableNext' -->
                                <ul role="menu" aria-label="Pagination">
                                    <button v-if="stepsEnded && !supervisorApproval" class="btn btn-primary btn-round waves-effect waves-light" @click.prevent="saveTargets()">{{btnSave}}</button>
                                    <button v-if="!stepsEnded && !supervisorApproval" class="btn btn-primary btn-round waves-effect waves-light " @click.prevent="next()">Next</button>
                                    <button v-if="!supervisorApproval" class="btn btn-inverse btn-round waves-effect waves-light " @click.prevent="previous()">Previous</button>
                                </ul>
                            </div>
                        </form>
                    </section>
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
            performanceTarget: {},
            templates: {},
            loading: false,
            section: {},
            disableTargetBtn: false,
            stepsEnded: false,
            btnSave: "Save",
            user: this.$baseRead("user"),
            supervisorApproval: false,
            isSupervisor: false,
            tableActions: [
                {
                    name: "Add Target",
                    type: "button",
                    icon: "trash",
                    path: "addTarget",
                    design: "danger"
                }
            ],
        }
    },
    methods: {
        previous(){
            this.stepsEnded = false,
            this.step -= 1
            this.step = this.step < 1 ? 1 : this.step
            this.disableTargetBtn = this.step == 2
        },
        next(){ 
			this.step = this.stepsEnded ? this.step : this.step += 1
			this.stepsEnded = this.step > 2
            this.disableTargetBtn = this.step == 2
        },
        buttonEvent(item, action) {
            switch (action) {
                case "addTarget":
                    this.step += 1
                    this.section = item
                break;
                default:
                break;
            }
        },
        removeTarget(index){
            this.section.performanceTargets.splice(--index, 1);
        },
        getCurrentTemplate(reporter){
            var username = reporter.empNo ? reporter.empNo : this.user.username
            this.loading = true;
            this.$http.get("performance/getCurrentTemplate?username=" + username)
            .then(result => {
            if (result.data.success) {
                result.data.data.target = result.data.data.target ? result.data.data.target : {}
                result.data.data.target.status = result.data.data.target.status ? result.data.data.target.status : "Pending"
                this.supervisorApproval = result.data.data.target.status != "Pending"
                this.isSupervisor = result.data.data.target.supervisor === this.user.username
                var pending = result.data.data.target.status === "Pending"
                this.btnSave = pending && this.isSupervisor? "Approve" : "Save"
                if(!result.data.data.target.performanceTargetDetail){
                    result.data.data.target.performanceTargetDetail = []
                }
                this.loading = false;
                var index = 0;
                result.data.data.template.performanceSections.forEach(element => {
                    element.index = index++
                    element.performanceTargets = result.data.data.target.performanceTargetDetail.filter(d => {
                        return element.id == d.performanceSectionId
                    })

                    element.size = element.performanceTargets.length ? element.performanceTargets.length : 0
                });
                this.templates = result.data.data;
            } else {
                this.$toastr("error", result.data.message);
            }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        pushTarget(){
            if (!this.performanceTarget.activity) {
				this.$toastr('error', "Kindly, provide the activity")
				return;
			}

            this.templates.template.performanceSections[this.section.index].performanceTargets.push(this.performanceTarget)
			this.performanceTarget = {}
        },
        saveTargets(){
            var performanceTargets = this.templates.template
            performanceTargets.userName = this.$route.params.empNo ? this.$route.params.empNo : this.user.username
            performanceTargets.sessionId = this.templates.performance.id
            performanceTargets.targetId = this.templates.target.id ? this.templates.target.id : 0
            performanceTargets.isSupervisor = this.isSupervisor

			this.$http.post("performance/saveTargets", performanceTargets)
			.then(response => {
				if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: "performance" })
				} else {
					this.$toastr('Error', response.data.message);
				}
			})
			.catch(e => {
				this.$toastr('error', "Server error occured,please try again");
			})
        },
    },
    created(){
        this.getCurrentTemplate(this.$route.params)
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
		width: 33%;
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
