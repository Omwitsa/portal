<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>Add Event</h5>
        <span v-if="subTitle">New Event</span>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="form-group">
              <fg-input
                type="text"
                label="Event Title"
                placeholder="Event Title"
                v-model="events.eventTitle"
              />
            </div>
            <div class="form-group">
              <fg-input
                type="text"
                label="Event Venue"
                placeholder="Event Venue"
                v-model="events.eventVenue"
              />
            </div>
            <div class="form-group">
              <label for>Select Category</label>
              <select v-model="events.portalEventsTypeId" class="form-control">
                <option
                  v-for="(type, tIndex) in eventsTypes"
                  :key="tIndex"
                  :value="type.id"
                  >{{ type.eventTypeName }}</option
                >
              </select>
            </div>

            <div class="form-group row">
              <div class="col-md-6">
                <label>Start Date</label>
                <date-picker v-model="events.eventStartDate" :config="options"></date-picker>
              </div>
              <div class="col-md-6">
                <label>End Date</label>
                <date-picker v-model="events.eventEndDate" :config="options"></date-picker>
              </div>
            </div>
            <!-- <div class="form-group">
              <label for>Select Role</label>
              <br />
              <button
                @click="getuserGroups(option.value)"
                v-for="(option, oIndex) in roles"
                :key="oIndex"
                class="btn btn-primary btn-round waves-effect waves-light ml-1"
              >
                <i :class="role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                {{option.name}}
              </button>
            </div>
            <br />
            <div class="form-group" @if="userGroups">
              <label for>{{assignText}}</label>
              <select v-model="events.targetAudience" class="form-control">
                <option
                  v-for="(group, gIndex) in userGroups"
                  :key="gIndex"
                  :value="group.id"
                >{{group.name}}</option>
              </select>
            </div> -->
            <div class="form-group">
              <label for>Select Target Group(s)</label>
              <br />
              <span
                class="target-group"
                v-for="(group, gIndex) in userGroups"
                :key="gIndex"
              >
                <input
                  type="checkbox"
                  :id="gIndex"
                  :value="group.id"
                  v-model="targetGroups"
                  @change="groupOnChange(group)"
                />
                <label :for="gIndex">
                  {{ group.name === 'AbnAdmin' ? 'Admin' : group.name }}
                </label>
              </span>
            </div>
            <div v-if="isSudent">
               <div class="row">
                <div class="col-md-3">
                  <label>Select Campus</label>
                  <v-select :options="studAcademicInfo.universityCampuses" v-model="events.campus"></v-select>
                </div>
                <div class="col-md-3">
                  <label> Select Department</label>
                  <v-select :options="studAcademicInfo.universityDepartments" v-model="events.department"></v-select>
                </div>
                <div class="col-md-3">
                  <label>Select School</label>
                  <v-select :options="studAcademicInfo.schools" v-model="events.school"></v-select>
                </div>
                <div class="col-md-3">
                  <label>Year of study</label>
                  <v-select :options="studAcademicInfo.years" v-model="events.yearOfStudy"></v-select>
                </div>
              </div> <br>
            </div>
            <div class="form-group">
              <label for>Content</label>
               <vue-editor v-model="events.eventDesc"></vue-editor>
            </div>

            <div class="row">
              <div class="col-md-3">
                <div class="form-group">
                  <label class="switch">
                    <input
                      type="checkbox"
                      id="checkbox18"
                      v-model="events.eventsStatus"
                    />
                    <span class="slider round"></span>
                  </label>
                </div>
              </div>
              <div class="col-md-8">
                <label for="checkbox5">Set Available</label>
              </div>
            </div>
            <div class="row">
              <div class="col-md-3">
                <div class>
                  <label class="switch">
                    <input
                      type="checkbox"
                      id="checkbox16"
                      v-model="events.sendEmailFlag"
                    />
                    <span class="slider round"></span>
                  </label>
                </div>
              </div>
              <div class="col-md-8">
                <label for="checkbox5">Send Email to target audience</label>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card-footer">
        <div class="pull-right">
          <submit-button
            :title="buttonText"
            :loading="submitting"
            styling="btn btn-primary btn-round waves-effect waves-light  "
            v-on:submit="save"
          ></submit-button>
          <button
            @click="cancel"
            class="btn btn-inverse btn-round waves-effect waves-light"
          >
            Cancel
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from '../../../components/constants/EndPoints';
import { VueEditor } from "vue2-editor";
export default {
  components: {
    VueEditor
  },
  data() {
    return {
      events: {
        sendEmailFlag: true,
        eventsStatus: true
      },
      eventList: null,
      user: {},
      eventsTypes: [],
      studAcademicInfo: {},
      role: '',
      roles: [],
      isSudent: false,
      userGroups: [],
      targetGroups: [],
      edit: false,
      submitting: false,
      emailRequired: false,
      subTitle: '',
      pagination: {
        total: 0
      },
      options: {
        format: 'DD/MM/YYYY',
        useCurrent: false,
      } 
    };
  },
  created() {
    this.user = this.$baseRead('user');
    this.roles = END_POINTS.ROLES(this.user);
    this.geteventsTypes();
    if (this.$route.params.id) {
      this.edit = true;
      this.getEventsDetails(this.$route.params.id);
    }
    this.getuserGroups('');
  },
  watch: {
    "events.eventStartDate"(){
      this.events.eventEndDate = ""
      if(this.toDate(this.events.eventStartDate) < new Date()){
        this.$toastr("error", "Start date must be greater than today");
        this.events.eventStartDate = ""
      }
    },
    "events.eventEndDate"(){
      if(this.toDate(this.events.eventStartDate) >  this.toDate(this.events.eventEndDate)){
        this.events.eventEndDate = ""
        this.$toastr("error", "Event start date can't be greater than end date");
      }
    },
  },
  methods: {
    groupOnChange(group){
      group.checked = !group.checked
      if(group.role == "Student"){
        this.isSudent = group.checked ? true : false
        this.getStudAcademicInfo()
      }
    },
    geteventsTypes() {
      this.assignText = 'Fetching Categories ...';
      this.$http.get('events/geteventstypes')
        .then(result => {
          var info = result.data;
          if (info.success) {
            this.eventsTypes = result.data.data;
            this.assignText = 'Select target audience';
          } else {
            this.$toastr('error', result.data.message);
            if (info.notAuthenticated) {
              this.$router.replace({ name: '401-forbidden' });
            }
          }
        })
        .catch(error => {
          this.assignText = 'Error fetching User Groups';
        });
    },
    cancel() {
      this.$router.replace({ name: 'events' });
    },
    toDate(date) {
      var from = date.split("/")
      return new Date(from[2], from[1] - 1, from[0])
    },
    save() {
      this.events.eventStartDate = this.toDate(this.events.eventStartDate)
      this.events.eventEndDate = this.toDate(this.events.eventEndDate)
      this.events.targetGroups = this.targetGroups.toString();
      this.events.portalUrl = window.location.origin;
      
      this.events.CreatedBy = this.user.username;
      this.events.DateCreated = new Date();
      this.submitting = true;
      var url = END_POINTS.ADDEVENTS;
      if (this.edit) url = 'events/editEvents';
      this.$http
      .post(url, this.events)
      .then(response => {
        if (response.data.success) {
          this.submitting = true;
          this.$toastr('success', 'Success');
          this.$router.replace({ name: 'events' });
        } else {
          this.$toastr('error', response.data.message);
          if (response.data.notAuthenticated) {
            this.$router.replace({ name: '401-forbidden' });
          }
        }
      })
      .catch(e => {
        this.$toastr('error', e.message);
      });
    },
    getEventsDetails(id) {
      this.$http
        .get(END_POINTS.GETEVENTSDETAILS + '/?id=' + id)
        .then(response => {
          this.events = {};
          if (response.data.success) {
            response.data.data.eventStartDate = new Date(response.data.data.eventStartDate)
            response.data.data.eventEndDate = new Date(response.data.data.eventEndDate)
            this.events = response.data.data;
            this.targetGroups = this.events.targetGroups.split(',');
          } else {
            this.$toastr('error', response.data.message);
          }
        })
        .catch(e => {
          this.$toastr('error', e.message);
        });
    },
    getuserGroups(role) {
      this.userGroups = [];
      this.role = role;
      this.assignText = 'Fetching target audience ...';
      this.$http.get('usergroups/pages/?role=' + role + '')
        .then(result => {
          this.userGroups = [];
          result.data.data.forEach(element => {
              element.name = element.groupName
              element.checked = false
          });
          this.userGroups = result.data.data
          this.assignText = 'Select target audience';
        })
        .catch(error => {
          this.assignText = 'Error fetching User Groups';
        });
    },
    getStudAcademicInfo(){
      this.$http.get('events/getStudAcademicInfo')
      .then(result => {
        this.studAcademicInfo = result.data.data
      })
      .catch(error => {
      });
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return 'Edit Category: ';
      }
      return 'Category';
    },
    buttonText() {
      if (this.edit) {
        return 'Save Changes';
      }
      return 'Save';
    }
  }
};
</script>

<style>
.target-group + .target-group {
  padding-left: 1rem;
}
</style>