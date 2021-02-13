<template>
  <div class="page-body">
    <div class="card">
      <loading-spinner :loading="loading"></loading-spinner>
      <div class="card-header">
        <h5>Compose Messaging</h5>
      </div>

      <div class="card-block" v-if="!loading">
        <div class="row">
          <div class="col-md-2" style="text-align: right">Recipient:</div>
          <div class="col-md-4">
            <v-select
              :options="recipients"
              v-model="receipientName"
            ></v-select>
          </div>
        </div>
        <br />

        <div class="row">
          <div class="col-md-2" style="text-align: right">Subject:</div>
          <div class="col-md-4">
            <fg-input type="text" v-model="message.subject" />
          </div>
        </div>

        <div class="row">
          <div class="col-md-2" style="text-align: right">Message Content:</div>
          <div class="col-md-8 form-group">
            <vue-editor v-model="message.message"></vue-editor>
            <!-- v-validate="'required|not_empty'" -->
          </div>
        </div>
        <br />
        <!-- <div class="row">
                    <div class="col-md-2" style="text-align: right">Mark Important:</div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <select class="form-control" v-model="message.groupMessage">
                                <option>True</option>
                                <option>False</option>
                            </select>
                        </div>
                    </div>
                </div><br> -->
      </div>

      <div class="card-footer" v-if="!loading">
        <div class="pull-right">
          <submit-button
            :class="[{ disabled: loading }]"
            :loading="loading"
            title="send"
            v-on:submit="sent"
            styling="btn btn-primary btn-round waves-effect waves-light "
          />

          <submit-button
            title="Back To Inbox"
            v-on:submit="cancel"
            styling="btn btn-inverse btn-round waves-effect waves-light "
          />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { EventBus } from '../../../app';
import { VueEditor } from "vue2-editor";
export default {
  components: {
    VueEditor
  },
  data() {
    return {
      loading: false,
      message: {},
      receipientName: '',
      user: this.$baseRead('user'),
      recipients: [],
      recepientsArr: [],
      messageReceipient: {},
    };
  },
  watch: {
    // receipientName: function(value) {
    //   this.getRecipients();
    // }
  },
  created() {
    this.getRecipients();
  },

  methods: {
    getRecipients() {
      this.loading = true;
      this.$http
        .get('messages/getRecipients?username='+ this.user.username)
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            result.data.data.forEach(element => {
              this.recipients.push(`${element.recipientName}`);
              this.recepientsArr.push(element);
            });
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr('error', error.message);
        });
    },
    sent() {
      let recepient = this.recepientsArr.filter(u => {
          return u.recipientName === this.receipientName;
      })[0];
      this.loading = true;
      var val = this.message.message
      debugger // getText
      // this.$http.post('messages/compose?senter=' + this.user.username + '&receiver=' + recepient.userName, this.message)
      //   .then(result => {
      //     this.loading = false;
      //     if (result.data.success) {
      //       this.$toastr('success', result.data.message);
      //       this.$router.replace({ name: 'inbox' });
      //     } else {
      //       this.$toastr('error', result.data.message);
      //     }
      //   })
      //   .catch(error => {
      //     this.loading = false;
      //     this.$toastr('error', 'Exception : ' + error.message);
      //   });
    },
    cancel() {
      this.$router.replace({ name: 'inbox' });
    }
  }
};
</script>
<style></style>
