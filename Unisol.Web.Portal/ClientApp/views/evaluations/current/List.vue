<template>
    <div class="page-body navbar-page">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Current Evaluations</h5>
                        <span>List Of Created Evaluations.</span>
                    </div>
                     <div class="card-block">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                               <router-link class="btn btn-primary btn-round waves-effect waves-light waves-effect waves-light" to="add-current">
                                    <svg aria-hidden="true" data-prefix="fas" data-icon="plus" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" class="svg-inline--fa fa-plus fa-w-14"><path fill="currentColor" d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z" class=""></path></svg>
                                    Add
                                </router-link>
                            </div>

                            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 offset-md-2">
                                <div class="input-group">
                                    <input type="text" v-model="searchText" @keyup="searchByText" placeholder="Search here" class="form-control"> 
                                    <span class="input-group-append">
                                        <label class="input-group-text">Search</label>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="list-group">
                                    <li class="list-group-item" v-for="(cEval,index) in currentEvaluations" :key="index">

                                        <div class="h6">
                                            <div class="col-md-10 pull-left row">
                                                <b>
                                                    {{index+1}}. {{cEval.currentEvaluationName}} <{{returnLevelType(cEval.evaluationTarget)}}>
                                                </b>
                                                <br />
                                                <div class="text-default col-md-12">Extra Description</div>
                                            </div>

                                            <div class="dropdown-secondary dropdown col-md-12 text-right">
                                                <a style="color:white" class="btn btn-primary btn-mini dropdown-toggle waves-effect waves-light" type="button" id="dropdown7" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Actions</a>
                                                <div class="dropdown-menu" aria-labelledby="dropdown7" data-dropdown-in="fadeIn" data-dropdown-out="fadeOut">
                                                    <a class="dropdown-item waves-light waves-effect" href="#" @click="deleteEvaluation(cEval,index)">
                                                        <span class="point-marker bg-danger"></span>Delete
                                                    </a>
                                                    <a class="dropdown-item waves-light waves-effect" href="#"
                                                    data-toggle="modal" data-target="#myModal"
                                                    @click="clickedCurrentEval(cEval)">
                                                        <span class="point-marker bg-danger"></span>Create Evaluation Period
                                                    </a>

                                                    <router-link class="dropdown-item waves-light waves-effect" :to="{ name: 'add-current', params: { id: cEval.id }}">
                                                        <span class="point-marker bg-warning"></span> Edit
                                                    </router-link>
                                                    <router-link class="dropdown-item waves-light waves-effect"
                                                                :to="{ name: 'current-responses', params: { id: cEval.id }}">
                                                        <span class="point-marker bg-warning"></span> Responses
                                                    </router-link>
                                                </div>
                                                <!-- end of dropdown menu -->
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <ul class="list-group col-md-12">
                                                <li class="list-group" v-for="(cEvalActive,index) in cEval.evaluationsCurrentActive" :key="index">
                                                    <div style="border-bottom:1px lightgrey solid;">
                                                      
                                                        <span style="padding-bottom:6px;font-weight:600;color:grey;">
                                                            {{index+1}}. {{cEvalActive.startDate}} - {{cEvalActive.endDate}}
                                                        </span>
                                                        <span class="badge badge-danger " v-if="!cEvalActive.status">
                                                            inactive
                                                        </span>
                                                        <span class="badge badge-primary " v-if="cEvalActive.status">
                                                            active
                                                        </span>
                                                        <div class="pull-right">{{returnLevelType(cEval.evaluationTarget)}}'s</div>
                                                    </div>
                                                    <ul class="col-md-12" v-for="(groups,index) in cEvalActive.evaluationTargetGroups" :key="index">
                                                        <li>{{index+1}}. {{groups.names}}</li>
                                                    </ul>
                                                    <br />
                                                </li>
                                                
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="card-block" v-if="!tableDataPresent && !loading">
                        <div class="col-md-12 alert-warning">
                            <div> &nbsp;
                                <h5 class="text-center"> <i class="fa fa-exclamation-circle fa-5x"></i><br>{{"Evaluation is currently unavailable"}} </h5> 
                                &nbsp;
                            </div>
                        </div>
                    </div>

                    <loading-spinner :loading="loading"></loading-spinner>
                    <div class="card-footer" v-if="tableDataPresent && !loading">
                        <div class="pull-left">
                            <select v-model="itemsPerPage" v-on:change="changeItems" class="form-control">
                                <option selected :value="5">5</option>
                                <option :value="10">10</option>
                                <option :value="50">50</option>
                                <option :value="100">100</option>
                            </select>
                            <label>
                                Page Size:{{itemsPerPage}}
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header text-left bg-primary">
                       
                        <div class="h5">Create New Active Evaluation</div>
                       
                        <span class="">{{clickCEval.currentEvaluationName}}</span>
                    </div>
                    <div class="modal-body">
                        <div class="form-group row">
                            <div class="col-md-12">
                                <label>Start Date</label>
                                <date-picker v-model="activeEvaluation.startDate"></date-picker>
                            </div>

                        </div>
                        <div class="form-group row">
                            <div class="col-md-12">
                                <label>End Date</label>
                                <date-picker v-model="activeEvaluation.endDate"></date-picker>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="checkbox-color checkbox-primary">
                                <input type="checkbox" id="checkbox18" checked v-model="activeEvaluation.status">
                                <label for="checkbox18">
                                    <b v-show="!activeEvaluation.status">Evaluation is Inactive</b>
                                    <b v-show="activeEvaluation.status">Evaluation is Active</b>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="pull-right">
                            <submit-button :title="buttonText" 
                            styling="btn btn-primary btn-round waves-effect waves-light btn-sm"
                            :loading="submittingActive" v-on:submit="saveActiveEvaluation"></submit-button>
                            <button class="btn btn-inverse btn-round waves-effect waves-light btn-sm">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import END_POINTS from '../../../components/constants/EndPoints';
import DateFomatter from "../../../components/constants/DateFomatter"
export default {
  data() {
    return {
      usergroups: null,
        loading: true,
        submittingActive: false,
        tableDataPresent:"",
        subTitle: 'List of Evaluations.',
        pageSize: 15,
        itemsPerPage: 10,
        activeEvaluation: {},
        totalPages: 0,
        searchText: "",
        clickCEval: {},
        currentEvaluations:[],
      currentPage: 1,    
      pagination: {
        total: 0,
      }
    }
  },

methods: {
    searchByText(){
        this.loadData(10, 1)
    },
    saveActiveEvaluation: function () {
        this.submittingActive = true;
        var activeEvaluation = {
            startDate: this.activeEvaluation.startDate,
            endDate: this.activeEvaluation.endDate,
            EvaluationsCurrentId: this.clickCEval.id,
            EvaluationsId: this.clickCEval.evaluationId,
            status: this.activeEvaluation.status,
            EvaluationTarget: this.clickCEval.evaluationTarget

        }

        this.$http
            .post(END_POINTS.SAVEACTIVEEVALUATIONS, activeEvaluation)
            .then(response => {
                this.submittingActive = false
                if (response.data.success) {

                    this.$toastr("success", response.data.message)
                    
                    $("#myModal").modal("hide");
                    this.activeEvaluation = {};

                } else {
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.submittingActive = false;
                this.$toastr("error", "A server error occured,please try again")
            })

    },

    deleteEvaluation: function (cEval,index) {
        swal({
            title: "Are you sure you want to delete?",
            icon: "warning",
            buttons: true,
            dangerMode: false
        }).then(action => {
            if(action){
                this.currentEvaluations.splice(index, 1)
                this.loading = true;
                this.$http.get(
                    END_POINTS.DELETECURRENTEVALUATION + "/?id=" + cEval.id 
                ).then(result => {
                    this.loading = false;
                    var status = 'error';
                
                    if (result.data.success) {
                    
                        status = 'success'
                    }

                    this.$toastr(status, result.data.message)
                })
                .catch(error => {
                    this.loading = false
                    this.$toastr("error", result.data.message)
                })  
            }
        })
    },

      clickedCurrentEval: function (cEval) {
          this.clickCEval = cEval;
      },
      returnLevelType: function (level) {
          var name = '';
          END_POINTS.DEPARTMENTLEVELS.forEach(dept => {
              if (dept.value == level)
                  name = dept.name; 
          })
          return name;
      },
     loadData(itemsPerPage, pageNumber) {
      this.loading = true
      var offset = 0
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1)
      this.$http.get(END_POINTS.GETCURRENTEVALUATIONS+"/?itemsPerPage=" + itemsPerPage + "&offset=" + offset + "&searchText="+this.searchText)
          .then(result => {
            this.loading = false
            this.usergroups = []
            this.currentEvaluations  = []
            //this.currentEvaluations =  result.data.data
            var array = result.data.data
            this.tableDataPresent = array.length > 0 ? true: false
            array.forEach(element => {
                var item = { 
                    id: element.id,
                    evaluationId: element.evaluationId,
                    yearId: element.yearId,
                    semesterId: element.semesterId,
                    dateCreated: DateFomatter.ReturnDate(element.dateCreated),
                    currentEvaluationName: element.currentEvaluationName,
                    status: element.status,
                    evaluationTarget: element.evaluationTarget,
                    startDate: DateFomatter.ReturnDate(element.startDate),
                    endDate: DateFomatter.ReturnDate(element.endDate),
                    evaluation: element.evaluation,
                }

                var currentActiveEvaluations = []
                element.evaluationsCurrentActive.forEach(element => {
                    var item = {
                        id: element.id,
                        evaluationTarget: element.evaluationTarget,
                        evaluationsCurrentId: element.evaluationsCurrentId,
                        evaluationsId: element.evaluationsId,
                        startDate: DateFomatter.ReturnDate(element.startDate),
                        endDate: DateFomatter.ReturnDate(element.endDate),
                        dateCreated: DateFomatter.ReturnDate(element.dateCreated),
                        evaluationTargetGroups: element.evaluationTargetGroups,
                         status: element.status,
                    }
                    currentActiveEvaluations.push(item)
                });
                item.evaluationsCurrentActive = currentActiveEvaluations
                this.currentEvaluations.push(item)
            });
            this.pagination.total = result.data.totalItems
            this.pagination.current = pageNumber
        })
          .catch(error => {
            this.loading = false
        })
    },
    changeItems() {
        this.goToPage(this.pagination.current)
    },
    goToPage(pageNum) {
        this.$emit('loadData', this.itemsPerPage, pageNum)
    },
    relay(item, action) {
        this.$emit('buttonEvent', item, action)
    },
    concatenateHeader (column) {
        var columnArray = column.split(' ')
        if(columnArray.length > 1) column = columnArray.join("")
        return column.toLowerCase()
    },
    buttonEvent (item, action) {
      switch (action) {
        case 'delete':
          alert('deleted')
          break
        case 'status':
          var activity = 'disabled'
          if(item.status)
            activity = 'activated'
          alert(activity)
          break
        default:
          break
      }
    },
  },

   created() {
    this.loadData(10, 1)
        },
        computed: {
            title() {
                if (this.edit) {
                    return "Edit : " + this.usergroup.groupName
                }
                if (!this.edit) {
                    return "Add A Current Evaluation"
                }
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
