<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="users"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:buttonEvent="buttonEvent"
      v-on:searchByText="searchByText"
      :confirmAccounts="confirmAccounts"
      :updateEmails="updateEmails"
    ></data-table>
  </div>
</template>
<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      users: null,
      user: this.$baseRead("user"), 
      confirmAccounts: false,
      updateEmails: true,
      loading: true,
      title: "Users",
      confirm: {},
      dateFomatter: DateFomatter,
      searchText: "",
      subTitle: "List of users.",
      tableActions: [],
      headerActions: [
        {
          name: "Add",
          icon: "plus",
          type: "link",
          path: "users/add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Username",
          type: "currency"
        },
        {
          name: "Email",
          type: "centered"
        },
        {
          name: "Group",
          type: "text"
        },
        {
          name: "Date Created",
          type: "text"
        },
        {
          name: "Activation Status",
          type: "text"
        },
        {
          name: "Status",
          type: "text"
        }
      ],
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    searchByText(enteredText) {
      this.searchText = enteredText;
      this.loadData(10, 1);
    },
    loadData(itemsPerPage, pageNumber, unconfirmed) {
      this.getTableActions(unconfirmed);
      this.confirmAccounts = false;
      this.loading = true;
      unconfirmed = !unconfirmed ? false : unconfirmed;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http.get("users/pages/?itemsPerPage=" + itemsPerPage + "&offset=" + offset + 
        "&searchText=" + this.searchText + "&unconfirmed=" + unconfirmed)
        .then(result => {
          this.users = [];
          var info = result.data;
          if (info.success) {
            var number = 0;
            info.data.forEach(element => {
              if(!element.activationStatus){
                this.confirmAccounts = !element.activationStatus
              }
              var item = {
                no: ++number,
                id: element.id,
                username: element.userName,
                email: element.email,
                datecreated: this.dateFomatter.ReturnDate(element.dateCreated),
                group: element.userGroup,
                activationstatus: element.activationStatus
                  ? "Confirmed"
                  : "Pending",
                status: element.status ? "Active" : "Disabled"
              };

              // if(element.activationStatus)
              //   this.tableActions.remove(this.confirm)

              this.users.push(item);
            });
            this.pagination.total = result.data.totalItems;
            this.pagination.current = pageNumber;
          } else {
            this.$toastr("error", info.message);
            if (info.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loading = false;
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          this.$http
            .get("users/DeleteUser/?id=" + item.id)
            .then(response => {
              if (response.data.success) {
                this.$toastr("success", response.data.message);
              } else {
                this.$toastr("error", response.data.message);
              }
              this.loadData(10, 1);
            })
            .catch(e => {
              this.$toastr("error", e.message);
            });
          break;
        case "updateStatus":
          this.$http
            .get("users/updateUsersStatus/?id=" + item.id)
            .then(response => {
              if (response.data.success) {
                this.$toastr("success", response.data.message);
              } else {
                this.$toastr("error", response.data.message);
              }
              this.loadData(10, 1);
            })
            .catch(e => {
              this.$toastr("error", e.message);
            });
          break;
        case "confirm":
          this.$http
            .get("users/adminconfirmpassword/?usercode=" + item.username)
            .then(response => {
              if (response.data.success) {
                this.$toastr("success", response.data.message);
                this.getTableActions();
              } else {
                this.$toastr("error", response.data.message);
              }
              this.loadData(10, 1, this.confirmAccounts);
            })
            .catch(e => {
              this.$toastr("error", e.message);
            });
          break;
        case "reset":
        
          break;
        default:
          break;
      }
    },
    getTableActions(unconfirmed = false) {
      this.tableActions = [
        {
          name: "Reset Password",
          icon: "edit",
          type: "link",
          path: "reset-password",
          design: "success"
        },
        {
          name: "Activate/Deactivate",
          icon: "edit",
          type: "button",
          path: "updateStatus",
          design: "success"
        },
        {
          name: "Delete",
          type: "button",
          icon: "trash",
          path: "delete",
          design: "danger"
        }
      ];
      if(unconfirmed){
        this.tableActions = [
        {
          name: "Confirm account",
          icon: "edit",
          type: "button",
          path: "confirm",
          design: "success"
        }
      ];
      }
    }
  },
  created() {
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
