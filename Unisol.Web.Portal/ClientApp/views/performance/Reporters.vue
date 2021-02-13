<template>
   <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading"
        :data="reporters"
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
export default {
    data(){
        return{
            loading: false,
            reporters: [],
            headerActions: [],
            subTitle: "",
            title: "Performance Supervision",
            searchText: "",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            tableActions: [
                {
                    name: "Details",
                    type: "button",
                    icon: "trash",
                    path: "details",
                    design: "danger"
                }
            ],
            columns: [
                {
                name: "Performance", 
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
                name: "Status", 
                type: "text"
                },
            ],
        }
    },
    methods: {
        buttonEvent(item, action) {
            switch (action) {
                case "details":
                    if(item.status === "Pending"){
                        this.$router.replace({ name: "performance-targets", params: item})
                    }
                    else{
                        this.$router.replace({ name: "performance-response-items", params: item})
                    }
                break;
                default: 
                break;
            }
        },
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get("performance/getReporters?username="+this.user.username)
            .then(result => {
                if (result.data.success) {
                    this.loading = false;
                    result.data.data.reporters.forEach(element => {
                        element.empno = element.empNo
                    });
                    this.reporters = result.data.data.reporters
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
