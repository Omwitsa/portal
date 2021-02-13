<template>
  <div class="page-body">
    <div class="card">
      <div class="slide"></div>
      <div class="card-header">
        <div class="row">
          <div class="col-md-2">
            <h5>{{title}}</h5>
            <span>{{subTitle}}.</span>
          </div>
          <div class="col-md-8"></div>
          <div class="col-md-2" v-if="allowedFeeStatusDownload == 2">
            <button
              class="btn btn-primary btn-round waves-effect waves-light"
              :disabled="checkingFeesStatusHttp"
              @click="printFeesStatement()"
            >
              <i class="fa fa-print" style="color:white;"></i> print
            </button>
          </div>
        </div>
      </div>

      <div class v-if="checkingFeesStatusHttp">
        <div class="text-center">
          <i class="fa fa-spin fa-spinner"></i>
          <br />Checking fees status...
        </div>
      </div>

      <div class="card-block" v-if="allowedFeeStatusDownload==1&&!checkingFeesStatusHttp">
        <div class="col-md-12 alert-warning">
          <div v-if="!isParentfolderPresent">
            &nbsp;
            <h5 class="text-center">
              <i class="fa fa-exclamation-circle fa-5x"></i>
              <br />
              {{eligibleMessage}}
            </h5>&nbsp;
          </div>
        </div>
      </div>

      <div v-if="allowedFeeStatusDownload==2">
        <div
          class="col-md-12 card-header"
          style="padding: 10px;"
          v-if="allowedFeeStatusDownload == 2"
        >
          <div v-if="loadingStudentDetails" class="text-center">
            <small-spinner :loading="loadingStudentDetails"></small-spinner>
            <br />Fetching your department Details...
          </div>
        </div>

        <div class v-if="loading">
          <div class="text-center">
            <i class="fa fa-spin fa-spinner"></i>
            <br />Fetching fee Statement..
          </div>
        </div>

        <div class="card-block" id="FeeStatement" v-if="!loading && feesStatement.length >0">
          <div class="card-body" v-if="!loadingStudentDetails">
            <div class="row">
              <div class="col-md-4"></div>
              <div  class="col-md-4 text-center">
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

          <div class="card-body text-we" v-if="!loadingStudentDetails" >
            <div class="row">{{session}}
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
                  <strong>YEAR OF STUDY:</strong> {{session}}
                </div>
                <div>
                  <strong>STUDENT TYPE:</strong> {{studentDetails.sponsor}}
                </div>
              </div>
            </div>
          </div>

          <div class="row" id="willy">
            <div class="col-md-12 table-responsive">
              <table class="table table-sm table-bordered">
                <thead class>
                  <th>No.</th>
                  <th>Date</th>
                  <th>Ref</th>
                  <th>Description</th>
                  <th style="text-align:right">Debit (KES)</th>
                  <th style="text-align:right">Credit (KES)</th>
                  <th style="text-align:right">Balance (KES)</th>
                </thead>
                <tbody>
                  <tr v-for="(txn ,index) in feesStatement " :key="index">
                    <td>{{index+1}}</td>
                    <td>{{ txn.rdate }}</td>
                    <td>{{txn.ref}}</td>
                    <td>
                      {{txn.description}}
                      <br />
                      <small>{{txn.notes}}</small>
                    </td>
                    <td style="text-align:right">
                      <span v-if="!txn.debit==0">{{ txn.debit.substr(4) }}</span>
                    </td>
                    <td style="text-align:right">
                      <span v-if="!txn.credit==0">{{ txn.credit.substr(4) }}</span>
                    </td>
                    <td style="text-align:right">{{ txn.balance.substr(4) }}</td>
                  </tr>
                  <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="font-weight: bold">TOTAL</td>
                    <td style="text-align:right; font-weight: bold">{{totals.debit.substr(4) }}</td>
                    <td style="text-align:right; font-weight: bold">{{totals.credit.substr(4) }}</td>
                    <td style="text-align:right; font-weight: bold">{{ calculateBalance(totals) }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

      <div class="clearfix">&nbsp;</div>
    </div>
  </div>
</template>
<script>
import dateFormatter from "../../../components/constants/DateFomatter";
import PdfPrinter from "../../../components/constants/PdfPrinter";
import AppData from "../../../components/constants/AppData";
import jsPDF from 'jspdf'

export default {
  data() {
    return {
      feesStatement: [],
      totals: {},
      fuculty: {},
      examLogs: [],
      dateFormatter: dateFormatter,
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
      loading: false,
      loadingStudentDetails: false,
      loadingLogHttp: false,
      allowedFeeStatusDownload: 0,
      checkingFeesStatusHttp: false,
      eligibleMessage: "",
      title: "Fees Statement",
      subTitle: "History of fees",
      user: this.$baseRead("user"),
      settings: JSON.parse(localStorage.getItem("settings")),
      institutionInfo: JSON.parse(localStorage.getItem("institutionInfo"))
    };
  },

  methods: {
    calculateBalance(totals) {
      var debit = totals.debit.substr(4).replace(",", "");
      var credit = totals.credit.substr(4).replace(",", "");
      var balance = debit - credit;
      return balance.toLocaleString("en", {
            minimumFractionDigits: 2
          });
    },
    printFeesStatement() {
      if(this.settings.initials == "MNP" || this.settings.initials == "NTTI"){ 
        this.printFeesStatementPdfMake()
      }else{
        this.$htmlToPaper("FeeStatement");
      }
    },
    printFeesStatementPdfMake() {
      var tableData = [];
      var tableWidth = ["5%","10%", "10%", "30%", "15%", "15%", "15%"];
      var feeStatementHeader = [
        { text: "No.", style: "subHeader" },
        { text: "Date", style: "subHeader" },
        { text: "Ref", style: "subHeader" },
        { text: "Description", style: "subHeader" },
        { text: "Debit (KES)", style: "feeHeader" },
        { text: "Credit (KES)", style: "feeHeader" },
        { text: "Balance (KES)", style: "feeHeader" }
      ];

      tableData.push(feeStatementHeader);
      var number = 1;
      this.feesStatement.forEach(element => {
        var notes = element.notes ? "- " + element.notes + " " : "";
        var rowData = [
          { text: " " + number++, style: ["content"] },
          { text: " " + element.rdate, style: ["content"] }, 
          { text: " " + element.ref, style: ["content"] },
          {
            text: " " + element.description + "" + notes,
            style: ["content"]
          },
          {
            text:
              " " +
              element.debit
                .substr(4)
                .toLocaleString("en", { minimumFractionDigits: 2 }),
            style: ["numeric"]
          },
          {
            text:
              " " +
              element.credit
                .substr(4)
                .toLocaleString("en", { minimumFractionDigits: 2 }),
            style: ["numeric"]
          },
          {
            text:
              " " +
              element.balance
                .substr(4)
                .toLocaleString("en", { minimumFractionDigits: 2 }),
            style: ["numeric"]
          }
        ];

        tableData.push(rowData);
      });

      var feeStatementTotals = [
        { text: "", style: "subHeader" },
        { text: "", style: "subHeader" },
        { text: "", style: "subHeader" },
        { text: "TOTAL", style: "subHeader" },
        {
          text: this.totals.debit
            .substr(4)
            .toLocaleString("en", { minimumFractionDigits: 2 }),
          style: "numeric"
        },
        {
          text: this.totals.credit
            .substr(4)
            .toLocaleString("en", { minimumFractionDigits: 2 }),
          style: "numeric"
        },
        {
          text: this.calculateBalance(this.totals),
          style: "numeric"
        }
      ];

      tableData.push(feeStatementTotals);

      var reportHeader = "FEE STATEMENT ";

      var userInfoTable = [];

      var userInfoTableWidth = ["auto", "*", "auto", "*"];

      var userInfo1 = [
        { text: " " + "STUDENT NAME:", style: ["subHeader"] },
        { text: " " + this.fuculty.studentName, style: ["content"] },
        { text: " " + "REG NO:", style: ["subHeader"] },
        { text: " " + this.fuculty.regNo, style: ["content"] }
      ];
      userInfoTable.push(userInfo1);

      var userInfo2 = [
        { text: " " + "PROGRAM:", style: ["subHeader"] },
        { text: " " + this.fuculty.program, style: ["content"] },
        { text: " " + "ADMISSION YEAR", style: ["subHeader"] },
        { text: " " + this.studentDetails.studentClass.admissionYear, style: ["content"] }
      ];
      userInfoTable.push(userInfo2);

      var userInfo3 = [
        { text: " " + "DEPARTMENT:", style: ["subHeader"] },
        { text: " " + this.studentDetails.studentDeparment.department, style: ["content"] },
        { text: " " + "YEAR OF STUDY:", style: ["subHeader"] },
        { text: " " + this.currentOpenSession.year, style: ["content"] }
      ];
      userInfoTable.push(userInfo3);

      var userInfo4 = [
        { text: " " + "SCHOOL/FACULTY:", style: ["subHeader"] },
        { text: " " + this.fuculty.fuculty, style: ["content"] },
        { text: " " + "STUDENT TYPE:", style: ["subHeader"] },
        { text: " " + this.studentDetails.sponsor, style: ["content"] }
      ];
      userInfoTable.push(userInfo4);

      var userInfo5 = [
        { text: " " + "ACADEMIC YEAR:", style: ["subHeader"] },
        { text: " " + "", style: ["content"] },
        { text: " " + "ADMISSION DATE:", style: ["subHeader"] },
        { text: " " + this.fuculty.admissionDate, style: ["content"] }
      ];
      // userInfoTable.push(userInfo4)

      var underline = {
        text:
          "_______________________________________________________________________________________________",
        margin: [0, 0, 0, 2]
      };

    var userInfoTableObj = {
        table: {
            headerRows: 0,
            widths: userInfoTableWidth,
            body: userInfoTable,
        },
        layout: {
            hLineWidth: function (i, node) {
                return (i === 0 || i === node.table.body.length) ? 0.0 : 0.0;
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
      var date = new Date().toLocaleString("en-US")
      var timeStamp = {text: ' ' + date, style: ['content']}
      var detailsObject = {
          tableWidth: tableWidth,
          reportHeader: reportHeader.toUpperCase(),
          timeStamp: timeStamp,
          userInfoTableObj: userInfoTableObj,
          underline: underline,
          fileName: AppData.getFileName("FeeStatement", this.user.username)
      }

      PdfPrinter.printPdf(tableData, detailsObject);
    },
    loadData() {
      this.loading = true;
      this.feesStatement = [];
      this.fuculty = JSON.parse(localStorage.getItem("fucultyInfo"));
      this.$http
        .get("finance/GetStudentFeeStatement?userCode=" + this.user.username)
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            this.feesStatement = result.data.data.statement;
            this.totals = result.data.data.totals;
          } else {
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    },
    checkCurrentSemester(semester, stage) {
      // return stage === this.studentDetails.studentSemester.yearOfStudy
      return (
        semester === this.returnSemesterName() &&
        stage === this.studentDetails.studentSemester.yearOfStudy
      );
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
            this.loadData();
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
    },

    openCurrentSession(year, session) {
      this.currentOpenSession.session = session;
      this.currentOpenSession.year = year;
    },
    returnSemesterName() {
      return this.studentDetails.studentSemester.semester;
    },
    checkSettingStatus: function() {
      this.allowedFeeStatusDownload = 1;
      this.checkingFeesStatusHttp = true;
      this.$http
        .get("CommonUtilities/settingstatus?settingCode=007")
        .then(result => {
          this.checkingFeesStatusHttp = false;
          if (result.data.success) {
            this.allowedFeeStatusDownload = 2;
            this.getStudentDetails();
          } else {
            this.allowedFeeStatusDownload = 1;
            this.eligibleMessage = result.data.message;
            this.$toastr("error", result.data.message);
          }
        })
        .catch(error => {
          this.checkingFeesStatusHttp = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.checkSettingStatus();
  }
};
</script>
<style scoped>
td {
  padding-left: 4px;
  padding-right: 4px;
}
</style>


