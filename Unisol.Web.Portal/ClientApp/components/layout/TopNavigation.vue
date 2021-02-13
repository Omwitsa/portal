<template>
  <nav class="navbar header-navbar pcoded-header">
    <div class="navbar-wrapper">
      <div class="navbar-logo">
        <a class="mobile-menu waves-effect waves-light" id="mobile-collapse" href="#!">
          <icon icon="bars" />
        </a>
        <a class="mobile-options waves-effect waves-light">
          <icon icon="bars" />
        </a>
      </div>
      <div class="navbar-container container-fluid">
        <ul class="nav-left">
          <li class="header-search" v-show="false">
            <div class="main-search morphsearch-search">
              <div class="input-group">
                <span class="input-group-prepend search-close">
                  <i class="input-group-text fa fa-times" />
                </span>
                <input type="text" class="form-control" placeholder="Enter Keyword" />
                <span class="input-group-append search-btn">
                  <i class="input-group-text fa fa-search" />
                </span>
              </div>
            </div>
          </li>
          <li>
            <a href="#!" onclick="javascript:toggleFullScreen()" class="waves-effect waves-light">
              <i class="full-screen fa fa-maximize" />
            </a>
          </li>
        </ul>
        <ul class="nav-right">
          <li class="user-profile header-notification">
            <div class="dropdown-primary dropdown">
              <div class="dropdown-toggle" data-toggle="dropdown">
                <span>{{username}}</span>
                <icon icon="chevron-down" />
              </div>
              <ul
                class="show-notification profile-notification dropdown-menu"
                data-dropdown-in="fadeIn"
                data-dropdown-out="fadeOut">
                <li v-if="isAdmin">
                  <a @click="routeTo('settings')">
                    <icon icon="cogs" />&nbsp; Settings
                  </a>
                </li>
                <li>
                  <a @click="routeTo('messaging')">
                    <icon icon="envelope" />&nbsp; My Messages
                  </a>
                </li>
                <li>
                  <a @click="routeTo(userUrl)">
                    <icon icon="user" />&nbsp; Profile
                  </a>
                </li>
                <li>
                  <a @click="changePassword">
                    <icon icon="table" />&nbsp; Change Password
                  </a>
                </li>
                <li>
                  <a @click="logout">
                    <icon icon="lock" />&nbsp; Logout
                  </a>
                </li>
              </ul>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  data() {
    return {
      username: String,
      userUrl: "",
      user: {},
      isAdmin: false
    };
  },
  methods: {
    logout: function() {
      this.$baseStore("user", null);
      this.$toastr("success", "You have been logged out");
      this.routeTo("login");
    },
    changePassword() {
      this.$router.replace({ name: "changePassword" });
    },
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to });
      }
    }
  },
  created() {
    this.user = this.$baseRead("user");
    if (this.user.role == 1) this.isAdmin = true;
    if (this.user.role == 3) {
      this.userUrl = "student-profile";
    } else {
      this.userUrl = "staff-profile";
    }
    var name = this.user.userRegister.names.split(" ");
    if (name[0]) {
      this.username = name[0];
    }
  }
};
</script>

<style>
</style>