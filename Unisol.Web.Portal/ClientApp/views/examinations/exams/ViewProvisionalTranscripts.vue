<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <div class="row">
          <div class="col-md-2">
            <h5>{{title}}</h5>
            <span>{{subTitle}}.</span>
          </div>
          <div class="col-md-8"></div>
          <div class="col-md-2" v-if="allowedTranscriptViewDownload == 2">
            <button class="btn btn-primary btn-round waves-effect waves-light" @click="printTranscript()">
              <i class="fa fa-print" style="color:white;"></i> print
            </button>
          </div>
        </div>
      </div>

      <div class v-if="checkingTranscriptStatusHttp">
        <div class="text-center">
          <i class="fa fa-spin fa-spinner"></i>
          <br>Checking settings...
        </div>
      </div>

      <div
        class="card-block"
        v-if="allowedTranscriptViewDownload==1&&!checkingTranscriptStatusHttp"
      >
        <div class="alert alert-warning">
          <i class="fa fa-exclamation-circle"></i>
          {{eligibleMessage}}
        </div>
      </div>

      <div v-if="allowedTranscriptViewDownload==2">
        <div class v-if="loadingAcademicYears">
          <div class="text-center">
            <i class="fa fa-spin fa-spinner"></i>
            Fetching Academic Year...
          </div>
        </div>
        <div class="card-block" v-if="!loadingAcademicYears&&academicYears.length >0">
          <div class>
            <div class="form-group row">
              <div class="col-md-5">
                <label>Academic Year</label>
                <select
                  class="form-control"
                  @change="getSemestersWithYear()"
                  v-model="selectedAcademicYear">
                  <option disabled selected>--select year of study--</option>
                  <option
                    v-for="(year,index) in academicYears"
                    :key="index"
                    :value="year"
                  >{{year.academicyear}}</option>
                </select>
              </div>
              <div class="col-md-5">
                <label>Session</label>
                <select class="form-control" v-model="semRefNumber">
                  <option value selected>--All Semesters--</option>
                  <option
                    v-for="(semester,index) in semestersInAcademicYear"
                    :key="index"
                    :value="semester"
                  >{{semester.semester}}</option>
                </select>
              </div>
              <div class="col-md-1">
                <label>&nbsp;</label>
                <button
                  @click="getSemesterGrades()"
                  class="btn btn-primary btn-round waves-effect waves-light"
                >
                  <small-spinner :loading="gradesHttp"></small-spinner>Generate
                </button>
              </div>
            </div>
          </div>

          <div class="row table-responsive" v-if="semesterGrades.length>0" id="Transcript">
            <div class="col-md-12 card-header"
              style="padding: 10px;"
              v-if="allowedTranscriptViewDownload == 2">
              <div v-if="loadingStudentDetails" class="text-center">
                <small-spinner :loading="loadingStudentDetails"></small-spinner>
                <br>Fetch your department Details...
              </div>

              <div class="card-body" v-if="!loadingStudentDetails">
                <div class="row">
                  <div class="col-md-4"></div>
                  <div class="col-md-4 text-center">
                    <img v-if="!isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="30%" />
                    <img v-if="isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="70%" style="margin:3rem;" />
                  </div>
                  <div class="col-md-4"></div>
                </div>

                <div class="row">
                  <div class="col-md-12 text-center">
                    <h4>{{institutionInfo.setting.orgName}}</h4>
                    <h6 v-for="(contact, index) in institutionInfo.contactArray" :key="index">
                      {{contact}}
                    </h6>
                    <h4>{{registrarOfficeLabel}}</h4>
                    <h4>{{title}}</h4>
                  </div>
                </div>
              </div>
              <hr style="border: 1px solid">

              <div class="card-body text-we" v-if="!loadingStudentDetails">
                <div class="row">
                  <div class="col-md-8">
                    <div>
                      <strong>STUDENT NAME:</strong> {{user.userRegister.names.toUpperCase()}}
                    </div>
                    <div>
                      <strong>PROGRAMME:</strong> {{studentDetails.studentProgramme.programme.toUpperCase()}}
                    </div>
                    <div>
                      <strong>DEPARTMENT:</strong> {{studentDetails.studentDeparment.department.toUpperCase()}}
                    </div>
                    <div>
                      <strong>SCHOOL/FACULTY:</strong> {{studentDetails.studentDeparment.school.toUpperCase()}}
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div>
                      <strong>REG NO:</strong> {{user.username.toUpperCase()}}
                    </div>
                    <div>
                      <strong>ADMISSION YEAR:</strong> {{studentDetails.studentClass.admissionYear}}
                    </div>
                     <div>
                      <strong>YEAR OF STUDY:</strong> {{session.toUpperCase()}}
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-12" v-if="!isTvetProg">
              <table class="table table-sm table-bordered"> 
                <thead class>
                  <!-- <th>No.</th> -->
                  <th>UNIT CODE</th>
                  <th>UNIT TITLE</th>
                  <th>{{academicHours}}</th>
                  <th>GRADE</th>
                </thead>  
                <tbody v-for="(Grades, index) in semesterGrades" :key="index">
                  <tr v-for="(unit, index1) in Grades.units" :key="index1">
                    <!-- <td>{{index1 + 1}}</td> -->
                    <td>{{unit.unitCode.toUpperCase()}}</td>
                    <td>{{unit.unitName.toUpperCase()}}</td>
                    <!-- <td v-if="!isEmbu">{{unit.creditUnits}}</td> -->
                    <td>{{unit.unitHours}}</td>
                    <td>{{unit.grade.toUpperCase()}}</td>
                  </tr>
                </tbody>
              </table>
            </div>

            <div class="col-md-12" v-if="isTvetProg">
              <table class="table table-sm table-bordered">
                <thead class>
                  <th>UNIT CODE</th>
                  <th>UNIT TITLE</th>
                  <th>C.A.T</th>
                  <th>EXAM</th>
                  <th>TOTAL</th>
                  <th>GRADE</th>
                </thead>
                <tbody v-for="(Grades, index) in semesterGrades" :key="index">
                  <tr v-for="(unit, index1) in Grades.units" :key="index1">
                    <td>{{unit.unitCode.toUpperCase()}}</td>
                    <td>{{unit.unitName.toUpperCase()}}</td>
                    <td>{{unit.cat}}</td>
                    <td>{{unit.exam}}</td>
                    <td>{{unit.total}}</td>
                    <td>{{unit.grade.toUpperCase()}}</td>
                  </tr>
                </tbody>
              </table>
            </div>

            <div class="row col-md-12">
              <hr>
              <strong>{{average}}</strong>
              <hr>
            </div>

            <div class="row col-md-12" v-if="recommendation">
              <hr>
              <strong>RECOMMENDATION: {{recommendation}}</strong>
              <hr>
            </div>

            <div class="container-fluid">
              <div class="row">
              <div class="col-md-4">
                <h5><u>Key Grading System</u></h5>
                <div class="row">
                  <div class="col-md-6">Grade</div>
                  <div class="col-md-6">Points</div>
                </div>

                <div class="row" v-for="(grade,index) in gradeSettings.grading" :key="index">
                  <div class="col-md-6">{{grade.range}}</div>
                  <div class="col-md-6">{{grade.points}}</div>
                </div>
              </div>

              <div class="col-md-4"></div>
              <div class="col-md-4">
                <h5><u>Other Keys</u></h5>
                <div class="row">
                  <div class="col-md-6">Symbol</div>
                  <div class="col-md-6">Names</div>
                </div>

                <div class="row" v-for="(markSymbols,index) in gradeSettings.markSymbols" :key="index">
                  <div class="col-md-6">{{markSymbols.symbol}}</div>
                  <div class="col-md-6">{{markSymbols.names}}</div>
                </div>
              </div>
            </div><br>

            <div class="row">
              <div class="col-md-12 text-center">
                <h6>{{departmentHeadSig}}</h6>
                <h6>{{transcriptNote}}</h6>
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
import PdfPrinter from "../../../components/constants/PdfPrinter"
import AppData from "../../../components/constants/AppData";
export default {
  data() {
    return {
      examCardUnits: [],
      isLaikipia: false,
      studentDetails: {
        studentProgramme: {
          programme: ""
        },
        studentClass: {
          className: ""
        },
        studentSemester: {
          yearOfStudy: "",
          semester: ""
        }
      },
      currentOpenSession: {
        year: "",
        session: ""
      },
      gradeSettings: {
        grading: [],
        markSymbols: []
      },
      average: "",
      recommendation: "",
      isTvetProg: false,
      isEmbu: false,
      loading: false,
      gradesHttp: false,
      loadingStudentDetails: false,
      loadingAcademicYears: false,
      allowedTranscriptViewDownload: 0,
      checkingTranscriptStatusHttp: false,
      eligibleMessage: "",
      academicHours: "HOURS",
      title: "Provisional Transcript",
      registrarOfficeLabel: "OFFICE OF THE REGISTRAR - ACADEMICS",
      departmentHeadSig: "Head of Department: ___________________________________________________Sign______________________Date________________",
      subTitle: "",
      user: this.$baseRead("user"),
      transcriptNote: "",
      academicYears: [],
      semestersInAcademicYear: [],
      semesterGrades: [],
      semRefNumber: {},
      selectedAcademicYear: {},
      settings: JSON.parse(localStorage.getItem("settings")),
      institutionInfo: JSON.parse(localStorage.getItem('institutionInfo')),
      institutionContacts: []
    };
  },
  computed: {
    session(){
      this.title = this.semRefNumber.semester ? "RESULT SLIP" : this.title
      var year = this.semestersInAcademicYear ? this.semestersInAcademicYear[0] : ""
      var selectedYear = year ? year.yearOfStudy : ""
      var yearSem = this.semRefNumber.semester ? `${this.semRefNumber.yearOfStudy} ${this.semRefNumber.semester}` : selectedYear
      return yearSem
    }
  },
  methods: {
    printTranscript() {
      if(this.settings.initials === "KNP"){
        this.printWithPdfPrinter();
      }
      else{
        this.$htmlToPaper("Transcript");
      }
    },
    printWithPdfPrinter(){
      var tableData = []
      var tableWidth = ['auto', '50%', 'auto', 'auto',]
      if(this.isTvetProg){
        tableWidth = ['auto', '40%', 'auto', 'auto', 'auto', 'auto']
      }
   
      var feeStatementHeader = [
          // {text: 'No.', style: 'sectionHeader'},
          {text: 'Unit Code', style: 'sectionHeader'},
          {text: 'Unit Name', style: 'sectionHeader'},
          {text: this.academicHours, style: 'sectionHeader'},
          {text: 'Grade', style: 'sectionHeader'},
      ]

      if(this.isTvetProg){
        feeStatementHeader = [
          // {text: 'No.', style: 'sectionHeader'},
          {text: 'Unit Code', style: 'sectionHeader'},
          {text: 'Unit Name', style: 'sectionHeader'},
          {text: 'C.A.T', style: 'sectionHeader'},
          {text: 'EXAM', style: 'sectionHeader'},
          {text: 'Total', style: 'sectionHeader'},
          {text: 'Grade', style: 'sectionHeader'},
        ]
      }
      tableData.push(feeStatementHeader)
      var number = 1
      this.semesterGrades.forEach(s => {
        s.units.forEach(element => {
          var rowData = [
              // {text: ' ' +   number++, style: ['paddedTable']},
              {text: ' ' +  element.unitCode, style: ['paddedTable']},
              {text: ' ' +  element.unitName, style: ['paddedTable']},
              {text: ' ' +  element.unitHours, style: ['paddedTable']},
              {text: ' ' +  element.grade, style: ['paddedTable']}
          ] 

          if(this.isTvetProg){
            rowData = [
              // {text: ' ' +   number++, style: ['paddedTable']},
              {text: ' ' +  element.unitCode, style: ['paddedTable']},
              {text: ' ' +  element.unitName, style: ['paddedTable']},
              {text: ' ' +  element.cat, style: ['paddedTable']},
              {text: ' ' +  element.exam, style: ['paddedTable']},
              {text: ' ' +  element.total, style: ['paddedTable']},
              {text: ' ' +  element.grade, style: ['paddedTable']}
            ]
          }

          tableData.push(rowData)
        })
      });
      var username = {text: ' ' +   "Name: "+ this.user.userRegister.names, style: ['subHeader']}
      var usercode = {text: ' ' +   "Reg No: "+ this.user.username, style: ['subHeader']}
      var school = {text: ' ' +   "School: "+ this.studentDetails.studentDeparment.school, style: ['subHeader']}
      var Program = {text: ' ' +   "Program: "+ this.studentDetails.studentProgramme.programme, style: ['subHeader']}
      var Class = {text: ' ' +   "Class: "+ this.studentDetails.studentClass.className, style: ['subHeader']}
      var admissionYear = {text: ' ' +   "Admission Year: "+ this.studentDetails.studentClass.admissionYear, style: ['subHeader']}
      var Session = {text: ' ' +   "Year of study: "+ this.session, style: ['subHeader']}
      var underline = {
          text: "_____________________________________________________________________________________________",
          margin: [0, 0, 0, 5]
      }

      var infoTableWidth = ['auto', 'auto', '40%', 'auto', 'auto']
      var infoTableData = []
      var infoTableHeader = [
          {text: 'Grade', style: 'sectionHeader'},
          {text: 'Points', style: 'sectionHeader'},
          {text: ' ', style: 'sectionHeader'},
          {text: 'Symbol', style: 'sectionHeader'},
          {text: 'Names', style: 'sectionHeader'},
      ]

    infoTableData.push(infoTableHeader)

      var infoTable = {
          table: {
              headerRows: 0,
              widths: infoTableWidth,
              body: infoTableData,
          },
          layout: {
              hLineWidth: function (i, node) {
                  return (i === 0 || i === node.table.body.length) ? 0.0 : detailsObject.lineWidth;
              },
              vLineWidth: function (i, node) {
                  return (i === 0 || i === node.table.widths.length) ? 0.0 : 0.0;
              },
              hLineColor: function (i, node) {
                  return (i === 0 || i === node.table.body.length) ? 'black' : 'black';
              },
              vLineColor: function (i, node) {
                  return (i === 0 || i === node.table.widths.length) ? 'black' : 'black';
              },
              paddingLeft: function (i, node) {
                  return 4;
              },
              paddingRight: function (i, node) {
                  return 4;
              },
              paddingTop: function(i, node) { return 2; },
              paddingBottom: function(i, node) { return 2; }
          }
      }

      var grading = this.gradeSettings.grading
      var markSymbols = this.gradeSettings.markSymbols
      var pos = 0
      if(grading.length > markSymbols.length){
          grading.forEach(element => {
          var markSymbol = pos >= markSymbols.length? "" : markSymbols[pos].symbol
          var markName = pos >= markSymbols.length? "" : markSymbols[pos].names
            var rowData = [
                {text: element.range, style: 'paddedTable'},
                {text: element.points, style: 'paddedTable'},
                {text: ' ', style: 'paddedTable'},
                {text: markSymbol, style: 'paddedTable'},
                {text: markName, style: 'paddedTable'},
            ]
            infoTableData.push(rowData)
            pos++
        });
      }
      else{
        markSymbols.forEach(element => {
          var range = pos >= grading.length? "" : grading[pos].range
          var points = pos >= grading.length? "" : grading[pos].points
            var rowData = [
                {text: range, style: 'paddedTable'},
                {text: points, style: 'paddedTable'},
                {text: ' ', style: 'paddedTable'},
                {text: element.symbol, style: 'paddedTable'},
                {text: element.names, style: 'paddedTable'},
            ]
            infoTableData.push(rowData)
            pos++
        });
      }
       
      var transcriptNote = {text: ' ' +  this.transcriptNote, style: ['content']}
      var average = {text: ' ' +  this.average, style: ['content']}
      var recommendation = {text: ' ' +  this.recommendation, style: ['content']}
      var depSigatureTxt = '\n\n ' + this.departmentHeadSig
      var departmentSignature = {text: ' ' +  depSigatureTxt, style: ['paddedTable']}
      var registererLabel ={ text: '\n ' + this.registrarOfficeLabel, style: ['subHeader', 'centerData'] }
      var fileName = this.title.replace(" ", "");
      var detailsObject = {
          tableWidth: tableWidth,
          registererLabel: registererLabel,
          reportHeader: this.title,
          school: school,
          Program: Program,
          username: username,
          usercode: usercode,
          Class: Class,
          admissionYear: admissionYear,
          Session: Session,
          underline: underline,
          average: average,
          recommendation: recommendation,
          infoTable: infoTable,
          departmentSignature: departmentSignature,
          transcriptNote: transcriptNote,
          fileName: AppData.getFileName(fileName, this.user.username)
      }

      PdfPrinter.printPdf(tableData, detailsObject)
    },

    loadData() {
      this.loading = true;
      this.examCardUnits = [];
      this.$http
        .get("examcard/GetStudentExamCard?userCode=" + this.user.username)
        .then(result => {
          this.loading = false;
          this.examCardUnits = result.data.data;
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    },
    getSemestersWithYear() {
      this.semestersInAcademicYear = this.selectedAcademicYear.semesters;
    },
    loadAcademicYears() {
      this.loadingAcademicYears = true;
      this.academicYears = [];
      this.$http
        .get("transcript/GetStudentPreviousAcademicYears?userCode=" + this.user.username)
        .then(result => {
          this.loadingAcademicYears = false;
          if (result.data.success) {
            this.academicYears = result.data.data.data;
            this.title = this.academicYears[0].institution == "UOEM" ? "Academic Result Slip" : this.title
          } else {
            this.$toastr("error", error.message);
          }
        })
        .catch(error => {
          this.loadingAcademicYears = false;
          this.$toastr("error", error.message);
        });
    },
    getSemesterGrades() {
      this.gradesHttp = true;
      this.semesterGrades = [];
      var data = {
        ref: this.semRefNumber.ref,
        userCode: this.user.username,
        academicYear: this.selectedAcademicYear.academicyear,
        semester: this.semRefNumber.semester
      };
      if (!data.academicYear) {
        this.$toastr("error", "Error : Please select both year");
        this.gradesHttp = false;
        return;
      }
      this.$http
        .post("transcript/GetStudentProvivisonalTranscript", data)
        .then(result => {
          this.gradesHttp = false;
          if (result.data.success) {
            this.semesterGrades = result.data.data.results;
            this.average = `Averages:> | Current..: ${result.data.data.average}% | Cumulative..: ${result.data.data.cumulativeAverage}%`
            this.average = result.data.data.institutionInitials == "LU" ? this.average : ""
            this.isEmbu = result.data.data.institutionInitials == "UOEM" ? true : false;
            this.isTvetProg = this.semesterGrades[0].isTivetTranscript;
            this.gradeSettings = result.data.data.gradeSettings;
            this.recommendation = result.data.data.remarks;
            this.transcriptNote = result.data.data.transcriptNote ? result.data.data.transcriptNote : "NB: This result slip is issued without any erasures or alterations.   Not Valid without Official Stamp"
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.gradesHttp = false;
          this.$toastr("error", "Exception : " + error.message);
        });
    },
    getStudentDetails() {
      this.loadingStudentDetails = true;
      this.loading = false;
      this.$http.get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.studentDetails = result.data.data;
            this.currentOpenSession.session = this.studentDetails.studentSemester ? this.studentDetails.studentSemester.semester.substring(0, this.studentDetails.studentSemester.semester.length - 5) : "";
            this.currentOpenSession.year = this.studentDetails.studentSemester ? this.studentDetails.studentSemester.yearOfStudy : "";
          } else {
            this.$toastr("error", error.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loadingStudentDetails = false;
    },
    checkSettingStatus: function() {
      this.allowedTranscriptViewDownload = 1;
      this.checkingTranscriptStatusHttp = true;
      this.$http.get("CommonUtilities/settingstatus?settingCode=004")
      .then(result => {
        this.checkingTranscriptStatusHttp = false;
        if (result.data.success) {
          this.allowedTranscriptViewDownload = 2;
        } else {
          this.allowedTranscriptViewDownload = 1;
          this.eligibleMessage = result.data.message;
          this.$toastr("error", result.data.message);
          this.loadingStudentDetails = false;
        }
      })
      .catch(error => {
        this.checkingTranscriptStatusHttp = false;
        this.$toastr("error", error.message);
        this.loadingStudentDetails = false;
      });
    }
  },
  created() {
    this.isLaikipia = this.settings.initials == 'LU' ? true : false;
    this.checkSettingStatus();
    this.getStudentDetails();
    this.loadAcademicYears();
  }
};
</script>


