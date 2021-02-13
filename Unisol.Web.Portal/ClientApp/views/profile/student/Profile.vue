<template>
    <div class="page-body">
        <div class="row">
            <div class="col-lg-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/student-profile/student-data">
                                Personal Data
                            </router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item"> 
                            <router-link exact-active-class="active" class="nav-link" to="/student-profile/academic-profile">Academics
                                <small-spinner :loading="loading"></small-spinner>
                            </router-link>
                            <div class="slide"></div>
                        </li>
                    </ul>
                </div>

                <div class="tab-content">
                    <router-view>

                    </router-view>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
            loading: true,
        }
    },
    computed: {
        title() {
            return "Profile"
        }
    },
    created() {
        this.loadData()
    },
    methods: {
         loadData(){
              this.loading = false
         }
    }
}
</script>
<style>

</style>
