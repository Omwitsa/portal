<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span>{{subTitle}}.</span>
                <div class="card-header-right">
                    <button class="btn btn-primary btn-sm" @click="printPNine()">
                        <i class="fa fa-print" style="color:white;"></i> print
                    </button>
                </div>
            </div>
            <div>
                <div class="card-block">
                    <div class="">
                        <div class="form-group row">
                            <div class="col-md-5">
                                <label>Year
                                    <small-spinner :loading="filterHttp"></small-spinner>
                                </label>
                                <select class="form-control"
                                        v-model="payYear">
                                    <option disabled selected>--Current year--</option>
                                    <option v-for="(year,index) in payTimes.years" :value="year.ryear"
                                            :key="index">{{year.ryear}}
                                    </option>
                                </select>
                            </div>

                            <div class="col-md-1">
                                <label>&nbsp;</label>
                                <button @click="generateP9()" class="btn btn-sm btn-primary" :disabled="payslipHttp">
                                    <small-spinner :loading="payslipHttp"></small-spinner>
                                    Generate p9
                                </button>
                            </div>
                        </div>

                        <div class="" v-if="showP9" id="feeStatement">
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade " id="myModal" role="dialog" style="padding-right: 0px!important;">
                <div class="modal-dialog modal-full modal-lg">
                    <div class="modal-content">
                        <div class="row">
                            <div class="col-md-1">
                                <div class="btn btn-primary btn-sm" @click="back()">
                                    <i class="fa fa-backward" style="color:white;"></i> Back
                                </div>
                            </div>
                            <div class="col-md-10"></div>
                            <div class="col-md-1">
                                <div class="btn btn-primary btn-sm" @click="printPNine()">
                                    <i class="fa fa-print" style="color:white;"></i> print
                                </div>
                            </div>
                        </div>
                         
                        <div id="print_p9">
                            <div style="text-align: center;">
                                <img v-if="!isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="10%" />
                                <img v-if="isLaikipia" :src="settings.logoImageUrl" :alt="settings.initials" width="20%"/>
                            </div>
                            <div class=" ">
                                <div class="h3 text-center"><b>KENYA REVENUE AUTHORITY</b></div>
                                <div class="h4 text-center"><b>DOMESTIC TAXES DEPARTMENT</b></div>
                                <div class="h5  text-center"><b>{{pNine.p9Details.year}}</b></div>
                                <div class="col-md-12 row" style="margin-top: -25px">
                                    <div class="col-md-4"><b>P9A</b></div>
                                </div>
                            </div>
                            <div class="modal-body p9">
                                <div class=" row col-12">
                                    <div class="col-md-9 row  row pull-left">
                                        Employer's Name : {{pNine.p9Details.employerName}}<br>
                                        Employee's Name : {{pNine.p9Details.employeeName}}<br>
                                        Employee's Other Names : {{pNine.p9Details.employeeOtherNames}}
                                    </div>
                                    <div class="col-md-3 pull-left col-6">
                                        Employer PIN : {{pNine.p9Details.employerPin}}<br><br>
                                        Employee PIN : {{pNine.p9Details.employeePin}}
                                    </div>
                                </div>
                                <div class="table-responsive_" v-if="showP9">
                                    <table class="table table-bordered table-md">
                                        <thead>
                                        <tr>
                                            <th valign="top">
                                                MONTH
                                            </th>
                                            <th valign="top">
                                                Basic Salary
                                            </th>
                                            <th valign="top">
                                                Benefits-<br>NonCash
                                            </th>
                                            <th valign="top">
                                                Value Of <br>Quarters
                                            </th>
                                            <th valign="top">
                                                Total Gross <br>Pay
                                            </th>
                                            <th colspan="3">
                                                Defined Contribution<br> Retirement Scheme
                                            </th>
                                            <th valign="top">
                                                Owner<br> Occupied<br> Interest
                                            </th>
                                            <th valign="top">
                                                Retirement<br> Contribution &<br> Owner <br>Occupied <br>Interest
                                            </th>
                                            <th valign="top">
                                                Chargable <br>Pay
                                            </th>
                                            <th valign="top">
                                                Tax Charged
                                            </th>
                                            <th valign="top">
                                                Personal <br>Relief +<br> Insurance <br>Relief
                                            </th>
                                            <th valign="top">
                                                Paye Tax<br>
                                                J-K
                                            </th>
                                        </tr>
                                        <tr class="td-bold">
                                            <td></td>
                                            <td>A</td>
                                            <td>B</td>
                                            <td>C</td>
                                            <td>D</td>
                                            <td>E1</td>
                                            <td>E2</td>
                                            <td>E3</td>
                                            <td>F</td>
                                            <td>G</td>
                                            <td>H</td>
                                            <td>J</td>
                                            <td>K</td>
                                            <td>L</td>

                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr class="" v-for="(payment,index) in pNine.monthlyAmounts" :key="index">
                                            <td>{{payment.month}}</td>
                                            <td>{{payment.a_BasicSalary.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.b_Beneficts.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.c_HousingQuarters.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.d_TotalGrossIncome.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.e1_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.e2_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.e3_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.f_InterestAmountOnHouse.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.g_RetirementContribution.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.h_ChargeablePay.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.j_TaxCharged.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.k_PersonalRelief.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{payment.l_PayeTax.toLocaleString('en', {minimumFractionDigits: 2})}}</td>

                                        </tr>
                                        <tr class="td-bold">
                                            <td>TOTALS</td>
                                            <td>{{pNine.annualTotals.a_BasicSalary.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.b_Beneficts.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.c_HousingQuarters.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.d_TotalGrossIncome.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.e1_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.e2_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.e3_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.f_InterestAmountOnHouse.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.g_RetirementContribution.toLocaleString('en', {minimumFractionDigits: 2})}}
                                            </td>
                                            <td>{{pNine.annualTotals.h_ChargeablePay.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.j_TaxCharged.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.k_PersonalRelief.toLocaleString('en', {minimumFractionDigits: 2})}}</td>
                                            <td>{{pNine.annualTotals.l_PayeTax.toLocaleString('en', {minimumFractionDigits: 2})}}</td>

                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="col-12 row" v-if="showP9">
                                    <div class="col-md-6 row">
                                        <div class="col-md-12 row">To be comppleted by Employer at the end of the year
                                        </div>
                                        <div class="col-md-12 row"><b>TOTAL CHARGABLE PAY(COL.H) Kshs. {{pNine.annualTotals.h_ChargeablePay.toLocaleString('en', {minimumFractionDigits: 2})}} </b></div>
                                        <div class="">
                                            <div style="font-size: 16px"><b>IMPORTANT</b></div>
                                            <div class="col-md-12 row pull-left">
                                                <div class="col-md-2 row pull-left">1.Use P9A</div>
                                                <div class="col-md-10 row pull-right">
                                                    (a)For all reliable employees annd where director/employee received
                                                    Benefits in addition to cash emoluments.<br>
                                                    (b) Where an employee is eligible to deduction on owner occupier
                                                    interest.
                                                </div>
                                            </div>
                                            <div class="col-md-12 row pull-left">
                                                (a) Allowable interest in respect of any month must not exceed Kshs
                                                12,500/= or Kshs. 150,000 per year.<br>
                                                <b>(See back of this card for further information required by the
                                                    Department)</b>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 row" v-if="showP9">
                                        <div class="col-md-12 row">
                                            <b>TOTAL TAX (COL.L) Kshs. {{pNine.annualTotals.l_PayeTax.toLocaleString('en', {minimumFractionDigits: 2})}}</b>
                                        </div>
                                        <div class="col-md-12 row pull-left">
                                            <div class="col-md-2 row pull-left">(b) Attach.</div>
                                            <div class="col-md-10 row pull-right">
                                                (i)Photostat copy of interest certificate and statement of account from
                                                the
                                                Financial Institution.<br>
                                                (ii) The DECLARATION duly signed by the employee.

                                            </div>
                                        </div>
                                        <div class="col-md-12 text-capitalize row pull-left">
                                            <b>NAMES OF THE FINANCIAL INSTITUTION ADVANCING MORTGAGE LOAN</b>
                                        </div>
                                        <div class="col-md-12 text-capitalize row pull-left">
                                            ..............................................................................................................................................

                                        </div>
                                        <div class="col-md-12 text-capitalize row pull-left">
                                            <b>L R OF OWNER OCCUPIED
                                                PROPERTY................................................................................................................
                                            </b>
                                        </div>
                                        <div class="col-md-12 text-capitalize row pull-left">
                                            <b>DATE OF OCCUPATION OF
                                                HOUSE................................................................................................................
                                            </b>
                                        </div>

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
<style>
    .modal-full {
        min-width: 100%;
        margin: 0;
    }

    .modal-full .modal-content {
        min-height: 100vh;
    }

    .td-bold {
        font-weight: bold;
    }

    td {
    padding-top: 7px!important;
    padding-bottom: 7px!important;
    }

    .p9 {
        zoom: 80%;
    }

    #print_p9 {
        size: landscape !important;
    }
</style>
<style type="text/css" media="print">
    @page {
        size: landscape;
        display: contents;
    }
</style>
<script>
    import PdfPrinter from "../../../components/constants/PdfPrinter"
    import EndPoints from "../../../components/constants/EndPoints"
    import AppData from "../../../components/constants/AppData"
    export default {
        data() {
            return {
                isLaikipia: false,
                payYear: "",
                showP9: false,
                filterHttp: false,
                payPeriodHttp: false,
                payslipHttp: false,
                settings: {},
                pNine: {
                    monthlyAmounts: [],
                    annualTotals: {},
                    p9Details: {}
                },
                payTimes: {
                    years: []
                },
                title: "P9",
                subTitle: "P9",
                user: this.$baseRead('user')
            }
        },
        methods: {
            // printPNine(){
            //     var tableData = [];
            //     var tableWidth = ['*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*']
            //     var pNinesHeader = [
            //         {text: '', style: 'subHeader'},
            //         {text: 'A', style: 'subHeader'},
            //         {text: 'B', style: 'subHeader'},
            //         {text: 'C', style: 'subHeader'},
            //         {text: 'D', style: 'subHeader'},
            //         {text: 'E1', style: 'subHeader'},
            //         {text: 'E2', style: 'subHeader'},
            //         {text: 'E3', style: 'subHeader'},
            //         {text: 'F', style: 'subHeader'},
            //         {text: 'G', style: 'subHeader'},
            //         {text: 'H', style: 'subHeader'},
            //         {text: 'J', style: 'subHeader'},
            //         {text: 'K', style: 'subHeader'},
            //         {text: 'L', style: 'subHeader'}
            //     ]

            //     tableData.push(pNinesHeader)

            //     var array = this.pNine.monthlyAmounts

            //     array.forEach(element => {
            //         var rowData = [
            //             {text: ' ' +  element.month, style: ['content']},
            //             {text: ' ' +  element.a_BasicSalary.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.b_Beneficts.toLocaleString('en', {minimumFractionDigits: 2}) , style: ['content']},
            //             {text: ' ' +  element.c_HousingQuarters.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.d_TotalGrossIncome.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.e1_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.e2_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.e3_RetirementScheme.toLocaleString('en', {minimumFractionDigits: 2}) , style: ['content']},
            //             {text: ' ' +  element.f_InterestAmountOnHouse.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.g_RetirementContribution.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.h_ChargeablePay.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.j_TaxCharged.toLocaleString('en', {minimumFractionDigits: 2}) , style: ['content']},
            //             {text: ' ' +  element.k_PersonalRelief.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']},
            //             {text: ' ' +  element.l_PayeTax.toLocaleString('en', {minimumFractionDigits: 2}), style: ['content']}
            //         ]

            //         tableData.push(rowData)
            //     });

            //     var reportHeader = "P9A"
            //     var detailsObject = {
            //         // netPayableObj: netPayableObj,
            //         // netPayableWords: netPayableWords,
            //         // tableWidth: tableWidth,
            //         // underline : underline,
            //         pageOrientation: 'landscape',
            //         reportHeader: reportHeader.toUpperCase(),
            //         fileName: AppData.getFileName("pNine", this.user.username)
            //     }

            //     PdfPrinter.printPdf(tableData, detailsObject)
            // },
            printPNine() {
              this.$htmlToPaper("print_p9");
            },
            back(){
                location.reload()
            },
            // printPNine: function () {
            //     $("#print_p9").printThis({
            //         debug: false,               // show the iframe for debugging
            //         importCSS: true,            // import parent page css
            //         importStyle: true,         // import style tags
            //         printContainer: true,       // print outer container/$.selector
            //         loadCSS: "",                // path to additional css file - use an array [] for multiple
            //         pageTitle: "",              // add title to print page
            //         removeInline: false,        // remove inline styles from print elements
            //         removeInlineSelector: "*",  // custom selectors to filter inline styles. removeInline must be true
            //         printDelay: 333,            // variable print delay
            //         header: null,               // prefix to html
            //         footer: null,               // postfix to html
            //         base: false,                // preserve the BASE tag or accept a string for the URL
            //         formValues: true,           // preserve input/form values
            //         canvas: false,              // copy canvas content
            //         doctypeString: '...',       // enter a different doctype for older markup
            //         removeScripts: false,       // remove script tags from print content
            //         copyTagClasses: false,      // copy classes from the html & body tag
            //         beforePrintEvent: null,     // function for printEvent in iframe
            //         beforePrint: null,          // function called before iframe is filled
            //         afterPrint: null            // function called before iframe is removed
            //     });
            // },
            generateP9: function () {
                this.showP9 = false;
                this.payslipHttp = true;
                this.$http
                    .get("pnine/GetEmpPnine?userCode=" + this.user.username + "&year=" + this.payYear)
                    .then(result => {
                        this.showP9 = true;
                        this.payslipHttp = false;
                        if (result.data.success) {
                            $("#myModal").modal('show');
                            this.pNine = result.data.data;
                        } else {
                            this.$toastr("error", "Alert : " + result.data.message)
                        }
                    })
                    .catch(error => {
                        this.payslipHttp = false;
                        this.$toastr("error", "Exception : " + error.message)
                    })
            },
            getPayslipYears: function () {
                this.filterHttp = true;
                this.$http
                    .get("payslip/GetPayslipYears")
                    .then(result => {
                        this.filterHttp = false;
                        if (result.data.success) {
                            this.payTimes.years = result.data.data;
                        } else {
                            this.$toastr("error", "Alert : " + result.data.message)
                        }
                    })
                    .catch(error => {
                        this.filterHttp = false;
                        this.$toastr("error", "Exception : " + error.message)
                    })
            }


        },
        created() {
            this.settings = JSON.parse(localStorage.getItem('settings'))
            this.isLaikipia = this.settings.initials == 'LU' ? true : false;
            this.getPayslipYears(); // logoImageUrl
        }
    }
</script>


