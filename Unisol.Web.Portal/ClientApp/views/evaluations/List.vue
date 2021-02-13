<template>
  <div class="page-body navbar-page">
    <div class="row">
      <div class="col-sm-12">
        <!-- Custom Light Colors card start -->
        <div class="card">
          <div class="card-header">
            <h5>Evaluations</h5>
            <span>List Of Evaluations.</span>
          </div>

          <div class="card-block">
            <div class="row">
              <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <router-link
                  class="btn btn-primary btn-round waves-effect waves-light"
                  to="add-evaluation"
                >
                  <i class="fa fa-plus"></i>
                  Add
                </router-link>
              </div>

              <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 offset-md-2">
                <div class="input-group">
                  <input
                    type="text"
                    v-model="searchText"
                    @keyup="searchByText"
                    placeholder="Search here"
                    class="form-control"
                  />
                  <span class="input-group-append">
                    <label class="input-group-text">Search</label>
                  </span>
                </div>
              </div>
            </div>
          </div>

          <loading-spinner :loading="loading"></loading-spinner>

          <div class="card-block" v-if="!tableDataPresent && !loading">
            <div class="col-md-12 alert-warning">
              <div>
                &nbsp;
                <h5 class="text-center">
                  <i class="fa fa-exclamation-circle fa-5x"></i>
                  <br />
                  {{"Evaluation is currently unavailable"}}
                </h5>&nbsp;
              </div>
            </div>
          </div>
          <div class="card-footer">
            <div class="col-md-12" v-for="(evaluation,index) in evaluations" :key="index">
              <div class="card card-border-success">
                <div class="card-header">
                  <a class="card-title" @click="clickedIndex=index">
                    <b>{{evaluation.evaluationName}}</b>
                    <br />
                    {{evaluation.evaluationDesc}}
                  </a>
                  <span class="label label-default float-right">{{evaluation.dateCreated}}</span>
                </div>
                <div class="card-block" v-if="clickedIndex==index">
                  <div class="row">
                    <div class="col-sm-12">
                      <div
                        class="task-detail"
                        v-for="(sec,index) in evaluation.evaluationSections"
                        :key="index"
                      >
                        <div
                          style="border-bottom:1px lightgrey solid;margin-bottom:8px;padding-bottom:8px;"
                        >
                          <div>
                            <b>{{index+1}}. {{sec.sectionName}}</b>
                          </div>
                          <div class style="color:grey;margin-left:15px;">{{sec.sectionDesc}}</div>
                        </div>
                        <div class="col-md-12">
                          <div
                            class="h-25 col-md-12"
                            style="font-weight:bold;color:darkgrey;"
                          >Questions</div>

                          <div v-for="(quiz,index) in sec.evaluationQuestions" :key="index">
                            {{index+1}}. {{quiz.questionDesc}}
                            <div class="col-md-12">
                              <div class="h-25 col-md-12">
                                <b>Options</b>
                              </div>
                              <ul class="col-md-12 list-unstyled">
                                <li
                                  v-for="(option,index) in quiz.evaluationQuestionOptions"
                                  :key="index"
                                >
                                  <i class="fa fa-chevron-right"></i>
                                  {{option.questionOption}}
                                </li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                      <p class="task-due">
                        <strong>Responses :</strong>
                        <strong class="label label-primary">23</strong>
                      </p>
                    </div>
                    <!-- end of col-sm-8 -->
                  </div>
                  <!-- end of row -->
                </div>
                <div class="card-footer">
                  <div class="task-list-table">
                    <!--<a href="#!"><img class="img-fluid img-radius" src="../files/assets/images/avatar-1.jpg" alt="1"></a>-->
                    <!--<a href="#!"><img class="img-fluid img-radius" src="../files/assets/images/avatar-2.jpg" alt="1"></a>-->
                    <a href="#!">
                      <i class="icofont icofont-plus"></i>
                    </a>
                  </div>
                  <div class="task-board">
                    <div class="dropdown-secondary dropdown">
                      <button
                        class="btn btn-primary btn-mini dropdown-toggle waves-effect waves-light"
                        type="button"
                        id="dropdown7"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                      >Actions</button>
                      <div
                        class="dropdown-menu"
                        aria-labelledby="dropdown7"
                        data-dropdown-in="fadeIn"
                        data-dropdown-out="fadeOut"
                      >
                        <a
                          class="dropdown-item waves-light waves-effect"
                          href="#"
                          @click="deleteEvaluation(evaluation.id,index)"
                        >
                          <span class="point-marker bg-danger"></span>Delete
                        </a>

                        <router-link
                          class="dropdown-item waves-light waves-effect"
                          :to="{ name: 'edit-evaluation', params: { id: evaluation.id }}"
                        >
                          <span class="point-marker bg-warning"></span> Edit
                        </router-link>
                        <router-link
                          class="dropdown-item waves-light waves-effect"
                          :to="{ name: 'responses', params: { id: evaluation.id }}"
                        >
                          <span class="point-marker bg-warning"></span> Responses
                        </router-link>
                      </div>
                      <!-- end of dropdown menu -->
                    </div>

                    <!-- end of seconadary -->
                  </div>
                  <!-- end of pull-right class -->
                </div>
                <!-- end of card-footer -->
              </div>
            </div>

            <div class="pull-left" v-if="tableDataPresent && !loading">
              <select v-model="itemsPerPage" class="form-control">
                <option selected :value="5">5</option>
                <option :value="10">10</option>
                <option :value="50">50</option>
                <option :value="100">100</option>
              </select>
              <label>Page Size:{{itemsPerPage}}</label>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFomatter from "../../components/constants/DateFomatter";

export default {
  data() {
    return {
      evaluations: [],
      clickedIndex: null,
      loading: true,
      tableDataPresent: false,
      user: this.$baseRead("user"),
      title: "Evaluations",
      subTitle: "List of Evaluations.",
      pageSize: 15,
      searchText: "",
      itemsPerPage: 10,
      totalPages: 0,
      currentPage: 1,
      tableActions: [
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "user-groups/edit",
          design: "success"
        },
        {
          name: "Delete",
          type: "button",
          icon: "trash",
          path: "delete",
          design: "danger"
        },
        {
          name: "Activate / Disable",
          type: "button",
          icon: "lock",
          path: "status",
          design: "warning"
        }
      ],
      headerActions: [
        {
          name: "Add",
          icon: "plus",
          type: "link",
          path: "user-groups/add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Group Name",
          type: "text"
        },
        {
          name: "Status",
          type: "code"
        },
        {
          name: "Role",
          type: "badge"
        },
        {
          name: "Default",
          type: "badge"
        },
        {
          name: "Privileges",
          type: "text"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    searchByText() {
      this.loadData(10, 1);
    },
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http
        .get("evaluations/getevaluations/?itemsPerPage=" + itemsPerPage + "&offset=" + offset + "&searchText=" + this.searchText)
        .then(result => {
          var array = result.data.data.data;
          this.tableDataPresent = array.length > 0 ? true : false;
          this.evaluations = [];
          array.forEach(element => {
            var item = {
              id: element.id,
              dateCreated: DateFomatter.ReturnDate(element.dateCreated),
              evaluationName: element.evaluationName,
              status: element.status,
              evaluationSections: element.evaluationSections,
              evaluationDesc: element.evaluationDesc
            };
            this.evaluations.push(item);
          });
          this.pagination.total = result.data.totalItems;
          this.pagination.current = pageNumber;
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loading = false;
    },
    deleteEvaluation: function(id, index) {
      swal({
            title: "Are you sure you want to delete?",
            icon: "warning",
            buttons: true,
            dangerMode: false
        }).then(action => {
            if(action){
              this.loading = true;
              this.$http.get("evaluations/deleteEvaluation/?id="+id)
                .then(response => {
                  this.loading = false;
                  this.$toastr("success", response.data.message);
                  this.$router.replace({ name: "evaluations" });
                })
                .catch(e => {
                  this.loading = false;
                  this.$toastr("error", e.message);
                }); 
            }
        })
      
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          alert("deleted");
          break;
        case "status":
          var activity = "disabled";
          if (item.status) activity = "activated";
          alert(activity);
          break;
        default:
          break;
      }
    }
  },

  created() {
    if(this.user.role == '2'){
      this.$router.replace({ name: "responses" });
    }
    else{
      this.loadData(10, 1);
    }
  }
};
</script>

<style>
</style>
