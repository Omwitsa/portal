<template>
    <div class="page-body navbar-page">
        <div class="row" v-if="showUnitUi">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Evaluation response</h5>
                        <div class="card-header-right">
                            <input type="checkbox" id="showTextResponse" @change="showTextResponse()">
                            <label for="showTextResponse">Show text Response</label> &nbsp;&nbsp;&nbsp;
                            <button class="btn btn-primary btn-sm" @click="exportTableToExcel()"> 
                                <i style="color:white;" class="fa fa-file-excel-o"></i> Export to excel
                            </button>
                            <button class="btn btn-primary btn-sm" @click="printEvaluation()">
                                <i style="color:white;" class="fa fa-print"></i> print
                            </button>
                        </div>
                    </div>
                   
                    <div class="card-block table-border-style">
                        <loading-spinner :loading="eventHttp"></loading-spinner>
                        <div class="row">
                            <div class="col-md-3">
                                <p>Year:</p>
                                <v-select v-model="selectedFilter.AcademicYear" :options=evalFilters.academicYear></v-select>
                            </div>
                            <div class="col-md-3">
                                <p>Semester:</p>
                                <v-select v-model="selectedFilter.semester" :options=evalFilters.semester></v-select>
                            </div>
                            <div class="col-md-3">
                                <p>Campus:</p>
                                <v-select v-model="selectedFilter.campus" :options=evalFilters.campus></v-select>
                            </div>
                            <div class="col-md-3">
                                <p>Department:</p>
                                <v-select v-model="selectedFilter.department" :options=evalFilters.department></v-select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <p>Programme:</p>
                                <v-select v-model="selectedFilter.programme" :options=evalFilters.programme @change="evaluationFilters()"></v-select>
                            </div>
                            <div class="col-md-3">
                                <p>Unit Code:</p>
                                <v-select v-model="selectedFilter.unitCode" :options=evalFilters.unitCode @change="evaluationFilters()"></v-select>
                            </div>
                            <div class="col-md-3" v-if="user.role == '1'">
                                <p>Lecturer:</p>
                                <v-select v-model="selectedFilter.lecturerName" :options=evalFilters.lecturerName @change="evaluationFilters()"></v-select>
                            </div>
                            <div class="col-md-3"><br>
                                <button class="btn btn-primary btn-sm form-control" @click="filterData()">
                                    Filter  
                                </button>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 table-responsive" id="evalationResponse">
                                <table class="table table-sm table-bordered" v-if="showFilters">
                                    <tbody>
                                        <tr>
                                            <td><strong>Year:</strong> {{ selectedFilter.AcademicYear }}</td>
                                            <td><strong>Session:</strong> {{ selectedFilter.semester }}</td>
                                            <td><strong>Campus:</strong> {{ selectedFilter.campus }}</td>
                                        </tr>
                                        <tr>
                                            <td><strong>Programme:</strong> {{ selectedFilter.programme }}</td>
                                            <td><strong>Unit Code:</strong> {{ selectedFilter.unitCode }}</td>
                                            <td><strong>Lecturer Name:</strong> {{ selectedFilter.lecturerName }}</td>
                                        </tr>
                                        <tr>
                                            <td><strong>Department:</strong> {{ selectedFilter.department }}</td>
                                        </tr>
                                    </tbody>
                                </table>

                                <table class="table table-hover table-sm" v-if="evaluationResponse.sectionResponse" id="evalResponse">
                                    <thead class="table-primary text-white">
                                        <th>Question</th>
                                        <th>Strongly Agree</th>
                                        <th>Agree</th>
                                        <th>Uncertain</th>
                                        <th>Disagree</th>
                                        <th>Strongly Disagree</th>
                                        <th>Mean</th>
                                        <th>Total responses</th>
                                        <th>Students</th>
                                    </thead>
                                    <tbody v-for="(section, index) in evaluationResponse.sectionResponse" :key="index">
                                        <tr><td><b>{{section.sectionName}}</b></td></tr>
                                        <tr v-for="(question, index1) in section.questionResponses" :key="index1">
                                            <td v-if="question.questionType != 3">{{question.question}}</td>
                                            <td v-if="question.questionType != 3">{{question.stronglyAgree}}</td>
                                            <td v-if="question.questionType != 3">{{question.agree}}</td>
                                            <td v-if="question.questionType != 3">{{question.uncertain}}</td>
                                            <td v-if="question.questionType != 3">{{question.disagree}}</td>
                                            <td v-if="question.questionType != 3">{{question.stronglyDisagree}}</td>
                                            <td v-if="question.questionType != 3">{{question.mean}}</td>
                                            <td v-if="question.questionType != 3">{{question.totalQuestions}}</td>
                                            <td v-if="question.questionType != 3">{{question.students}}</td>

                                            <td v-if="question.questionType == 3 && isTextResponse">{{question.question}}</td>
                                            <td v-if="question.questionType == 3 && isTextResponse" colspan="8">
                                                <ol>
                                                    <li v-for="(response, index2) in question.textResponse" :key="index2">
                                                        {{response}}
                                                    </li>
                                                </ol>
                                            </td>
                                        </tr>
                                        <tr v-if="section.mean != 'NaN'">
                                            <td><strong>TOTAL:</strong></td>
                                            <td>{{section.stronglyAgree}}</td>
                                            <td>{{section.agree}}</td>
                                            <td>{{section.uncertain}}</td>
                                            <td>{{section.disagree}}</td>
                                            <td>{{section.stronglyDisagree}}</td>
                                            <td>{{section.mean}}</td>
                                            <td>{{section.questions}}</td>
                                            <td>{{section.students}}</td>
                                        </tr>
                                    </tbody>
                                    <tbody>
                                        <tr>
                                            <td><strong>OVERAL RATING:</strong></td>
                                            <td colspan="8">{{evaluationResponse.overAllMean}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import fullCalendar from 'vue-fullcalendar'
    import END_POINTS from "../../../components/constants/EndPoints"
    import DateFomatter from "../../../components/constants/DateFomatter"

    export default {
        components: {
            'full-calendar': require('vue-fullcalendar')
        },
        data() {
            return {
                evaluations: [],
                evalFilters: [],
                selectedFilter: {},
                showUnitUi: true,
                showFilters: false,
                user: this.$baseRead("user"),
                clickedIndex: null,
                clickedUnit: {
                    evaluation: {}
                },
                loading: true,
                eventHttp: false,
                pageSize: 15,
                itemsPerPage: 3,
                offset: 0,
                isTextResponse: false,
                totalPages: 0,
                totalItems: 0,
                evaluationResponse: [],
                respondedUnits: [],
                currentActiveEvaluationId: {},
                searchText: '',
                pagination: {
                    total: 0
                }
            }
        },
        watch: {
            "selectedFilter.AcademicYear"(){
               this.evaluationFilters()
            },
            "selectedFilter.semester"(){
               this.evaluationFilters()
            },
            "selectedFilter.campus"(){
               this.evaluationFilters()
            },
            "selectedFilter.department"(){
               this.evaluationFilters()
            },
            "selectedFilter.programme"(){
               this.evaluationFilters()
            },
            "selectedFilter.unitCode"(){
               this.evaluationFilters()
            },
            "selectedFilter.lecturerName"(){
               this.evaluationFilters()
            }
        },
        methods: { 
            exportTableToExcel(){
                if(this.evaluationResponse.sectionResponse){
                    var downloadLink;
                    var dataType = 'application/vnd.ms-excel';
                    var tableSelect = document.getElementById('evalResponse');
                    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

                    // Specify file name
                    var filename = 'evaluation_response.xls';
                    
                    // Create download link element
                    downloadLink = document.createElement("a");
                    
                    document.body.appendChild(downloadLink);

                    if(navigator.msSaveOrOpenBlob){
                        var blob = new Blob(['\ufeff', tableHTML], {
                            type: dataType
                        });
                        navigator.msSaveOrOpenBlob( blob, filename);
                    }else{
                        // Create a link to the file
                        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;
                    
                        // Setting the file name
                        downloadLink.download = filename;
                        
                        //triggering the function
                        downloadLink.click();
                    }
                }
            },
            evaluationFilters(){
                this.eventHttp = true;
                this.selectedFilter.lecturerEmpNo = this.user.username
                this.$http.post("adminEvaluationsResponse/getEvaluationTargets/?currentActiveEvaluationId=" 
                + this.currentActiveEvaluationId, this.selectedFilter)
                .then(response => {
                    this.eventHttp = false;
                    this.httpStatus = false;
                    if (response.data.success) {
                        this.evalFilters = response.data.data.evaluationFilters
                    }
                })
                .catch(e => {
                    this.eventHttp = false;
                    this.$toastr("error", e.message);
                    this.httpStatus = false;
                });
            },
            printEvaluation(){
                if(this.evaluationResponse.sectionResponse){
                    this.$htmlToPaper("evalationResponse")
                    this.showFilters = false
                }
            },
            showTextResponse(){
                this.isTextResponse = $("#showTextResponse").is(":checked")
            },
            filterData(){
                this.loadData();
                this.showFilters = true
            },
            loadData() {
                this.eventHttp = true;
                this.selectedFilter.lecturerEmpNo = this.user.username
                this.$http.post(END_POINTS.GETRESPONDEDUNITS + this.currentActiveEvaluationId + "&offset=" + this.offset 
                + "&searchText=" + this.searchText, this.selectedFilter)
                    .then(result => {
                        this.eventHttp = false
                        if (result.data.success) {
                            this.totalItems = result.data.totalItems;
                            this.totalPages = Math.ceil(result.data.totalItems / this.itemsPerPage);
                            this.evaluationResponse = result.data.data
                            // this.respondedUnits = result.data.data
                        } else {
                            this.$toastr("error", result.data.message)
                        }
                    })
                    .catch(error => {
                        this.eventHttp = false
                        this.$toastr("error", error.message)
                    })

            },
            returnResponseCount: function (options, optionId) {
                let total = 0;
                for (let i = 0; i < options.length; i++) {
                    if (options[i].evaluationQuestionOptionId == optionId) {
                        total++;
                    }
                }
                return total;
            },
            showUnitClickedUi: function (unit) {
                this.clickedUnit = unit;
                this.showUnitUi = false;
            },
            nextPage: function () {
                if (Math.abs(this.offset) + 1 <= this.totalPages) {
                    this.offset++;
                    this.loadData();
                }
            },
            stripContent(content) {
                let regex = /(<([^>]+)>)/ig
                return content.replace(regex, "") + "..."
            },
            previousPage: function () {
                if (Math.abs(this.offset) - 1 >= 0) {
                    this.offset--;
                    this.loadData();
                }
            },
            searchEvent: function () {
                this.respondedUnits = [];
                this.totalPages = 0;
                this.totalItems = 0;
                this.offset = 0;
                this.loadData();

            },
            deleteEvaluation: function (id, index) {
                this.evaluations.splice(index, 1);
            },
            buttonEvent(item, action) {
                switch (action) {
                    case 'delete':
                        alert('deleted')
                        break
                    case 'status':
                        var activity = 'disabled'
                        if (item.status)
                            activity = 'activated'
                        alert(activity)
                        break
                    default:
                        break
                }
            },
        },
        created() {
            this.currentActiveEvaluationId = this.$route.params.id
            this.evaluationFilters()
            // this.loadData(10, 1)
        }
    }
</script>

<style>
</style>
