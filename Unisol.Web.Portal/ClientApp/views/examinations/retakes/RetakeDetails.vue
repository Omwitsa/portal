<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <p><b>AdmnNo: </b> {{retakeDetails.retake.admnNo}}</p>
                        <p><b>Class: </b> {{retakeDetails.retake.class}}</p>
                        <p><b>Term: </b> {{retakeDetails.retake.term}}</p>
                        <p><b>Rdate: </b> {{dateFormatter.ReturnDate(retakeDetails.retake.rdate)}}</p>
                        <p><b>Notes: </b> {{retakeDetails.retake.notes}}</p> 

                        <div class="table-responsive">
                            <table class="table table-sm table-bordered">
                                <thead>
                                    <th>Unit Code</th>
                                    <th>Unit Name</th>
                                </thead>
                                <tbody>
                                    <tr v-for="(detail, index) in retakeDetails.retakeDetails" :key="index">
                                        <td>{{detail.unitCode}}</td>
                                        <td>{{detail.unitName}}</td>
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
import dateFormatter from "../../../components/constants/DateFomatter"
export default {
    data(){
        return{
            loading: true,
            title: "Retake Details",
            user: this.$baseRead("user"),
            retakeId: 0,
            dateFormatter :dateFormatter,
            retakeDetails: []
        }
    },
    methods: {
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get("retake/getRetakeDetails/?userCode=" + this.user.username + "&retakeId="+ this.retakeId)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    this.retakeDetails = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                    if (result.data.notAuthenticated) {
                        this.$router.replace({ name: "401-forbidden" });
                    }
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
    },
    created(){
        this.retakeId = this.$route.params.id;
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>
