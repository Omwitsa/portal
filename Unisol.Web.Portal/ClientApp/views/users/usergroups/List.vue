<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="usergroups"
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
export default {
  data() {
    return {
      usergroups: null,
      loading: true,
      title: "User Groups",
      subTitle: "List of user groups.",
      pageSize: 15,
      searchText: "",
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
          name: "No",
          type: "text"
        },
        {
          name: "Group Name",
          type: "text"
        },
        {
          name: "Status",
          type: "text"
        },
        {
          name: "Role",
          type: "text"
        }
        // {
        //     name: "Default",
        //     type: "text"
        // }
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
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http
        .get(
          "usergroups/pages/?itemsPerPage=" +
            itemsPerPage +
            "&offset=" +
            offset +
            "&searchText=" +
            this.searchText
        )
        .then(result => {
          this.usergroups = [];
          if (result.data.success) {
            var info = result.data.data;
            var number = 0;
            info.forEach(element => {
              var item = {
                id: element.id,
                no: ++number,
                groupname: element.groupName,
                status: element.status ? "Active" : "Disabled",
                role: element.role,
                default: element.isDefault,
                privileges: element.privileges ? element.privileges.length : ""
              };
              this.usergroups.push(item);
            });
            this.pagination.total = result.data.totalItems;
            this.pagination.current = pageNumber;
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }
        })
        .catch(error => {
          this.$toastr("error", error.message);
        });
      this.loading = false;
    },
    disableGroup: function(item, status) {
      this.groupExists = false;
      this.httpStatus = true;

      var url = "usergroups/disableusergroup" + "/?id=" + item.id;
      if (status) {
        url = "usergroups/deleteusergroup" + "/?id=" + item.id;
      }
      //return;
      this.$http
        .get(url)
        .then(response => {
          this.httpStatus = false;
          if (response.data.success) {
            this.groupExists = true;
            this.$toastr("success", response.data.message);
          } else {
            this.$toastr("error", response.data.message);
          }
        })
        .catch(e => {
          this.$toastr("error", "Server error occured");
          this.httpStatus = false;
        });
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          swal({
            title: "Are you sure you want to delete?",
            icon: "warning",
            buttons: true,
            dangerMode: false
          }).then(action => {
            if (action) {
              this.disableGroup(item, true);
            }
          });
          break;
        case "status":
          if (item.status == "Disabled") {
            item.status = "Active";
          } else {
            item.status = "Disabled";
          }
          this.disableGroup(item, false);
          break;
        default:
          break;
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
