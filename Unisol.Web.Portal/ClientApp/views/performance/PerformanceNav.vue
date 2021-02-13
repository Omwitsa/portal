<template>
    <div class="page-body"> <br>
        <div class="row">
            <div class="col-md-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item" v-if="user.role==1">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-template">Template</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==1">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-list">Performance Session</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==1">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-grades">Grades</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==1">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-grade-levels">Grade Level</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==1">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-responses">Response</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==2">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-targets">Performance Targets</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==2">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-response-items">Performance Response</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role==2">
                            <router-link exact-active-class="active" class="nav-link" to="/performance/performance-reporters">Reporters</router-link>
                            <div class="slide"></div>
                        </li>
                    </ul>
                </div>
                <div class="tab-content">
                    <router-view></router-view>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            user: this.$baseRead("user"),
        }
    } 
}
</script>

<style>

</style>
