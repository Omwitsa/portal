<template>
    <div class="page-body">
        <div class="row">
            <div class="col-lg-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/work-details/edit">Details</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/work-details/order-details">Work order details</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/work-details/feedback">Feedback / Comment</router-link>
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
