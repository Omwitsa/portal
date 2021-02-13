<template>
  <div class="page-body">
    <div class="col-md-12 card" style="padding: 10px;">
      <div v-if="loadingStudentDetails" class="text-center">
        <small-spinner :loading="loadingStudentDetails"></small-spinner>
        <br>Fetching your department Details...
      </div>
      <div class v-if="!loadingStudentDetails">
        <div class="card-body">
          <div>Program : {{studentDetails.studentProgramme.programme}}</div>
          <div>Class : {{studentDetails.studentClass.className}}</div>
          <div>Session : {{studentDetails.studentSemester.yearOfStudy}} {{studentDetails.studentSemester.semester}}</div>
        </div>
      </div>
    </div>
    <div class="card" v-if="loading">
      <div class="text-center">
        <i class="fa fa-spin fa-spinner"></i>
        <br>Fetching your unit registration history...
      </div>
    </div>
    <div class="card" v-for="(program,index) in unitHistory" :key="index">
      <div class="card-header">
        <h5>{{program.stage}}</h5>
        <span>Stage Of Study</span>
        <!-- <div class="card-header-right"><span class="badge badge-primary">{{program.semesters.length}}</span>
        </div>-->
      </div>
      <div class="card-block">
        <div class="panel-group" v-for="(semester,index) in program.semesters" :key="index">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h4 class="panel-title">
                <a
                  data-toggle="collapse"
                  href="#collapse1"
                  @click="openCurrentSession(program.stage,semester.semesterName)"
                >{{semester.semesterName}}</a>

                <!-- <span class="badge badge-primary pull-right small" style="font-size: 12px;">
                                    {{semester.curriculumUnits.length}}
                </span>-->
              </h4>
            </div>
            <div class="panel-collapse">
              <ul
                class="list-group"
                v-if="currentOpenSession.year==program.stage&&currentOpenSession.session==semester.semesterName"
              >
                <li
                  class="list-group-item"
                  style="border: 0 none #ccc;border-bottom: 2px solid #ccc;"
                  v-for="(unit,index) in semester.curriculumUnits"
                  :key="index"
                >
                  <div class="col-md-12 row">
                    <div class="col-md-2">{{unit.unitCode}}</div>
                    <div class="col-md-6">{{unit.unitName}}</div>
                    <div class="col-md-2">{{unit.type}}</div>
                    <div class="col-md-2">
                      <span
                        class="label label-success"
                        v-if="unit.status=='Approved'"
                      >{{unit.status}}</span>
                      <span
                        class="label label-danger"
                        v-if="unit.status!='Approved'"
                      >{{unit.status}}</span>
                    </div>
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      unitHistory: [],
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
      user: this.$baseRead("user")
    };
  },

  methods: {
    loadData() {
      this.loading = true;
      this.unitHistory = [];
      this.$http
        .get(
          "units/GetStudentUnitRegisteredHistory?userCode=" + this.user.username
        )
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            this.unitHistory = result.data.data;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
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
        semester ===
          this.studentDetails.studentSemester.semester.substring(
            0,
            this.studentDetails.studentSemester.semester.length - 5
          ) && stage === this.studentDetails.studentSemester.yearOfStudy
      );
    },
    getStudentDetails() {
      this.loadingStudentDetails = true;
      this.$http
        .get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            result.data.data.studentSemester = result.data.data.studentSemester ? result.data.data.studentSemester : {}
            result.data.data.studentSemester.semester = result.data.data.studentSemester.semester ? result.data.data.studentSemester.semester : ""
            this.studentDetails = result.data.data;
            this.currentOpenSession.session = this.studentDetails.studentSemester.semester
            .substring(0,this.studentDetails.studentSemester.semester.length - 5);
            this.currentOpenSession.year = this.studentDetails.studentSemester.yearOfStudy;
            this.loadingStudentDetails = false;
            this.loadData();
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
    openCurrentSession(year, session) {
      this.currentOpenSession.session = session;
      this.currentOpenSession.year = year;
    }
  },
  created() {
    this.getStudentDetails();
  }
};
</script>


