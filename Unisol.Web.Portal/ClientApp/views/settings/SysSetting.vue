<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <!-- <span v-if="subTitle">{{subTitle}}</span> -->
            </div>

            <div class="card-block" v-if="!loading">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-header-text">Leave</h5>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="switch"> 
                                        <input type="checkbox" id="checkbox1" v-model="settings.leaveRelieverMandatory">
                                        <span class="slider round"></span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-10">
                            <label for="checkbox1">Leave reliever mandatory</label>
                            </div>
                        </div>

                        <div class="card-footer text-right">
                            <submit-button :title="buttonText"
                            styling="btn btn-primary btn-round waves-effect waves-light "
                            :loading="submit" v-on:submit="update"></submit-button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            loading: false,
            submit: false,
            title: "Portal Settings",
            buttonText: "Update",
            settings: {}
        }
    },
    methods: {
        update(){
            this.updating = true
            this.$http.post(`settings/updateSettings?isSystemSettings=${true}`, this.settings)
            .then(result => {
            if (result.data.success) {
                this.$toastr("success", result.data.message)
                this.getSystemSettings()
            }
            else{
                this.$toastr("error", result.data.message)
            }
            this.updating = false
            })
            .catch(error => {
            this.$toastr("error", error.message)
            this.updating = false
            })
        },
        getSystemSettings(){
            this.$http.get("settings/get/")
            .then(result => {
            if(result.data.success){
                this.settings = result.data.data
            }else{
                this.$toastr("error", result.data.message)
            }
            })
            .catch(error => {
            this.$toastr("error", error.message)
            })
        }
    },
    created(){
        this.getSystemSettings()
    }
}
</script>

<style>

</style>
