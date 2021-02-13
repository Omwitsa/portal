<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span>{{subTitle}}.</span>
      </div>
      <div v-if="!loanStatementCurrentlyActive">
        <div class="card-block">
          <div class>
            <div class="text-center" v-if="showLoansHttp">
              <small-spinner :loading="showLoansHttp"></small-spinner>
            </div>
            <div class v-if="!showLoansHttp">
              <div class="col-md-12 row table-responsive">
                <table class="table table-sm">
                  <tr>
                    <th></th>
                    <th>Loan Description</th>
                    <th>Amount</th>
                    <th>Loan Period</th>
                    <th>Status</th>
                    <th></th>
                  </tr>
                  <tr v-for="(loan,index) in loans.loans" :key="index">
                    <td>{{index+1}}</td>
                    <td>{{loan.loan}}</td>
                    <td>{{loan.amount.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                    <td>{{loan.loanTerm}} Months</td>
                    <td>{{loan.closed}}</td>
                    <td>
                      <button class="btn btn-primary btn-sm" @click="getLoanStatement(loan)">
                        <i class="fa fa-eye"></i> View
                      </button>
                    </td>
                  </tr>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div v-if="loanStatementCurrentlyActive">
        <div class="card-header">
          <div class="row">
            <div class="col-md-10">
              <h4>
                <span
                  style="margin-right: 30px;"
                  @click="loanStatementCurrentlyActive=!loanStatementCurrentlyActive"
                >
                  <i class="fa fa-chevron-left"></i>
                </span> Loan Statement
              </h4>
              <span>Loan Statement : {{currentClickLoan.loan}}</span>
            </div>
            <div class="col-md-2">
              <button class="btn btn-primary btn-sm" @click="PrintLoanStatement()">
                <i style="color:white;" class="fa fa-print"></i> print
              </button>
            </div>
          </div>
        </div>

        <div class="card-block">
          <div class id="printOut">
            <div class="text-center" v-if="showLoansStamentHttp">
              <small-spinner :loading="showLoansStamentHttp"></small-spinner>
            </div>
            <div class v-if="!showLoansStamentHttp">
              <div class style="border:1px solid lightgrey">
                <div class="text-center col-md-12 h5 text-uppercase">
                  {{currentClickLoan.loan}}
                  <br>
                  {{userInfo.names}}
                </div>
                <div class="row col-md-12">
                  <div class="col-md-4">
                    <span class="col-md-5 row float-left" float-left>
                      <b>NATIONAL ID</b>
                    </span>
                    <span class="col-md-5 row">{{userInfo.idno}}</span>
                  </div>
                  <div class="col-md-5 float-right">
                    <span class="col-md-6 row pull-left">
                      <b>INTEREST TYPE</b>
                    </span>
                    <span class="col-md-5 row">{{currentClickLoan.intType}}</span>
                  </div>
                </div>
                <div class="row col-md-12">
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>LOAN VALUE</b>
                    </span>
                    <span
                      class="col-md-5 row"
                    >{{currentClickLoan.amount.toLocaleString('en', {minimumFractionDigits: 2})}}</span>
                  </div>
                  <div class="col-md-4">
                    <span class="col-md-6 row pull-left">
                      <b>INTEREST RATE</b>
                    </span>
                    <span class="col-md-5 row">{{currentClickLoan.intRate}}</span>
                  </div>
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>LOAN TERM</b>
                    </span>
                    <span class="col-md-5 row">{{currentClickLoan.loanTerm}} Month(s)</span>
                  </div>
                </div>
                <div class="row col-md-12">
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>START DATE</b>
                    </span>
                    <span class="col-md-5 row">{{endPoints.ReturnDate(currentClickLoan.sdate)}}</span>
                  </div>
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>END DATE</b>
                    </span>
                    <span class="col-md-5 row">{{endPoints.ReturnDate(currentClickLoan.edate)}}</span>
                  </div>
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>STATUS</b>
                    </span>
                    <span class="col-md-5 row">
                      <span>{{currentClickLoan.status}}</span>
                    </span>
                  </div>
                </div>
                <div class="row col-md-12">
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>INSTITUTION</b>
                    </span>
                    <span class="col-md-6 row">{{currentClickLoan.fi}}</span>
                  </div>
                  <div class="col-md-4">
                    <span>
                      <b></b>
                    </span>
                  </div>
                  <div class="col-md-4">
                    <span class="col-md-5 row pull-left">
                      <b>ACCOUNT NO.</b>
                    </span>
                    <span class="col-md-5 row">{{userInfo.accNo}}</span>
                  </div>
                </div>
                <div class="row col-md-12">
                  <div class="col-md-9">
                    <span class="col-md-5 row pull-left">
                      <b>DESCRIPTION</b>
                    </span>
                    <span class="col-md-5 row">{{currentClickLoan.loan}}</span>
                  </div>
                </div>
              </div>

              <div class="col-md-12 row table-responsive">
                <table class="table table-sm">
                  <thead>
                    <th>#</th>
                    <th>MONTH</th>
                    <th>PRINCIPAL</th>
                    <th>INTEREST</th>
                    <th>PREMIUM</th>
                    <th>RECOVERED</th>
                    <th>BALANCE</th>
                  </thead>
                  <tbody>
                    <tr v-for="(statement,index) in loanStatement.loanTransactions" :key="index">
                      <td>{{index+1}}</td>
                      <td>{{statement.month}}</td>
                      <td>{{statement.required?statement.required.toLocaleString('en', {minimumFractionDigits: 2}):""}}</td>
                      <td>{{statement.interest.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                      <td>{{statement.premium.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                      <td>{{statement.recovered?statement.recovered.toLocaleString('en', {minimumFractionDigits: 2}):""}}</td>
                      <td>{{statement.balance.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                    </tr>
                    <tr>
                      <th colspan="2">Loan Amount</th>
                      <th>{{loanStatement.totalRequired.toLocaleString('en', {minimumFractionDigits: 2})}}</th>
                      <th colspan="4"></th>
                      <!-- <th>{{loanStatement.totalRecovered.toLocaleString('en', {minimumFractionDigits: 2})}}</!--> 
                      <!-- <th>{{(loanStatement.totalRequired-loanStatement.totalRecovered).toLocaleString('en', {minimumFractionDigits: 2})}}</!-->
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
import END_POINTS from "../../../components/constants/EndPoints";
import PdfPrinter from "../../../components/constants/PdfPrinter";
import AppData from "../../../components/constants/AppData";
export default {
  data() {
    return {
      payslipHttp: false,
      showLoansHttp: false,
      showLoansStamentHttp: false,
      loanStatementCurrentlyActive: false,
      loans: [],
      endPoints: END_POINTS,
      currentClickLoan: {},
      loanStatement: [],
      userInfo: {
        name: "",
        accNo: "",
        idno: ""
      },
      title: "Loan",
      subTitle: "Loan Statements",
      user: this.$baseRead("user")
    };
  },
  methods: {
    getLoans: function() {
      this.showLoansHttp = true;
      this.$http
        .get("loans/GetEmployeeLoans?userCode=" + this.user.username)
        .then(result => {
          this.showLoansHttp = false;
          if (result.data.success) {
            result.data.data.loans.forEach(element => {
              element.closed = element.closed ? "Closed" : "Active";
            });

            this.loans = result.data.data;
            this.userInfo = this.loans.userInfor;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.showLoansHttp = false;
          this.$toastr("error", "Exception : " + error.message);
        });
    },
    PrintLoanStatement: function() {
      var tableData = [];
      var userInfoTable = [];
      var tableWidth = ["10%", "*", "*", "*", "*", "*", "*"];
      var userInfoTableWidth = ["auto", "*", "auto", "*", "auto", "*"];
      var feeStatementHeader = [
        { text: "No.", style: "subHeader" },
        { text: "MONTH", style: "subHeader" },
        { text: "PRINCIPAL", style: "subHeader" },
        { text: "INTEREST", style: "subHeader" },
        { text: "PREMIUM", style: "subHeader" },
        { text: "RECOVERED (CREDIT)", style: "subHeader" },
        { text: "BALANCE", style: "subHeader" }
      ];

      tableData.push(feeStatementHeader);

      var array = this.loanStatement.loanTransactions;

      var number = 1;
      array.forEach(element => {
        var required = element.required
          ? element.required.toLocaleString("en", { minimumFractionDigits: 2 })
          : "";
        var recovered = element.recovered
          ? element.recovered.toLocaleString("en", { minimumFractionDigits: 2 })
          : "";
        var rowData = [
          { text: " " + number++, style: ["content"] },
          { text: " " + element.month, style: ["content"] },
          { text: " " + required, style: ["content"] },
          { text: " " + element.interest.toLocaleString('en', {minimumFractionDigits: 2}), style: ["content"] },
          { text: " " + element.premium.toLocaleString('en', {minimumFractionDigits: 2}), style: ["content"] },
          { text: " " + recovered, style: ["content"] },
          {
            text:
              " " +
              element.balance.toLocaleString("en", {
                minimumFractionDigits: 2
              }),
            style: ["content"]
          }
        ];

        tableData.push(rowData);
      });

      var reportHeader = "LOAN STATEMENT ";

      var loans = this.loans.loans;

      var userInfo1 = [
        { text: " " + "NATIONAL ID", style: ["subHeader"] },
        { text: " " + this.userInfo.idno, style: ["content"] },
        { text: " " + "INTEREST TYPE", style: ["subHeader"] },
        { text: " " + this.currentClickLoan.intType, style: ["content"] },
        { text: " " + "LOAN TERM", style: ["subHeader"] },
        { text: " " + this.currentClickLoan.loanTerm, style: ["content"] }
      ];

      userInfoTable.push(userInfo1);

      var userInfo2 = [
        { text: " " + "LOAN VALUE", style: ["subHeader"] },
        {
          text:
            " " +
            this.currentClickLoan.amount.toLocaleString("en", {
              minimumFractionDigits: 2
            }),
          style: ["content"]
        },
        { text: " " + "INTEREST RATE", style: ["subHeader"] },
        { text: " " + this.currentClickLoan.intRate, style: ["content"] },
        { text: " " + "STATUS", style: ["subHeader"] },
        { text: " " + this.currentClickLoan.status, style: ["content"] }
      ];

      userInfoTable.push(userInfo2);

      var userInfo3 = [
        { text: " " + "START DATE", style: ["subHeader"] },
        {
          text: " " + this.endPoints.ReturnDate(this.currentClickLoan.sdate),
          style: ["content"]
        },
        { text: " " + "END DATE", style: ["subHeader"] },
        {
          text: " " + this.endPoints.ReturnDate(this.currentClickLoan.edate),
          style: ["content"]
        },
        { text: " " + "ACCOUNT NO", style: ["subHeader"] },
        { text: " " + this.userInfo.accNo, style: ["content"] }
      ];

      userInfoTable.push(userInfo3);

      var underline = {
        text:
          "_______________________________________________________________________________________________",
        margin: [0, 0, 0, 2]
      };

      var userInfoTableObj = {
        table: {
          headerRows: 0,
          widths: userInfoTableWidth,
          body: userInfoTable
        },
        layout: {
          hLineWidth: function(i, node) {
            return i === 0 || i === node.table.body.length ? 0.0 : 0.0;
          },
          vLineWidth: function(i, node) {
            return i === 0 || i === node.table.widths.length ? 0.0 : 0.0;
          },
          hLineColor: function(i, node) {
            return i === 0 || i === node.table.body.length ? "black" : "black";
          },
          vLineColor: function(i, node) {
            return i === 0 || i === node.table.widths.length
              ? "black"
              : "black";
          },
          paddingLeft: function(i, node) {
            return 4;
          },
          paddingRight: function(i, node) {
            return 4;
          },
          paddingTop: function(i, node) {
            return 2;
          },
          paddingBottom: function(i, node) {
            return 2;
          }
        }
      };

      var loanDescription = {
        text: this.currentClickLoan.loan,
        style: ["subHeader", "centerData"]
      };
      var debtorName = {
        text: this.userInfo.names,
        style: ["subHeader", "centerData"]
      };

      var detailsObject = {
        tableWidth: tableWidth,
        reportHeader: reportHeader.toUpperCase(),
        underline: underline,
        loanDescription: loanDescription,
        debtorName: debtorName,
        userInfoTableObj: userInfoTableObj,
        fileName: AppData.getFileName("Loans", this.user.username)
      };
      PdfPrinter.printPdf(tableData, detailsObject);
    },
    getLoanStatement: function(loan) {
      this.loanStatementCurrentlyActive = true;
      this.showLoansStamentHttp = true;
      this.currentClickLoan = loan;
      this.currentClickLoan.status =
        this.currentClickLoan.closed == false ? "CURRENT" : "CLEARED";
      this.$http
        .get(
          "loans/GetEmployeeLoanStatement?userCode=" +
            this.user.username +
            "&refId=" +
            loan.id
        )
        .then(result => {
          this.showLoansStamentHttp = false;
          if (result.data.success) {
            this.loanStatement = result.data.data;
          } else {
            this.$toastr("error", "Alert : " + result.data.message);
          }
        })
        .catch(error => {
          this.showLoansStamentHttp = false;
          this.$toastr("error", "Exception : " + error.message);
        });
    }
  },
  created() {
    this.getLoans();
  }
};
</script>

