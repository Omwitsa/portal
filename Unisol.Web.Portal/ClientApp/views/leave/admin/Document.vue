<template>
    <div class="page-body">
        <div class="card">
            <div class="card-block">
                <div class="row">
                    <div class="col-md-8">
                        <input v-model="empNo" placeholder="Employee Number" type="text" class="form-control"/>
                    </div>
                    <div class="col-md-4">
                        <div class="btn  btn-primary" @click="searchDocuments()">Search</div>
                    </div>
                </div>
            </div>
        </div>
        
        <data-table
            v-if="ducuments"
            :data="ducuments"
            :columns="columns"
            :tableActions="tableActions"
            :headerActions="headerActions"
            :subTitle="subTitle"
            :title="title"
            :pagination="pagination"
            v-on:buttonEvent="buttonEvent"
            v-on:searchByText="searchByText"
        ></data-table>
    </div>
</template>

<script>
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
    data(){
        return{
            loading: false,
            ducuments: null,
            headerActions: [],
            subTitle: "",
            empNo: "",
            title: "Leave Documents",
            searchText: "",
            pagination: {
                total: 0
            },
            tableActions: [
                {
                    name: "Download",
                    type: "button",
                    icon: "lock",
                    path: "download",
                    design: "warning"
                }
            ],
            columns: [
                {
                name: "Name",
                type: "text"
                },
                {
                name: "Ref",
                type: "text"
                },
                {
                name: "Leave Type",
                type: "text"
                },
                {
                name: "Date",
                type: "text"
                }
            ],
        }
    },
    methods: {
        searchByText(enteredText) {
            this.searchText = enteredText;
            // this.loadData(10, 1);
        },
        buttonEvent(item, action) {
            switch (action) {
                case "download":
                    var url = `${window.location.origin}/${item.endPoint}/${item.name}`
                    window.open(url, "_blank");
                break;
            }
        },
        searchDocuments(){
           this.$http.get("leave/getDocuments?empNo="+this.empNo)
			.then(result => {
                if(result.data.success){
                    result.data.data.forEach(element => {
                        element.leavetype = element.type
                        element.ref = element.leaveRef
                        element.date =  DateFomatter.ReturnDate(element.dateCreated)
                    });
                  
                    this.ducuments = result.data.data;
                }
                else{
                    this.$toastr("error", result.data.message); 
                }
			})
			.catch(error => {
				this.$toastr("error", error.message);
			});
        }
    }
}
</script>

<style>

</style>
