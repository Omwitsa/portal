<template>
  <div class="page-body">
    <div class="col-lg-12" style="padding: 0px 0px;">
      <div class="card user-card">
        <div class="card-header">
          <h5>{{title}}</h5>
        </div>

        <div class="card-block">
          <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
              <full-calendar :events="calenderEvents" locale="en"></full-calendar>
            </div>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
              <h4 class="eventTitle">
                {{this.event.eventTitle}}
                <hr />
              </h4>
              <div class="row">
                <div class="col-md-4">
                  <h6>{{"From Date: "+ startDate}}</h6>
                </div>
                <div class="col-md-4">
                  <h6>{{"- To Date: "+endDate}}</h6>
                </div>
              </div>
              <hr />
              <p v-html="event.eventDesc"></p>
              <br />Date Created:
              <div class="m-r-30 badge badge-primary">{{ EventsDateCreated }}</div>
              <br/>Event venue:
              <div class="m-r-30">{{ event.eventVenue }}</div>
            </div>
          </div>
        </div>

        <div class="card-footer"></div>
      </div>
    </div>
  </div>
</template>
<script>
import END_POINTS from "../../../components/constants/EndPoints";
import DateFomatter from "../../../components/constants/DateFomatter";
import fullCalendar from "vue-fullcalendar";
export default {
  components: {
    "full-calendar": require("vue-fullcalendar")
  },
  data() {
    return {
      event: {},
      subTitle: "",
      roles: END_POINTS.ROLES,
      EventsDateCreated: "",
      calenderEvents: [],
      startDate: "",
      endDate: ""
    };
  },
  computed: {
    title() {
      return "Details: " + this.event.eventTitle;
    }
  },
  created() {
    if (this.$route.params.id) {
      this.getEventDetails(this.$route.params.id);
    }
  },
  methods: {
    getEventDetails(id) {
      var eventItems = "";
      this.$http
        .get(END_POINTS.GETEVENTSDETAILS + "/?id=" + id)
        .then(response => {
          if (response.data.success) {
            this.event = response.data.data;
            this.EventsDateCreated = DateFomatter.ReturnDate(
              this.event.dateCreated
            );
            this.startDate = DateFomatter.ReturnDate(this.event.eventStartDate);
            this.endDate = DateFomatter.ReturnDate(this.event.eventEndDate);
            eventItems = {
              title: this.event.eventTitle,
              start: this.event.eventStartDate,
              end: this.event.eventEndDate
            };

            this.calenderEvents.push(eventItems);
          } else {
            this.$toastr("error", response.data.message);
            if (response.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(e => {
          this.$toastr("error", e.message);
        });
    }
  }
};
</script>
<style scopped>
.eventTitle {
  margin-top: 1em;
  margin-bottom: 1em;
  padding: 2px;
}
</style>
