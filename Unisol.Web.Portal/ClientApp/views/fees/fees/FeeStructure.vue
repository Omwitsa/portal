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
          <button @click="printFeeStructure()" class="btn btn-primary btn-round waves-effect waves-light">
            <i class="fa fa-print" style="color:white;"></i> print
          </button>
        </div>
        </div>
      </div>

      <div
        class="col-md-12 card-header"
        style="padding: 10px;"
        v-if="allowedTranscriptViewDownload == 2">
        <div v-if="loadingStudentDetails" class="text-center">
          <small-spinner :loading="loadingStudentDetails"></small-spinner>
          <br>Fetching your department Details...
        </div>
        <div class="card-body text-we" v-if="!loadingStudentDetails">
          <div>
            <strong>Program : {{studentDetails.studentProgramme.programme}}</strong>
          </div>
          <div>
            <strong>Class : {{studentDetails.studentClass.className}}</strong>
          </div>
          <div>
            <strong>
              Session : {{studentDetails.studentSemester.yearOfStudy}}
              {{studentDetails.studentSemester.semester}}
            </strong>
          </div>
        </div>
      </div>

      <div class v-if="checkingTranscriptStatusHttp">
        <div class="text-center">
          <i class="fa fa-spin fa-spinner fa-3x"></i>
          <br>Checking settings...
        </div>
      </div>

      <div class="card-block" v-if="allowedTranscriptViewDownload==1&&!checkingTranscriptStatusHttp">
        <div class="col-md-12 alert-warning">
          <div v-if="!isParentfolderPresent">
            &nbsp;
            <h5 class="text-center">
              <i class="fa fa-exclamation-circle fa-5x"></i>
              <br>
              {{eligibleMessage}}
            </h5>&nbsp;
          </div>
        </div>
      </div>

      <div v-if="allowedTranscriptViewDownload==2">
        <div class v-if="loadingAcademicYears">
          <div class="text-center">
            <i class="fa fa-spin fa-spinner"></i>
            <br>Fetching Fee structure
          </div>
        </div>
        <div class="card-block" v-if="!loadingAcademicYears && academicYears">
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
                    :value="year"
                    :key="index"
                  >{{year.academicyear}}</option>
                </select>
              </div>

              <div class="col-md-1">
                <label>&nbsp;</label>
                <button
                  @click="getFeeStructure()"
                  class="btn btn-primary btn-round waves-effect waves-light"
                >
                  <small-spinner :loading="feesHttp"></small-spinner>Generate
                </button>
              </div>
            </div>
          </div>

          <div class="row table-responsive" v-if="feesStructure.length >0">
            <div class="col-md-12">
              <div class="panel-group" v-for="(semester,index) in feesStructure" :key="index">
                <div class="panel panel-primary">
                  <div class="panel-heading">
                    <h4 class="panel-title">
                      <a data-toggle="collapse" href="#collapse1">{{semester.term}}</a>
                    </h4>
                  </div>
                  <div class="panel-collapse">
                    <table class="table table-sm table-bordered">
                      <thead class>
                        <th>No.</th>
                        <th>Account</th>
                        <th style="text-align:right">Amount (KES)</th>
                      </thead>
                      <tbody>
                        <tr v-for="(fees,index) in semester.fees" :key="index">
                          <td>{{index+1}}</td>
                          <td>{{fees.account}}</td>
                          <td
                            style="text-align:right"
                          >{{fees.amount.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                        </tr>
                        <tr>
                          <td></td>
                          <td style="font-weight: bold">TOTAL</td>
                          <td
                            style="text-align:right; font-weight: bold"
                          >{{semester.total.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
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
    </div>
  </div>
</template>

<script>
import PdfPrinter from "../../../components/constants/PdfPrinter";
import AppData from "../../../components/constants/AppData";
export default {
  data() {
    return {
      feesStructure: [],
      sessionName: "",
      sessionTotalFees: "",
      tableData: [],
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
      loading: false,
      feesHttp: false,
      loadingStudentDetails: false,
      loadingAcademicYears: false,
      allowedTranscriptViewDownload: 0,
      checkingTranscriptStatusHttp: false,
      eligibleMessage: "",
      title: "Fees Structure",
      subTitle: "Fees Structure Based On Programme",
      user: this.$baseRead("user"),
      academicYears: null,
      semestersInAcademicYear: [],
      semesterGrades: [],
      semRefNumber: {},
      selectedAcademicYear: {}
    };
  },

  methods: {
    printFeeStructure() {
      var tableWidth = ["10%", "60%", "30%"];
      this.tableData = [];
      this.feesStructure.forEach(element => {
        this.sessionName = element.term;
        this.sessionTotalFees = element.total;
        var semisterFees = element.fees;
        this.getTableToPrint(semisterFees);
      });

      var lineWidth = 0.0;

      var Program = { text: " " + "Program: " + this.studentDetails.studentProgramme.programme, style: ["subHeader"] };
      var Class = {
        text: " " + "Class: " + this.studentDetails.studentClass.className,
        style: ["subHeader"]
      };
      var Session = {
        text:
          " " +
          "Session: " +
          this.studentDetails.studentSemester.yearOfStudy +
          " " +
          this.studentDetails.studentSemester.semester,
        style: ["subHeader"]
      };
      var underline = {
        text:
          "_____________________________________________________________________________________________",
        margin: [0, 0, 0, 5]
      };

      var detailsObject = {
        tableWidth: tableWidth,
        lineWidth: lineWidth,
        reportHeader: "FEES STRUCTURE",
        Program: Program,
        Class: Class,
        Session: Session,
        underline: underline,
        fileName: AppData.getFileName("FeeStructure", this.user.username)
      };

      PdfPrinter.printPdf(this.tableData, detailsObject);
    },
    getSemestersWithYear() {
      this.semestersInAcademicYear = this.selectedAcademicYear.semesters;
    },
    getTableToPrint(semisterFees) {
      var number = 1;
      var semister = [
        { text: " " + " ", style: ["sectionHeader"] },
        { text: " " + this.sessionName, style: ["sectionHeader"] },
        { text: " " + " ", style: ["sectionHeader"] }
      ];
      this.tableData.push(semister);

      var subHeader = [
        { text: " " + " ", style: ["subHeader"] },
        { text: " " + "Account", style: ["subHeader"] },
        { text: " " + "Amount (KES)", style: ["numeric"] }
      ];
      this.tableData.push(subHeader);
      semisterFees.forEach(element => {
        var rowData = [
          { text: " " + number++, style: ["paddedTable"] },
          { text: " " + element.account, style: ["paddedTable"] },
          {
            text:
              " " +
              element.amount.toLocaleString("en", { minimumFractionDigits: 2 }),
            style: ["numeric"]
          }
        ];
        this.tableData.push(rowData);
      });

      var totals = [
        { text: " " + " ", style: ["subHeader"] },
        { text: " " + "Total", style: ["subHeader"] },
        {
          text:
            " " +
            this.sessionTotalFees.toLocaleString("en", {
              minimumFractionDigits: 2
            }),
          style: ["numeric"]
        }
      ];
      this.tableData.push(totals);
    },
    loadAcademicYears() {
      this.loadingAcademicYears = true;
      this.academicYears = [];
      this.$http.get("commonutilities/GetStudentFeeStructureYears?progCode=" + this.studentDetails.studentProgramme.progCode)
        .then(result => {
          this.loadingAcademicYears = false;
          if (result.data.success) {
            this.academicYears = result.data.data;
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.loadingAcademicYears = false;
          this.$toastr("error", error.message);
        });
    },
    getFeeStructure() {
      this.feesStructure = [];
      var data = {
        userCode: this.user.username,
        stage: this.selectedAcademicYear.academicyear
      };
      if (!data.stage) {
        this.$toastr("error", "Error : Please select a year");
        return;
      }
      this.feesHttp = true;
      this.$http
        .post("finance/getStudentfeestructure", data)
        .then(result => {
          this.feesHttp = false;
          if (result.data.success) {
            this.feesStructure = result.data.data;
            this.feesStructure.forEach(element => {
              var sessionFees = element.fees;
              element.total = this.getSessionTotals(sessionFees);
            });
          } else {
            this.$toastr("error", "Alert : " + result.data.message);
          }
        })
        .catch(error => {
          this.feesHttp = false;
          this.$toastr("error", "Exception : " + error.message);
        });
    },
    getSessionTotals(sessionFees) {
      var total = 0;
      sessionFees.forEach(element => {
        total += element.amount;
      });
      return total;
    },
    getStudentDetails() {
      this.loadingStudentDetails = true;
      this.loading = false;
      this.$http.get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username)
        .then(result => {
          if (!result.data.data.studentSemester)
            result.data.data.studentSemester = "";
          this.loadingStudentDetails = false;
          if (result.data.success) {
            this.studentDetails = result.data.data;
            this.currentOpenSession.session = this.returnSemesterName();
            this.currentOpenSession.year = this.studentDetails.studentSemester.yearOfStudy;
            this.loadAcademicYears();
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.loadingStudentDetails = false;
          this.$toastr("error", error.message);
        });
      this.loadingStudentDetails = false;
    },
    returnSemesterName() {
      return this.studentDetails.studentSemester.semester;
    },
    checkSettingStatus: function() {
      this.allowedTranscriptViewDownload = 1;
      this.checkingTranscriptStatusHttp = true;
      this.$http
        .get("CommonUtilities/settingstatus?settingCode=009")
        .then(result => {
          this.checkingTranscriptStatusHttp = false;
          if (result.data.success) {
            this.allowedTranscriptViewDownload = 2;
            this.getStudentDetails();
          } else {
            this.allowedTranscriptViewDownload = 1;
            this.eligibleMessage = result.data.message;
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.checkingTranscriptStatusHttp = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.checkSettingStatus();
  }
};
</script>


