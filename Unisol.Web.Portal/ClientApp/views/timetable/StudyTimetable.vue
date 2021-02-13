<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header d-print-none">
                <div class="offset-md-10">
                    <button class="btn btn-primary btn-sm" @click="print()">
                        <i class="fa fa-print" style="color:white;"></i> print
                    </button>
                </div>
            </div>

            <div class="card-block" id="studyTimetable">
                <loading-spinner :loading="loading"></loading-spinner>
                <div class="row" v-if="calendarOptions.events.length">
                    <div class="col-md-12"> 
                        <FullCalendar :options="calendarOptions" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import FullCalendar from "@fullcalendar/vue";
import dayGridPlugin from "@fullcalendar/daygrid";
import interactionPlugin from "@fullcalendar/interaction";
import timeGridPlugin from "@fullcalendar/timegrid";
import listPlugin from "@fullcalendar/list";
// import adaptivePlugin from '@fullcalendar/adaptive'
// import scrollGridPlugin from '@fullcalendar/scrollgrid'

export default {
  components: {
    FullCalendar
  },
  data() {
    return {
      user: this.$baseRead("user"),
      weeklyTimetable: [],
      dailyTimetable: null,
      loading: true,
      selectedDay: "",
      calendarOptions: {
        plugins: [
          dayGridPlugin,
          timeGridPlugin,
          listPlugin,
          // adaptivePlugin,
          // scrollGridPlugin,
          interactionPlugin // needed for dateClick
        ],
        headerToolbar: {
          left: "title",
          center: "",
          right: "timeGridWeek,listWeek"
        },
        allDaySlot: false,
        slotMinTime: "06:00:00",
        slotMaxTime: "18:00:00",
        initialView: "timeGridWeek",
        eventTimeFormat:{
            hour: 'numeric',
            minute: '2-digit',
            omitZeroMinute: true,
            meridiem: 'short',
            // hour12: false
        },
        
        // displayEventTime: false,
        weekends: true,
        // hiddenDays: [ 2, 4 ],
        // dayMaxEvents: false,
        // dateClick: this.handleDateClick,

        events: []
      }
    };
  },
  methods: {
    print() {
      window.print();
    },
    getDayDate(dayName, refDate = new Date()) {
      const dayOfWeek = [
        "sun",
        "mon",
        "tue",
        "wed",
        "thu",
        "fri",
        "sat"
      ].indexOf(dayName.slice(0, 3).toLowerCase());
      if (dayOfWeek < 0) return;
      refDate.setHours(0, 0, 0, 0);
      refDate.setDate(refDate.getDate() + dayOfWeek - refDate.getDay());

      return refDate;
    },
    onChange(day) {
      var units = this.weeklyTimetable.filter(function(lessons) {
        return lessons.day == day;
      });

      units.forEach(element => {
        this.dailyTimetable = element;
      });
    },
    getTimetable() {
      this.loading = true;
      var url = "timetable/getStudyTimetable";
      url = this.user.role == 2 ? "timetable/getLecturerStudyTimetable" : url;
      this.user.regNumber = this.user.username;
      this.$http
        .post(url, this.user)
        .then(response => {
          this.submitting = false;
          this.loading = false;
          if (response.data.success) {
            this.weeklyTimetable = response.data.data;
            var minTime = 24;
            var maxTime = 0;
            response.data.data.forEach(element => {
              element.lessons.forEach(lesson => {
                lesson.startTime = lesson.startTime
                  ? lesson.startTime
                  : "0:0:0";
                var startTime = lesson.startTime.split(":");
                if (parseInt(startTime[0]) < minTime) {
                  minTime = parseInt(startTime[0]);
                  this.calendarOptions.slotMinTime = startTime.join(":");
                }

                var startDateTime = this.getDayDate(element.day);
                startDateTime.setHours(
                  startTime[0],
                  startTime[1],
                  startTime[2]
                );

                lesson.endTime = lesson.endTime ? lesson.endTime : "0:0:0";
                var endTime = lesson.endTime.split(":");
                if (parseInt(endTime[0]) > maxTime) {
                  maxTime = parseInt(endTime[0]);
                  this.calendarOptions.slotMaxTime = `${parseInt(endTime[0]) + 2}:${endTime[1]}:${endTime[2]}`
                }
                var endDateTime = this.getDayDate(element.day);
                endDateTime.setHours(endTime[0], endTime[1], endTime[2]);
                var room = lesson.room ? `/ ${lesson.room}` : "";
                var campus = this.user.role == 2 ? `/ ${lesson.campus}` : "";
                var studyMode = this.user.role == 2 ? `/ ${lesson.studyMode}` : "";
                var lecturer =
                this.user.role == 3 ? `/ ${lesson.lecturerName}` : "";
                this.calendarOptions.events.push({
                  title: `${lesson.uuCode} ${room} ${campus} ${lecturer} ${studyMode} / ${lesson.unitName } `,
                  start: startDateTime,
                  end: endDateTime
                  // backgroundColor: 'green',
                  // borderColor: 'green',
                });
              });
            });
          } else {
            // this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.submitting = true;
          this.$toastr(
            "error",
            "An error occured,please contact administrator"
          );
        });
    }
  },
  created() {
    this.getTimetable();
  }
};
</script>

<style>
.fc-event-time,
.fc-event-title {
  padding: 0 1px;
  white-space: normal;
}
</style>
