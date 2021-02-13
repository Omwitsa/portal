<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading"
        :data="performances"
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
        return{
            loading: true,
            performances: null,
            subTitle: "",
            title: "Performances",
            searchText: "",
            dateFomatter: DateFomatter,
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "performance-session",
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
                name: "Name", 
                type: "text"
                },
                {
                name: "Template Name", 
                type: "text"
                },
                {
                name: "Start Date", 
                type: "text"
                },
                {
                name: "End Date", 
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
            this.$http.get("performance/getPerformances")
            .then(result => {
                if (result.data.success) {
                    this.loading = false;
                    result.data.data.forEach(element => {
                        element.templatename = element.templateName
                        element.startdate = this.dateFomatter.ReturnDate(element.startDate)
                        element.enddate = this.dateFomatter.ReturnDate(element.endDate)
                    });
                    this.performances = result.data.data
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
                    this.$router.replace({ name: "performance-session", params: item });
                break;
                case "delete":
                    swal({
                        title: "Are you sure you want to delete?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: false
                    }).then(action => {
                        if(action){
                        this.$http.post("performance/deletePerformance", item)
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
