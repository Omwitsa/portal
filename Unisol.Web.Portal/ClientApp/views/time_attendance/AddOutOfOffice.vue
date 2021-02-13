<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">

            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-2">
                                From
                            </div>
                            <div class="col-md-4">
                                <date-picker v-model="officeOut.from"></date-picker>
                            </div>

                            <div class="col-md-2">
                                To
                            </div>
                            <div class="col-md-4">
                                <date-picker v-model="officeOut.to"></date-picker>
                            </div>
                        </div> <br>
                        <div class="form-group">
                            <label for>Reason for out of office</label> 
                            <br />
                            <textarea class="form-control" v-model="officeOut.reason"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <button
                        class="btn btn-primary btn-round waves-effect waves-light" 
                        :loading="submitting"
                        @click.prevent="save"
                    >Submit</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return {
            officeOut: {},
            submitting: false,
            user: this.$baseRead("user"),
        }
    },
    methods: {
        save(){
            this.submitting = true;
            this.officeOut.empNo = this.user.username
            this.$http.post("attendance/outOfOffice", this.officeOut)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'outOfOffice' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
    },
    created(){

    }
}
</script>

<style>

</style>
