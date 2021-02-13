<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-2">
                        <h5>{{title}}</h5>
                    </div>
                    <div class="col-md-8"></div>
                    <div class="col-md-2">
                        <button class="btn btn-primary btn-sm" @click="printIpPayslip()">
                        <i style="color:white;" class="fa fa-print"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            Salary Period
                        </label>
                        <select class="form-control" v-model="project">
                            <option value selected disabled>--Project--</option>
                            <option
                                v-for="(project,index) in projects"
                                :value="project"
                                :key="index"
                            >{{project}}
                            </option>
                        </select>
                    </div>

                    <div class="col-md-1">
                        <label>&nbsp;</label>
                        <button
                        @click="getIpPayslip()"
                        class="btn btn-sm btn-primary"
                        :disabled="loading"
                        >
                        <small-spinner :loading="loading"></small-spinner>Generate
                        </button>
                    </div>
                </div><br>

                <div class="row" v-if="ipPayslip">
                    <div class="col-md-12 table-responsive">
                        <table class="table table-sm table-bordered">
                            <tr>
                                <th>Earnings</th>
                                <th>Deductions</th>
                            </tr>

                            <tr>
                                <td>
                                    <ul v-for="(earning,index) in ipPayslip.earnings" :key="index">
                                        <li>
                                            <div class="row">
                                                <div class="col-md-8">{{earning.payAccount}}</div>
                                                <div class="col-md-4" style="text-align:right">
                                                {{earning.amount.toLocaleString('en', {minimumFractionDigits: 2})}}
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </td>
                                <td>
                                    <ul v-for="(deduction,index) in ipPayslip.deductions" :key="index">
                                        <li>
                                        <div class="row">
                                            <div class="col-md-8">{{deduction.projectName}}</div>
                                            <div class="col-md-4" style="text-align:right">
                                            {{deduction.deductionAmount.toLocaleString('en', {minimumFractionDigits: 2})}}
                                            </div>
                                        </div>
                                        </li>
                                    </ul>
                                </td>
                            </tr>

                            <tr>
                                <th colspan="2">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-8">Total Earnings</div>
                                                <div class="col-md-4">
                                                    {{ipPayslip.totalEarnings.toLocaleString('en', {minimumFractionDigits: 2})}}
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-8">Total Deductions</div>
                                                <div class="col-md-4"> 
                                                    {{ipPayslip.totalDeductions.toLocaleString('en', {minimumFractionDigits: 2})}}
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </th>
                            </tr>
                        </table>
                    </div>
                </div>

                <div v-if="ipPayslip"> Net Payable (Total Earnings - Total Deductions) :
                    <b> {{ (ipPayslip.totalEarnings-ipPayslip.totalDeductions).toLocaleString('en', {minimumFractionDigits: 2}) }} </b> <br>
                    <b class="text-capitalize"> {{ endPoints.numberToEnglish(ipPayslip.totalEarnings-ipPayslip.totalDeductions,' ') }}</b>
                    <hr>
              </div>
            </div>
        </div>
    </div>
</template>
<script>
import EndPoints from "../../../components/constants/EndPoints";
import PdfPrinter from "../../../components/constants/PdfPrinter";
import DateFomatter from "../../../components/constants/DateFomatter";
import AppData from "../../../components/constants/AppData";
export default {
    data() {
        return {
            title: "IP Payslip",
            user: this.$baseRead("user"),
            loading: true,
            projects: [],
            project: "",
            endPoints: EndPoints,
            dateFomatter: DateFomatter,
            employee: {},
            ipPayslip: null
        }
    },
    methods: {
        printIpPayslip(){
            var tableData = [];
            var tableWidth = ["30%", "20%", "30%", "20%"];
            var earningsHeader = [
                { text: "Earnings", style: "subHeader" },
                { text: "", style: "subHeader" },
                { text: "Deductions", style: "subHeader" },
                { text: "", style: "subHeader" }
            ];
            tableData.push(earningsHeader);

            var NetPayInFigures = this.ipPayslip.totalEarnings-this.ipPayslip.totalDeductions;
            var NetPayInWords = this.endPoints.numberToEnglish(NetPayInFigures);
            var netPayableObj = {
                text: " Net Payable (Total Earnings - Total Deductions) : ".toUpperCase() +
                NetPayInFigures.toLocaleString("en", { minimumFractionDigits: 2 }), margin: [0, 0, 0, 5], style: ["subHeader"]
            };

            var netPayableWords = {
                text: NetPayInWords.toUpperCase(), margin: [0, 0, 0, 5], style: ["subHeader"]
            };

            var underline = {
                text:
                "_______________________________________________________________________________________________",
                margin: [0, 0, 0, 2]
            };

            var username = {text: ' ' +  `${this.employee.title} ${this.user.userRegister.names} [${this.user.username}]` , style: ['subHeader']}
            var pinNo = {text: ' ' +   "P.I.N.: "+ this.employee.pin, style: ['subHeader']}
            var nationalId = {text: ' ' +   "National Id: "+ this.employee.idno, style: ['subHeader']}
            var department = {text: ' ' +   "Department: "+ this.employee.department, style: ['subHeader']}
            var bank = {text: ' ' +   "Bank/Branch: "+ this.employee.bank, style: ['subHeader']}
            var jobTitle = {text: ' ' +   "Job Title: "+ this.employee.jobTitle, style: ['subHeader']}
            var nhif = {text: ' ' +   "NHIF: "+ this.employee.nhif, style: ['subHeader']}
            var nssf = {text: ' ' +   "NSSF: "+ this.employee.nssf, style: ['subHeader']}
            var pgrade = {text: ' ' +   "NSSF: "+ this.employee.pgrade, style: ['subHeader']}
            var rDate = {text: ' ' +   "Date: "+ this.dateFomatter.ReturnDate(this.ipPayslip.ipProcess.rDate), style: ['subHeader']}

            var reportHeader = "PAYSLIP FOR " + this.project;
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
                tableWidth: tableWidth,
                underline: underline,
                reportHeader: reportHeader.toUpperCase(),
                fileName: AppData.getFileName("Payslip", this.user.username)
            };

            var i = 0;
            this.ipPayslip.earnings.forEach(element => { 
                var rowData = [
                    { text: " " + element.payAccount, style: ["content"] },
                    { text: " " + element.amount, style: ["numeric"] },
                    { text: " " + this.ipPayslip.deductions[i].projectName, style: ["content"] },
                    { text: " " + this.ipPayslip.deductions[i].deductionAmount, style: ["numeric"] }
                ];

                i++;
                tableData.push(rowData);
            });

            var earningsHeader = [
                { text: "", style: ["content"] },
                { text: "", style: ["content"] },
                { text: "", style: ["content"] },
                { text: "", style: ["content"] }
            ];
            tableData.push(earningsHeader);

            var totals = [
                { text: "Total Earnings", style: "subHeader" },
                { text: this.ipPayslip.totalEarnings.toLocaleString("en", { minimumFractionDigits: 2 }), style: "numeric" },
                { text: "Total Deductions", style: "subHeader" },
                { text: this.ipPayslip.totalDeductions.toLocaleString("en", { minimumFractionDigits: 2 }),  style: "numeric" }
            ];

            tableData.push(totals);
            PdfPrinter.printPdf(tableData, detailsObject);
        },
        getIpPayslip(){
            this.loading = true;
            this.$http.get("ipPayslip/getIpPaySlip/?userCode=" + this.user.username + "&project=" + this.project)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    console.log(result.data);
                    this.ipPayslip = result.data.data
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        getProjects(){
            this.loading = true;
            this.$http.get("ipPayslip/getIpProjects/?userCode=" + this.user.username)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    this.projects = result.data.data
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        fetchEmpInfo(){
            this.$http.get("profile/getStaffData?userCode="+ this.user.username)
            .then(result => {
                if(result.data.success){
                this.employee =  result.data.data
                this.employmentStatusTitle = this.employee.terminated ? "Terminated" : "Employed"
                }
            }).catch(error => {
                this.$toastr("error", error.message)
            })
        }
    },
    created(){
        this.getProjects()
        this.fetchEmpInfo();
    }
}
</script>
<style>

</style>
