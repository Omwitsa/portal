<template>
  <div class="page-body"><br>
    <div class="row">
      <div class="col-lg-12">
        <div class="tab-header card">
          <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
            <li class="nav-item">
              <a @click="routeTo('users')" :class="linkClass('users')">Users</a>
              <div class="slide"></div>
            </li>
            <li class="nav-item">
              <a @click="routeTo('user-groups')" :class="linkClass('user-groups')">User Groups</a>
              <div class="slide"></div>
            </li>
            <li class="nav-item" v-if="settings.initials ==='UOEM'">
              <a @click="routeTo('previous-examCard')" :class="linkClass('previous-examCard')">(SEMESTER 2 2019/2020)Exam Card</a>
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
     settings: JSON.parse(localStorage.getItem("settings")),
    };
  },
  methods: {
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to });
      }
    },
    linkClass(to) {
      if (to) {
        var styling = "nav-link";
        if (this.$route.name.includes(to)) styling = styling + " active";
        return styling;
      }
    }
  }
};
</script>

<style>
.tab-content {
  margin-left: 1px !important;
}
</style>
