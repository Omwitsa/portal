<template>
    <div class="page-body">

        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span>{{subTitle}}.</span>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
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
                curriculum: [],
                studentDetails: {
                    studentProgramme: {
                        programme: ''
                    },
                    studentClass: {
                        className: ''
                    },
                    studentSemester: {
                        yearOfStudy: '',
                        semester: ''
                    }
                },
                currentOpenSession: {
                    year: '',
                    session: ''
                },
                loading: false,
                loadingStudentDetails: false,
                title: "Examination history",
                subTitle: "",
                user: this.$baseRead('user'),
            }
        },

        methods: {
            loadData() {
                this.loading = true
                this.curriculum = []

                this.$http
                    .get("units/ReturnStudentCurriulum?userCode=" + this.user.username)
                    .then(result => {
                        this.loading = false
                        this.curriculum = result.data.data

                    })
                    .catch(error => {
                        this.loading = false
                        this.$toastr("error", error.message)
                    })

            },
            checkCurrentSemester(semester, stage) {
                return semester === this.studentDetails.studentSemester.semester
                    .substring(0, this.studentDetails.studentSemester.semester.length - 5) && stage === this.studentDetails.studentSemester.yearOfStudy;
            },
            getStudentDetails() {
                this.loadingStudentDetails = true
                this.$http.get("commonutilities/GetStudentAcademicInfo?userCode=" + this.user.username)
                .then(result => {

                    this.studentDetails = result.data.data;
                    this.currentOpenSession.session = this.studentDetails.studentSemester.semester.substring(0, this.studentDetails.studentSemester.semester.length - 5);
                    this.currentOpenSession.year = this.studentDetails.studentSemester.yearOfStudy;
                    this.loadingStudentDetails = false
                    this.loadData();
                })
                .catch(error => {
                    this.loadingStudentDetails = false
                    this.$toastr("error", error.message)
                })

            },
            openCurrentSession(year, session) {
                this.currentOpenSession.session = session;
                this.currentOpenSession.year = year;
            }
        },
        created() {
            this.getStudentDetails();
        }
    }
</script>


