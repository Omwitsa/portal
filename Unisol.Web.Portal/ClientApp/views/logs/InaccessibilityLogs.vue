<template>
    <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="logs"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:searchByText="searchByText"
    ></data-table>
  </div>
</template>

<script>
import dateFormatter from "../../components/constants/DateFomatter"
export default {
    data() {
        return {
            loading: true,
            logs: [],
            tableActions: [],
            headerActions: [],
            searchText: "",
            dateFormatter :dateFormatter,
            title: "Inaccessibility logs",
            subTitle: "",
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "Institution",
                type: "text"
                },
                {
                name: "Ip",
                type: "text"
                },
                {
                name: "Date Created",
                type: "text"
                }
            ],
        }
    },
    methods: {
        searchByText(enteredText) {
            this.searchText = enteredText;
            this.loadData(10, 1);
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true
            var url = `PortalLogs/getInaccessibilityLogs?itemsPerPage=${itemsPerPage}&offset=${pageNumber}&searchText=${this.searchText}`
            this.$http.get(url).then(response => {
                this.loading = false
                if (response.data.success) {
                    response.data.data.forEach(element => {
                        element.datecreated = this.dateFormatter.ReturnDate(element.dateCreated, "DD MMM YYYY H:MM")
                    });

                    this.logs = response.data.data
                } 
                }).catch(e => {
            });
        }
    },
    created() {
        this.loadData(10, 1);
    }
}
</script>

<style>

</style>
