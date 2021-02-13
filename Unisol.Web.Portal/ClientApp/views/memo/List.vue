<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading && isAllowed"
        :data="memos"
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
    data() {
        return{
            loading: true,
            memos: [],
            tableActions: [],
            isAllowed: false,
            subTitle: "Online Memos",
            title: "Memos",
            user: this.$baseRead("user"),
            searchText: "",
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "add-memo",
                design: "primary"
                }
            ],
            columns: [
                {
                name: "Reference",
                type: "text"
                },
                {
                name: "From(Department)", 
                type: "text"
                },
                {
                name: "To(Department)",
                type: "text"
                },
                {
                name: "Subject",
                type: "text"
                },
                {
                name: "Description",
                type: "text"
                },
                {
                    name: "Status",
                    type: "text"
                },
                {
                    name: "Reason",
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
            this.$http.get("memo/getImprestMemo/?usercode=" + this.user.username + "&searchText=" + this.searchText)
            .then(result => {
                this.loading = false;
                this.isAllowed = result.data.success
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.reference = element.ref
                        element.fromdepartment = element.deptFrom
                        element.todepartment = element.deptTo
                        element.reason = element.reason ? element.reason : ""
                    });
                    this.memos = result.data.data
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
        buttonEvent(item, action) {
           
        }
    },
    created(){
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>
