<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>Create clearance reason</h5>
            </div>

            <div class="card-block">
               <div class="row">
                   <div class="col-md-12">
                       <input v-model="clearance.reason" placeholder="Reason" type="text" class="form-control"/>
                   </div>
               </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <submit-button
                    styling="btn btn-primary btn-round waves-effect waves-light "
                    :loading="submitting" v-on:submit="submit"></submit-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return {
            clearance: {},
            submitting: false,
        }
    },
    methods: {
        submit(){
            this.$http.post("clearances/createClearanceReason", this.clearance)
			.then(response => {
				if (response.data.success) {
                    this.$router.replace({ name: "clearanceReasons" });
					this.$toastr('success', response.data.message);
				} else {
					this.$toastr('error', response.data.message);
				}
			})
			.catch(e => {
				this.$toastr('Error', "Server error occured,please try again");
			})
        }
    }
}
</script>

<style>

</style>
