<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block">
                <div class="row" v-if="!modifyGrades">
                    <div class="col-md-12">
                        <input v-model="section.name" placeholder="Section" type="text" class="form-control"/><br>
                        <div class="btn  btn-primary" @click="pushSection()">Add Section</div>
                    </div>
                </div> <hr>

                <div class="row" v-if="gradeLevel.sections.length && !modifyGrades">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th></th>
                                    <th v-for="(section, index) in gradeLevel.sections" :key="index">{{section.name}}</th>
                                    <th>Action</th>
                                </thead>

                                <tbody>
                                    <tr v-for="(level, index) in gradeLevel.levelGradings" :key="index">
                                        <td>{{level.grade}}</td>
                                        <td v-for="(section, index) in gradeLevel.sections" :key="index">{{level[`000${index + 1}`]}}</td>
                                        <td><list-button :item="level" :actions="tableActions" v-on:listButtonEvent="buttonEvent"></list-button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row" v-if="modifyGrades">
                    <div class="col-md-12">
                        <h5>{{minValue.grade}}</h5>
                        <div v-for="(section, index) in gradeLevel.sections" :key="index">
                            <label for="">{{section.name}}</label>
                            <input v-model="minValue[`000${index + 1}`]" placeholder="Minimum Value" type="text" class="form-control"/>
                        </div> <br>
                        <div class="btn  btn-primary" @click="editGrades()">Done</div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" title="Delete Levels" v-on:submit="deleteLevels"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            title: "Grade Levels",
            subTitle: "",
            gradeLevel: {
                levelGradings: [],
                sections: [],
            },
            section: {},
            minValue: {},
            submitting: false,
            tableActions: [
                {
                    name: "Edit",
                    type: "button",
                    icon: "trash",
                    path: "edit",
                    design: "danger"
                }
            ],
            modifyGrades: false,
            loading: false
        }
    },
    methods: {
        editGrades(){
            this.modifyGrades = false
        },
        pushSection(){
            if(this.section.name){
                var nameExist = false
                this.gradeLevel.sections = this.gradeLevel.sections ? this.gradeLevel.sections : []
                this.gradeLevel.sections.forEach(element => {
                    if(this.section.name == element.name){
                        this.$toastr("error", "Sorry name already exist")
                        nameExist = true
                        return
                    }
                });

                if(nameExist){
                    return
                }

                var code = `000${this.gradeLevel.sections.length + 1}`;
                this.section.code = code
                this.gradeLevel.sections.push(this.section)
                this.gradeLevel.levelGradings.forEach(element => {
                    element[code] = ''
                });

                this.section = {}
            }
        },
        buttonEvent(item, action) {
            switch (action) {
                case "edit":
                    this.minValue = item
                    this.modifyGrades = true
                break;
                default:
                break;
            }
        },
        save(){
            this.submitting = true
            this.$http.post("performance/saveGradeLevels", this.gradeLevel)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    this.getGradeLevel()
                } 
                else{
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.$toastr("error", e.message)
                this.submitting = false
            })
        },
        deleteLevels(){
            swal({
                title: "Are you sure you want to delete?",
                icon: "warning",
                buttons: true,
                dangerMode: false
            }).then(action => {
                if(action){
                    this.loading = true;
                    this.$http.get(`performance/deleteLevels`)
                    .then(response => {
                        this.loading = false;
                        if (response.data.success) {
                            this.$toastr("success", response.data.message)
                            this.getGradeLevel()
                        } 
                        else{
                            this.$toastr("error", response.data.message)
                        }
                    })
                    .catch(error => {
                        this.loading = false;
                    });
                }
            })
        },
        getGradeLevel(){
            this.loading = true;
            this.$http.get(`performance/getGradeLevel`)
            .then(result => {
                this.gradeLevel = {}
                this.loading = false;
                if(result.data.data.levelGradings.length){
                    this.gradeLevel = result.data.data
                }
                else{
                    result.data.data.employeeGrades.forEach(element => {
                    this.gradeLevel.levelGradings = this.gradeLevel.levelGradings ? this.gradeLevel.levelGradings : []
                    this.gradeLevel.levelGradings.push({
                        grade: element
                    })
                });
                }
            })
            .catch(error => {
                this.loading = false;
            });
        }
    },
    created(){
        this.getGradeLevel()
    }
}
</script>

<style>

</style>
