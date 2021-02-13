<template>
    <div class="page-body"><br>
        <div class="row">
            <div class="col-lg-12">
                    <div class="tab-header card">
                        <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
                            <li class="nav-item">
                                <a @click="routeTo('news')" :class="linkClass('news')"> News </a>
                                <div class="slide"></div>
                            </li>
                            <li class="nav-item">
                                <a @click="routeTo('events')" :class="linkClass('events')"> Events </a>
                                <div class="slide"></div>
                            </li>
                            <li class="nav-item" v-if="categoryStatus()">
                                <a @click="routeTo('categories')" :class="linkClass('categories')"> News Categories </a>
                                <div class="slide"></div>
                            </li>
                            <li class="nav-item" v-if="categoryStatus()">
                                <a @click="routeTo('event-categories')" :class="linkClass('event-categories')"> Events Categories </a>
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
    categoryStatus(){
        if(this.user.role == 1) return true
        return false
    },
    linkClass(to) {
        if (to) {
        var styling = "nav-link"
         const { name } = this.$route

        if (name.startsWith(to)) 
          styling = styling + " active"
        return styling
      }
    }
  }
}
</script>

<style>
</style>
