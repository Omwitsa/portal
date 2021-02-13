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
      user: this.$baseRead("user"), 
      logs: [],
      loading: true,
      title: "ExamCard logs",
      subTitle: "",
      dateFormatter :dateFormatter,
      searchText: "",
      tableActions: [],
      headerActions: [],
      columns: [
        {
          name: "Username",
          type: "currency"
        },
        {
          name: "Session",
          type: "centered"
        },
        {
          name: "Date Created",
          type: "text"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },
  methods: {
    searchByText(enteredText) {
      this.searchText = enteredText;
      this.loadData(10, 1);
    },
    loadData(itemsPerPage, pageNumber) {
        this.loading = true
        var url = `PortalLogs/getExamCardLogs?itemsPerPage=${itemsPerPage}&offset=${pageNumber}&searchText=${this.searchText}`
        this.$http.get(url).then(response => {
              if (response.data.success) {
                  response.data.data.forEach(l => { 
                      l.username = l.adminNo,
                      l.session = l.semester,
                      l.datecreated = this.dateFormatter.ReturnDate(l.dateCreated, "DD MMM YYYY H:MM")
                  })
                this.logs = response.data.data
              } 
              this.loading = false
            })
            .catch(e => {
              this.$toastr("error", e.message);
              this.loading = false
            });
    }
  },
  created() {
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
