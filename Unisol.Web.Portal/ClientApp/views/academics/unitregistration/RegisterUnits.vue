<template>
  <div class="page-body">
    <div class="col-md-12 card" style="padding: 10px;">
      <div class="text-center" v-if="loadingStudentDetails">
        <small-spinner :loading="loadingStudentDetails"></small-spinner>
        <br>Fetch your department Details...
      </div>
      <div class="card-body" v-if="!loadingStudentDetails">
        <div>Program : {{studentDetails.studentProgramme.programme}}</div>
        <div>Class : {{studentDetails.studentClass.className}}</div>
        <div>Session : {{studentDetails.studentSemester.yearOfStudy}} {{studentDetails.studentSemester.semester}}</div>
        <div v-if="!loading">
          Unit Registration :
          <span
            v-if="!unitRegistrationDeadline"
            class="label label-danger"
          >Closed</span>
          <span v-if="unitRegistrationDeadline" class="label label-success">Open</span>
          Reported Status :
          <span
            v-if="!reportedCurrentSem"
            class="label label-danger">Not reported / Reporting pending</span>
          <span v-if="reportedCurrentSem" class="label label-success">Reported</span>
        </div>
      </div>
    </div>
    <div class="card" v-if="loading">
      <div class="text-center">
        <i class="fa fa-spin fa-spinner"></i>
        <br>Fetching your current units...
      </div>
    </div>
    <div class="card" v-if="!loading" v-for="(yearlyUnits, yIndex) in regUnits" :key="yIndex">
      <div class="card-header">
        <h5>{{yearlyUnits.stage}}</h5>
        <span>Stage Of Study</span>

        <div class="modal-footer pull-right" v-if="registerValidity&&unitRegistrationDeadline&&reportedCurrentSem">
          <div class="btn btn-primary btn-round waves-effect waves-light btn-sm" @click="saveUnits()">
            <small-spinner :loading="savingHttp"></small-spinner>Submit
          </div>
        </div>
      </div>

      <div class="card-block">
        <div class="panel-group" v-for="(semester,index) in yearlyUnits.semesters" :key="index">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse1">{{semester.semesterName}}</a>
              </h4>
            </div>
            <div class="panel-collapse">
              <ul class="list-group">
                <li class="list-group-item"
                  style="border: 0 none #ccc;border-bottom: 2px solid #ccc;"
                  v-for="(unit,index) in semester.curriculumUnits" :key="index">
                  <div class="col-md-12 row">
                    <div class="col-md-2">
                      <label class="customcheck">
                        {{unit.unitCode}}
                        <input
                          type="checkbox"
                          v-model="unit.doneStatus"
                          :id="'checkbox_'+index"
                          v-if="!unit.donePreviously"
                          :disabled="!checkCurrentSemester(semester.semesterName,yearlyUnits.stage) && !unit.unitRegLevel">

                        <input
                          type="checkbox"
                          v-if="unit.donePreviously"
                          v-model="unit.donePreviously"
                          :disabled="unit.donePreviously">

                        <span
                          class="checkmark"
                          v-if="unit.donePreviously"
                          style="background-color:green!important"
                        ></span>
                        <span class="checkmark" v-if="!unit.donePreviously"></span>
                      </label>
                    </div>
                    <div class="col-md-6">{{unit.unitName}}</div>
                    <div class="col-md-2">{{unit.type}}</div>
                    <div class="col-md-2">
                      <label :class="getClassStyle(unit.status)">{{unit.status}}</label>
                    </div>
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="card-footer">
      <div class="modal-footer pull-right"
        v-if="registerValidity&&unitRegistrationDeadline&&reportedCurrentSem">
        <div class="btn btn-primary btn-round waves-effect waves-light btn-sm" @click="saveUnits()">
          <small-spinner :loading="savingHttp"></small-spinner>Submit
        </div>
        <button class="btn btn-inverse btn-round waves-effect waves-light btn-sm">Cancel</button>
      </div>
      <div v-if="!loading" class="card-body">
        <div class="alert alert-info"
          v-if="!unitRegistrationDeadline">
          Unit registration deadline has passed.
        </div>
        <div
          class="alert alert-info" v-if="!reportedCurrentSem">
          You haven't reported for the current semester.
        </div>
      </div>
    </div>
  </div>
</template>
<script>
// import END_POINTS from '../../components/constants/EndPoints'
export default {
  data() {
    return {
      clickedIndex: null,
      loading: false,
      savingHttp: false,
      unitRegistrationDeadline: false,
      reportedCurrentSem: false,
      registerValidity: false,
      loadingStudentDetails: false,
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
      regUnits: {
        semesters: [],
        stage: ""
      },
      user: this.$baseRead("user"),
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    getClassStyle(status){
      return status === "Approved" ? "label label-success" : "label label-danger";
    },
    loadData() {
      this.loading = true;
      this.registerValidity = false;
      this.$http.get("units/ReturnStudentCurrentSemesterUnits?userCode=" + this.user.username)
        .then(response => {
          this.loading = false;
          if (response.data.success) {
            var result = response.data.data;
            this.unitRegistrationDeadline = result.unitRegistrationDeadline;
            this.reportedCurrentSem = result.reportedCurrentSem;
            if (result.studentCurriculumViewModel) {
              this.regUnits = result.studentCurriculumViewModel[0] ? result.studentCurriculumViewModel : [];
              this.registerValidity = this.regUnits.length
            }
          } else {
            this.$toastr("error", response.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
            this.regUnits.semesters = [];
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    },
    saveUnits: function() {
      if (this.regUnits) {
        var units = []
        this.regUnits.forEach(element => {
          element.semesters.forEach(s => {
            s.curriculumUnits.forEach(u => {
              if(u.doneStatus){
                units.push(u.unitCode)
              }
            })
          })
        });
        this.saveSemesterUnitToHttp(units)
      }
    },
    saveSemesterUnitToHttp: function(units) {
      this.savingHttp = true;
      var pickedUnits = {
        curriculumUnits: units,
        userCode: this.user.username,
        semester: this.studentDetails.studentSemester.semester
      };
      this.$http.post("units/SaveStudentCurrentSemesterUnits", pickedUnits)
        .then(response => {
          this.savingHttp = false;
          if (response.data.success) {
            this.$router.replace({ name: "Register-Units" });
            this.loadData();
            this.$toastr("success", response.data.message);
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.savingHttp = false;
          this.$toastr("error", "Server error occured,please try again");
        });
    },
    returnSemesterName() {
      return this.studentDetails.studentSemester.semester;
    },
    checkCurrentSemester(semester, stage) {
      var status = semester === this.returnSemesterName() &&
        stage === this.studentDetails.studentSemester.yearOfStudy;
      return status && this.unitRegistrationDeadline && this.reportedCurrentSem;
    },
    getStudentDetails() {
      this.loadingStudentDetails = true;
      this.$http.get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            result.data.data.studentSemester = result.data.data.studentSemester ? result.data.data.studentSemester : {}
            result.data.data.studentSemester.semester = result.data.data.studentSemester.semester ? result.data.data.studentSemester.semester : ""
            result.data.data.studentSemester.yearOfStudy = result.data.data.studentSemester.yearOfStudy ? result.data.data.studentSemester.yearOfStudy : ""
            this.studentDetails = result.data.data;
            this.currentOpenSession.session = this.returnSemesterName();
            this.currentOpenSession.year = this.studentDetails.studentSemester.yearOfStudy;
            this.loadingStudentDetails = false;
          } else {
            this.$toastr("error", response.data.message);
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
    deleteEvaluation: function(id, index) {
      this.evaluations.splice(index, 1);
    }
  },
  created() {
    this.loadData();
    this.getStudentDetails();
  }
};
</script>

<style>
/* The customcheck */
.customcheck {
  display: block;
  position: relative;
  padding-left: 35px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 14px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default checkbox */
.customcheck input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

/* Create a custom checkbox */
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: #eee;
  border-radius: 0px;
}

/* On mouse-over, add a grey background color */
.customcheck:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.customcheck input:checked ~ .checkmark {
  background-color: #005cbf;
  border-radius: 0px;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the checkmark when checked */
.customcheck input:checked ~ .checkmark:after {
  display: block;
}

/* Style the checkmark/indicator */
.customcheck .checkmark:after {
  left: 9px;
  top: 5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
}
</style>