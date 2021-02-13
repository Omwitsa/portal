<template>
  <div class="page-body"> <br>
    <div class="row">
      <div class="col-lg-12">
        <div class="tab-header card">
          <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
            <li class="nav-item" v-if="settings.initials == 'KIBU' && user.role === 3">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/clearances/survey"
              >Fill Survey</router-link>
              <div class="slide"></div>
            </li>
            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/clearances/apply"
              >Apply For Clearance</router-link>
              <div class="slide"></div>
            </li>
            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/clearances/clearance-certificate"
              >Clearance Certificate</router-link>
              <div class="slide"></div>
            </li>
            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/clearances/history"
              >Clearance History</router-link>
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
      user: this.$baseRead('user'),
      settings : JSON.parse(localStorage.getItem("settings"))
    };
  },
};
</script>

<style>
</style>
