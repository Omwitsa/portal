<template>
    <div class="page-body navbar-page">
        <div class="row">
            <div class="col-sm-12">
                <!-- Custom Light Colors card start -->
                <div class="card">
                    <div class="card-header">
                        <h5>Evaluations Responses</h5>
                        <span>List Of Responses.</span>
                        <div class="card-header-right">
                            <!-- <span class="badge badge-primary">
                                {{currentEvaluation.evaluationsCurrentActive.length}}
                            </span> -->
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            
                            <div class="col-md-12 row">
                                <div class="col-md-12" style="border-bottom:1px lightgrey solid;">
                                    <div class="h3"> {{currentEvaluation.currentEvaluationName}}</div>

                                </div>
                                <div class="col-md-12">

                                    <div class="h5 btn-default btn"> Click on period</div>

                                    <div class="">
                                        <table class="table table-condensed table-sm">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Period</th>
                                                    <th>View</th>
                                                </tr>
                                            </thead>
                                            
                                            <tbody>
                                                <tr v-for="(period,index) in currentEvaluation.evaluationsCurrentActive" :key="index"> 
                                                    <td>{{index+1}}</td>
                                                    <td><b>Starts :</b> {{funcs.ReturnDate(period.startDate)}} <b>To :</b> {{funcs.ReturnDate(period.endDate)}}</td>
                                                    <td><div class="btn btn-primary btn-round waves-effect waves-light btn-sm" >View Responses</div></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <loading-spinner :loading="loading"></loading-spinner>

                </div>
            </div>
        </div>
        
       
    </div>
    




</template>

<script>
import END_POINTS from '../../../components/constants/EndPoints';
export default {
  data() {
    return {
      usergroups: null,
        loading: true,
        submittingActive: false,
     
      subTitle: 'List of Responses.',
        pageSize: 15,
        itemsPerPage: 10,
        activeEvaluation: {},
        totalPages: 0,
        clickCEval: {},
        funcs: END_POINTS,
        currentEvaluation:[],
      currentPage: 1,    
      pagination: {
        total: 0,
      }
    }
  },

methods: {

     loadData(itemsPerPage, pageNumber) {
      this.loading = true
      var offset = 0
         var id = this.$route.params.id;
      this.$http.get(
          END_POINTS.GETCURRENTEVALUATION+"?id=" + id
        )
          .then(result => {
              this.loading = false;           
              this.currentEvaluation = result.data.data;
        })
          .catch(error => {
            this.loading = false;
        })
     
    },  
    returnFormattedDate: function (date) {
        //return END_POINTS.ReturnDate(date);
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
