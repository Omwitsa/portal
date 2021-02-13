<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="newsTypes"
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
import END_POINTS from "../../../components/constants/EndPoints";
export default {
  data() {
    return {
      newsTypes: null,
      loading: true,
      title: "News categories",
      subTitle: "List of news categories",
      searchText: "",
      tableActions: [
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "categories/edit",
          design: "success"
        },
        {
          name: "Delete",
          type: "button",
          icon: "trash",
          path: "delete",
          design: "danger"
        }
      ],
      headerActions: [
        {
          name: "Add",
          icon: "plus",
          type: "link",
          path: "categories/add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "No"
        },
        {
          name: "Name"
        },
        {
          name: "Status"
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
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var count = 0;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http
        .get(
          END_POINTS.GETNEWSTYPES +
            "?offSet=" +
            offset +
            "&itemsPerPage=" +
            itemsPerPage +
            "&searchText=" +
            this.searchText
        )
        .then(result => {
          this.newsTypes = [];
          if (result.data.success) {
            var info = result.data.data;
            info.forEach(element => {
              var item = {
                no: ++count,
                id: element.id,
                name: element.newsTypeName,
                status: element.status ? "Active" : "Inactive"
              };
              this.newsTypes.push(item);
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
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          this.$http
            .get("news/deleteNewsType/?id=" + item.id)
            .then(response => {
              if (response.data.success) {
                this.$toastr("success", response.data.message);
              } else {
                this.$toastr("error", response.data.message);
              }
              this.loadData(10, 1);
            })
            .catch(e => {
              this.$toastr("error", "Server error occured");
            });
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
