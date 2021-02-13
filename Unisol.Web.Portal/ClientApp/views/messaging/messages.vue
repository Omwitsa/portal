<template>
  <div class="page-body"><br>
    <div class="row">
      <div class="col-lg-12">
        <div class="tab-header card">
          <ul class="nav nav-tabs md-tabs tab-timeline" role="tablist">
            <li class="nav-item">
              <router-link exact-active-class="active" class="nav-link" to="/messaging/inbox">Inbox</router-link>
              <div class="slide"></div>
            </li>

            <li class="nav-item">
              <router-link
                exact-active-class="active"
                class="nav-link"
                to="/messaging/compose"
              >Compose</router-link>
              <div class="slide"></div>
            </li>

            <li class="nav-item">
              <router-link exact-active-class="active" class="nav-link" to="/messaging/sent">Sent</router-link>
              <div class="slide"></div>
            </li>

            <li class="nav-item">
              <router-link exact-active-class="active" class="nav-link" to="/messaging/trash">Trash</router-link>
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
      connection: null
    };
  },
  created() {
   
  },
  methods: {}
};
</script>
<style>
</style>
