<template>
    <div class="page-body"><br>
        <div class="row">
            <div class="col-lg-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/sor-claims-imprest/sor">SOR (Procurement Requisition)</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/sor-claims-imprest/IR">IR (Store Requisition)</router-link>
                            <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="!user.genesisUser">
                            <router-link exact-active-class="active" class="nav-link" to="/sor-claims-imprest/claims">Part-Time Claim</router-link>
                            <div class="slide"></div>
                        </li>

                        <!-- <li class="nav-item" v-if="user.genesisUser">
                            <router-link exact-active-class="active" class="nav-link" to="/sor-claims-imprest/eclaims">Expense Claim</router-link>
                            <div class="slide"></div>
                        </li> -->

                        <li class="nav-item">
                            <router-link exact-active-class="active" class="nav-link" to="/sor-claims-imprest/imprest">Imprest</router-link>
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
        return {
            user: this.$baseRead('user'),
            roles: []
        }
    },
    created(){
       
    },
    methods: {

    }
}
</script>
<style>

</style>
