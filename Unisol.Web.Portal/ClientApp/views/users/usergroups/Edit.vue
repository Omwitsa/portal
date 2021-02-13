<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div id="wizardc">
              <section>
                <form
                  class="wizard-form wizard clearfix"
                  id="design-wizard"
                  action="#"
                  role="application"
                >
                  <div class="steps clearfix">
                    <ul role="tablist">
                      <li
                        role="tab"
                        :class="step == 1 ? 'first current' : 'first done'"
                        aria-disabled="false"
                        aria-selected="true"
                      >
                        <a>
                          <span v-if="step==1" class="current-info audible">current step:</span>
                          <span class="number" style="font-size:10px;">User Groups</span>
                        </a>
                      </li>

                      <li
                        role="tab"
                        :class="step == 2 ? 'current last' : 'done last'"
                        aria-disabled="true"
                      >
                        <a>
                          <span v-if="step==2" class="current-info audible">current step:</span>
                          <span class="number" style="font-size:10px;">Rights</span>
                        </a>
                      </li>
                    </ul>
                  </div>

                  <!-- <div class="content clearfix"> -->
                  <div class="clearfix col-md">
                    <h3 id="design-wizard-h-0" tabindex="-1" class="title"></h3>
                    <fieldset
                      v-if="step==1"
                      id="design-wizard-p-0"
                      role="tabpanel"
                      aria-labelledby="design-wizard-h-0"
                      class="body current"
                      aria-hidden="false"
                    >
                      <div class="form-group">
                        <label>
                          Group Name
                          <i class="fa fa-spin fa-circle-o-notch" v-if="httpStatus"></i>
                        </label>
                        <input
                          type="text"
                          class="form-control"
                          @keyup="checkUserGroupExists()"
                          placeholder="Name"
                          v-model="usergroup.groupName"
                        />
                        <span
                          v-if="groupExists"
                          class="text-danger"
                        >Please use a different group name</span>
                      </div>
                      <div class="form-group">
                        <label for>Select Role</label>
                        <br />
                        <a
                          style="color:white"
                          @click="setRole(option.value)"
                          v-for="(option, oIndex) in roles"
                          :key="oIndex"
                          class="btn btn-primary btn-round waves-effect waves-light  ml-1"
                        >
                          <i
                            :class="usergroup.role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"
                          ></i>
                          {{option.name}}
                        </a>
                      </div>
                      <div class="row">
                        <div class="col-md-3">
                          <div class="form-group">
                            <label class="switch">
                              <input type="checkbox" id="checkbox18" v-model="usergroup.isDefault" />
                              <span class="slider round"></span>
                            </label>
                          </div>
                        </div>
                        <div class="col-md-8">
                          <label for="checkbox5">Default Group</label>
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-md-3">
                          <div class>
                            <label class="switch">
                              <input type="checkbox" id="checkbox16" v-model="usergroup.status" />
                              <span class="slider round"></span>
                            </label>
                          </div>
                        </div>
                        <div class="col-md-8">
                          <label for="checkbox5">Set Active</label>
                        </div>
                      </div>
                    </fieldset>

                    <h3 id="design-wizard-h-1" tabindex="-1" class="title"></h3>
                    <fieldset
                      v-if="step==2"
                      id="design-wizard-p-1"
                      role="tabpanel"
                      aria-labelledby="design-wizard-h-1"
                      class="body current"
                      aria-hidden="false"
                    >
                      <div class="col-md-12">
                        <div class="row">

                        <div class="col-md-4">
                          <div>

                          <input
                            class="form-check-input"
                            @change="getPrivileges()"
                            type="radio"
                            name="privileges"
                            id="privilege1"
                            value="Menu Privileges"
                            v-model="privilegeLevel"
                            checked
                          />
                          <label class="form-check-label" for="privilege1">Menu Privileges</label>
                          </div>
                        </div>
                        <div class="col-md-8" v-if="this.edit">
                          <div>

                          <input
                            @change="getPrivileges()"
                            type="radio"
                            name="privileges"
                            id="privilege2"
                            value="Other Privileges"
                            v-model="privilegeLevel"
                          />
                          <label class="form-check-label" for="privilege2">Other Privileges</label>
                          </div>
                        </div>
                        </div>
                        <br />
                        <br />
                        <!-- <div
                          class="col-md-12"
                          v-for="(privilege, index) in privileges"
                          :key="index"
                        >
                          <div :key="index" class="checkbox-color checkbox-primary">
                            <input type="checkbox" :id="index" v-model="privilege.checked" />
                            <label :for="index">{{privilege.privilegeName}}</label>
                          </div>
                        </div>-->
                        <div class="privileges-align">
                          <div v-for="(privilege, index) in privileges" :key="index">
                            <div class="row">
                              <div class="col-md-3">
                                <div class="form-group">
                                  <label class="switch">
                                    <input type="checkbox" :id="index" v-model="privilege.checked" />
                                    <span class="slider round"></span>
                                  </label>
                                </div>
                              </div>
                              <div class="col-md-8">
                                <label :for="index">{{privilege.privilegeName}}</label>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </fieldset>
                  </div>

                  <div class="actions clearfix">
                    <ul role="menu" aria-label="Pagination">
                      <li
                        class="btn btn-inverse btn-round waves-effect waves-light "
                        v-if="step>1"
                        @click="previous()"
                      >Previous</li>
                      <li
                        v-if="step<2"
                        class="btn btn-primary btn-round waves-effect waves-light "
                        @click="next()"
                      >Next</li>

                      <li v-if="step==2">
                        <submit-button
                          :class="[ { 'disabled' : submitting }]"
                          :loading="submitting"
                          :disabled="submitting "
                          title="Finish"
                          v-on:submit="save"
                          styling="btn btn-primary btn-round waves-effect waves-light "
                        />
                      </li>
                    </ul>
                  </div>
                </form>
              </section>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../../components/constants/EndPoints";
export default {
  data() {
    return {
      privilegeLevel: "",
      isSettingPrivileges: false,
      user: this.$baseRead("user"),
      settings: JSON.parse(localStorage.getItem("settings")),
      menuPrivileges: [],
      otherPrivileges: [],
      currentGroupName: [],
      isMenuPrivilege: true,
      level: 1,
      edit: false,
      submitting: false,
      groupExists: false,
      httpStatus: false,
      subTitle: "",
      assignText: "Select User Group",
      step: 1,
      privileges: [],
      usergroup: {
        role: ""
      }
    };
  },
  created() {
    this.roles = END_POINTS.ROLES(this.user);
    if (this.$route.params.id) {
      this.edit = true;
      this.fetch(this.$route.params.id);
    }
  },
  methods: {
    setRole(role) {
      this.usergroup.role = role;
    },
    getPrivileges() {
      this.isSettingPrivileges = true;
      this.level = this.privilegeLevel == "Menu Privileges" ? 1 : 2;
      this.isMenuPrivilege =
        this.privilegeLevel == "Menu Privileges" ? true : false;
      this.next();
    },
    checkUserGroupExists: function() {
      this.groupExists = false;
      this.httpStatus = true;
      this.$http.get("usergroups/checkusergroup" + "/?name=" + this.usergroup.groupName)
        .then(response => {
          this.httpStatus = false;
          if (response.data.success) {
            this.groupExists = true;
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.$toastr("error", e.message);
          this.httpStatus = false;
        });
    },

    fetch(id) {
      this.usergroup = {};
      this.$http
        .get("usergroups/get/" + id)
        .then(result => {
          this.usergroup = result.data.data;
          this.currentGroupName = this.usergroup.groupName;
        })
        .catch(error => {});
    },

    save() {
      var url = "usergroups/add/";
      if (this.edit)
        url = "usergroups/editUserGroup/?groupName=" + this.currentGroupName;
      var availablePrivileges = this.menuPrivileges.concat(
        this.otherPrivileges
      );
      var selectedPrivileges = [];
      availablePrivileges.forEach(element => {
        if (element.checked) selectedPrivileges.push(element.code);
      });

      if (selectedPrivileges.length == 0) {
        this.$toastr("error", "Please select atleast one right/privilege");
        return;
      }
      if (!this.usergroup.role) {
        this.step -= 1;
        this.$toastr("error", "Please select a role");
        return;
      }

      this.usergroup.privileges = selectedPrivileges.join();

      this.$http
        .post(url, this.usergroup)
        .then(response => {
          this.submitting = false;
          if (response.data.success) {
            this.$toastr("success", response.data.message);

            this.$router.replace({ name: "user-groups" });
          } else {
            this.step -= 1;
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.submitting = false;
          this.$toastr("error", e.message);
        });
    },

    next: function() {
      this.$http.get("privileges/pages?role=" + this.usergroup.role + "&level=" + this.level)
        .then(response => {
          if(this.settings.isGenesis){
              response.data.data = response.data.data.filter(item => item.action !== "evaluations" && item.action !== "timetable")
          }

          if(this.settings.initials != 'ABNO'){
            response.data.data = response.data.data.filter(item => item.action !== "leaveDocuments")
          }
          
          response.data.data.forEach(element => {
            element.checked = false;
          });

          if (this.edit) {
            var privileges = this.usergroup.allowedPrivileges.split(",");
            response.data.data.forEach(element => {
              var checkedValues = privileges.includes(element.code);
              element.checked = checkedValues;
            });
          }
          if (this.isMenuPrivilege) this.menuPrivileges = response.data.data;
          if (!this.isMenuPrivilege) this.otherPrivileges = response.data.data;

          this.privileges = response.data.data;
          if (!this.isSettingPrivileges) this.step += 1;
          this.isSettingPrivileges = false;
        })
        .catch(e => {
          this.$toastr("error", e.message);
        });
    },
    previous: function() {
      if (this.step >= 0) {
        this.step -= 1;
      }
    },
    contains(arrayData, id) {
      var i = arrayData.length;
      while (i--) {
        if (parseInt(arrayData[i]) === id) {
          return true;
        }
      }
      return false;
    }
  },
  computed: {
    title() {
      if (this.edit) {
        if (this.step == 1) {
          return "Edit : " + this.usergroup.groupName;
        }
        if (this.step == 2) {
          return "Edit : " + this.usergroup.groupName + " Privileges";
        }
      }
      if (!this.edit) {
        if (this.step == 1) {
          return "Add User Group";
        }

        if (this.step == 2) {
          return "Select Group Privileges";
        }
      }
    },
    buttonText() {
      if (this.edit) {
        return "Save Changes";
      }
      return "Save";
    }
  }
};
</script>

<style>
.wizard {
  display: block;
  width: 100%;
  overflow: hidden;
}
.roleBtn {
  color: #fff;
}
/* Accessibility */
.wizard > .steps .current-info,
.tabcontrol > .steps .current-info {
  position: absolute;
  left: -999em;
}

.wizard > .content > .title,
.tabcontrol > .content > .title {
  position: absolute;
  left: -999em;
}

.wizard > .steps .number {
  font-size: 1.429em;
}

.wizard > .steps > ul > li {
  width: 50%;
}

.wizard > .steps > ul > li,
.wizard > .actions > ul > li {
  float: left;
}

.wizard > .steps a,
.wizard > .steps a:hover,
.wizard > .steps a:active {
  display: block;
  width: auto;
  margin: 0 0.5em 0.5em;
  padding: 1em 1em;
  text-decoration: none;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .steps .current a,
.wizard > .steps .current a:hover,
.wizard > .steps .current a:active {
  background: #2184be;
  color: #fff;
  cursor: default;
}

.wizard > .steps .done a,
.wizard > .steps .done a:hover,
.wizard > .steps .done a:active {
  background: #9dc8e2;
  color: #fff;
}

.wizard > .steps .error a,
.wizard > .steps .error a:hover,
.wizard > .steps .error a:active {
  background: #ff3111;
  color: #fff;
}

.wizard > .content {
  background: #fff;
  display: block;
  margin: 0.5em;
  min-height: 20em;
  overflow: hidden;
  position: relative;
  width: auto;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .content > .body {
  float: left;
  position: absolute;
  width: 95%;
  height: 95%;
  padding: 2.5%;
}

.wizard > .actions {
  position: relative;
  display: block;
  text-align: right;
  width: 100%;
}

.wizard > .actions > ul {
  display: inline-block;
  text-align: right;
}

.wizard > .actions > ul > li {
  margin: 0 0.5em;
}
.privileges-align {
  display: flex;
  flex-direction: column;
}
</style>
