<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>

            <div class="card-block" v-if="orderDetails">
                <div class="row"> 
                    <div class="table-responsive">
                        <table class="table table-sm table-bordered">
                            <thead>
                                <th>PARTICULARS</th>
                                <th>VALUE</th>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>W.O. REF.</td>
                                    <td>{{orderDetails.ref}}</td>
                                </tr>
                                <tr>
                                    <td>ASSIGNEE</td>
                                    <td>{{orderDetails.requestor}}</td>
                                </tr>
                                <tr>
                                    <td>ASSIGNEE NAME</td>
                                    <td>{{employeeDetails.names}}</td>
                                </tr>
                                <tr>
                                    <td>DOWNTIME</td>
                                    <td>{{orderDetails.downTime}}</td>
                                </tr>
                                <tr>
                                    <td>PRIORITY</td>
                                    <td>NORMAL</td>
                                </tr>
                                <tr>
                                    <td>START DATE</td>
                                    <td>{{endPoints.ReturnDate(orderDetails.wDate)}}</td>
                                </tr>
                                <tr>
                                    <td>CLOSED DATE</td>
                                    <td>{{orderDetails.eDate ? endPoints.ReturnDate(orderDetails.eDate) : ""}}</td>
                                </tr>
                                <tr>
                                    <td>STATUS</td>
                                    <td>{{orderDetails.status}}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- <div class="col-md-2">
                        Department
                    </div>
                    <div class="col-md-8">
                        <input v-model="userFleet.department" type="text" class="form-control" disabled>
                    </div> -->
                </div> <br>
            </div>
        </div>
    </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
export default {
    data(){
        return {
            subTitle: "Details",
            endPoints: END_POINTS,
            title: "Order Details",
            orderDetails: null,
            employeeDetails: null,
            orderRef:"",
            user: this.$baseRead("user"),
        }
    },
    methods: {
        getUserWorkRequestDetails(){
            this.loading = true;
            this.$http.get(`workRequest/getWorkOrderDetails?usercode=${this.user.username}&orderRef=${this.orderRef}`)
            .then(result => {
            if (result.data.success) {
               this.orderDetails = result.data.data.workRequests
               this.employeeDetails = result.data.data.employeeDetails
            } 
            else {
                this.$toastr("error", result.data.message);
                if (result.data.notAuthenticated) {
                    this.$router.replace({ name: "401-forbidden" });
                }
            }
            })
            .catch(error => {
                this.loading = false;
            });
        }
    },
    created(){
        var request = JSON.parse(localStorage.getItem('workRequests'))
        this.orderRef = request ? request.ref : ""
        this.getUserWorkRequestDetails();
    }
}
</script>

<style>

</style>
