<template>
    <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="reasons"
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
            reasons: null,
            tableActions: [],
            subTitle: "",
            searchText: "",
            title: "Clearance Reasons",
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "clearanceAddReason",
                design: "primary"
                }
            ],
            columns: [
                {
                name: "Reason",
                type: "text"
                },
                {
                name: "Date", 
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
        buttonEvent(item, action) {
           
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get("clearances/getReasons")
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.date = DateFomatter.ReturnDate(element.createDate)
                    });
                    this.reasons = result.data.data
                } 
                else {
                    this.$toastr("error", result.data.message);
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
