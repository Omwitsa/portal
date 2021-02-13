<script>
const BasePlugin = {};
BasePlugin.install = function(Vue, options) {
  Vue.myGlobalMethod = function() {
  };
  //local storage hash
  Vue.prototype.$baseStore = function(key, data) {
    localStorage.setItem(key, null);
    localStorage.setItem(key, btoa(JSON.stringify(data)));
  };

  Vue.prototype.$baseRead = function(key) {
    var res = localStorage.getItem(key);
    if(res){
        var data = res.length  < 5 ? null : JSON.parse(atob(res));
        return data;
    }
    return undefined;
  };

  //active class link
  Vue.prototype.$baseLinkClass = function(to) {
    if (to) {
      var styling = "nav-link";
      if (this.$route.path.includes(to)) styling = styling + " active";
      return styling;
    }
  };
};
export default BasePlugin;
</script>