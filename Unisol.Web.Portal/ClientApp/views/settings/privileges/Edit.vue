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
                        label="Name"
                        placeholder = "Name"
                        v-model="privilege.privilegeName"
                    />

                    <fg-input
                        type="text"
                        label="Action URL"
                        placeholder = "Action"
                        v-model="privilege.action"
                    />
                </div>

                <div class="form-group">
                    <label for="">Select Role</label><br>
                    <button @click="getRole(option.value)" v-for="(option, oIndex) in roles" :key="oIndex" class="btn btn-primary btn-round waves-effect waves-light btn-sm ml-1 ">
                        <i :class="privilege.role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                        {{option.name}}
                    </button>
                </div> 
                <br>
            </div>
        </div>
       
        <div class="card-footer">
            <div class="pull-right">
             <submit-button :title="buttonText"
             styling="btn btn-primary btn-round waves-effect waves-light "
              :loading="submitting" v-on:submit="save"></submit-button>
             <router-link  class="btn btn-inverse btn-round waves-effect waves-light " to="/settings/privileges">Cancel</router-link>
            </div>
        </div>
    </div>

    </div>
</template>

<script>
export default {
  data() {
    return {
      privilege: {},
      edit: false,
      user: this.$baseRead('user'),
      submitting: false,
      subTitle: "",
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
        }
      ]
    }
  },
  created() {
    if(this.user.genesisUser){
      this.roles = [
        {
          name: "Admin",
          value: 1
        },
        {
          name: "Staff",
          value: 2
        }
      ]
    }
    this.roles = END_POINTS.ROLES(this.user)
    if (this.$route.params.id) {
      this.edit = true
      this.fetch(this.$route.params.id)
    }
  },
  methods: {
    getRole(role) {
      this.privilege.role = role
    },
    save() {
      var url = "privileges/add/"
      if(this.edit) url = "privileges/editUserGroupPrivilege/"
      this.submitting = true
      this.$http
        .post(url, this.privilege)
          .then(response => {
              this.submitting = false
          if (response.data.success) {
        
              this.$toastr("success", response.data.message)
            this.$router.replace({ name: "privileges" })
          } else {
            this.$toastr("error", response.data.message)
          }
        })
          .catch(e => {
              this.submitting = false;
          this.$toastr("error", e.message)
        })
    },
    fetch(id) {
      this.privilege = {}
      this.$http
        .get("privileges/get/" + id)
        .then(result => {
          this.privilege = result.data.data
        })
        .catch(error => {
          this.$toastr("error", error.message)
        })
    }
  },
  computed: {
    title() {
      if (this.edit) {
        return "Edit privilege: " + this.privilege.privilegeName
      }
      return "Add privilege"
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
