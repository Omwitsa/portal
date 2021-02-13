<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="history"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:buttonEvent="buttonEvent"
    ></data-table>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      history: [],
      loading: true,
      title: "Booking History",
      subTitle: "List of booking History.",
      user: this.$baseRead("user"),
      tableActions: [],
      headerActions: [],

      columns: [
        {
          name: "Room"
        },
        {
          name: "Term"
        },
        {
          name: "Date"
        },
        {
          name: "Hostel"
        },
        {
          name: "Status"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http
        .get("hostelbooking/myhostelbookings?usercode=" + this.user.username)
        .then(result => {
          this.history = [];
          if (result.data.success) {
            var info = result.data.data;
            info.forEach(element => {
              var hostelInfo = element.hostel.split(":");
              var hostelName = "";
              var roomName = "";
              if (hostelInfo.length > 0) {
                hostelName = hostelInfo[0];
              }
              if (hostelInfo.length > 1) {
                roomName = hostelInfo[1];
              }
              var item = {
                room: roomName,
                term: element.term,
                date: DateFomatter.ReturnDate(element.rdate),
                hostel: hostelName,
                status: "Booked"
              };
              this.history.push(item);
            });
          } else {
            this.$toastr("error", error.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
          this.pagination.total = this.history.length;
          this.pagination.current = pageNumber;
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loading = false;
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          swal({
            title: "Are you sure you want to delete?",
            icon: "warning",
            buttons: true,
            dangerMode: false
          }).then(action => {
            if (action) {
              this.$toastr("success", "Deleted");
            }
          });
          break;
        default:
          break;
      }
    }
  },
  created() {
    this.loadData(100, 1);
  }
};
</script>

<style>
</style>
