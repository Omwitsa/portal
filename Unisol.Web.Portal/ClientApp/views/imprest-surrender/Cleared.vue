<template>
    <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="surrenderReqs"
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
    data() {
        return{
            loading: true,
            surrenderReqs: null,
            dateFomatter: DateFomatter,
            tableActions: [],
            subTitle: "Cleared",
            title: "Cleared Surrender Requests",
            searchText: "",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            headerActions: [],
            columns: [
                {
                name: "ImpRef",
                type: "text"
                },
                {
                name: "PayeeRef", 
                type: "text"
                },
                {
                name: "EmployeeName",
                type: "text"
                },
                {
                name: "SurReqDate",
                type: "text"
                },
                {
                name: "Description",
                type: "text"
                },
                {
                name: "ClearedStatus",
                type: "text"
                }
            ],
        }
    },
    methods:{
        searchByText(enteredText) {
            this.searchText = enteredText;
            this.loadData(10, 1);
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get("imprestSurrender/getAllSurrenderRequests")
            .then(result => {
            if (result.data.success) {
                this.loading = false;
                result.data.data.clearedRequests.forEach(element => {
                    element.impref = element.impRef;
                    element.payeeref = element.payeeRef;
                    element.employeename = element.employeeName;
                    element.description = element.description;
                    element.clearedstatus = element.clearedStatus;
                    element.surreqdate = this.dateFomatter.ReturnDate(element.surReqDate);
                });
                this.surrenderReqs = result.data.data.clearedRequests;
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
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>


