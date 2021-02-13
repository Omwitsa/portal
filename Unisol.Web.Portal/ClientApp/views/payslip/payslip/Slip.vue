<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <div class="row">
          <div class="col-md-2">
            <h5>{{ title }}</h5>
            <span>{{ subTitle }}.</span>
          </div>
          <div class="col-md-8"></div>
          <div class="col-md-2">
            <button class="btn btn-primary btn-sm" @click="printPayslip()">
              <i style="color:white;" class="fa fa-print"></i> print
            </button>
          </div>
        </div>
      </div>

      <div>
        <div class="card-block">
          <div class>
            <div class="form-group row">
              <div class="col-md-5">
                <label>
                  Year
                  <small-spinner :loading="filterHttp"></small-spinner>
                </label>
                <select
                  class="form-control"
                  @change="getPayslipPeriod()"
                  v-model="payYear"
                >
                  <option disabled selected>--Current year--</option>
                  <option
                    v-for="(year, index) in payTimes.years"
                    :value="year.ryear"
                    :key="index"
                    >{{ year.ryear }}</option
                  >
                </select>
              </div>
              <div class="col-md-5">
                <label>
                  Salary Period
                  <small-spinner :loading="payPeriodHttp"></small-spinner>
                </label>
                <select class="form-control" v-model="month">
                  <option value selected disabled>--Pay Period--</option>
                  <option
                    v-for="(month, index) in payTimes.months"
                    :value="month.names"
                    :key="index"
                    >{{ month.names }}</option
                  >
                </select>
              </div>
              <div class="col-md-1">
                <label>&nbsp;</label>
                <button
                  @click="getPayslip()"
                  class="btn btn-sm btn-primary"
                  :disabled="payslipHttp"
                >
                  <small-spinner :loading="payslipHttp"></small-spinner>Generate
                </button>
              </div>
            </div>

            <div></div>
			<div class v-if="showPayslip" id="feeStatement">
				<div class="col-md-12 row table-responsive">
					<table class="table table-sm table-bordered">
						<tr>
							<th>Earnings</th>
							<th>Deductions</th>
						</tr>
						<tr>
							<td>
								<ul v-for="(earning, index) in payslip.sortedPayments
                          .earnings"
									:key="index">
									<li>
										<div class="row">
											<div class="col-md-8">{{ earning.name }}</div>
											<div class="col-md-4" style="text-align:right">
												{{
                                earning.amount.toLocaleString('en', {
                                  minimumFractionDigits: 2
                                })
												}}
											</div>
										</div>
									</li>
								</ul>
							</td>
							<td>
								<ul v-for="(deduction, index) in payslip.sortedPayments
                          .deductions"
									:key="index">
									<li>
										<div class="row">
											<div class="col-md-8">
												{{ getAccountName(deduction) }}
											</div>
											<div class="col-md-4" style="text-align:right">
												{{
                                deduction.amount.toLocaleString('en', {
                                  minimumFractionDigits: 2
                                })
												}}
											</div>
										</div>
									</li>
								</ul>
							</td>
						</tr>
						<tr>
							<th>
								<div class="col-md-6 row pull-left">Total Earnings</div>
								<div class="col-md-4 row pull-right">
									{{
                          payslip.earningDeductions.earnings.toLocaleString(
                            'en',
                            { minimumFractionDigits: 2 }
                          )
									}}
								</div>
							</th>
							<th>
								<div class="col-md-6 row pull-left">Total Deductions</div>
								<div class="col-md-4 row pull-right">
									{{
                          payslip.earningDeductions.deductions.toLocaleString(
                            'en',
                            { minimumFractionDigits: 2 }
                          )
									}}
								</div>
							</th>
						</tr>
					</table>
				</div>
				<div>
					Net Payable (Total Earnings - Total Deductions) :
					<b>
						{{(payslip.earningDeductions.earnings - payslip.earningDeductions.deductions).toLocaleString('en', { minimumFractionDigits: 2 })}}
					</b> <br>
					<b class="text-capitalize"> {{endPoints.numberToEnglish(payslip.earningDeductions.earnings-payslip.earningDeductions.deductions,' ')}}</b>
					<!-- <b class="text-capitalize"> {{numberToEnglish(payslip.earningDeductions.earnings-payslip.earningDeductions.deductions,' ')}}</b> -->
					<hr />
				</div>
			</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PdfPrinter from '../../../components/constants/PdfPrinter';
import EndPoints from '../../../components/constants/EndPoints';
import AppData from '../../../components/constants/AppData';
import DateFomatter from '../../../components/constants/DateFomatter';
export default {
  data() {
    return {
      payTimes: {
        years: [],
        months: []
      },
      month: '',
      employee: {},
      dateFomatter: DateFomatter,
      payslip: {
        sortedPayments: [],
        earningDeductions: {
          earnings: 0,
          deductions: 0
        }
      },
      endPoints: EndPoints,
      payYear: '',
      showPayslip: false,
      filterHttp: false,
      payPeriodHttp: false,
      payslipHttp: false,
      title: 'Payslip',
      subTitle: 'Monthly Payslip',
      user: this.$baseRead('user')
    };
  },
  methods: {
    getAccountName(deduction) {
      var accountName = deduction.balance
        ? `${deduction.name} (${deduction.balance.toLocaleString('en', {
            minimumFractionDigits: 2
          })})`
        : deduction.name;
      return accountName;
    },
    fetchEmpInfo() {
      this.$http
        .get('profile/getStaffData?userCode=' + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.employee = result.data.data;
            this.employmentStatusTitle = this.employee.terminated
              ? 'Terminated'
              : 'Employed';
          }
        })
        .catch(error => {
          this.$toastr('error', error.message);
        });
    },
    printPayslip() {
      var earnings = this.payslip.sortedPayments.earnings;
      var deductions = this.payslip.sortedPayments.deductions;
      var savingsDeductionTotals = this.payslip.earningDeductions;

      var tableData = [];
      var tableWidth = ['30%', '20%', '30%', '20%'];
      var earningsHeader = [
        { text: 'Earnings', style: 'subHeader' },
        { text: 'Amount', style: 'subHeader' },
        { text: 'Deductions', style: 'subHeader' },
        { text: 'Amount', style: 'subHeader' }
      ];

      tableData.push(earningsHeader);

      var NetPayInFigures =
        savingsDeductionTotals.earnings - savingsDeductionTotals.deductions;
      var NetPayInWords = EndPoints.numberToEnglish(NetPayInFigures);

      var netPayableObj = {
        text:
          ' Net Payable (Total Earnings - Total Deductions) : '.toUpperCase() +
          NetPayInFigures.toLocaleString('en', { minimumFractionDigits: 2 }),
        margin: [0, 0, 0, 5],
        style: ['subHeader']
      };

      var netPayableWords = {
        text: NetPayInWords.toUpperCase(),
        margin: [0, 0, 0, 5],
        style: ['subHeader']
      };
      var underline = {
        text:
          '_______________________________________________________________________________________________',
        margin: [0, 0, 0, 2]
      };
      var username = {
        text:
          ' ' +
          `${this.employee.title} ${this.user.userRegister.names} [${this.user.username}]`,
        style: ['subHeader']
      };
      var pinNo = {
        text: ' ' + 'P.I.N.: ' + this.employee.pin,
        style: ['subHeader']
      };
      var nationalId = {
        text: ' ' + 'National Id: ' + this.employee.idno,
        style: ['subHeader']
      };
      var department = {
        text: ' ' + 'Department: ' + this.employee.department,
        style: ['subHeader']
      };
      var bank = {
        text: ' ' + 'Bank/Branch: ' + this.employee.bank,
        style: ['subHeader']
      };
      var jobTitle = {
        text: ' ' + 'Job Title: ' + this.employee.jobTitle,
        style: ['subHeader']
      };
      var nhif = {
        text: ' ' + 'NHIF: ' + this.employee.nhif,
        style: ['subHeader']
      };
      var nssf = {
        text: ' ' + 'NSSF: ' + this.employee.nssf,
        style: ['subHeader']
      };
      var pgrade = {
        text: ' ' + 'NSSF: ' + this.employee.pgrade,
        style: ['subHeader']
      };
      var rDate = {
        text: ' ' + 'Date: ' + this.dateFomatter.ReturnDate(this.payslip.rDate),
        style: ['subHeader']
      };

      var reportHeader = 'PAYSLIP FOR THE ' + this.month;
      var paySlipHeader = [
        [
          { text: 'NATIONAL ID: ', style: 'subHeader' },
          {
            text: this.employee.idno,
            style: 'tableHeader'
          },
          { text: 'P.I.N: ', style: 'subHeader' },
          {
            text: this.employee.pin,
            style: 'tableHeader'
          }
        ],
        [
          { text: 'DEPARTMENT: ', style: 'subHeader' },
          {
            text: this.employee.department,
            style: 'tableHeader'
          },
          { text: 'DATE: ', style: 'subHeader' },
          {
            text: this.dateFomatter.ReturnDate(this.payslip.rDate),
            style: 'tableHeader'
          }
        ],
        [
          { text: 'JOB TITLE: ', style: 'subHeader' },
          {
            text: this.employee.jobTitle,
            style: 'tableHeader'
          },
          { text: 'NHIF: ', style: 'subHeader' },
          {
            text: this.employee.nhif,
            style: 'tableHeader'
          }
        ],
        [
          { text: 'PAY GRADE: ', style: 'subHeader' },
          {
            text: this.employee.pgrade,
            style: 'tableHeader'
          },
          { text: 'NSSF: ', style: 'subHeader' },
          {
            text: this.employee.nssf,
            style: 'tableHeader'
          }
        ],
        [
          { text: 'BANK/BRANCH: ', style: 'subHeader' },
          {
            text: this.employee.bank,
            style: 'tableHeader'
          },
          { text: '', style: 'subHeader' },
          {
            text: '',
            style: 'tableHeader'
          }
        ]
      ];
      var detailsObject = {
        netPayableObj: netPayableObj,
        netPayableWords: netPayableWords,
        username: username,
        rDate: rDate,
        pinNo: pinNo,
        nationalId: nationalId,
        department: department,
        bank: bank,
        jobTitle: jobTitle,
        nhif: nhif,
        nssf: nssf,
        pgrade: pgrade,
        pSlipHeader: paySlipHeader,
        tableWidth: tableWidth,
        underline: underline,
        reportHeader: reportHeader.toUpperCase(),
        fileName: AppData.getFileName('Payslip', this.user.username)
      };

      if (earnings.length >= deductions.length) {
        var i = 0;
        earnings.forEach(element => {
          var rowData = [
            { text: ' ' + element.name, style: ['content'] },
            { text: ' ' + element.amount, style: ['numeric'] }
          ];
          if (i >= deductions.length) {
            rowData.push({ text: ' ' + '', style: ['content'] });
            rowData.push({ text: ' ' + '', style: ['numeric'] });
          } else {
            rowData.push({
              text: ' ' + deductions[i].name,
              style: ['content']
            });
            rowData.push({
              text: ' ' + deductions[i].amount,
              style: ['numeric']
            });
          }
          i++;
          tableData.push(rowData);
        });
      }

      if (earnings.length < deductions.length) {
        var i = 0;
        deductions.forEach(element => {
          var rowData = [];
          if (i >= earnings.length) {
            rowData.push({ text: ' ' + '', style: ['content'] });
            rowData.push({ text: ' ' + '', style: ['numeric'] });
          } else {
            rowData.push({ text: ' ' + earnings[i].name, style: ['content'] });
            rowData.push({
              text:
                ' ' +
                earnings[i].amount.toLocaleString('en', {
                  minimumFractionDigits: 2
                }),
              style: ['numeric']
            });
          }
          var accountName = element.balance
            ? `${element.name} (${element.balance})`
            : element.name;
          rowData.push({ text: ' ' + accountName, style: ['content'] });
          rowData.push({
            text:
              ' ' +
              element.amount.toLocaleString('en', { minimumFractionDigits: 2 }),
            style: ['numeric']
          });
          i++;
          tableData.push(rowData);
        });
      }

      var earningsHeader = [
        { text: '', style: ['content'] },
        { text: '', style: ['content'] },
        { text: '', style: ['content'] },
        { text: '', style: ['content'] }
      ];
      tableData.push(earningsHeader);

      var totals = [
        { text: 'Total Earnings', style: 'subHeader' },
        {
          text: savingsDeductionTotals.earnings.toLocaleString('en', {
            minimumFractionDigits: 2
          }),
          style: 'numeric'
        },
        { text: 'Total Deductions', style: 'subHeader' },
        {
          text: savingsDeductionTotals.deductions.toLocaleString('en', {
            minimumFractionDigits: 2
          }),
          style: 'numeric'
        }
      ];

      tableData.push(totals);

      PdfPrinter.printPaySlip(tableData, detailsObject);
    },
    getPayslip: function() {
      this.showPayslip = false;
      this.payslipHttp = true;
      this.$http
        .get(
          'payslip/GetEmployeePayslip?userCode=' +
            this.user.username +
            '&month=' +
            this.month
        )
        .then(result => {
          this.showPayslip = true;
          this.payslipHttp = false;
          if (result.data.success) {
            this.payslip = result.data.data;
          } else {
            this.$toastr('error', 'Alert : ' + result.data.message);
          }
        })
        .catch(error => {
          this.payslipHttp = false;
          this.$toastr('error', 'Exception : ' + error.message);
        });
    },
    getPayslipYears: function() {
      this.filterHttp = true;
      this.$http
        .get('payslip/GetPayslipYears')
        .then(result => {
          this.filterHttp = false;
          if (result.data.success) {
            this.payTimes.years = result.data.data;
          } else {
            this.$toastr('error', result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: '401-forbidden' });
            }
          }
        })
        .catch(error => {
          this.filterHttp = false;
          this.$toastr('error', 'Exception : ' + error.message);
        });
    },
    numberToEnglish: function(n, custom_join_character) {
      var string = n.toString(),
        units,
        tens,
        scales,
        start,
        end,
        chunks,
        chunksLen,
        chunk,
        ints,
        i,
        word,
        words;

      var and = custom_join_character || 'and';

      /* Is number zero? */
      if (parseInt(string) === 0) {
        return 'zero';
      }

      /* Array of units as words */
      units = [
        '',
        'one',
        'two',
        'three',
        'four',
        'five',
        'six',
        'seven',
        'eight',
        'nine',
        'ten',
        'eleven',
        'twelve',
        'thirteen',
        'fourteen',
        'fifteen',
        'sixteen',
        'seventeen',
        'eighteen',
        'nineteen'
      ];

      /* Array of tens as words */
      tens = [
        '',
        '',
        'twenty',
        'thirty',
        'forty',
        'fifty',
        'sixty',
        'seventy',
        'eighty',
        'ninety'
      ];

      /* Array of scales as words */
      scales = [
        '',
        'thousand',
        'million',
        'billion',
        'trillion',
        'quadrillion',
        'quintillion',
        'sextillion',
        'septillion',
        'octillion',
        'nonillion',
        'decillion',
        'undecillion',
        'duodecillion',
        'tredecillion',
        'quatttuor-decillion',
        'quindecillion',
        'sexdecillion',
        'septen-decillion',
        'octodecillion',
        'novemdecillion',
        'vigintillion',
        'centillion'
      ];

      /* Split user arguemnt into 3 digit chunks from right to left */
      start = string.length;
      chunks = [];
      while (start > 0) {
        end = start;
        chunks.push(string.slice((start = Math.max(0, start - 3)), end));
      }

      /* Check if function has enough scale words to be able to stringify the user argument */
      chunksLen = chunks.length;
      if (chunksLen > scales.length) {
        return '';
      }

      /* Stringify each integer in each chunk */
      words = [];
      for (i = 0; i < chunksLen; i++) {
        chunk = parseInt(chunks[i]);

        if (chunk) {
          /* Split chunk into array of individual integers */
          ints = chunks[i]
            .split('')
            .reverse()
            .map(parseFloat);

          /* If tens integer is 1, i.e. 10, then add 10 to units integer */
          if (ints[1] === 1) {
            ints[0] += 10;
          }

          /* Add scale word if chunk is not zero and array item exists */
          if ((word = scales[i])) {
            words.push(word);
          }

          /* Add unit word if array item exists */
          if ((word = units[ints[0]])) {
            words.push(word);
          }

          /* Add tens word if array item exists */
          if ((word = tens[ints[1]])) {
            words.push(word);
          }

          /* Add 'and' string after units or tens integer if: */
          if (ints[0] || ints[1]) {
            /* Chunk has a hundreds integer or chunk is the first of multiple chunks */
            if (ints[2] || (!i && chunksLen)) {
              words.push(and);
            }
          }

          /* Add hundreds word if array item exists */
          if ((word = units[ints[2]])) {
            words.push(word + ' hundred');
          }
        }
      }

      return words.reverse().join(' ');
    },
    getPayslipPeriod: function() {
      this.payPeriodHttp = true;
      this.$http
        .get('payslip/GetPayslipPeriod?year=' + this.payYear)
        .then(result => {
          this.payPeriodHttp = false;
          if (result.data.success) {
            this.payTimes.months = result.data.data;
          } else {
            this.$toastr('error', 'Alert : ' + result.data.message);
          }
        })
        .catch(error => {
          this.payPeriodHttp = false;
          this.$toastr('error', 'Exception : ' + error.message);
        });
    }
  },
  created() {
    this.getPayslipYears();
    this.fetchEmpInfo();
  }
};
</script>
