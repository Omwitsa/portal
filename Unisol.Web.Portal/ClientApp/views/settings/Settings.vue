<template>
    <div class="page-body">
        <div class="row">
            <div class="col-lg-12">
                    <div class="tab-header card">
                        <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                            <li class="nav-item">
                                <a @click="routeTo('branding')" :class="linkClass('branding')"> Branding </a>
                                <div class="slide"></div>
                            </li>
                            <li class="nav-item">
                                <a @click="routeTo('email')" :class="linkClass('email')"> Email </a>
                                <div class="slide"></div>
                            </li>
                            <li class="nav-item">
                                <a @click="routeTo('sys-setting')" :class="linkClass('sys-setting')"> System </a>
                                <div class="slide"></div>
                            </li>
                            <!-- <li class="nav-item">
                                <a @click="routeTo('privileges')" :class="linkClass('privileges')"> Privileges </a>
                                <div class="slide"></div>
                            </li> -->
                            <li class="nav-item" v-if="!user.genesisUser">
                                <a @click="routeTo('other-settings')" :class="linkClass('other-settings')"> Other </a>
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
            user: this.$baseRead('user')
        }
    },
    methods: {
        routeTo(to) {
        if (to) {
            this.$router.replace({ name: to })
        }
    },
    linkClass(to) {
      if (to) {
        var styling = "nav-link"
        if (this.$route.name.includes(to)) 
          styling = styling + " active"
        return styling
      }
    }
  }
}
</script>

<style>
</style>
