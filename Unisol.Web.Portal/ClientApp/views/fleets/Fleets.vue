<template>
    <div class="page-body"> <br>
        <div class="row">
            <div class="col-md-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/fleet/fleet-bookings">Booked Details</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/fleet/assigned-vehicles">Assigned vehicle details</router-link>
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
    
}
</script>
<style>

</style>
