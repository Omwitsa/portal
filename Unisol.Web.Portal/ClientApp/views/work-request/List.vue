<template>
    <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="requests"
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
        return {
            loading: true,
            requests: null,
            tableActions: [
                {
                    name: "Details",
                    type: "button",
                    icon: "trash",
                    path: "details",
                    design: "danger"
                }
            ],
            subTitle: "Requests",
            title: "Work Request",
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
                path: "work-details",
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
                name: "Subject",
                type: "text"
                },
                {
                name: "Description",
                type: "text"
                },
                {
                name: "Project",
                type: "text"
                },
                {
                name: "Location",
                type: "text"
                },
                {
                name: "Status",
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
            this.$http.get(`workRequest/getWorkOrders?usercode=${this.user.username}`)
            .then(result => {
            if (result.data.success) {
                this.loading = false;
                result.data.data.forEach(element => {
                    element.reference = element.ref;
                    element.empno = element.empNo;
                });
                this.requests = result.data.data;

                this.pagination.total = result.data.totalItems;
                this.pagination.current = pageNumber;
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
            var val = this.$route.params.ref;
            switch (action) {
                case "details":
                    localStorage.setItem("workRequests", JSON.stringify(item));
                    this.$router.replace({ name: "work-details" });
                // 
                    // this.$http
                    //     .get("users/DeleteUser/?id=" + )
                    //     .then(response => {
                    //     if (response.data.success) {
                    //         this.$toastr("success", response.data.message);
                    //     } else {
                    //         this.$toastr("error", response.data.message);
                    //     }
                    //     this.loadData(10, 1);
                    //     })
                    //     .catch(e => {
                    //     this.$toastr("error", e.message);
                    // });
                break;
                default:
                break;
            }
        }
    },
    created(){
        localStorage.setItem("workRequests", null);
        this.loadData(10, 1)
    }
}
</script>
<style>

</style>
