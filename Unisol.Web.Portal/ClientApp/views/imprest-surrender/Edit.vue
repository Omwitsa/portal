<template>
  <div class="page-body">
    <div class="card">
      <div class="card-header">
        <h5>{{title}}</h5>
        <span v-if="subTitle">{{ subTitle }}</span>
      </div>

      <div class="card-block">
        <div class="row">
          <div class="col-md-2">
            PayeeRef/ Employee No
          </div>
          <div class="col-md-8">
            <input
              v-model="surrenderReq.payeeRef"
              type="text"
              class="form-control"
              disabled
            />
          </div>
        </div>
        <br />
        <div class="row">
          <div class="col-md-2">
            Employee Name
          </div>
          <div class="col-md-8">
            <input
              v-model="surrenderReq.employeeName"
              type="text"
              class="form-control"
              disabled
            />
          </div>
        </div>
        <br />
        <div class="row">
          <div class="col-md-2">
            ImpRef
          </div>
          <div class="col-md-3">
            <v-select
              :options="imprests"
              v-model="surrenderReq.impRef"
            ></v-select>
          </div>
          <div class="col-md-2">
            Surrender Date
          </div>
          <div class="col-md-3">
            <date-picker
              v-model="surrenderReq.surReqDate"
              :config="options"
            ></date-picker>
          </div>
        </div>
        <br />

        <div class="row">
          <div class="col-md-2">
            Description
          </div>
          <div class="col-md-8">
            <textarea
              v-model="surrenderReq.description"
              type="text"
              rows="3"
              class="form-control"
            />
          </div>
        </div>
        <br />
      </div>

      <div class="card-footer">
        <div class="pull-right">
          <submit-button
            styling="btn btn-primary btn-round waves-effect waves-light "
            :loading="submitting"
            v-on:submit="save"
          ></submit-button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      subTitle: 'Imprest Surrender Request Form',
      title: 'Imprest Surrender',
      submitting: false,
      loading: false,
      imprests: [],
      user: this.$baseRead('user'),
      surrenderReq: {
        payeeRef: "",
        employeeName: "",
        description: "",
        impRef: "",
        surReqDate: new Date()
      },
      options: {
        format: 'DD/MM/YYYY',
        useCurrent: false
      }
    };
  },
  methods: {
    GetImprestSurrenderDetails() {
      this.loading = true;
      this.$http
        .get(
          'imprestSurrender/getImprestDetails/?usercode=' +
            this.user.username
        )
        .then(result => {
          if (result.data.success) {
            this.imprests = result.data.data.validImprests;
            this.surrenderReq.payeeRef = result.data.data.payeeRef;
            this.surrenderReq.employeeName = result.data.data.employeeName;
          } else {
            this.$toastr('error', result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: '401-forbidden' });
            }
          }
        })
        .catch(error => {
          this.loading = false;
        });
    },
    save() {
      this.submitting = true;
      this.$http
        .post('imprestSurrender/saveSurrenderReq', this.surrenderReq)
        .then(response => {
          this.submitting = false;
          if (response.data.success) {
            this.$toastr('success', response.data.message);
            this.surrenderReq.description = '';
            this.surrenderReq.impRef = '';
            this.$router.replace({ name: 'user-imprest-surrender' });
          } else {
            this.$toastr('error', response.data.message);
          }
        })
        .catch(e => {
          this.$toastr('error', e.message);
        });
    },
  },
  created() {
    this.GetImprestSurrenderDetails();
    console.log(this.user.username)
  }
};
</script>
<style></style>
