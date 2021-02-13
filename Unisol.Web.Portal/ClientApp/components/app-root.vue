<template>
  <div id="app">
    <div class="loader-bg">
      <div class="loader-bar"></div>
    </div>
    <div id="pcoded" class="pcoded">
      <div class="pcoded-overlay-box"></div>
      <div class="pcoded-container navbar-wrapper">
        <top-navigation v-if="showNavigations"></top-navigation>
        <div class="pcoded-main-container">
          <nav-menu v-if="showNavigations" type="navmenu" :navmenu-links="links"></nav-menu>
          <div class="pcoded-wrapper">
            <div :class="[ { 'pcoded-content' : showNavigations }]">
              <div class="pcoded-inner-content">
                <div class="main-body">
                  <div class="page-wrapper">
                    <div class="page-body">
                      <router-view></router-view>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TopNavigation from "./layout/TopNavigation";
import BreadCrumbs from "./layout/BreadCrumbs";
export default {
  components: {
    BreadCrumbs,
    TopNavigation
  },
  computed: {
    showNavigations() {
      if (this.$route.path.includes("login")) {
        return false;
      }
      return true;
    },
    links() {
      let menuLinks = this.navMenuLinks;
      return menuLinks;
    }
  },
  created() {
    if (this.user) {
      this.getPrivileges();
    } else {
      this.generateLinks();
    }
  },
  data() {
    return {
      navMenuLinks: [],
      privileges: [],
      institutionsPortalDetails: [],
      settings: JSON.parse(localStorage.getItem("settings")),
      user: this.$baseRead("user"),
      iconName: "",
      
    };
  },
  // check if the user is idle and logout after a given duration
  onIdle() {
    this.$baseStore("user", null);
    this.$router.replace({ name: "login" });
  },
  // onActive() {

  // },

  methods: {
    getInstitutionsPortalDetaiils(){
      // var portalDownMailReceiver = "emeyo@abnosoftwares.com"
      var portalDownMailReceiver = "womwitsa@abnosoftwares.com"
      this.institutionsPortalDetails = [
        // { 'ip': 'http://portal.uoeld.ac.ke', 'name': 'UNIVERSITY OF ELDORET', 'fails' : 0, 'mailReceiver': portalDownMailReceiver }

        { 'ip': 'http://localhost:8090', 'name': 'UNIVERSITY OF ABNO', 'fails' : 0, 'mailReceiver': portalDownMailReceiver }
      ]
    },
    checkIfServerIsUp() {
      var settings = JSON.parse(localStorage.getItem("settings"))
      if(settings.initials === "ABNO"){
        this.institutionsPortalDetails.forEach(element => {
          $.ajax({
            type: 'GET',
            url: element.ip,
            success: function(result){
              element.fails = 0
            },     
            error: function(result){
              element.fails++
              if(element.fails >= 3){
                element.fails = 0
                // $.ajax({
                //   type: 'GET',
                //   url: `${window.location.origin}/api/PortalLogs/notifyPortalDown?institution=${element.name}&ip=${element.ip}&mailReceiver=${element.mailReceiver}`,
                //   success: function(result1){

                //   },     
                //   error: function(result1){

                //   }
                // });
              }
            }
          });
        }); 

        // setTimeout(() => {this.checkIfServerIsUp()}, 1000 * 60 * 10);
        setTimeout(() => {this.checkIfServerIsUp()}, 1000 * 30);
      }
    },
    getPrivileges() {
      this.privileges = [];
      this.$http
        .get(
          "privileges/getGroupPrivileges/?usercode=" +
            this.user.username +
            "&level=1"
        )
        .then(result => {
          if (result.data.success) {
            this.privileges = result.data.data;
            this.generateLinks();
          } else if (this.user.role === 1) this.generateLinks();
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
    },
    generateLinks() {
      if (!this.user) {
        var url = this.$route.path;
        if (
          url.includes("/login/confirm") ||
          url.includes("/login/register") ||
          url.includes("/login/email-confirmation") ||
          url.includes("/login/reset") ||
          url.includes("/login/reset-password")
        ) {
        } else {
          this.$baseStore("user", null);
          this.$router.replace({ name: "login" });
        }
        return;
      }
      this.navMenuLinks = [];
      this.navMenuLinks.push({ display: "Home", icon: "home", name: "home" });
      if (this.user.role) {
        switch (this.user.role) {
          case 1:
            if (this.user.groupName === "AbnAdmin") {
              this.privileges = [];
              this.navMenuLinks.push({
                display: "User Management",
                icon: "users",
                name: "users"
              });
              this.navMenuLinks.push({
                display: "News & Events",
                icon: "calendar-alt",
                name: "news"
              });
              this.navMenuLinks.push({
                display: "Messages",
                icon: "comments",
                name: "messaging"
              });
              this.navMenuLinks.push({
                display: "Repository",
                icon: "folder-open",
                name: "repository"
              });
              this.navMenuLinks.push({
                display: "Evaluations",
                icon: "question-circle",
                name: "evaluations"
              });
              this.navMenuLinks.push({
                display: "System Logs",
                icon: "file",
                name: "systemlogs"
              });
              this.navMenuLinks.push({
                display: "Clearance Quetionnaire",
                icon: "file",
                name: "clearanceQuetionnaire"
              });
              this.navMenuLinks.push({
                display: "Leave Documents",
                icon: "briefcase",
                name: "leaveDocuments"
              });
              this.navMenuLinks.push({
                display: "Research/projects/publications",
                icon: "file",
                name: "research"
              });
              this.navMenuLinks.push({
                display: "Complains/Complements",
                icon: "file",
                name: "complaint"
              });
              this.navMenuLinks.push({
                display: "Attendance",
                icon: "building",
                name: "attendance"
              });
              this.navMenuLinks.push({
                display: "Performance Management",
                icon: "file", 
                name: "performance"
              });
              if (this.user.genesisUser) {
                this.navMenuLinks.splice(5, 1);
              }
            }
            else{
                this.privileges.forEach(element => {
                this.iconName = this.geticonName(element.privilegeName);
                this.navMenuLinks.push({
                  display: element.privilegeName,
                  icon: this.iconName,
                  name: element.action
                });
              });
            }
          break;
          case 2:
            this.privileges.forEach(element => {
              this.iconName = this.geticonName(element.privilegeName);
              this.navMenuLinks.push({
                display: element.privilegeName,
                icon: this.iconName,
                name: element.action
              });
            });

            if(this.settings.isGenesis){
              this.navMenuLinks = this.navMenuLinks.filter(item => item.name !== "evaluations" && item.name !== "timetable")
            }
          break;
          case 3:
            this.privileges.forEach(element => {
              this.iconName = this.geticonName(element.privilegeName);
              this.navMenuLinks.push({
                display: element.privilegeName,
                icon: this.iconName,
                name: element.action
              });
            });
          default:
            break;
        }
      }
    },
    geticonName(FeatureName) {
      var iconName = "clock";
      switch (FeatureName) {
        case "User Management":
          iconName = "users";
          break;
        case "News & Events":
          iconName = "calendar-alt";
          break;
        case "Evaluations":
          iconName = "question-circle";
          break;
        case "Repository":
          iconName = "folder-open";
          break;
        case "Messages":
          iconName = "comments";
          break;
        case "Payments":
          iconName = "money-bill-alt";
          break;
        case "Leave Management":
          iconName = "briefcase";
          break;
        case "SOR, IR, Claims & Imprest":
          iconName = "credit-card";
          break;
        case "Units":
          iconName = "book";
          break;
        case "Fees":
          iconName = "money-bill-alt";
          break;
        case "Examinations":
          iconName = "graduation-cap";
          break;
        case "Hostel Booking":
          iconName = "bed";
          break;
        case "Evaluations":
          iconName = "question-circle";
          break;
        case "Clearance":
          iconName = "file";
          break;
        case "Clearances":
          iconName = "file";
          break;
        case "Fleet Management":
          iconName = "car";
          break;
        case "Imprest Surrender":
          iconName = "microchip";
          break;
        case "Finance Surrenders":
          iconName = "braille";
          break;
        case "Work Request":
          iconName = "building";
        break;
        case "Timetable":
          iconName = "table";
        break;
        case "System Logs":
          iconName = "file";
        break;
        case "Attendance":
          iconName = "building";
        break;
        case "Complaint":
          iconName = "comment";
        break;
        case "research":
          iconName = "file";
        break;
        case "Performance Management":
          iconName = "file";
        break;
        default:
          iconName = iconName;
          break;
      }
      return iconName;
    }
  },
  mounted(){
    // this.getInstitutionsPortalDetaiils()
    this.checkIfServerIsUp()
  }
};
</script>

<style scoped>
/* .pcoded-content {
    margin-left: 1px !important;
} */
</style>
