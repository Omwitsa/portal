<template>
    <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="eclaims"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:searchByText="searchByText"
      v-on:loadData="loadData"
    ></data-table>
  </div>
</template>
<script>
export default {
    data(){
        return {
            loading: true,
            eclaims: null,
            tableActions: [],
            searchText: "",
            subTitle: "Expense claims",
            title: "Claims",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "add-eclaims",
                design: "primary"
                }
            ],
            columns: [
                {
                name: "EC Ref",
                type: "text"
                },
                {
                name: "Emp No", 
                type: "text"
                },
                {
                name: "Names",
                type: "text"
                },
                {
                name: "Ledger",
                type: "text"
                },
                {
                name: "Project",
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
            this.loading = true;
            this.$http.get("eClaims/getEClaims/?usercode=" + this.user.username + "&searchText=" + this.searchText)
            .then(result => {
            if (result.data.success) {
                result.data.data.forEach(element => {
                    element.empno = element.payeeRef
                });
                this.loading = false;
                this.eclaims = result.data.data;
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
