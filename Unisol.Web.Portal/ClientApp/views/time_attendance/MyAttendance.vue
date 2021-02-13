<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
            v-if="!loading"
            :data="attendace"
            :columns="columns"
            :tableActions="tableActions"
            :headerActions="headerActions"
            :subTitle="subTitle"
            :title="title"
            :pagination="pagination"
            v-on:loadData="loadData"
            v-on:searchByText="searchByText"
            v-on:buttonEvent="buttonEvent"
        ></data-table>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data(){
        return { 
            loading: true,
            attendace: null,
            tableActions: [],
            headerActions: [],
            subTitle: "",
            title: "Attendance",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "EmpNo", 
                type: "text"
                },
                {
                name: "Date", 
                type: "text"
                },
                {
                name: "In", 
                type: "text"
                },
                {
                name: "Out", 
                type: "text"
                },
                {
                name: "Worked Hours", 
                type: "text"
                },
            ],
        }
    },
    methods:{
        searchByText(enteredText) {
            // this.searchText = enteredText;
            // this.loadData(10, 1);
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get(`attendance/getAttendance/?usercode=${this.user.username}&searchText=${this.searchText}&role=${this.user.role}`)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.empno = element.empNo
                        element.date = DateFomatter.ReturnDate(element.date);
                        element.workedhours = element.workedHours
                    });

                    this.attendace = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        buttonEvent(item, action) {
            switch (action) {
                case "requests":
                    this.$router.replace({ name: 'attendanceApprovalRequest', params: item });
                break;
                default:
                break;
            }
        }
    },
    created(){
        if(this.user.role == 2){
            this.tableActions = [{
                name: "Requests",
                type: "button",
                icon: "trash",
                path: "requests",
                design: "danger"
            }]
        }
        this.loadData(10, 1)
    }
}
</script>

<style>

</style>
