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
            
            <div class="card-block">
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
import FullCalendar from '@fullcalendar/vue'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction'
import timeGridPlugin from '@fullcalendar/timegrid'
import listPlugin from '@fullcalendar/list'

export default {
    components: {
        FullCalendar 
    },
    data(){
        return{
            user: this.$baseRead("user"),
            loading: true,
            calendarOptions: {
                plugins: [ 
                    dayGridPlugin, 
                    timeGridPlugin,
                    listPlugin,
                    interactionPlugin, // needed for dateClick
                ],
                headerToolbar: {
                    left: 'title',
                    center: '',
                    right: 'timeGridWeek,listWeek dayGridMonth,listMonth prev,next'
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
        }
    },
    methods:{
        print() {
            window.print();
        },
        getTimetable(){
            this.loading = true
            var url = "timetable/getExamTimetable"
            url = this.user.role == 2 ? "timetable/getLecturerExamTimetable" : url
            this.user.regNumber = this.user.username
            this.$http.post(url, this.user)
            .then(response => {
                this.loading = false
                this.submitting = false;
                if (response.data.success) {
                    this.examTimetable = response.data.data
                    var minTime = 24;
                    var maxTime = 0;
                    response.data.data.unitExamInfo.forEach(element => {
                        element.examUnits.forEach(lesson => {
                            lesson.startTime = lesson.startTime ? lesson.startTime : "0:0:0"
                            var startTime = lesson.startTime.split(":")
                            if(parseInt(startTime[0]) < minTime){
                                minTime = parseInt(startTime[0])
                                this.calendarOptions.slotMinTime = startTime.join(":")
                            }
                            var startDateTime = new Date(lesson.date)
                            startDateTime.setHours(startTime[0], startTime[1], startTime[2])

                            lesson.endTime = lesson.endTime ? lesson.endTime : "0:0:0"
                            var endTime = lesson.endTime.split(":")
                            if(parseInt(endTime[0]) > maxTime){
                                maxTime = parseInt(endTime[0]);
                                this.calendarOptions.slotMaxTime = `${parseInt(endTime[0]) + 2}:${endTime[1]}:${endTime[2]}`
                            }
                            var endDateTime = new Date(lesson.date)
                            endDateTime.setHours(endTime[0], endTime[1], endTime[2])

                            var room = lesson.room ? `/ ${lesson.room}` : ""
                            var campus = this.user.role == 2 ? `/ ${lesson.campus}` : ""
                            var lecturer = this.user.role == 3 ? `/ ${lesson.lecturerName}` : ""
                            this.calendarOptions.events.push({
                                title: `${lesson.unitCode} ${room} ${campus} ${lecturer} / ${lesson.unitName}`,
                                start: startDateTime,
                                end: endDateTime,
                                // backgroundColor: 'green',
                                // borderColor: 'green',
                            })
                        });
                    });
                } else {

                }
            })
            .catch(e => {
                this.submitting = true;
                this.$toastr("error", "An error occured,please contact administrator");
            });
        }
    },
    created(){
        this.getTimetable()
    }
}
</script>

<style>
.fc-event-time, .fc-event-title {
    padding: 0 1px;
    white-space: normal;
    }
</style>
