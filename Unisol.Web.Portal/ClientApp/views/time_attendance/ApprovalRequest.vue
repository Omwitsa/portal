<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">

            </div>

            <div class="card-block">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for>Reason for missed punch</label> 
                            <br />
                            <textarea class="form-control" v-model="attendancePunch.reason"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="pull-right">
                    <button v-if="attendancePunch.punchDate"
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
            attendancePunch: {},
            submitting: false,
            user: this.$baseRead("user"),
        }
    },
    methods : {
        save(){
            this.submitting = true;
            this.attendancePunch.empNo = this.user.role === 1 ? this.attendancePunch.empNo : this.user.username
            this.$http.post("attendance/missedPunch", this.attendancePunch)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'missedPunchList' });
                } else {
                    this.$toastr('error', response.data.message);
                    this.$router.replace({ name: 'attendance' });
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        },
    },
    created(){
        if(this.$route.params){
            this.attendancePunch.empNo = this.$route.params.empNo
            this.attendancePunch.punchDate = this.$route.params.date
        }
    }
}
</script>

<style>

</style>
