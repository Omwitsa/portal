<template>
    <div class="tab-pane active" role="tabpanel">
        <small-spinner :loading="httpStatus"></small-spinner>
        <div class="card">
            <div class="card-header">
                <h5 class="card-header-text">Student Examination Settings </h5>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox1" v-model="settings.examCardStatus">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox1"> Allow students to download Examination Card</label>
                       <br/>
                        <span 
                        class="" 
                        style="color:grey;font-size:12px">
                        If turned <b>OFF</b>, Students will not be able to download their exam cards online</span>
                    </div>
                </div>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox2" v-model="settings.retake">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox2"> Enable Retake</label>
                       <br/>
                        <span class="" style="color:grey;font-size:12px">If turned <b>OFF</b>, Studemts will not be able to do retake</span>
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox3" v-model="settings.viewTranscripts">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox3"> View/Download Transcripts</label>
                       <br/>
                        <span class="" style="color:grey;font-size:12px">If turned <b>OFF</b>, Studemts will not be able to download or view their transcripts</span>
                    </div>
                </div>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox4" v-model="settings.onlineUnitRegistration">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox4"> Allow Online Unit Registration</label>
                       <br/>
                    <span class="" style="color:grey;font-size:12px">If  turned <b>OFF</b>, Students will not be able to register units online</span>
     
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h5 class="card-header-text">Portal Settings </h5>
               
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox"  id="checkbox5" v-model="settings.loginStatus">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox5"> Allow Student to Login</label>
                       <br/>
                     <span class="" style="color:grey;font-size:12px">If turned <b>OFF</b>, Students will not be able to login in to the portal</span>
     
                    </div>
                </div>
            </div>
             <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox6" v-model="settings.onlineReporting">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox6"> Enable/ Disable Online Reporting</label>
                       <br/>
                   <span class="" style="color:grey;font-size:12px">If  turned <b>OFF</b>, Students will not be able to report via the portal
                   </span>
     
                    </div>
                </div>
            </div>
            
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox7" v-model="settings.onlineBooking">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox7"> Online Room Booking</label>
                       <br/>
                       <span class="" style="color:grey;font-size:12px">If turned <b>OFF</b>, Students will not be able to view or book rooms online</span>
                    </div>
                </div>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox8" v-model="settings.profileEditing">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox8">  Allow Direct Profile Editing</label>
                       <br/>
                   <span class="" style="color:grey;font-size:12px">If turned <b>OFF</b>, All User will not be able to Edit their profile details</span>
     
                    </div>
                </div>
            </div>
        </div>

       <div class="card">
            <div class="card-header">
                <h5 class="card-header-text"> Fees Settings</h5>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox9" v-model="settings.feesViewing">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox9">  Allow Online Fees Viewing</label>
                       <br/>
                   <span class="" style="color:grey;font-size:12px">If  turned <b>OFF</b>, Students will not be able to view/ download their Fees details</span>
     
                    </div>
                </div>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="switch"> 
                                <input type="checkbox" id="checkbox10" v-model="settings.feeStructure">
                                <span class="slider round"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-10">
                       <label for="checkbox10">  Allow Online Fees Structure Viewing</label>
                       <br/>
                   <span class="" style="color:grey;font-size:12px">If  turned <b>OFF</b>, Students will not be able to view/ download their Fees details</span>
     
                    </div>
                </div>
            </div>
        </div>

        <div class="card" v-if="institutionInitial=='UOEM'">
            <div class="card-header">
                <h5 class="card-header-text">Hostel Allocation Ratio (Percentage)</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-3">
                        <label>First year</label>
                        <input class="form-control border-input" v-model="firstYearHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>

                    <div class="col-md-3">
                        <label>Second year</label>
                        <input class="form-control border-input" v-model="secondYearHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>

                    <div class="col-md-3">
                        <label>Third year</label>
                        <input class="form-control border-input" v-model="thirdYearHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>

                    <div class="col-md-3">
                        <label>Forth year</label>
                        <input class="form-control border-input" v-model="fourthYearHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>
                </div>
            </div>
        </div>

        <div class="card" v-if="institutionInitial=='PCKTTI'">
            <div class="card-header">
                <h5 class="card-header-text">Hostel Allocation Ratio (Percentage)</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-6">
                        <label>PSSP</label>
                        <input class="form-control border-input" v-model="psspHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>
                    <div class="col-md-6">
                        <label>NYS</label>
                        <input class="form-control border-input" v-model="nysHostelRatio" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>
                </div>
            </div>
        </div>

        <div class="card" v-if="institutionInitial=='UOEM'">
            <div class="card-header">
                <h5 class="card-header-text">Hostel Deallocation</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-3">
                        <label>Booking Start Date</label>
                        <date-picker v-model="bookingStartDate" :config="options"></date-picker>
                    </div>

                    <div class="col-md-3">
                        <label>Duration (Hours)</label>
                        <input class="form-control border-input" v-model="hostelDuration" type="number" min="0" oninput="validity.valid||(value='');">
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h5 class="card-header-text">ExamCard Notes</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <label>Notes</label>
                        <textarea rows="3" class="form-control border-input" v-model="examCardNotes">

                        </textarea>
                    </div>
                </div>
            </div>
        </div>

        <div class="card" v-if="classStatus.length">
            <div class="card-header">
                <h5 class="card-header-text"> Student class status settings</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12" v-for="(classState, index) in classStatus" :key="index">
                        <div :key="index" class="checkbox-color checkbox-primary" >
                            <input type="checkbox" :id="index" v-model="classState.checked"  >
                            <label :for="index">
                                {{classState.names}}
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h5 class="card-header-text">Units displayed</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-4">
                        <v-select v-model="unitsLevel" :options=unitsLevels></v-select>
                    </div>
                </div>
            </div>
        </div>
         
        <div class="card">
            <div class="card-block text-right">
                <submit-button :title="buttonText"
                styling="btn btn-primary btn-round waves-effect waves-light "
                :loading="submitting" v-on:submit="save" ></submit-button>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  data() {
    return {
        buttonText: "Update Settings",
        classStatus: [],
        firstYearHostelRatio: "",
        secondYearHostelRatio: "",
        thirdYearHostelRatio: "",
        fourthYearHostelRatio: "",
        institutionInitial: "",
        psspHostelRatio: "",
        nysHostelRatio: "",
        examCardNotes: "",
        hostelDuration: 0,
        bookingStartDate: null,
        selectedStatus: [],
        unitsLevels: [],
        portalSettings: JSON.parse(localStorage.getItem('settings')),
        unitsLevel: "",
        submitting :false,
        httpStatus :false,
        options: {
            format: 'DD/MM/YYYY',
            useCurrent: false,
        } ,
        settings: {
            examCardStatus : false,
            onlineReporting : false,
            profileEditing: false,
            onlineBooking : false,
            loginStatus : false,
            onlineUnitRegistration : false,
            viewTranscripts : false,
            feesViewing: false,
            retake: false
        }
    }
  },
  methods: {
        toDate(date) {
            date = date ? date : ""
            var from = date.split("/")
            return new Date(from[2], from[1] - 1, from[0])
        },
        getClassStatus(){
            this.$http.get("portalconfig/getClassStatus")
            .then(response => {
                if (response.data.success) {
                    response.data.data.classStatus.forEach(element => {
                        var checkedValues = this.selectedStatus.includes(element.names);
                        element.checked = checkedValues
                    });
                    this.classStatus = response.data.data.classStatus
                    this.institutionInitial = response.data.data.institutionInitial
                    this.selectedStatus = []
                }else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
            })
        },
        getSelectedClassStatus(){
            this.$http.get("portalconfig/selectedPortalClassStutus")
            .then(response => {
                if (response.data.success) {
                    this.hostelDuration = response.data.data.setting.hostelDuration
                    this.options.date = response.data.data.setting.hostelBookingStartDate
                    var hostelRatio = response.data.data.setting.hostelRatio ? response.data.data.setting.hostelRatio.split(")*(") : []
                    if(this.institutionInitial != 'PCKTTI'){
                        this.firstYearHostelRatio = hostelRatio[0] ? parseInt(hostelRatio[0]) : 0
                        this.secondYearHostelRatio = hostelRatio[1] ? parseInt(hostelRatio[1]) : 0
                        this.thirdYearHostelRatio = hostelRatio[2] ? parseInt(hostelRatio[2]) : 0
                        this.fourthYearHostelRatio = hostelRatio[3] ? parseInt(hostelRatio[3]) : 0
                    }
                    else{
                        this.psspHostelRatio = hostelRatio[0] ? parseInt(hostelRatio[0]) : 0
                        this.nysHostelRatio = hostelRatio[1] ? parseInt(hostelRatio[1]) : 0
                    }

                    this.selectedStatus = response.data.data.setting.classStatus ? response.data.data.setting.classStatus.split(",") : []
                    this.unitsLevels = response.data.data.unitsLevels
                    this.unitsLevel = response.data.data.unitLevel ? response.data.data.unitLevel : "SessionUnits";
                    this.getClassStatus()
                }else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
            })
        }, 
        getSettings() {
            this.httpStatus = true;
            this.$http.get("portalconfig/getexamcardstatus")
            .then(result => {
                this.httpStatus = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        if (element.code == "001") this.settings.onlineBooking = element.status;
                        if (element.code == "002") this.settings.examCardStatus = element.status;
                        if (element.code == "003") this.settings.loginStatus = element.status;
                        if (element.code == "004") this.settings.viewTranscripts= element.status;
                        if (element.code == "005") this.settings.onlineUnitRegistration = element.status;
                        if (element.code == "006") this.settings.onlineReporting = element.status;
                        if (element.code == "007") this.settings.feesViewing = element.status;
                        if (element.code == "008") this.settings.profileEditing = element.status;
                        if (element.code == "009") this.settings.feeStructure = element.status;
                        if (element.code == "010") this.settings.retake = element.status;
                    })
                }
            })
            .catch(error => {
                this.httpStatus = false;
                this.$toastr("error", error.message)
            })
        },
        save() { 
            this.classStatus.forEach(element => {
                if(element.checked) this.selectedStatus.push(element.names)
            });
            
            var classStatus= this.selectedStatus.join()
            this.submitting = true;
            var setting = [
                { name: "ALLOW ONLINE BOOKING", code: "001", status: this.settings.onlineBooking },
                { name: "ALLOW EXAM CARD DOWNLOAD", code: "002", status: this.settings.examCardStatus },
                { name: "ALLOW ONLINE LOGIN", code: "003", status: this.settings.loginStatus },
                { name: "ALLOW TRANSCRIPT DOWNLOAD", code: "004", status: this.settings.viewTranscripts },
                { name: "ALLOW ONLINE UNIT REGISTRATION", code: "005", status: this.settings.onlineUnitRegistration },
                { name: "ALLOW ONLINE REPORTING", code: "006", status: this.settings.onlineReporting },
                { name: "ALLOW FEES STATEMENT VIEWING", code: "007", status: this.settings.feesViewing },
                { name: "ALLOW PROFILE EDITING", code: "008", status: this.settings.profileEditing },
                { name: "ALLOW FEES STRUCTURE VIEWING", code: "009", status: this.settings.feeStructure },
                { name: "ALLOW RETAKE APPLICATION", code: "010", status: this.settings.retake },
            ]

            var hostelRatio = `${this.firstYearHostelRatio} )*( ${this.secondYearHostelRatio} )*( ${this.thirdYearHostelRatio} )*( ${this.fourthYearHostelRatio}`;
            if(this.institutionInitial === 'PCKTTI'){
                hostelRatio = `${this.psspHostelRatio} )*( ${this.nysHostelRatio}`;
            }

            this.submitting = true;
            var portalConfigData = {
                portalConfigs: setting,
                classStatus: classStatus,
                unitsLevel: this.unitsLevel,
                hostelRatio: hostelRatio,
                hostelDuration: this.hostelDuration,
                examCardNotes: this.examCardNotes,
                bookingStartDate: this.toDate(this.bookingStartDate)
            }
            this.$http.post('portalconfig/savePortalSettingsConfigs', portalConfigData) 
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.$router.replace({ name: "other-settings" })
                    this.selectedStatus = []
                    this.getSettings();
                } else {
                    this.$toastr("error", response.data.message)
                }
                
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr("error", e.message)
            })
        }
  } ,
    created () {
        this.institutionInitial = this.portalSettings.initials
        this.examCardNotes = this.portalSettings.ExamCardNotes
        this.getSelectedClassStatus();
        this.getSettings();
    }
}
</script>
<style>
</style>


