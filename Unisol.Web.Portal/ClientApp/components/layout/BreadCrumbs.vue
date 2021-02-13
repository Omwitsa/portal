<template>
 <div>
     <!-- [ breadcrumb ] start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <h4 class="m-b-10">{{routeName}}</h4>
                    </div>
                    <ul class="breadcrumb">
                        <li class="breadcrumb-item">
                            <router-link replace exact
                            :to="{name: 'home'}">
                                <icon icon="home" />
                            </router-link>
                        </li>
                        <li class="breadcrumb-item bi" v-for="(breadcrumb, inx) in breadcrumbs" 
                        :key="inx"
                        @click="routeTo(inx)"
                        :class="{'linked':!!breadcrumb.link}"
                        >
                        {{breadcrumb.name}}
                        </li>
                    </ul>
                </div>
                
            </div>
        </div>
    </div>
 </div>
</template>

<script>
export default {
  data() {
    return {
      breadcrumbs: Array
    }
  },
  mounted() {
    this.updateList()
  },
  computed: {
    routeName() {
      const { name } = this.$route
      var joined = ""
      var res = name.split("-")
      if (res.length > 1)
      {
          for (let index = 0; index < res.length; index++) {
              joined = joined + " " + res[index];
          }
      }  
      else {
          joined = name
      }
      return this.capitalizeFirstLetter(joined)
    }
  },
  watch: {
    $route() {
      this.updateList()
    }
  },
  methods: {
    capitalizeFirstLetter(string) {
        string = string.trim()
        return string.charAt(0).toUpperCase() + string.slice(1)
    },
    updateList() {
      this.breadcrumbs = this.$route.meta.breadcrumb
    },
    routeTo(to) {
      if (this.breadcrumbs[to].link) {
        this.$router.replace({ name: this.breadcrumbs[to].link })
      }
    }
  }
}
</script>

<style>
.bi {
  color: #fff;
}
.linked {
  cursor: pointer;
}
</style>