<template>
  <div class="container-fluid">
    <router-view></router-view>
    <div class="footer"><br>
      <p> Powered By ABNO Softwares International LTD</p>
    </div>
  </div>
</template>
<script>
export default {
  methods: {
    register(){
      this.$router.replace({name: "register"})
    },
  }
}
</script>

<style scoped>
.col-md-10 {
    margin: auto;
    display: block;
}
.footer{
  text-align: center;
  color: gray;
}
</style>

