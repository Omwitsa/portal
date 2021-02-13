<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span>{{subTitle}}.</span>
        <!-- <div class="card-header-right"><span class="badge badge-primary">{{history.length}}</span></div> -->
      </div>

      <div v-if="loading" class="text-center card-block">
        <i class="fa fa-spin fa-spinner"></i> Loading. Please wait ...
      </div>
      <div class="card-block" v-if="!evaluationHistoryFound">
        <div v-if="!loading" class="alert alert-warning">
          <i class="fa fa-exclamation-circle"></i> We could not find evaluation history
        </div>
      </div>

      <div class="card-block" v-if="!loading && evaluationHistoryFound">
        <div v-for="(currentEval,index) in history" :key="index">
          <div class="card-header">
            <h4>
              {{index+1}}. {{currentEval.evaluationCurrentName}}
              <!-- <div class="card-header-right"><span class="badge badge-primary">
                                {{currentEval.respondedUnits.length}}</span>
              </div>-->
            </h4>
            <span>
              {{currentEval.evaluationCurrentTargetName}}
              <i
                class="fa fa-2x fa-chevron-down pull-right"
                v-if="clickedIndex!=index"
                @click="clickedIndex=index"
              ></i>
              <i
                class="fa fa-2x fa-chevron-up pull-right"
                v-if="clickedIndex==index"
                @click="clickedIndex=null"
              ></i>
            </span>
          </div>
          <div class="table-responsive" v-if="clickedIndex==index">
            <table class="table table-sm">
              <tbody>
                <tr v-for="(unit,index) in currentEval.respondedUnits" :key="index">
                  <td>{{index+1}}</td>
                  <td>{{unit.unitCode}}</td>
                  <td>{{unit.unitCode}}Subject Name</td>
                  <td>{{DateFormatter.ReturnDate(unit.dateCreated)}}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFormatter from "../../components/constants/DateFomatter";

export default {
  data() {
    return {
      history: [],
      loading: true,
      clickedIndex: null,
      evaluationHistoryFound: false,
      DateFormatter: DateFormatter,
      title: "Evaluation History",
      subTitle: "List of Evaluation History.",
      user: this.$baseRead("user")
    };
  },

  methods: {
    loadData() {
      this.loading = true;
      this.$http
        .get(
          "portalevaluations/GetEvaluationHistory?usercode=" +
            this.user.username
        )
        .then(result => {
          this.history = [];
          this.loading = false;
          if (result.data.success) {
            this.evaluationHistoryFound = true;
            this.history = result.data.data;
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.loadData();
  }
};
</script>

<style>
</style>
