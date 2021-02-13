<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{ title }}</h5>
        <span v-if="subTitle">{{ subTitle }}</span>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-10">
            <fg-input
              type="text"
              class
              label="News Title"
              placeholder="News Title"
              addon="newsTitle"
              v-model="news.newsTitle"
            />
            <div class="form-group">
              <label for>Select Category</label>
              <select v-model="news.portalNewsTypeId" class="form-control">
                <option value="0" selected="selected">-- select --</option>
                <option
                  v-for="(type, tIndex) in newsTypes"
                  :key="tIndex"
                  :value="type.id"
                  >{{ type.name }}</option
                >
              </select>
            </div>

            <div class="form-group">
              <div class>
                <label>Expiry Date</label>
                <date-picker
                  v-model="news.expiryDate"
                  :value="state.date"
                ></date-picker>
              </div>
            </div>
            <div class="form-group">
              <label for>Select Target Group(s)</label>
              <br />
              <span class="target-group" v-for="(group, gIndex) in userGroups" :key="gIndex">
                <input type="checkbox" id="checkbox" :value="group.id" v-model="targetGroups"/>
                <label for="checkbox">
                  {{ group.name === 'AbnAdmin' ? 'Admin' : group.name }}
                </label>
              </span>
            </div>
            <div class="form-group">
              <label for>Content</label>
              <vue-editor v-model="news.newsBody"></vue-editor>
            </div>
            <div v-if="user.role == 1">
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <label class="switch">
                      <input
                        type="checkbox"
                        id="checkbox18"
                        v-model="news.newsStatus"
                      />
                      <span class="slider round"></span>
                    </label>
                  </div>
                </div>
                <div class="col-md-8">
                  <label for="checkbox5">Publish</label>
                </div>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <div class>
                    <label class="switch">
                      <input
                        type="checkbox"
                        id="checkbox16"
                        v-model="news.sendEmailFlag"
                      />
                      <span class="slider round"></span>
                    </label>
                  </div>
                </div>
                <div class="col-md-8">
                  <label for="checkbox5">Email target audience</label>
                </div>
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
          <button @click="cancel" class="btn btn-inverse btn-round waves-effect waves-light">
            Cancel
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from '../../components/constants/EndPoints';
import { VueEditor } from "vue2-editor";
export default {
  components: {
    VueEditor
  },
  data() {
    return {
      user: this.$baseRead('user'),
      news: {
        sendEmailFlag: false,
        newsStatus: false
      },
      state: {
        date: new Date()
      },
      newsTypes: [],
      role: '',
      roles: [],
      userGroups: [],
      targetGroups: [],
      edit: false,
      submitting: false,
      emailRequired: false,
      subTitle: ''
    };
  },
  created() {
    this.roles = END_POINTS.ROLES(this.user);
    this.getNewsTypes();
    if (this.$route.params.id) {
      this.edit = true;
      this.getNewsDetails(this.$route.params.id);
    }
    this.getuserGroups('');
  },
  methods: {
    getNewsTypes() {
      this.assignText = 'Fetching Categories ...';
      this.$http
        .get(END_POINTS.GETNEWSTYPES)
        .then(result => {
          this.newsTypes = [];
          var info = result.data.data;
          if (result.data.success) {
            info.forEach(element => {
              var item = {
                id: element.id,
                name: element.newsTypeName
              };
              this.newsTypes.push(item);
            });
            this.assignText = 'Select target audience';
          } else {
            this.$toastr('error', result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: '401-forbidden' });
            }
          }
        })
        .catch(error => {
          this.assignText = 'Error fetching User Groups';
        });
    },
    cancel() {
      this.$router.replace({ name: 'news' });
    },
    save() {
      this.news.targetGroups = this.targetGroups.toString();
      this.news.portalUrl = window.location.origin;
      var url = END_POINTS.ADDNEWS + '/?userCode=' + this.user.username;
      if (this.edit) url = 'news/editnews';
      this.submitting = true;
      this.$http
        .post(url, this.news)
        .then(response => {
          this.submitting = false;
          if (response.data.success) {
            this.$toastr('success', 'Success');
            this.$router.replace({ name: 'news' });
          } else {
            this.$toastr('error', response.data.message);
          }
        })
        .catch(e => {
          this.submitting = false;
          this.$toastr('error', e.message);
        });
    },
    getNewsDetails(id) {
      this.$http
        .get(END_POINTS.GETNEWSDETAILS + '/?id=' + id, this.news)
        .then(response => {
          this.news = {};
          if (response.data.success) {
            this.news = response.data.data;
            this.targetGroups = this.news.targetGroups.split(',');
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
      this.$http
        .get('usergroups/pages/?role=' + role + '')
        .then(result => {
          this.userGroups = [];
          var info = result.data.data;
          info.forEach(element => {
            var item = {
              id: element.id,
              name: element.groupName
            };
            this.userGroups.push(item);
          });
          this.assignText = 'Select target audience';
        })
        .catch(error => {
          this.assignText = 'Error fetching User Groups';
        });
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return 'Edit News: ';
      }
      return 'News';
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
