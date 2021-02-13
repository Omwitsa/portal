<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h4>{{title}} {{this.currentSemester}}</h4>
      </div>
      <div v-if="eligibleHttp" class="text-center">
        <i class="fa fa-spin fa-spinner"></i> Checking for hostel booking eligibility...
      </div>
      <div class="card-block" v-if="eligibleToBook==2">
        <div class="alert alert-warning">
          <i class="fa fa-exclamation-circle"></i>
          {{eligibleMessage}}
        </div>
      </div>
      <div class="card-block" v-if="eligibleToBook==1">
        <div class="row">
          <div class="col-md-6">
            <label>
              select Hostel
              <small-spinner :loading="fetchingHostels"></small-spinner>
            </label>
            <select v-model="hostel" class="form-control" @change="getHostelRooms()">
              <option disabled>--select hostel--</option>
              <option
                v-for="(host,index) in hostelOptions"
                :value="host.label"
                :key="index"
              >{{host.label}}</option>
            </select>
          </div>
        </div>
        <br />
        <div class="row">
          <div class="col-md-12">
            <small-spinner :loading="fetchingRooms"></small-spinner>
            <div v-if="!fetchingRooms" class="table-responsive">
              <input
                class="form-control col-md-12"
                placeholder="search room"
                @keyup="getHostelRooms()"
                v-model="searchRoom"
              />
              <table class="table table-sm table-bordered">
                <thead>
                  <th>#</th>
                  <th>Names</th>
                  <th>Type</th>
                  <th>capacity</th>
                  <th>Free</th>
                  <th></th>
                </thead>
                <tbody>
                  <tr v-for="(room,index) in availableHostelRooms" :key="index">
                    <td>{{index+1}}</td>
                    <td>{{room.names}}</td>
                    <td>{{room.roomType}}</td>
                    <td>{{room.maxacc}}</td>
                    <td>{{room.notes}}</td>
                    <td>
                      <div
                        data-toggle="modal"
                        data-target="#myModal"
                        @click="createCurrentRoom(room)"
                        class="btn btn-primary btn-sm btn-round waves-effect waves-light"
                      >book</div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="modal fade" id="myModal" role="dialog">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header text-left">
            <div class="h5">Book Hostel</div>
            <!-- <span class>{{clickedRoom.hostel}}</span> -->
            <button type="button" class="close" data-dismiss="myModal">&times;</button>
          </div>
          <div class="modal-body">
            <div class="form-group">
              <div class="col-md-12">
                <label>
                  <b>Semester</b>
                </label>
                <div>{{currentSemester}}</div>
              </div>
            </div>
            <div class="form-group">
              <div class="col-md-12">
                <label>
                  <b>Hostel</b>
                </label>
                <div>{{clickedRoom.hostel}}</div>
              </div>
            </div>
            <div class="form-group">
              <div class="col-md-12">
                <label>
                  <b>Room</b>
                </label>
                <div>{{clickedRoom.names}} ({{clickedRoom.roomType}})</div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <div class="pull-right">
              <div class="btn btn-primary btn-round waves-effect waves-light" @click="bookRoom()">
                <small-spinner :loading="savingHttp"></small-spinner>Submit
              </div>
              <button
                data-dismiss="myModal"
                class="btn btn-inverse btn-round waves-effect waves-light"
              >Cancel</button>
            </div>
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
      title: "Hostel Booking",
      subTitle: "Booking",
      selectHostel: "",
      hostel: "",
      availableHostelRooms: [],
      hostelOptions: [],
      tableActions: [],
      searchRoom: "",
      eligibleMessage: "",
      currentSemester: "",
      clickedRoom: {},
      user: this.$baseRead("user"),
      fetchingHostels: false,
      fetchingRooms: false,
      eligibleToBook: 0,
      eligibleHttp: true,
      savingHttp: false,
      headerActions: [
        {
          name: "Add",
          icon: "plus",
          type: "link",
          path: "sor/list",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Room Number"
        },
        {
          name: "Number of Spaces"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },
  methods: {
    save: function() {
      this.$http
        .post("hostel/add", this.hostel)
        .then(response => {
          if (response.data.success) {
            this.$toastr("success", "Success");
            //this.$router.replace({ name: "users" })
          } else {
            this.$toastr("error", response.data.message);
          }
          this.submitting = false;
        })
        .catch(e => {
          this.$toastr("error", e.message);
        });
    },

    getHostels() {
      var userCode = this.user.username;
      this.fetchingHostels = true;
      this.$http
        .get("hostelbooking/RetrieveOpenHostels?usercode=" + userCode)
        .then(result => {
          this.fetchingHostels = false;
          this.hostelOptions = [];
          result.data.data.forEach(element => {
            var item = {
              label: element.names,
              value: element.names
            };
            this.hostelOptions.push(item);
          });
        })
        .catch(error => {
          this.fetchingHostels = false;
        });
    },
    getHostelRooms() {
      var search = "";
      if (this.searchRoom) search = this.searchRoom;
      if (!this.hostel) {
        this.$toastr("error", "Please select an hostel");
        return;
      }
      this.fetchingRooms = true;
      this.$http.get(
          "hostelbooking/retrievebookablerooms?hostel=" +
            this.hostel +
            "&usercode=" +
            this.user.username +
            "&searchString=" +
            search
        )
        .then(result => {
          this.availableHostelRooms = result.data.data;
          this.fetchingRooms = false;
          // if (this.availableHostelRooms.length == 0)
          //     this.$toastr("error", "No rooms with you search criteria");
        })
        .catch(error => {
          this.fetchingRooms = false;
          this.$toastr("error", error.message);
        });
    },
    createCurrentRoom: function(room) {
      this.clickedRoom = room;
    },
    checkEligibility: function() {
      var userCode = this.user.username;
      this.eligibleHttp = true;
      this.eligibleToBook = 0;
      this.$http
        .get("hostelbooking/checkeligibility?usercode=" + userCode)
        .then(result => {
          this.eligibleHttp = false;
          if (result.data.success) {
            this.currentSemester = result.data.data.currentTerm;
            this.getHostels();
            this.eligibleToBook = 1;
          } else {
            this.$toastr("error", result.data.message);
            this.eligibleMessage = result.data.message;
            this.eligibleToBook = 2;
          }
        })
        .catch(error => {
          this.fetchingHostels = false;
        });
    },
    bookRoom: function() {
      var room = {
        AdmnNo: this.user.username,
        Hostel: this.clickedRoom.names,
        Term: this.currentSemester,
        Personnel: this.user.username
      };

      this.savingHttp = true;
      this.$http
        .post("hostelbooking/savebooking", room)
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            this.savingHttp = false;
            $("#myModal").modal("hide");
            this.checkEligibility();
            this.$toastr("success", result.data.message);
          } else {
            this.$toastr("error", result.data.message);
            $("#myModal").modal("hide");
            this.savingHttp = false;
          } 
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", "We could not find what you searching for");
        });
    }
  },
  created() {
    this.checkEligibility();
  }
};
</script>

<style scoped>
</style>