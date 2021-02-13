<template>
  <div class="page-body card">
    <div class="card-header">
      <h5>Current Messages</h5>
    </div>
    <loading-spinner :loading="loading"></loading-spinner>
    <div class="card-block" v-if="!loading && !messages.length">
      <div class="col-md-12">
        <div class="alert alert-info">
          <i class="fa fa-exclamation-circle fa-2x"></i> No message available
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
import DateFomatter from "../../../components/constants/DateFomatter";
// import { EventBus } from "../../../app";
export default {
  props: {
    habUrl: {}
  },
  data() {
    return {
      loading: false,
      subTitle: "",
      title: "",
      // hubResponse: "ABNO",
      messageStatus: null,
      searchText: "",
      messages: [],
      dateFomatter: DateFomatter,
      user: this.$baseRead("user"),
      pagination: {
        total: 0
      },
      columns: [
        // {
        //   name: "",
        //   type: "text"
        // },
        {
          name: "From",
          type: "text"
        },
        {
          name: "Subject",
          type: "text"
        },
        {
          name: "Date",
          type: "text"
        }
      ],
      tableActions: [
        {
          name: "Mark As Read",
          type: "button",
          path: "markRead",
          design: "success", 
          icon: "edit"
        },
        {
          name: "Move To Trash",
          type: "button",
          path: "moveToTrash",
          design: "success", 
          icon: "edit"
        },
        {
          name: "View Message",
          type: "button",
          path: "view_message",
          design: "success", 
          icon: "edit"
        }
      ],
      headerActions: [
        {
          name: "Compose",
          type: "link",
          path: "compose",
          design: "primary"
        }
      ]
    };
  },
  created() {
    this.loadData(10, 1);
  },

  mounted() {},

  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      this.$http
        .get(
          "messages/getMessages?messageStatus=1&userCode=" + this.user.username
        )
        .then(result => {
          this.loading = false;
          if (result.data.success) {
            result.data.data.forEach(element => {
              element.date = this.dateFomatter.ReturnDate(element.date);
              element.tableRowColor =
                element.messageStatus == 3 ? "#d9d9d9" : "";
            });

            this.messages = result.data.data;
          }
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    },
    buttonEvent(item, action) {
      switch (action) {
        case "markRead":
          this.$http
            .get(
              "messages/getMessages?messageStatus=3&userCode=" +
                this.user.username +
                "&id=" +
                item.id
            )
            .then(result => {
              this.loading = false;
              if (result.data.success) {
                result.data.data.forEach(element => {
                  element.date = this.dateFomatter.ReturnDate(element.date);
                });
                this.messages = result.data.data;
                this.loadData(10, 1);
              } else {
                this.$toastr("error", result.data.message);
              }
            })
            .catch(error => {
              this.loading = false;
              this.$toastr("error", error.message);
            });
          break;
        case "moveToTrash":
          let message = {
            messageId: item.id
          }
          this.$http
            .post(
              "messages/trashMessage", message)
            .then(result => {
              this.loading = false;
              if (result.data.success) {
                this.loadData(10, 1);
              } else {
                this.$toastr("error", result.data.message);
              }
            })
            .catch(error => {
              this.loading = false;
              this.$toastr("error", error.message);
            });
          break;
        case "view_message":
          var selectedMessage = this.messages.filter(function(message) {
            return message.id == item.id;
          });
          this.$router.push({
            name: "view-message",
            params: { message: selectedMessage }
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
<style>
</style>
