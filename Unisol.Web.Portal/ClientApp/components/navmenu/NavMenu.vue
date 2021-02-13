<template>
  <div class="main-nav d-print-none">
    <nav class="pcoded-navbar">
        <div class="pcoded-inner-navbar main-menu">
            <div class="">
                <div class="main-menu-header">
                   <router-link 
                            :to="{name: 'home'}">
                    <img class="img-menu-user img-thumbnail" :src="settings.logoImageUrl" :alt="settings.initials" height="5rem" width="auto">
                            </router-link>
                    <div class="user-details">
                        <p id="more-details">
                          <router-link 
                            :to="{name: 'home'}">
                              {{settings.Name}}
                            </router-link>
                            </p>
                    </div>
                </div>
            </div>
            <ul class="pcoded-item pcoded-left-item">
              <li v-for="(route,ind) in navmenuLinks" :key="ind" v-bind:class="{'pcoded-hasmenu':(route.children)}" >
                <a v-if="route.children" href="javascript:void(0)" class="waves-effect waves-dark">
                    <span class="pcoded-micon"><icon :icon="route.icon" /></span>
                    <span class="pcoded-mtext">{{ route.display }}</span>
                </a>
                <ul class="pcoded-submenu" v-if="route.children">
                    <li v-for="(child,cind) of route.children" :key="cind">
                        <router-link 
                        :to="{name: child.name}" 
                        class="waves-effect waves-dark" 
                        exact-active-class="active">
                            <span class="pcoded-micon">
                                <icon :icon="child.icon" />
                            </span>
                            <span class="pcoded-mtext">{{ child.display }}</span>
                        </router-link>
                    </li>                                    
                </ul>
                <router-link v-if="!route.children" :to="{name: route.name}" 
                        class="waves-effect waves-dark" exact-active-class="active">
                        <!-- id="mobile-collapse"> -->
                    <span class="pcoded-micon">
                        <icon :icon="route.icon" />
                    </span>
                    <span class="pcoded-mtext">{{ route.display  }}</span>
                </router-link>
            </li>
          </ul>
        </div>
    </nav>
  </div>
</template>
<script>
export default {
  props: {
    type: {
      type: String,
      default: "navmenu",
      validator: value => {
        let acceptedValues = ["navmenu", "navbar"];
        return acceptedValues.indexOf(value) !== -1;
      }
    },
    navmenuLinks: {
      type: Array,
      default: () => []
    }
  },
  components: {},
  computed: {
    navmenuClasses() {
      if (this.type === "navmenu") {
        return "navmenu";
      } else {
        return "collapse navbar-collapse off-canvas-navmenu";
      }
    },
    navClasses() {
      if (this.type === "navmenu") {
        return "nav";
      } else {
        return "nav navbar-nav";
      }
    },
    settings(){
      var set = JSON.parse(localStorage.getItem('settings'))
      if(set)
        set.LogoImageUrl = '../'+ set.LogoImageUrl
      else        
        set.LogoImageUrl = ''
      return set
    }
  },
  data() {
    return {
      activeLinkIndex: 0,
    };
  },
  methods: {
    findActiveLink() {
      this.navmenuLinks.find((element, index) => {
        let found = element.name === this.$route.name;
        if (found) {
          this.activeLinkIndex = index;
        }
        return found;
      });
    }
  },
  mounted() {
    this.findActiveLink();
  },
  watch: {
    $route: function(newRoute, oldRoute) {
      this.findActiveLink();
    }
  }
};
</script>
<style>
</style>