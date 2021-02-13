<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-1">Session</div>
                    <div class="col-md-5">
                        <select class="form-control" v-model="retake.term">
                            <option value selected disabled>--Select Term--</option>
                            <option
                                v-for="(term,index) in terms"
                                :value="term.names"
                                :key="index"
                            >{{term.names}}
                            </option>
                        </select>
                    </div>
                </div> <br>

                <div class="row">
                    <div class="col-md-1">Notes</div>
                    <div class="col-md-5">
                        <textarea class="form-control" v-model="retake.notes" rows="3"></textarea>
                    </div>
                </div><br>

                <div class="row">
                    <div v-if="loading" class="col-md-12 text-center">
                        <small-spinner :loading="loading"></small-spinner>
                        <br>Fetching units...
                    </div>
                </div>

                <div class="row" v-for="(program,index) in curriculum" :key="index">
                    <div class="col-md-12"><br>
                        <h5>{{program.stage}}</h5>
                        <div class="panel-group" v-for="(semester,index) in program.semesters" :key="index">
                            <h4 class="panel-title">
                                <a
                                data-toggle="collapse"
                                href="#collapse1"
                                @click="openCurrentSession(program.stage,semester.semesterName)"
                                >{{semester.semesterName}}</a>
                            </h4>
                            <ul class="list-group" v-if="currentOpenSession.year==program.stage&&currentOpenSession.session==semester.semesterName">
                                <li class="list-group-item" style="border: 0 none #ccc;border-bottom: 2px solid #ccc;" 
                                v-for="(unit,index) in semester.curriculumUnits" :key="index">
                                    <div class="col-md-12 row">
                                        <div class="col-md-4">
                                            <div class="checkbox-color checkbox-primary">
                                                <input type="checkbox" v-model="unit.doneStatus" :id="'checkbox_'+index">
                                                <label :for="'checkbox_'+index">{{unit.unitCode}}</label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">{{unit.unitName}}</div>
                                        <div class="col-md-4">{{unit.type}}</div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right" v-if="curriculum">
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
            title: "Apply retake",
            submitting: false,
            user: this.$baseRead("user"),
            loading: true,
            retake: {},
            terms: [],
            curriculum: null,
            currentOpenSession: {
                year: "YEAR 1",
                session: "SEMESTER 1"
            },
        }
    },
    methods: {
        save(){
            var units = []
            if(this.curriculum){
                this.curriculum.forEach(element => {
                    element.semesters.forEach(s => {
                        s.curriculumUnits.forEach(u => {
                            if(u.doneStatus){
                                units.push(u.unitCode)
                            }
                        });
                    });
                });
            }
            this.retake.username = this.user.username
            this.retake.units = units

            this.$http.post("retake/saveRetake", this.retake)
            .then(response => {
                this.loading = false;
                if (response.data.success) {
                    this.$router.replace({ name: "retake" });
                    this.$toastr("success", response.data.message);
                } else {
                    this.$toastr("error", response.data.message);
                }
            })
            .catch(e => {
                this.loading = false;
                this.$toastr("error", "Server error occured,please try again");
            });
        },
        getRetakeTerms(){
            this.loading = true;
            this.$http.get("retake/getRetakeUnits/?userCode=" + this.user.username)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    this.terms = result.data.data.terms
                    this.curriculum = result.data.data.curriculum
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        openCurrentSession(year, session) {
            this.currentOpenSession.session = session;
            this.currentOpenSession.year = year;
        }
    },
    created(){
        this.getRetakeTerms()
    }
}
</script>
<style>

</style>
