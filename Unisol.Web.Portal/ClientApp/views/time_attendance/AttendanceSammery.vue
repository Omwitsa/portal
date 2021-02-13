<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2">
                        <button class="btn btn-primary btn-sm" @click="print()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-1">
                                From
                            </div>
                            <div class="col-md-3">
                                <date-picker v-model="from"></date-picker>
                            </div>

                            <div class="col-md-1">
                                To
                            </div>
                            <div class="col-md-3">
                                <date-picker v-model="to"></date-picker>
                            </div>

                            <div  class="col-md-2">
                                <input v-model="empNo" placeholder="Emp No." type="text" class="form-control"/>
                            </div>

                            <div class="col-md-2">
                                <div class="pull-right">
                                    <button
                                        class="btn btn-primary btn-round waves-effect waves-light" 
                                        :loading="submitting"
                                        @click.prevent="generate"
                                    >Generate</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> <br>

                <div class="row" v-if="attendace">
                    <div class="col-md-12">
                        <div class="table-responsive" id="attendance">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>EmpNo</th>
                                    <th>Names</th>
                                    <th>Hours Worked</th>
                                    <th>Over Time</th>
                                    <th>Lost Hours</th>
                                </thead>
                                <tbody>
                                    <tr v-for="(attend, index) in attendace" :key="index">
                                        <td>{{attend.empNo}}</td>
                                        <td>{{attend.names}}</td>
                                        <td>{{attend.hoursWorked}}</td>
                                        <td>{{attend.overTime}}</td>
                                        <td>{{attend.lostHours}}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data(){
        return {
            attendace: null,
            submitting: false,
            empNo: "",
            from: null,
            to: null,
            subTitle: "",
            title: "Attendance Summery",
            user: this.$baseRead("user"),
        }
    },
    methods : {
        searchByText(enteredText) {
            // this.searchText = enteredText;
            // this.loadData(10, 1);
        },
        generate(){
            this.submitting = true;
            this.from = DateFomatter.ReturnDate(this.from);
            this.to = DateFomatter.ReturnDate(this.to);
            this.$http.get(`attendance/getAttendanceSummery?from=${this.from}&to=${this.to}&empNo=${this.empNo}`)
            .then(result => {
                this.submitting = false;
                if (result.data.success) {
                    this.empNo = ""
                    this.from = null
                    this.to = null
                    this.attendace = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.submitting = false;
            });
        },
        print(){
            this.$htmlToPaper("attendance");
        },
        buttonEvent(item, action) {
            switch (action) {
                case "requests":
                break;
                default:
                break;
            }
        }
    },
    created(){
        this.loadData(10, 1)
    }
}
</script>

<style>

</style>
