<template>
    <div class="page-body">
        <div class="card" v-if="isAdmin && !canPrint">
            <div class="card-header">

            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2" style="text-align: right">Admin No:</div>
                    <div class="col-md-4">
                        <fg-input type="text" v-model="user.username" />
                    </div>
                    <div class="offset-md-1">
                        <submit-button
                            :class="[{ disabled: loading }]"
                            :loading="loading"
                            title="Generate Examcard"
                            v-on:submit="checkSettingStatus"
                            styling="btn btn-primary btn-round waves-effect waves-light "
                        />
                    </div>
                </div>
            </div>
        </div>
        <div class="card" v-if="canPrint"> 
            <div class="card-header">
                <div class="row">
                    <div class="col-md-10">
                        <h5>{{title}}</h5>
                        <span>{{subTitle}}.</span>
                        <span><a class="card-header-right" href="#" target="_self" data-toggle="modal" data-target="#examCardHistory"
                            @click="showLogHistory()"><i class="fa fa-download"></i> Download History
                        </a></span>
                    </div>
                    <div class="col-md-2" v-if="allowedExamCardDownload && cardUnitsAvailable"><br>
                        <button class="btn btn-primary btn-sm" @click="printExamcard()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>
            
            <div class="" v-if="checkingExamCardStatusHttp">
                <div class="text-center">
                    <i class="fa fa-spin fa-spinner fa-3x"></i><br>
                    Checking settings...
                </div>
                <div class="" v-if="loading">
                    <div class="text-center">
                        <i class="fa fa-spin fa-spinner fa-3x"></i><br>
                        Fetching examination card...
                    </div>
                </div>
            </div>

            <div class="card-block" v-if="!allowedExamCardDownload && !checkingExamCardStatusHttp && cardUnitsAvailable && !loading">
                <div class="col-md-12 alert-warning">
                    <div> &nbsp;
                        <h5 class="text-center"> <i class="fa fa-exclamation-circle fa-5x"></i><br>{{eligibleMessage}} </h5> 
                        &nbsp;
                    </div>
                </div>
            </div>
            <div class="card-block" v-if="!checkingExamCardStatusHttp && !cardUnitsAvailable">
                <div class="col-md-12 alert-warning">
                    <div> &nbsp;
                        <h5 class="text-center"> <i class="fa fa-exclamation-circle fa-5x"></i><br>{{eligibleMessage}}</h5> 
                        &nbsp;
                    </div>
                </div>
            </div>

            <div class="card-block" v-if="!loading&&examCardUnits.length >0" id="examcard">
                <div class="row">
                    <div class="col-md-5" style="font-size:12px">
                        <div class="row">
                            <div class="col-md-4">
                                <img :src="settings.logoImageUrl" :alt="settings.Initials" width="100%"/>
                            </div>
                            <div class="col-md-8">
                                {{institutionInfo ? institutionInfo.orgName : ""}} <br> 
                                {{institutionInfo ? institutionInfo.box : ""}} <br>
                                {{institutionInfo ? institutionInfo.tel : ""}}<br>
                                {{institutionInfo ? institutionInfo.email : ""}}<br>
                            </div>
                        </div>
                        <div v-if="loadingStudentDetails" class="text-center">
                            <small-spinner :loading="loadingStudentDetails"></small-spinner>
                            <br>
                            Fetch your department Details...
                        </div>
                        <div v-if="!loadingStudentDetails">
                            <div>
                                <strong>NAME :</strong>{{user.userRegister.names.toUpperCase()}}
                            </div>
                            <div>
                                <strong>REG NO :</strong>{{user.username}}
                            </div>
                            <div>
                                <strong>SERIAL NUMBER : </strong>{{serialNo}}
                            </div>
                            <div>
                                <strong>PROGRAM :</strong>{{studentDetails.studentProgramme.programme}}
                            </div>
                            <div>
                                <strong>DEPARTMENT : </strong>{{studentDetails.studentDeparment.department}}
                            </div>
                            <div>
                                <strong>CLASS : </strong>{{studentDetails.studentClass.className}}
                            </div>
                            <div>
                                <strong> SESSION : </strong>{{studentDetails.studentSemester.yearOfStudy}}
                                    {{studentDetails.studentSemester.semester}}
                            </div>
                        </div><br><br>

                        <div class="row">
                            <div class="col-md-6">
                                <P>_____________________</P>
                                <strong>REGISTRAR’S SIGNATURE</strong>
                            </div>
                            <div class="col-md-6">
                                <P>____________________</P>
                                <strong>DATE AND STAMP</strong>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-7 table-responsive">
                        <table class="table table-sm table-bordered">
                            <thead class="">
                                <th>Unit Code</th>
                                <th>Unit Name</th>
                                <th>Sign</th>
                            </thead>
                             <tbody>
                                <tr v-for="(unit ,index) in examCardUnits" :key="index">
                                    <td>{{unit.unitCode}}</td>
                                    <td>{{unit.names}}</td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <b>Notes:</b><br>
                        <p v-if="settings.ExamCardNotes">{{settings.ExamCardNotes}}</p>
                        <ol v-if="!settings.ExamCardNotes">
                            <li>This card must be presented to the invigilator at each examination</li>
                            <li>The name appearing on this card is the name that will appear on your certificate upon graduation.Report any anomalies or errors to the Registrar</li>
                            <li>Your registration number and not your name must appear on every answer book or supplementary sheet</li>
                        </ol>
                    </div>
                </div>
            </div>
            <div class="clearfix">
                &nbsp;
            </div>
        </div>
        <div class="modal fade" id="examCardHistory" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header text-left bg-primary">

                        <div class="h5">Exam Card Download History</div>

                        <span class=""></span>
                    </div>
                    <div class="modal-body">
                        <small-spinner :loading="loadingLogHttp"></small-spinner>
                        <ul class="list-group">
                            <li class="list-group-item"  style="border-left: none;border-right:none;"
                                v-for="(log,index) in examLogs" :key="index" v-if="!loadingLogHttp">
                                <span><b>{{index+1}} {{dateFormatter.ReturnDate(log.dateCreated,"DD MMM YYYY H:MM")}} {{log.semester}}</b></span><br>

                                <p>
                                    <b>{{log.action}}</b><br>
                                    {{log.actionDescription}}
                                </p>
                            </li>
                        </ul>
                    </div>

                </div>

            </div>
        </div>
    </div>
</template>


<script>
import dateFormatter from "../../../components/constants/DateFomatter"
import PdfPrinter from "../../../components/constants/PdfPrinter"
import AppData from "../../../components/constants/AppData";
    export default {
        data() {
            return {
                examCardUnits: [],
                examLogs: [],
                settings: {},
                isAdmin: false,
                canPrint: false,
                dateFormatter :dateFormatter,
                studentDetails: {
                    studentProgramme: {
                        programme: ''
                    },
                    studentClass: {
                        className: ''
                    },
                    studentSemester: {
                        yearOfStudy: '',
                        semester: ''
                    }
                },
                currentOpenSession: {
                    year: '',
                    session: ''
                },
                loading: false,
                loadingStudentDetails: false,
                loadingLogHttp: false,
                allowedExamCardDownload: false,
                serialNo: "",
                examCardNote: "",
                checkingExamCardStatusHttp: false,
                cardUnitsAvailable: false,
                eligibleMessage: '',
                title: "Previous Exam Card",
                subTitle: "Show exam card for previous semester",
                user: this.$baseRead('user'),
                settings: JSON.parse(localStorage.getItem('settings')),
                institutionInfo: JSON.parse(localStorage.getItem("institutionInfo"))
            }
        },

        methods: {
            loadData() {
                this.loading = true
                this.examCardUnits = []
                this.$http.get("examcard/GetStudentExamCard?userCode=" + this.user.username + "&isPreviousTermCard=" + true)
                    .then(result => {
                        this.loading = false
                        if(result.data.success){
                            this.cardUnitsAvailable = true
                            this.examCardUnits = result.data.data
                        }
                        else{
                            this.eligibleMessage = result.data.message
                        }
                    })
                    .catch(error => {
                        this.loading = false
                        this.$toastr("error", error.message)
                    })

            },
            checkCurrentSemester(semester, stage) {
                return semester === this.returnSemesterName() && stage === this.studentDetails.studentSemester.yearOfStudy;
            },
            getStudentDetails() {
                this.loadingStudentDetails = true
                this.loading = false
                this.$http
                .get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username + "&isPreviousTermCard=" + true)
                .then(result => {
                    this.studentDetails = result.data.data;
                    this.user.userRegister.names = this.studentDetails.studentName
                    var registerId = this.studentDetails.studentSemester ? this.studentDetails.studentSemester.registerId : ""
                    var semesterId = this.studentDetails.studentSemester ? this.studentDetails.studentSemester.semesterId : ""
                    this.serialNo = `0${registerId}-${semesterId}`
                    this.currentOpenSession.session = this.returnSemesterName();
                    this.currentOpenSession.year = this.studentDetails.studentSemester ? this.studentDetails.studentSemester.yearOfStudy : "";
                    this.loadingStudentDetails = false
                    this.loadData();
                })
                .catch(error => {
                    this.loadingStudentDetails = false
                    this.$toastr("error", error.message)
                })

            },
            showLogHistory() {
                this.loadingLogHttp = true;
                this.$http
                .get("portallogs/getexaminationloggingHistory?userCode=" + this.user.username)
                .then(result => {
                    this.loadingLogHttp = false;
                    if (result.data.success) {
                        this.examLogs = result.data.data;
                    } else {
                        this.$toastr("error", "No Logs")
                    }
                })
                .catch(error => {
                    this.loadingLogHttp = false
                    this.$toastr("error", error.message)
                })
            },
            openCurrentSession(year, session) {
                this.currentOpenSession.session = session;
                this.currentOpenSession.year = year;
            },
            returnSemesterName() {
                return this.studentDetails.studentSemester ? this.studentDetails.studentSemester.semester : "";
            },
            checkSettingStatus: function () {
                this.canPrint = true
                this.examCardNote = `1.This card must be presented to the invigilator at each examination
                2.The name appearing on this card is the name that will appear on your certificate upon graduation.Report any anomalies or errors to the Registrar
                3.Your registration number and not your name must appear on every answer book or supplementary sheet.`;
                this.examCardNote = this.settings.ExamCardNotes ? this.settings.ExamCardNotes : this.examCardNote
                this.allowedExamCardDownload = 1;
                this.checkingExamCardStatusHttp = true;
                this.$http
                    .get("CommonUtilities/settingstatus?settingCode=002")
                    .then(result => {
                        this.checkingExamCardStatusHttp = false;
                        if (result.data.success) {
                            this.allowedExamCardDownload = true;
                            this.getStudentDetails();
                        } else {
                            this.allowedExamCardDownload = false;
                            this.eligibleMessage = result.data.message;
                            this.$toastr("error", result.data.message)
                        }

                    })
                    .catch(error => {
                        this.checkingExamCardStatusHttp = false;
                        this.$toastr("error", error.message)
                    })
            },
            printExamcard() {
                this.canPrint = true
                if(this.isAdmin){
                    this.canPrint = false
                    this.user.username = ""
                    this.examCardUnits = []
                }
                this.saveExamCardLog()
                this.$htmlToPaper("examcard");
            },

            printExamCard() {
                this.saveExamCardLog()
                var tableData = []
                var tableWidth = ['auto', '50%', 'auto']
                var feeStatementHeader = [
                    {text: 'Unit Code', style: 'subHeader'},
                    {text: 'Unit Name', style: 'subHeader'},
                    {text: 'Sign', style: 'subHeader'},
                ]

                tableData.push(feeStatementHeader)

                var number = 1

                this.examCardUnits.forEach(element => {
                    var rowData = [
                        {text: ' ' +  element.unitCode, style: ['paddedTable']},
                        {text: ' ' +  element.names, style: ['paddedTable']},
                        {text: ' ', style: ['paddedTable']},
                    ]

                    tableData.push(rowData)
                });

                var username = {text: ' ' +   "Name: "+ this.user.userRegister.names, style: ['subHeader']}
                var usercode = {text: ' ' +   "Reg No: "+ this.user.username, style: ['subHeader']}
                var Program = {text: ' ' +   "Program: "+ this.studentDetails.studentProgramme.programme, style: ['subHeader']}
                var Class = {text: ' ' +   "Class: "+ this.studentDetails.studentClass.className, style: ['subHeader']}
                var Session = {text: ' ' +   "Session: "+ this.studentDetails.studentSemester.yearOfStudy+ " "+this.studentDetails.studentSemester.semester, style: ['subHeader']}
                var SerialNo = {text: ' ' +   "Serial No: "+ this.serialNo, style: ['subHeader']}
                var underline = {
                    text: "_____________________________________________________________________________________________",
                    margin: [0, 0, 0, 5]
                }
                var signature = {
                    text: "__________________________________________",
                    margin: [0, 0, 0, 5]
                }
                var registrarSign = {text: ' ' +   "REGISTRAR’S SIGNATURE:", style: ['subHeader']}
                var stamp = {text: ' ' +   "DATE AND STAMP", style: ['subHeader']}
                var notes = {text: ' ' +   "Notes", style: ['subHeader']}
                var notesContent = {text: ' ' +  this.examCardNote,
                 style: ['content']}

                var detailsObject = {
                    tableWidth: tableWidth,
                    reportHeader: "EXAM CARD",
                    SerialNo:SerialNo,
                    username: username,
                    usercode: usercode,
                    Program: Program,
                    Class: Class,
                    Session: Session,
                    underline: underline,
                    registrarSign: registrarSign,
                    stamp: stamp,
                    notes:notes,
                    notesContent: notesContent,
                    signature: signature,
                    fileName: AppData.getFileName("ExamCard", this.user.username)
                }
                PdfPrinter.printPdf(tableData, detailsObject)
            },
            saveExamCardLog() {
                var data = {
                    adminNo: this.user.username,
                    action: 'Downloaded exam card',
                    semester: this.studentDetails.studentSemester.semester,
                    dateCreated: new Date(),
                    actionDescription: 'Downloaded exam card from the portal for ' + this.studentDetails.studentSemester.yearOfStudy + " " + this.studentDetails.studentSemester.semester
                }
                this.$http
                .post("PortalLogs/saveexaminationlogging", data)
                .then(result => {
                    this.gradesHttp = false;
                    if (result.data.success) {

                    } else {
                        this.$toastr("error", "Alert : " + result.data.message + " : " + data.semester);
                         if (result.data.notAuthenticated) {
                            this.$router.replace({ name: "401-forbidden" });
                          }
                    }
                })
                .catch(error => {
                    this.gradesHttp = false;
                    this.$toastr("error", "Exception : " + error.message)
                })
            }
        },
        created() {
            if(this.user.role === 3){
                this.canPrint = true
                this.checkSettingStatus()
            }
            if(this.user.role === 1){
                this.user.username = ""
                this.isAdmin = true
                this.user.role = 3
            }
           
        }
    }
</script>


