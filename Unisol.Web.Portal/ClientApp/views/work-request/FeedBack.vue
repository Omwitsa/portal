<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>Feedback / Comment</h5>
            </div>

            <div class="card-block">
                <div class="row"> 
                    <div class="col-md-8">
                        <textarea v-model="workRequest.reaction" type="text" rows="3" class="form-control"/>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="save"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return {
            feedBack:"",
            workRequest: {},
            submitting: false,
            isUpdate: true
        }
    },
    methods: {
        save(){
            this.submitting = true
            // this.$http.post(`workRequest/orderWork,` + this.workRequest)
            // // this.$http.post(`workRequest/orderWork?isUpdate=${this.isUpdate}, ${this.workRequest}`)
            // // this.$http.post(`workRequest/orderWork, ${this.workRequest}`)
            // .then(response => {
            //     this.submitting = false
            //     if (response.data.success) {
            //         this.workRequest.reaction = ""
            //     } 
            //     else{
            //         this.$toastr("error", response.data.message)
            //     }
            // })
            // .catch(e => {
            //     this.submitting = false
            //     this.$toastr("error", e.message)
            // })

            this.$http.post(`workRequest/orderWork?isUpdate=${this.isUpdate}`, this.workRequest)
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                    // this.$router.replace({ name: "work-request" });
                } 
                else{
                    // this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
            this.$toastr("error", e.message)
            })
        }
    },
    created(){
        var request = JSON.parse(localStorage.getItem('workRequests'))
        this.workRequest.ref = request ? request.ref : ""
        this.workRequest.reaction = request ? request.reaction : ""
        this.workRequest.subject = request ? request.subject : ""
        this.workRequest.description = request ? request.description : ""
    }
}
</script>

<style>

</style>
