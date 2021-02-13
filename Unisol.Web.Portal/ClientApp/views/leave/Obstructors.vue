<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading"
        :data="obstructors"
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
            obstructors: null,
            tableActions: [
                {
                    name: "Approve",
                    type: "button",
                    icon: "trash",
                    path: "approve",
                    design: "danger"
                },
                {
                    name: "Decline",
                    type: "button",
                    icon: "trash",
                    path: "decline",
                    design: "danger"
                }
            ],
            headerActions: [],
            subTitle: "",
            title: "Leave Obstructors",
            searchText: "",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "Emp No", 
                type: "text"
                },
                {
                name: "leave Ref",
                type: "text"
                },
                {
                name: "Date",
                type: "text"
                }
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
            this.$http.get("leave/getObstructors/?usercode=" + this.user.username + "&searchText=" + this.searchText)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.empno = element.requestor,
                        element.leaveref = element.leaveRef,
                        element.date = DateFomatter.ReturnDate(element.createdDate)
                    });

                    this.obstructors = result.data.data
                } else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.loading = false;
            });
        },
        approveLeave(LeaveApproval){
            this.$http.post("leave/approve", LeaveApproval)
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
                    var LeaveApproval = {
                        empNo: item.empno,
                        leaveRef: item.leaveRef,
                        Status: 'Approved'
                    }
                    this.approveLeave(LeaveApproval)
                break;
                case "decline":
                    var LeaveApproval = {
                        empNo: item.empno,
                        leaveRef: item.leaveRef,
                        Status: 'Declined'
                    }
                    this.approveLeave(LeaveApproval)
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
