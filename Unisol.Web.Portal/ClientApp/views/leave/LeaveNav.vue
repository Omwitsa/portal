<template>
    <div class="page-body"> <br>
        <div class="row">
            <div class="col-lg-12">
                    <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link :class="this.$baseLinkClass('leave/applications')" to="/leave/applications"> Applications
                            </router-link>
                            <div class="slide"></div>
                        </li> 
                        <li class="nav-item">
                            <router-link  :class="this.$baseLinkClass('leave/days')" to="/leave/days"> Leave Days
                            </router-link>
                            <div class="slide"></div>
                        </li>
                        <li class="nav-item">
                            <router-link  :class="this.$baseLinkClass('leave/obstructors')" to="/leave/obstructors"> Relieve
                            </router-link>
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
    data() {
        return {
            settings : JSON.parse(localStorage.getItem("settings"))
        }
    }
}
</script>

<style>
</style>
