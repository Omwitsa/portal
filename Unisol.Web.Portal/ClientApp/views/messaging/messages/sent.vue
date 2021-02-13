<template>
  <div class="page-body card">
    <div class="card-header">
      <h5>Current Sent Messages</h5>
    </div>
    <loading-spinner :loading="loading"></loading-spinner>
    <div class="card-block" v-if="!loading && !messages.length">
      <div class="col-md-12">
        <div class="alert alert-info">
          <i class="fa fa-exclamation-circle fa-2x"></i> No sent messages
        </div>
      </div>
    </div>
    <data-table
      v-if="!loading && messages.length"
      :data="messages"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:buttonEvent="buttonEvent"
      v-on:searchByText="searchByText"
    ></data-table>
  </div>
</template>
<script>
import DateFomatter from '../../../components/constants/DateFomatter';
export default {
  data() {
    return {
      loading: false,
      subTitle: '',
      title: '',
      searchText: '',
      messages: [],
      dateFomatter: DateFomatter,
      user: this.$baseRead('user'),
      pagination: {
        total: 0
      },
      columns: [
        // {
        //   name: "",
        //   type: "text"
        // },
        {
          name: 'To',
          type: 'text'
        },
        {
          name: 'Subject',
          type: 'text'
        },
        {
          name: 'Date',
          type: 'text'
        }
      ],
      tableActions: [
        {
          name: 'Move To Trash',
          type: 'button',
          path: 'moveToTrash',
          design: 'success',
          icon: 'edit'
        }
      ],
      headerActions: [
        {
          name: 'Compose',
          type: 'link',
          path: 'compose',
          design: 'primary',
          icon: 'edit'
        }
      ]
    };
  },
  created() {
    this.loadData(10, 1);
  },
  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      this.$http
        .get(
          'messages/getMessages?messageStatus=2&userCode=' + this.user.username
        )
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            result.data.data.forEach(element => {
              element.date = this.dateFomatter.ReturnDate(element.date);
            });
            this.messages = result.data.data;
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr('error', 'Exception : ' + error.message);
        });
    },
    buttonEvent(item, action) {
      switch (action) {
        case 'moveToTrash':
          let message = {
            messageId: item.id
          };
          this.$http
             .post("messages/trashMessage", message)
             .then(result => {
              this.loading = false;
              if (result.data.success) {
                this.loadData(10, 1);
              } else {
                this.$toastr('error', result.data.message);
              }
            })
            .catch(error => {
              this.loading = false;
              this.$toastr('error', 'Exception : ' + error.message);
            });
          break;
        default:
          break;
      }
    },
    searchByText(enteredText) {
      this.searchText = enteredText;
      this.loadData(10, 1);
    }
  }
};
</script>
<style></style>
