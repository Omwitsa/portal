<template>
    <div class="page-body"> <br>
        <div class="row">
            <div class="col-md-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/myAttendance">Attendance</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if=" user.role == 1">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/attendanceSammery">Attendance Summery</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/missedPunchList">Missed Punches</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if=" user.role != 1">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/approveMissedPunch">Missed Punches To Approve</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/outOfOffice">Out of Office</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item"  v-if=" user.role != 1">
                            <router-link exact-active-class="active" class="nav-link" to="/attendance/approveOutOfOffice">Out of Office To Approve</router-link>
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
