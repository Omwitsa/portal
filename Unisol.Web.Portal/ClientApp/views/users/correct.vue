<template>
    <div class="page-body">
        <div class="card">
        <div class="card-header">
            <h5>{{title}}</h5>
            <span v-if="subTitle">{{subTitle}}</span>
        </div>
        <div class="card-block">
            <div class="row">
                <div class="col-md-12">
                    <fg-input
                        type="text"
                        label="Username"
                        placeholder = "Registration Number  / Employer Number"
                        addon="user"
                        v-model="user.regNumber"/>

                   <div class="form-group">
                        <label for="">Select Role</label><br>
                        <button @click="getuserGroups(option.value)" v-for="(option, oIndex) in roles" :key="oIndex" class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1 ">
                            <i :class="user.role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                            {{option.name}}
                        </button>
                    </div> 
                    <br>

                    <fg-input 
                    v-if="emailRequired"
                    type="email"
                    placeholder="Please provide a valid email address"
                    label="Email Address"
                    v-model="user.email"/>

                    <div class="form-group"> 
                        <label for="">{{assignText}}</label>
                        <select v-model="user.userGroup" class="form-control">
                            <option v-for="(group, gIndex) in userGroups" :key="gIndex" :value="group.id"> {{group.name}}</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-footer">
            <div class="pull-right">
              <submit-button :title="buttonText" 
              styling="btn btn-primary btn-round waves-effect waves-light btn-sm"
              :loading="submitting" v-on:submit="save"></submit-button>
              <button class="btn btn-inverse btn-round waves-effect waves-light" >Cancel</button>
            </div>
        </div>
    </div>

    </div>
</template>

<script>
export default {
  data() {
    return {
      user: {},
      userGroups: [],
      roles: [
        {
          name: "Admin",
          value: 1
        },
        {
          name: "Staff",
          value: 2
        },
        {
          name: "Student",
          value: 3
        },
        {
          name: "Applicant",
          value: 4
        }
      ],
      edit: false,
      submitting: false,
      emailRequired: false,
      subTitle: "",
      assignText: "Select User Group"
    }
  },
  created() {
    if (this.$route.params.id) {
      this.edit = true
      // get user by id
    }
  },
  methods: {
    getuserGroups(role) {
      this.user.role = role
      if (role == 1) {
        this.emailRequired = true
      } else {
        this.emailRequired = false
      }
      this.assignText = "Fetching User Groups ..."
      this.$http
        .get("usergroups/pages/?role=" + role + "")
        .then(result => {
          this.userGroups = []
          var info = result.data.data
          info.forEach(element => {
            var item = {
              id: element.id,
              name: element.groupName
            }
            this.userGroups.push(item)
          })
          this.assignText = "Select User Group"
        })
        .catch(error => {
          this.assignText = "Error fetching User Groups"
        })
    },
    save() {
        if (!this.user.userGroup) {
            this.$toastr("error", "Please setting user group");
            return;
        }

        if (this.user.role==1) {
            if (!this.user.email|| this.user.email=='') {
                this.$toastr("error", "Please enter the administrator email address");
                return;
            }
        }
        this.submitting = true;
      this.$http
        .post("users/register", this.user)
        .then(response => {
          if (response.data.success) {
            this.$toastr("success", "Success")
            this.$router.replace({ name: "users" })
          } else {
            this.$toastr("error", response.data.message)
          }
            this.submitting = false
        })
          .catch(e => {
              this.submitting = true;
          this.$toastr("error", "An error occured,please contact administrator")
        })
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return "Edit user: "
      }
      return "Add User"
    },
    buttonText() {
      if (this.edit) {
        return "Save Changes"
      }
      return "Save"
    }
  }
}
</script>

<style>
</style>
