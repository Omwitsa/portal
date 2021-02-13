<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span v-if="subTitle">{{subTitle}}</span>
        <button
          data-toggle="modal"
          data-target="#oldUsers"
          class="btn btn-primary btn-round waves-effect waves-light  ml-1 pull-right"
        >Import old membership</button>
      </div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="modal fade" id="oldUsers" role="dialog">
              <div class="modal-dialog modal-lg">
                <div class="modal-content">
                  <div class="modal-header text-left">
                    <div class="h5">Import old membership</div>
                  </div>

                  <div class="modal-body">
                    <form>
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
                      <br />
                    </form>
                  </div>

                  <div class="modal-footer">
                    <div class="pull-right">
                      <submit-button
                        title="submit"
                        styling="btn btn-primary btn-round waves-effect waves-light "
                        :loading="submittingUser"
                        v-on:submit="submitUsers()"
                      ></submit-button>
                      <button
                        class="btn btn-inverse btn-round waves-effect waves-light "
                        data-dismiss="modal"
                      >Cancel</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <fg-input
              type="text"
              label="Username"
              placeholder="Registration Number  / Employee Number"
              addon="user"
              v-model="user.regNumber"
            />

            <div class="form-group">
              <label for>Select Role</label>
              <br />
              <button
                @click="getuserGroups(option.value)"
                v-for="(option, oIndex) in roles"
                :key="oIndex"
                class="btn btn-primary btn-round waves-effect waves-light  ml-1"
              >
                <i :class="user.role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                {{option.name}}
              </button>
            </div>
            <br />

            <fg-input
              v-if="emailRequired"
              type="email"
              placeholder="Please provide a valid email address"
              label="Email Address"
              v-model="user.email"
            />

            <div class="form-group">
              <label for>{{assignText}}</label>
              <span class="text-danger" v-if="userGroups.length==0">No user group found</span>
              <select v-model="user.userGroup" class="form-control">
                <option
                  v-for="(group, gIndex) in userGroups"
                  :key="gIndex"
                  :value="group.id"
                >{{group.name}}</option>
              </select>
            </div>
          </div>
        </div>
      </div>
      <div class="card-footer">
        <div class="pull-right">
          <submit-button
            :class="[ { 'disabled' : submitting }]"
            :loading="submitting"
            :title="buttonText"
            v-on:submit="save"
            :disabled="userGroups.length==0"
            styling="btn btn-primary btn-round waves-effect waves-light "
          />

          <submit-button
            title="Cancel"
            v-on:submit="cancel"
            styling="btn btn-inverse btn-round waves-effect waves-light "
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
export default {
  data() {
    return {
      user: {},
      portalUser: this.$baseRead("user"),
      userGroups: [],
      roles: [],
      edit: false,
      submitting: false,
      submittingUser: false,
      emailRequired: false,
      subTitle: "",
      isDisabled: false,
      assignText: "Select User Group",
      usergroup: {
        role: ""
      }
    };
  },
  
  created() {
    this.roles = END_POINTS.ROLES(this.portalUser);
    if (this.$route.params.id) {
      this.edit = true;
      // get user by id
    }
  },
  methods: {
    setRole(role) {
      this.usergroup.role = role;
    },
    submitUsers() {
      this.submittingUser = true;
      if (!this.usergroup.role) {
        this.$toastr("error", "Kindly select the role");
      } else {
        this.$http
          .get("users/createBunchUsers?bunchRole=" + this.usergroup.role)
          .then(result => {
            this.submittingUser = false;
            $("#oldUsers").modal("hide");
            if (result.data.success) {
              this.$toastr("success", response.data.message);
              this.isDisabled = true;
              // this.$router.replace({name: "users"})
            } else {
              this.$toastr("error", response.data.message);
            }
          })
          .catch(error => {
            this.submittingUser = false;
            this.$toastr("error", response.data.message);
          });
      }
    },
    getuserGroups(role) {
      this.user.role = role;
      if (role == 1) {
        this.emailRequired = true;
      } else {
        this.emailRequired = false;
      }
      this.assignText = "Fetching User Groups ...";
      this.$http
        .get("usergroups/pages/?role=" + role + "")
        .then(result => {
          this.userGroups = [];
          var info = result.data.data.filter(function(groups) {
            return groups.groupName != "AbnAdmin";
          });
          info.forEach(element => {
            var item = {
              id: element.id,
              name: element.groupName
            };
            this.userGroups.push(item);
          });
          this.assignText = "Select User Group";
        })
        .catch(error => {
          this.assignText = "Error fetching User Groups";
        });
    },
    cancel() {
      this.user.regNumber = "";
    },
    save() {
      this.user.portalUrl =  window.location.origin
      localStorage.setItem("regNum", JSON.stringify(this.user.regNumber));
      if (!this.user.userGroup) {
        this.$toastr("error", "Please select user group");
        return;
      }

      if (this.user.role == 1) {
        if (!this.user.email || this.user.email == "") {
          this.$toastr("error", "Please enter the administrator email address");
          return;
        }
      }
      this.submitting = true;
      this.$http
        .post("users/register/?isAdmin=true", this.user)
        .then(response => {
          if (response.data.success) {
            this.$toastr("success", response.data.message);
            this.$router.replace({ name: "admin-set-password" });
          } else {
            this.$toastr("error", response.data.message);
          }
          this.submitting = false;
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
  computed: {
    title() {
      if (this.edit) {
        return "Edit user: ";
      }
      return "Add User";
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
</style>
