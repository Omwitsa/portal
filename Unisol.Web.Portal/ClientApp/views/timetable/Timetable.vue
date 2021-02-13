<template>
    <div class="page-body"> <br>
        <div class="row">
            <div class="col-md-12">
                <div class="tab-header card d-print-none">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/timetable/study-timetable">Study Timetable</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/timetable/exam-timetable">Exam Timetable</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role == 2">
                            <router-link exact-active-class="active" class="nav-link" to="/timetable/allocation-summary">Allocation Summary</router-link>
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
            user: this.$baseRead("user")
        }
    }
}
</script>

<style>

</style>
