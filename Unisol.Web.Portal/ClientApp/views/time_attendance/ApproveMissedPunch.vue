<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
            v-if="!loading"
            :data="missedPunches"
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
    data (){
        return {
            loading: true,
            missedPunches: null,
            user: this.$baseRead("user"),
            tableActions: [
                {
                    name: "Approve",
                    type: "button",
                    icon: "trash",
                    path: "approve",
                    design: "danger"
                }
            ],
            headerActions: [],
            searchText: "",
            subTitle: "",
            title: "Missed Punches",
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "EmpNo", 
                type: "text"
                },
                {
                name: "Supervisor", 
                type: "text"
                },
                {
                name: "Reason", 
                type: "text"
                },
                {
                name: "Status", 
                type: "text"
                },
                {
                name: "PunchDate", 
                type: "text"
                },
                {
                name: "CreatedDate", 
                type: "text"
                },
            ],
        }
    },
    methods: {
        searchByText(enteredText) {
            // this.searchText = enteredText;
            // this.loadData(10, 1);
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get(`attendance/getMissedPunch/?usercode=${this.user.username}&searchText=${this.searchText}&role=${this.user.role}&isApproval=${true}`)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.createddate = DateFomatter.ReturnDate(element.createdDate);
                        element.punchdate = DateFomatter.ReturnDate(element.punchDate);
                        element.supervisor = element.supervisor ? element.supervisor : ""
                        element.empno = element.empNo
                    });

                    this.missedPunches = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        approveMissedPunch(item){
            this.loading = true;
            this.$http.post("attendance/approveMissedPunch", item)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.loadData(10, 1)
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
        buttonEvent(item, action) {
            switch (action) {
                case "approve":
                    this.approveMissedPunch(item)
                break;
                default:
                break;
            }
        }
    },
    created(){
        this.loadData(10, 1)
    }
}
</script>

<style>

</style>
