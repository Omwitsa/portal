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
                                <form class="wizard-form wizard clearfix" id="design-wizard" action="#" role="application">
                                    <div class="steps clearfix">
                                        <ul role="tablist">
                                            <li role="tab" :class="step == 1 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
                                                <a>
                                                    <span v-if="step==1" class="current-info audible">current step: </span>
                                                    <span class="number">1.</span> 
                                                </a>
                                            </li>
                                            
                                            <li role="tab" :class="step == 2 ? 'current last' : 'done last'" aria-disabled="true">
                                                <a>
                                                    <span v-if="step==2" class="current-info audible">current step: </span>
                                                    <span class="number">2.</span> 
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    
                                    <div class="content clearfix">
                                        <h3 id="design-wizard-h-0" tabindex="-1" class="title"></h3>
                                        <fieldset v-if="step==1" id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false" >
                                            <fg-input
                                                type="text"
                                                label="Name"
                                                placeholder = "Name"
                                                v-model="usergroup.groupName"
                                            />

                                            <div class="form-group">
                                                <label for="">Select Role </label><br>
                                                <a @click="setRole(option.value)" v-for="(option, oIndex) in roles" :key="oIndex" class="btn btn-primary btn-round waves-effect waves-light  ml-1" style="color: #fff">
                                                    <i :class="usergroup.role == option.value ? 'fa fa-check-circle' : 'fa fa-circle-o'"></i>
                                                    {{option.name}}
                                                </a>
                                            </div><br>

                                            <div class="checkbox-color checkbox-primary">
                                                <input type="checkbox" id="checkbox18" v-model="usergroup.isDefault"  >
                                                <label for="checkbox18">
                                                    Default Group 
                                                </label>
                                            </div>
                                        </fieldset>

                                        <h3 id="design-wizard-h-1" tabindex="-1" class="title"></h3>
                                        <fieldset v-if="step==2" id="design-wizard-p-1" role="tabpanel" aria-labelledby="design-wizard-h-1" class="body current" aria-hidden="false" >
                                            <div class="row">
                                                        <div class="col-md-12">

                                                            <div v-for="(privilege, index) in privileges" :key="index" class="checkbox-color checkbox-primary" >
                                                                <input type="checkbox" :id="index" v-model="privilege.checked"  >
                                                                <label :for="index">
                                                                    {{privilege.privilegeName}}
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </fieldset>
 
                                    </div>
                                
                                <div class="actions clearfix">
                                    <ul role="menu" aria-label="Pagination">
                                        <li class="btn btn-primary btn-round waves-effect waves-light " @click="previous()">Previous</li>
                                        <li v-if="step<2" class="btn btn-primary btn-round waves-effect waves-light " @click="next()">Next</li> 

                                        <li v-if="step==2">
                                            <a class="btn btn-primary btn-round waves-effect waves-light " @click="save()">Finish</a>
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
export default {
  data() {
    return {
      usergroup: {},
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
      subTitle: "",
      assignText: "Select User Group",
      step:1,
      privileges: []
    };
  },
  created() {
    if (this.$route.params.id) {
      this.edit = true;
      this.fetch(this.$route.params.id);
    }
  },
  methods: {
    setRole(role) {
      this.usergroup.role = role;
    },
    fetch(id) {
      this.usergroup = {};
      this.$http
        .get("usergroups/get/" + id)
        .then(result => {
          this.usergroup = result.data.data;
        })
        .catch(error => {
        });
    },
    save() {
        var prevs = []
        this.privileges.forEach(element => {
            if(element.checked)
                prevs.push(element.id)
          })
          this.usergroup.privileges = JSON.stringify(prevs)
        this.$http
            .post("usergroups/add", this.usergroup)
            .then(response => {
            if (response.data.success) {
                this.$router.push({ name: "user-groups" });
            }
            })
            .catch(e => {
            
            })
    },
    next: function(){
        this.$http
        .get('privileges/pages')
        .then(response => {
            response.data.data.forEach(element => {
                element.checked = false
            })

            if(this.edit){
                var allowedPrivilegesArray= (this.usergroup.allowedPrivileges) ? this.usergroup.allowedPrivileges.substr(1).slice(0, -1).split(',') : this.usergroup.allowedPrivileges;
                response.data.data.forEach(element => {
                    var checkedValues = this.contains(allowedPrivilegesArray, element.id)
                        if(checkedValues) element.checked = true;
                });
            }

            this.privileges = response.data.data
            this.step += 1
        })
        .catch(error => {
            this.$toastr("error", error.message)
        })
    },
    previous: function(){
        if(this.step >= 0){
            this.step -= 1
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
            if(this.step == 1){
                return "Edit : " + this.usergroup.groupName;
            }
            if(this.step == 2){
                return "Edit : " + this.usergroup.groupName + " Privileges";
            }
        }
        if(!this.edit){
             if(this.step == 1){
                return "Add User Group";
            }

            if(this.step == 2){
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
.roleBtn{color:#fff}
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
</style>
