<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading"
        :data="grades"
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
            loading: true,
            grades: null,
            subTitle: "",
            title: "Performance Grades",
            searchText: "",
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "add-performance-grade",
                design: "primary"
                }
            ],
            tableActions: [
                {
                    name: "Edit",
                    type: "button",
                    icon: "trash",
                    path: "edit",
                    design: "danger"
                },
                {
                    name: "Delete",
                    type: "button",
                    icon: "trash",
                    path: "delete",
                    design: "danger"
                }
            ],
            columns: [
                {
                name: "Range", 
                type: "text"
                },
                {
                name: "Description", 
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
            this.$http.get("performance/getGrades")
            .then(result => {
                let num = 0;
                if (result.data.success) {
                    this.loading = false;
                    this.grades = result.data.data;
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
            switch (action) {
                case "edit":
                    this.$router.replace({ name: "add-performance-grade", params: item });
                break;
                case "delete":
                    swal({
                        title: "Are you sure you want to delete?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: false
                    }).then(action => {
                        if(action){
                        this.$http.post("performance/deleteGrade", item)
                            .then(response => {
                                this.submitting = false
                                if (response.data.success) {
                                    this.$toastr("success", response.data.message)
                                    this.loadData(10, 1)
                                } 
                                else{
                                    this.$toastr("error", response.data.message)
                                }
                            })
                            .catch(e => {
                                this.$toastr("error", e.message)
                            })
                        }
                    })
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
