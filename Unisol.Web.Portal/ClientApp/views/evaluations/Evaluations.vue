<template>
    <div class="page-body"><br>
        <div class="row">
            <div class="col-lg-12">
                <div class="tab-header card">
                    <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                        <li class="nav-item" v-if="user.role == '1'">
                             <router-link exact-active-class="active" class="nav-link" to="/evaluations/evaluations"> Evaluation Templates 
                                </router-link>
                                <div class="slide"></div>
                        </li>

                        <li class="nav-item" v-if="user.role == '1'">
                             <router-link exact-active-class="active" class="nav-link" to="/evaluations/current-evaluations"> Current Evaluation Settings
                                </router-link>
                                <div class="slide"></div>
                        </li>

                        <li class="nav-item">
                             <router-link exact-active-class="active" class="nav-link" to="/evaluations/responses">
                                 Evaluation Responses
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
    data(){
        return{
            user: this.$baseRead("user")
        }
    },
    created(){
        if(this.user.role == '2'){
            this.$router.replace({ name: "responses" });
        }
    }
};
</script>

<style>
</style>
