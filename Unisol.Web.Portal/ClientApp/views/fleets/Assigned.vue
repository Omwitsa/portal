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
      v-on:buttonEvent="buttonEvent"
      v-on:loadData="loadData"
      v-on:searchByText="searchByText"
    ></data-table>
  </div>
</template>
<script>
export default {
    data(){
        return {
            loading: true,
            fleets: null,
            tableActions: [
                {
                    name: "Slip",
                    type: "button",
                    icon: "trash",
                    path: "slip",
                    design: "danger"
                }
            ],
            headerActions: [],
            user: this.$baseRead("user"),
            subTitle: "Assigned Vehicles",
            title: "Fleets",
            searchText: "",
            pagination: {
                total: 0
            },
            columns: [
                {
                name: "Plate No",
                type: "text"
                },
                {
                name: "Make/Model", 
                type: "text"
                },
                {
                name: "Driver",
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
            this.$http.get("fleet/getAssignedVehicles/?usercode=" + this.user.username + "&searchText=" + this.searchText)
            .then(result => {
            if (result.data.success) {
                this.loading = false;
                result.data.data.forEach(element => {
                    element.plateno = element.plateNo
                    element.driver = element.driverName
                    element.makemodel = ""
                });
                this.fleets = result.data.data
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
                case "slip": 
                    this.$router.replace({ name: "allocation-slip", params: item });
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
