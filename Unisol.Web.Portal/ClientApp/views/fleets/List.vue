<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table
        v-if="!loading"
        :data="fleets"
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
            fleets: null,
            dateFomatter: DateFomatter,
            tableActions: [],
            subTitle: "Requested Vehicles",
            title: "Fleet",
            searchText: "",
            user: this.$baseRead("user"),
            pagination: {
                total: 0
            },
            headerActions: [
                {
                name: "Add",
                icon: "plus",
                type: "link",
                path: "book-vehicle",
                design: "primary"
                }
            ],
            columns: [
                {
                name: "Reference",
                type: "text"
                },
                {
                name: "Emp No", 
                type: "text"
                },
                {
                name: "Requested by",
                type: "text"
                },
                {
                name: "Department",
                type: "text"
                },
                {
                name: "Purpose",
                type: "text"
                },
                {
                name: "Dep Date",
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
            this.$http.get("fleet/getFleetBookings/?usercode=" + this.user.username + "&searchText=" + this.searchText)
            .then(result => {
            if (result.data.success) {
                this.loading = false;
                result.data.data.fleetBookings.forEach(element => {
                    element.reference = element.ref;
                    element.empno = element.empNo;
                    element.depdate = this.dateFomatter.ReturnDate(element.dDate);
                    element.requestedby = result.data.data.userDetails.names;
                    element.department = result.data.data.userDetails.department;
                    element.status = element.status;
                    element.reason = element.reason ? element.reason : ""
                });
                this.fleets = result.data.data.fleetBookings;
                // this.pagination.total = result.data.totalItems;
                // this.pagination.current = pageNumber;
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
            // switch (action) {
            //     case "view":
                
            //     break;
            //     default:
            //     break;
            // }
            // }
        }
    },
    created(){
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>


