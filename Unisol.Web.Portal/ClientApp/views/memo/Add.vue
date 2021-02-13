<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">From</div>
                    <div class="col-md-8">
                        <input v-model="memo.deptFrom" type="text" class="form-control" disabled/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">To</div>
                    <div class="col-md-8">
                        <v-select :options="memo.departments" v-model="memo.deptTo"></v-select>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">Subject</div>
                    <div class="col-md-8">
                        <input v-model="memo.subject" type="text" class="form-control"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">Details</div>
                    <div class="col-md-8">
                        <textarea v-model="memo.description" type="text" class="form-control" rows="3"/>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">Participants</div>
                    <div class="col-md-8">
                        <button data-toggle="modal" data-target="#memoParticipantModal" class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1">
                            <i class="fa fa-plus-circle"></i> Add Participant
                        </button> 
                        <div class="table-responsive"> <br>
                            <table class="table table-sm table-bordered">
                                <tbody>
                                    <tr v-for="(participant, index) in participants" :key="index">
                                        <td>{{participant.empNo}}</td>
                                        <td>{{participant.names}}</td>
                                        <td>{{participant.department}}</td>
                                        <td>{{participant.jobCat}}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                       Starts
                    </div>
                    <div class="col-md-3">
                        <date-picker v-model="memo.sdate" :config="options"></date-picker>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-2">
                       Ends
                    </div>
                    <div class="col-md-3">
                        <date-picker v-model="memo.edate" :config="options"></date-picker>
                    </div>
                </div> <br>
            </div>

            <div class="modal fade" id="memoParticipantModal" role="dialog">
              <div class="modal-dialog modal-lg">
                <div class="modal-content">
                  <div class="modal-header text-left">
                    <div class="h5">Add Partcipant</div>
                  </div>

                  <div class="modal-body">
                    <form>
                      <div>
                          <v-select :options="memo.participants" v-model="memo.participant"></v-select>
                      </div>
                    </form>
                  </div>

                  <div class="modal-footer">
                    <div class="pull-right">
                      <submit-button
                        :title="buttonText"
                        styling="btn btn-primary btn-round waves-effect waves-light btn-sm"
                        :loading="submitting"
                        v-on:submit="addParticipant()"
                      ></submit-button>
                      <button
                        class="btn btn-inverse btn-round waves-effect waves-light btn-sm"
                        data-dismiss="modal"
                      >Cancel</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            memo: {},
            user: this.$baseRead("user"),
            loading: true,
            buttonText: "Add",
            title: "Request Memo",
            subTitle: "",
            participants: [],
            employees: [],
            submitting: false,
            options: {
                format: 'DD/MM/YYYY',
                useCurrent: false,
            }, 
        }
    },
    watch: {
        "memo.sdate"(){
            this.memo.edate = ""
            if(this.toDate(this.memo.sdate) < new Date()){
                this.$toastr("error", "Start date has to be greater than today");
                this.memo.sdate = ""
            }
        },
        "memo.edate"(){
            if(this.toDate(this.memo.sdate) >  this.toDate(this.memo.edate)){
                this.$toastr("error", "Start date can't be greater than End date");
                this.memo.edate = ""
            }
        }
    },
    methods: {
        getUserDetails(){
            this.loading = true;
            this.$http.get("memo/getMemoResources/?usercode=" + this.user.username)
            .then(result => {
                this.memo = {}
                this.loading = false
                this.memo.deptFrom = result.data.data.staffDetails.department
                this.memo.departments = result.data.data.departments
                this.employees = result.data.data.participants
                this.memo.participants = []
                result.data.data.participants.forEach(element => {
                    this.memo.participants.push(element.names);
                });
            })
            .catch(error => {
                this.loading = false;
            });
        },
        toDate(date) {
            var from = date.split("/")
            return new Date(from[2], from[1] - 1, from[0])
        },
        addParticipant(){
            var participantName = this.memo.participant
            var selectedMessage = this.employees.filter(function(employee) {
                return employee.names == participantName
            });
            var selectedEmployee = []
            this.participants.forEach(element => {
                selectedEmployee.push(element.empNo)
            });
            selectedMessage.forEach(element => {
                if(!selectedEmployee.includes(element.empNo)){
                    this.participants.push(element)
                }
                $('#memoParticipantModal').modal('toggle');
            });
        },
        save(){
            this.submitting = true
            this.memo.sdate = this.toDate(this.memo.sdate)
            this.memo.edate = this.toDate(this.memo.edate)
            var reguestedMemo = {
                imprestMemo: this.memo,
                imprestMemoDetail: this.participants
            }

            this.$http.post("memo/reguestMemo/?usercode=" + this.user.username, reguestedMemo)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.$router.replace({ name: "onlineMemo" });
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
            })
        },
    },
    created(){
        this.getUserDetails()
    }
}
</script>
<style>

</style>

