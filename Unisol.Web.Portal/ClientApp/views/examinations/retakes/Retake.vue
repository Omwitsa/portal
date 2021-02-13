<template>
   <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading && settingstatus"
        :data="retakes"
        :columns="columns"
        :tableActions="tableActions"
        :headerActions="headerActions"
        :subTitle="subTitle"
        :title="title"
        :pagination="pagination"
        v-on:loadData="loadData"
        ></data-table>
    </div>
</template>
<script>
import dateFormatter from "../../../components/constants/DateFomatter"
export default {
    data() {
        return{
            loading: true,
            settingstatus: false,
            retakes: [],
            tableActions: [
                {
                    name: "Details",
                    icon: "edit",
                    type: "link",
                    path: "retake-details",
                    design: "success"
                },
            ],
            dateFormatter :dateFormatter,
            subTitle: "",
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "apply-retake",
                design: "primary"
                }
            ],
            title: "Retake",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "Session",
                type: "text"
                },
                {
                name: "Date Registered",
                type: "text"
                }
            ],
        }
    },
    methods: {
        loadData(itemsPerPage, pageNumber) {
            this.loading = true;
            this.$http.get("retake/getRetakes/?userCode=" + this.user.username)
            .then(result => {
                this.loading = false;
                if (result.data.success) {
                    result.data.data.forEach(element => {
                        element.session = element.term
                        element.dateregistered = dateFormatter.ReturnDate(element.rdate)
                    });
                    this.retakes = result.data.data
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
        checkSettingStatus: function() {
            this.$http.get("CommonUtilities/settingstatus?settingCode=010")
            .then(result => {
                if (result.data.success) {
                    debugger
                    this.settingstatus = result.data.success
                } 
                else {
                    this.$toastr("error", result.data.message);
                }
            })
            .catch(error => {
                this.checkingTranscriptStatusHttp = false;
                this.$toastr("error", error.message);
            });
        },
        
    },
    
    created(){
        this.checkSettingStatus();
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>
