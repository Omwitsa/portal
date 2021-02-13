<template>
  <div>
    <admin-dashboard v-if="role=='ADMIN'"></admin-dashboard>
    <student-dashboard v-if="role=='STUDENT'"></student-dashboard>
    <staff-dashboard v-if="role=='STAFF'"></staff-dashboard>
  </div>
</template>
<script>
import AdminDashboard from "./AdminDashboard";
import StudentDashboard from "./StudentDashboard";
import StaffDashboard from "./StaffDashboard";
export default {
  components: {
    AdminDashboard,
    StudentDashboard,
    StaffDashboard
  },
  data() {
    return {
      role: String
    };
  },
  created() {
    var user = this.$baseRead("user");
    switch (user.role) {
      case 1:
        this.role = "ADMIN";
        break;
      case 2:
        this.role = "STAFF";
        break;
      case 3:
        this.role = "STUDENT";
        break;
      default:
        break;
    }
  }
};
</script>

<style>
</style>

