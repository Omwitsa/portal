<template>
  <div>
    <div class="row">
      <div class="col-lg-7 col-md-12">
        <div class="row">
          <div class="col-md-12">
            <div class="card table-card review-card">
              <div class="card-header">
                <h5>Latest News</h5>
                <small-spinner :loading="loading"></small-spinner>
              </div>
              <div class="card-block">
                <div class="review-block">
                  <div class="row" v-for="(newsItem, nIndex) in news" :key="nIndex">
                    <div class="col">
                      <h6 class="m-b-15">
                        {{newsItem.title}}
                        <span
                          class="float-right f-13 text-muted"
                        >{{newsItem.posted}}</span>
                      </h6>
                      <p class="m-t-15 m-b-15 text-muted">{{newsItem.body}}</p>
                      <!-- <div class="m-r-30 badge badge-primary">{{newsItem.type}}</div> -->
                      <router-link
                        class="btn btn-link pull-right"
                        :to="{ name: 'news-details', params: { id: newsItem.id }}"
                      >Read More</router-link>
                      <hr />
                    </div>
                  </div>
                </div>
                <div v-if="news.length > 3" class="text-right m-r-20">
                  <a @click="routeTo('portal-news')" class="b-b-primary text-primary">View all News</a>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div class="card table-card latest-activity-card">
              <div class="card-header borderless">
                <h5>Current Registered Units</h5>
                <small-spinner :loading="loading"></small-spinner>
                <div class="card-header-right">
                  <ul class="list-unstyled card-option">
                    <li class="first-opt">
                      <i class="fa fa-chevron-left open-card-option"></i>
                    </li>
                    <li>
                      <i class="fa fa-maximize full-card"></i>
                    </li>
                    <li>
                      <i class="fa fa-minus minimize-card"></i>
                    </li>
                    <li>
                      <i class="fa fa-refresh-cw reload-card"></i>
                    </li>
                    <li>
                      <i class="fa fa-trash close-card"></i>
                    </li>
                    <li>
                      <i class="fa fa-chevron-left open-card-option"></i>
                    </li>
                  </ul>
                </div>
              </div>

              <div v-if="unitsPrestent && !loading" class="card-block">
                <div class="table-responsive">
                  <table class="table table-hover table-borderless table-sm">
                    <thead>
                      <tr>
                        <th>Unit Name</th>
                        <th>Unit Code</th>
                        <th>Status</th>
                      </tr>
                    </thead>

                    <tbody v-for="(unit, index) in registeredUnits" :key="index">
                      <tr>
                        <td>{{unit.names}}</td>
                        <td>{{unit.code}}</td>
                        <td>
                          <label class="label label-warning">{{unit.status}}</label>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>

                <div class="text-right m-r-20">
                  <a
                    @click="routeTo('Register-Units')"
                    class="b-b-primary text-primary"
                  >Units Section</a>
                </div>

                <div
                  v-if="!unitsPrestent && !loading"
                  class="card-block text-danger"
                >{{noRegisteredUnitMessage}}</div>
              </div>
            </div>
          </div>
        </div>

        <div class="row">
          <div class="col-md-12">
            <div class="card table-card review-card">
              <div class="card-header">
                <h5>Latest Event</h5>
                <small-spinner :loading="loading"></small-spinner>
              </div>
              <div v-if="isEventResults" class="card-block">
                <div class="review-block">
                  <div class="row" v-for="(EventItem, Index) in events" :key="Index">
                    <div class="col">
                      <h6 class="m-b-15">
                        {{EventItem.title}}
                        <span
                          class="float-right f-13 text-muted"
                        >{{EventItem.startdate}}</span>
                      </h6>
                      <p class="m-t-15 m-b-15 text-muted">{{EventItem.description}}</p>
                      <router-link
                        class="btn btn-link"
                        :to="{ name: 'events-details', params: { id: EventItem.id }}"
                      >Read More</router-link>
                    </div>
                  </div>
                </div>

                <div v-if="events.length > 3" class="text-right m-r-20">
                  <a @click="routeTo('portal-events')" class="btn btn-link">View all Events</a>
                </div>
              </div>

              <div style="color:red" v-if="!isEventResults" class="card-block">
                <div class="review-block">
                  <div class="row">
                    <div class="col">There is no current event entry</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="col-xl-5 col-md-12">
        <div class="card bg-c-yellow text-white widget-visitor-card">
          <div class="text-center">
            <small-spinner :loading="loading"></small-spinner>
          </div>
          <div class="card-block-small text-center" v-if="!loading">
            <h5>Your Fee Balance is:</h5>
            <h3>{{feesDetails.data.balance.toLocaleString('en')}}</h3>
            <i class="fa fa-newspaper-o"></i>
          </div>
        </div>

        <div class="card bg-c-blue text-white widget-visitor-card">
          <div class="text-center">
            <small-spinner :loading="loadingHostels"></small-spinner>
          </div>
          <div class="card-block-small text-center" v-if="!loadingHostels">
            <h4>Current Hostel</h4>
            <h5 v-if="isBookingResults">{{"Hostel Name: "+ hostelsDetail.hostelName}}</h5>
            <h5 v-if="isBookingResults">{{"Room Name: "+ hostelsDetail.roomName}}</h5>

            <h4 v-if="!isBookingResults">
              No hostel History
              <i class="fa fa-file-text"></i>
            </h4>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      news: [],
      newsCount: 0,
      eventsCount: 0,
      events: [],
      loading: false,
      loadingHostels: false,
      user: {},
      registeredUnits: [],
      hostelsDetail: {
        hostelName: ".",
        roomName: "."
      },
      hostel: {},
      unitsPrestent: true,
      noRegisteredUnitMessage: "",
      feesDetails: {
        data: {
          balance: ""
        }
      },
      bookingResults: {},
      eventsResults: {},
      isBookingResults: true,
      isEventResults: true
    };
  },
  created() {
    this.user = this.$baseRead("user");
    this.fetchNews();
    this.fetchEvents();
    this.getregisteredUnits();
    this.getFeesDetails();
    this.getHostelsDetails();
    this.getInstitutionInfo();
    this.getFacultyInfo();
  },
  methods: {
    getFacultyInfo(results) {
      this.$http
        .get("academic/getStudentFucultyInfo/?userCode=" + this.user.username)
        .then(response => {
          localStorage.setItem("fucultyInfo", null);
          var fucultyInfo = JSON.stringify(response.data.data);
          localStorage.setItem("fucultyInfo", fucultyInfo);
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
    },
    getInstitutionInfo() {
        this.$http.get("commonutilities/GetInstitutionInfo")
            .then(response => {
              localStorage.setItem("institutionInfo", null);
              var institutionInfo = JSON.stringify(response.data.data);
              localStorage.setItem("institutionInfo", institutionInfo);
            })
            .catch(error => {
            this.$toastr("error", error.message);
        });
    },
    fetchNews() {
      this.loading = true;
      this.$http
        .get("news/GetNews?searchText=&offset=0&userCode=" + this.user.username)
        .then(result => {
          this.news = [];
          var info = result.data.data;
          this.newsCount = result.data.totalItems;
          info.forEach(element => {
            var item = {
              id: element.id,
              title: element.newsTitle,
              body: this.stripContent(element.newsBody).substr(0, 200) + "...",
              type: element.portalNewsType.newsTypeName,
              posted: DateFomatter.ReturnDate(element.dateCreated),
              status: element.newsStatus == 1 ? "Active" : "Inactive"
            };
            this.news.push(item);
            this.loading = false;
          });
        })
        .catch(error => {
          this.$toastr("error", error.message);
          this.loading = false;
        });
    },
    fetchEvents() {
      this.loading = true;
      this.$http
        .get(
          END_POINTS.GETEVENTS +
            3 +
            "&offset=0&tokenString=" +
            this.user.token +
            "&userCode=" +
            this.user.username
        )
        .then(result => {
          this.events = [];
          if (result.data.success) {
            var info = result.data.data;
            this.eventsCount = result.data.totalItems;
            if (info == "") {
              this.isEventResults = false;
            } else {
              info.forEach(element => {
                var item = {
                  id: element.id,
                  title: element.eventTitle,
                  description:
                    this.stripContent(element.eventDesc).substr(0, 140) + "...",
                  startdate: DateFomatter.ReturnDate(element.eventStartDate),
                  enddate: DateFomatter.ReturnDate(element.eventEndDate)
                };
                this.events.push(item);
                this.loading = false;
              });
            }
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
          this.loading = false;
        });
    },
    getregisteredUnits() {
      this.loading = true;
      this.$http.get("units/GetRegisteredUnits?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.unitsPrestent = true;
            this.registeredUnits = result.data.data;
          } else {
            this.unitsPrestent = false;
            this.noRegisteredUnitMessage = result.data.message;
          }
          this.loading = false;
        })
        .catch(error => {
          this.$toastr("error", error.message);
          this.loading = false;
        });
    },
    getFeesDetails() {
      this.loading = true;
      this.$http.get("finance/getStudentFeeInfo?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.feesDetails = result.data;
            if (this.feesDetails.data.balance == "0")
              this.feesDetails.data.balance = "0.00";
          }
          this.loading = false;
        })
        .catch(error => {
          this.$toastr("error", error.message);
          this.loading = false;
        });
    },
    getHostelsDetails() {
      this.loadingHostels = true;
      this.isBookingResults = true;
      this.$http
        .get(
          "hostelbooking/myhostelbookings?userCode=" +
            this.user.username +
            "&fetchLatestHostel=true"
        )
        .then(result => {
          if (result.data.success) {
            var val = result.data.data.hostel.split(":");
            if (val[0]) {
              this.hostelsDetail.hostelName = val[0];
              this.loadingHostels = false;
            }
            if (val[1]) {
              this.hostelsDetail.roomName = val[1];
              this.loadingHostels = false;
            }
          } else {
            this.isBookingResults = false;
            this.bookingResults = result.data;
            this.loadingHostels = false;
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
          this.loadingHostels = false;
        });
    },
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to });
      }
    },
    stripContent(content) {
      let regex = /(<([^>]+)>)/gi;
      return content.replace(regex, "");
    }
  }
};
</script>

<style>
</style>
