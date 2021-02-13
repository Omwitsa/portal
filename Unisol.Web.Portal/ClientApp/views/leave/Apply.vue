<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span>{{subTitle}}</span>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="row col-md-12">
            <div class="col-md-6">
              <div class="form-group">
                <label for>Leave Type</label>
                <select
                  v-model="leave.LeaveType"
                  @change="getMaxLeaveDays(leave.LeaveType)"
                  class="form-control">
                  <option
                    v-for="(type, gIndex) in leaveTypes"
                    :key="gIndex"
                    :value="type.leavetype"
                  >{{type.leavetype}} || {{type.leavedays}}</option>
                </select>
              </div>
            </div>
            <div class="col-md-3">
              <fg-input
                type="number"
                label="Entitled Days"
                placeholder="Balance Days"
                readonly
                v-model="leave.MaxLeaveDays"
              />
            </div>
            <div class="col-md-3">
              <fg-input
                type="number"
                label="Remaining Days"
                placeholder="Leave Days"
                readonly
                v-model="pendingBalDays"
              />
            </div>
          </div>
          <div class="row container">
            <div class="col-md-4">
              <label>Start Date</label>
              <date-picker v-model="leave.Sdate" :disabled-dates="disabledDates" :config="options"></date-picker>
              <br>
            </div>
            <div class="col-md-1.5">
              <div class="form-group">
                <label>Time</label>
                <select class="form-control" v-model="leave.Stime" @change="calcLeaveDays()">
                  <option>AM</option>
                  <option>PM</option>
                </select>
              </div>
            </div>

            <div class="col-md-4">
              <label>End Date</label>
              <span v-if="pickEnd">
                <date-picker v-model="leave.Edate" :config="options"></date-picker>
              </span>
              <span v-if="!pickEnd">
                <code>Pick start date</code>
                <input type="text" class="form-control" placeholder="End Date" readonly>
              </span>
              <br>
            </div>
            <div class="col-md-1.5">
              <div class="form-group">
                <label>Time</label>
                <select class="form-control" v-model="leave.Etime" @change="calcLeaveDays()">
                  <option>AM</option>
                  <option>PM</option>
                </select>
              </div>
            </div>

            <div class="col-md-2">
              <fg-input
                type="number"
                label="Leave Days"
                placeholder="Leave Days"
                readonly
                v-model="leaveDiffDays"
              />
            </div>
          </div>

          <div class="col-md-6">
            <div class="form-group">
              <label for>Reliever</label>
              <v-select
                :options="relievers"
                v-model="leave.Reliever"
              ></v-select>
            </div>
          </div>

          <div class="col-md-6" v-if="isAbno && leaveHasDocuments">
            <div class="form-group">
              <label>Upload Document</label>
              <input class="form-control" type="file"  @change="fileChanged">
            </div>
          </div>

          <div class="col-md-12">
            <div class="form-group">
              <label for>leave details</label>
              <br>
              <textarea class="form-control" v-model="leave.Notes" placeholder="leave details"></textarea>
            </div>
          </div>
          <div class="col-md-12">
            <div class="form-group">
              <input type="checkbox" id="emergency" v-model="leave.emergency" :disabled="this.leave.isEmergency">
              <label for="emergency">Emergency Leave</label>
            </div>
          </div>
        </div>
      </div>
      <div class="card-footer">
        <div class="pull-right">
          <button
            class="btn btn-primary btn-round waves-effect waves-light"
            :class="submitBtnClass()"
            :loading="submitting"
            :disabled="submitting||!canSubmit"
            @click.prevent="save"
          >Submit</button>
          <button @click="cancel" class="btn btn-inverse btn-round waves-effect waves-light">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import dateFomater from "../../components/constants/EndPoints";
export default {
  data() {
    return {
      dateFomater: dateFomater,
      leave: {
        isEmergency: true
      },
      employee: {},
      leaveHasDocuments: false,
      leaveTypes: [],
      relievers: [],
      leaveDiffDays: 0,
      pendingBalDays: 0,
      submitting: false,
      subTitle: "Add Leave Request",
      title: "Apply",
      buttonText: "Submit",
      settings: JSON.parse(localStorage.getItem("settings")),
      isAbno: false,
      pickEnd: false,
      canSubmit: false,
      disabledDates: {
       to: new Date(), 
      },
      options: {
        format: 'DD/MM/YYYY',
        useCurrent: false,
      } 
    };
  },
  created() {
    this.employee = this.$baseRead("user");
    this.isAbno = this.settings.initials === 'ABNO'
    this.getEmpLeaveTypes();
    this.initLeaveProps();
  },

  watch: {
    "leave.Sdate"() {
      this.pickEnd = true;
      this.calcLeaveDays();
    },
    "leave.Edate"() {
      this.calcLeaveDays();
    }
  },

  methods: {
    fileChanged(event) {
      this.leave.documents = event.target.files[0]
    },
    initLeaveProps() {
      var date = new Date();
      var timestamp = date.getTime();
      this.leave.Ref = this.employee.username + "." + timestamp;
      this.leave.Status = "Pending";
      this.leave.EmpNo = this.employee.username;
      this.leave.Etime = "PM";
      this.leave.Stime = "AM";
      this.leave.Personnel = this.employee.username;
      this.leave.LeavePeriod = date.getFullYear();
      this.leave.LeaveDays = 0;
      this.leave.MaxLeaveDays = 0;
    },

    getMaxLeaveDays(leaveType) {
      var myArray = this.leaveTypes;
      for (var i = 0; i < myArray.length; i++) {
        if (myArray[i].leavetype == leaveType) {
          this.leave.MaxLeaveDays = myArray[i].leavedays;
          this.leave.isEmergency = !myArray[i].emergency;
          if(!myArray[i].emergency){
            this.leave.emergency = false
          }
        }
        this.leaveHasDocuments = true
        if(leaveType.trim().toUpperCase() === 'ANNUAL LEAVE' ||  leaveType.trim().toUpperCase().includes("Compassionate")){
          this.leaveHasDocuments = false
        }

        this.pendingBalDays = this.leave.MaxLeaveDays;
        this.leaveDiffDays = this.leave.LeaveDays = 0;
        this.canSubmit = false;
      }
    },

    toDate(date) {
      var from = date.split("/")
      return new Date(from[2], from[1] - 1, from[0])
    },

    calcLeaveDays() {
      var today = new Date();
      var startDate = this.toDate(this.leave.Sdate)
      var endDate = this.toDate(this.leave.Edate)
      if (!this.leave.Edate) 
        return;
      
      var dateList = this.getDatesList(startDate, endDate)
      var getDatesRequest = {
        SDate: startDate,
        EDate: endDate,
        LeavePeriod: this.leave.LeavePeriod,
        Dates: dateList,
        LeaveType: this.leave.LeaveType
      };

      if (dateList.length <= 0) {
        this.$toastr("error", "Invalid dates selected");
        this.leaveDiffDays = 0;
        this.leave.Edate = '';
        this.canSubmit = false;
        this.return;
      } 
      else {
        this.submitting = true;
        this.$http.post("leave/getValidLeaveDates", getDatesRequest)
          .then(response => {
            this.submitting = false;
            if (response.data.success) {
              var vDates = response.data.data;
              var validDays = vDates.length;
              validDays = this.calcHalfDays(
                validDays,
                this.leave.Stime,
                this.leave.Etime,
                this.leave.Sdate,
                this.leave.Edate
              );

              if (validDays <= 0) {
                this.$toastr("error", "Invalid leave days");
                this.leaveDiffDays = 0;
                this.leave.Edate = '';
                this.canSubmit = false;
                return;
              } 
              else if (validDays > this.leave.MaxLeaveDays) {
                this.$toastr("error", "Invalid. Maximum days : " + this.leave.MaxLeaveDays);
                this.leaveDiffDays = 0;
                this.leave.Edate = '';
                this.canSubmit = false;
                return;
              }
              this.canSubmit = true;

              this.leaveDiffDays = this.leave.LeaveDays = validDays;
              this.pendingBalDays = this.leave.MaxLeaveDays - validDays;
            } else {
              this.$toastr("error", response.data.message);
            }
            this.submitting = false;
          }).catch(e => {
            this.submitting = true;
            this.$toastr("error", "An error occured,please contact administrator");
          });
      }
    },

    getDatesList(startDate, endDate) {
      var dates = [],
        currentDate = startDate,
        addDays = function(days) {
          var date = new Date(this.valueOf());
          date.setDate(date.getDate() + days);
          return date;
        };
      while (currentDate <= endDate) {
        dates.push(currentDate);
        currentDate = addDays.call(currentDate, 1);
      }
      return dates;
    },

    calcHalfDays(days, sTime, eTime, sDate, Edate) {
      if ((sTime == "AM" && eTime == "AM") || (sTime == "PM" && eTime == "PM")){
        days = days - 0.5
      }
      else if((sDate == Edate) && (sTime == "PM" && eTime == "AM")) {
        days = -0.5
      }
      else if((sDate != Edate) && (sTime == "PM" && eTime == "AM")){
         days = days -1
      }
      else{
        days
      }
      
      return days;
    },

    getEmpLeaveTypes() {
      this.$http.get("leave/getLeaveDaysCredit?empNo=" + this.employee.username)
        .then(result => {
          this.leaveTypes = [];
          if (result.data.success) {
            var id = 0;
            result.data.data.leave.forEach(element => {
              id++;
              element.id = id
              element.leavetype = element.leaveType
              element.leavedays = element.leaveDays
              element.leavegroup = element.leaveGroup
            });
            
            this.leaveTypes = result.data.data.leave
            
            result.data.data.employees.forEach(element => {
               this.relievers.push(`${element.names}-(${element.empNo})`)
            });
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.assignText = "Error fetching User leave types";
        });
    },
    cancel(){
      this.$router.replace({ name: "leave" });
    },
    save() {
      if (!this.leave.LeaveType) {
        this.$toastr("error", "Please select leave type to apply");
        return;
      }
      if (this.leave.LeaveDays <= 0) {
        this.$toastr("error", "Invalid leave days submitted");
        return;
      }
      if(this.isAbno && this.leaveHasDocuments){
        this.uploadDocument()
      }
      else{
        this.submitLeave()
      }
    },
    uploadDocument(){
      this.submitting = true
      if(!this.leave.documents){
        this.$toastr("error", "Kindly, attach your leave document")
        return
      }
      const formData = new FormData()
      formData.append("leaveDocument", this.leave.documents, this.leave.documents.name)
      this.$http.post(`leave/uploadDocument?usercode=${this.employee.username}&type=${this.leave.LeaveType}`, formData, {
      headers: {
          "Content-Type": "multipart/form-data"
      }})
      .then(response => {
          this.submitting = false
          if (response.data.success) {
              this.submitLeave()
          } else {
              this.$toastr("error", response.data.message)
          }
      })
      .catch(e => {
          this.submitting = false
          this.$toastr("error", e.message)
      })
    },
    submitLeave(){
      var tempEdate = this.leave.Edate
      this.leave.Edate = this.toDate(this.leave.Edate)
      var tempSdate = this.leave.Sdate
      this.leave.Sdate = this.toDate(this.leave.Sdate)
      this.leave.LeaveDays = this.leaveDiffDays;
      this.submitting = true;
      this.$http.post("leave/applyleave", this.leave)
      .then(response => {
        this.leave.Edate = tempEdate
        this.leave.Sdate = tempSdate
        if (response.data.success) {
          this.$toastr("success", "Success");
          this.$router.replace({ name: "leave" });
        } else {
          this.$toastr("error", response.data.message);
        }
        this.submitting = false;
      })
      .catch(e => {
        this.submitting = true;
        this.$toastr(
          "error",
          "An error occured,please contact administrator"
        );
      });
    },
    
    submitBtnClass() {
      return this.canSubmit ? "" : "disabled";
    }
  },
  computed: {}
};
</script>

<style>
</style>
