<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <!-- <div class="offset-md-10">
                    <button class="btn btn-primary btn-sm" @click="print()">
                        <i class="fa fa-print" style="color:white;"></i> print
                    </button>
                </div> -->
            </div>

            <div class="card-block">
                <loading-spinner :loading="loading"></loading-spinner>
                <div class="table-responsive">
                    <table class="table table-sm table-bordered" id="tt_allocation">
                        <thead>
                            <th>UNIT CODE</th>
                            <th>UNIT NAME</th>
                            <th>PROGRAMME</th>
                            <th>ROOM</th>
                            <th>CAMPUS</th>
                            <th>HOURS</th>
                            <th>STUDENTS</th>
                        </thead>

                        <tbody>
                            <tr v-for="(summary, index) in allocationSummary" :key="index">
                                <td>{{summary.unitCode}}</td>
                                <td>{{summary.unitName}}</td>
                                <td>{{summary.programme}}</td>
                                <td>{{summary.room}}</td>
                                <td>{{summary.campus}}</td>
                                <td>{{summary.unitHours}}</td>
                                <td>{{summary.numOfStudentsUsed}}</td>
                            </tr>
                            <tr>
                                <td colspan="5">TOTAL HOURS</td>
                                <td colspan="2">{{totalHours}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            user: this.$baseRead("user"),
            allocationSummary: null,
            loading: true,
            totalHours: 0
        }
    },
    methods:{
        print() {
            this.$htmlToPaper("tt_allocation");
        },
        getSummary(){
            this.loading = true
            this.user.regNumber = this.user.username
            this.$http.post("timetable/lecturerAllocationSammary", this.user)
            .then(response => {
                this.loading = false
                if (response.data.success) {
                    response.data.data.forEach(element => {
                        this.totalHours = this.totalHours + element.unitHours
                    });
                    this.allocationSummary = response.data.data
                } else {

                }
            })
            .catch(e => {
                this.$toastr("error", "An error occured, please contact administrator");
            });
        }
    },
    created(){
        this.getSummary()
    }
}
</script>

<style>

</style>
