<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="news"
      :columns="columns"
      :tableActions="tableActions"
      :headerActions="headerActions"
      :subTitle="subTitle"
      :title="title"
      :pagination="pagination"
      v-on:loadData="loadData"
      v-on:buttonEvent="buttonEvent"
    ></data-table>
  </div>
</template>
<script>
import END_POINTS from "../../components/constants/EndPoints";
import DateFomatter from "../../components/constants/DateFomatter";
export default {
  data() {
    return {
      news: null,
      loading: true,
      user: {},
      searchText: "",
      title: "News",
      subTitle: "List of News",
      user: this.$baseRead("user"),
      settings: JSON.parse(localStorage.getItem('settings')),
      tableActions: [],
      headerActions: [],
      columns: [
        {
          name: "News Title"
        },
        {
          name: "Category"
        },
        {
          name: "Status"
        }, 
      ],
      pagination: {
        total: 0
      }
    };
  },

  methods: {
    stripContent(content) {
      let regex = /(<([^>]+)>)/ig
      return content.replace(regex, "")
    },
    loadData(itemsPerPage, pageNumber) {
      this.loading = true;
      var offset = 0;
      if (pageNumber > 1) offset = itemsPerPage * (pageNumber - 1);
      this.$http
        .get(
          "news/GetNews?searchText=" +
            this.searchText +
            "&offset=0&userCode=" +
            this.user.username
        )
        .then(result => {
          result.data.data.forEach(element => {
            var date = DateFomatter.ReturnDate(element.expiryDate)
            element.newstitle = this.stripContent(element.newsTitle).substr(0,100) + '...',
            element.category = element.portalNewsType.newsTypeName
            element.expirydate = date
            element.status = element.newsStatus == 1 ? "Active" : "Inactive"
          });

          this.news = result.data.data
          this.pagination.total = result.data.totalItems;
          this.pagination.current = pageNumber;
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
            .get("news/deleteNews/?id=" + item.id)
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

          case "publish":
            this.$http.get("news/publishNews/?id=" + item.id)
              .then(response => {
                if (response.data.success) {
                  this.$toastr("success", response.data.message);
                  this.loadData(10, 1);
                } else {
                  this.$toastr("error", response.data.message);
                }
              })
              .catch(e => {
                this.$toastr("error", "Server error occured");
              });
          break;
        default:
          break;
      }
    },
    getHeaderActions() {
      this.headerActions = [
          {
            name: "Add",
            icon: "plus",
            type: "link",
            path: "news/add",
            design: "primary"
          }
        ];

        if(!this.settings.isGenesis && this.user.role != 1){
          this.headerActions = [];
        }
    },
    getTableActions(){
      this.tableActions = [
         {
          name: "Details",
          icon: "details",
          type: "link",
          path: "news/details",
          design: "success"
        },
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "news/edit",
          design: "success"
        },
        {
          name: "Publish",
          type: "button",
          icon: "edit",
          path: "publish",
          design: "success"
        },
        {
          name: "Delete",
          type: "button",
          icon: "trash",
          path: "delete",
          design: "danger"
        }
      ]

      if (this.user.role != 1){
        this.tableActions = [
          {
            name: "Details",
            icon: "details",
            type: "link",
            path: "news/details",
            design: "success"
          },
          {
            name: "Edit",
            icon: "edit",
            type: "link",
            path: "news/edit",
            design: "success"
          }
        ]
        if(!this.settings.isGenesis){
          this.tableActions = [
            {
              name: "Details",
              icon: "details",
              type: "link",
              path: "news/details",
              design: "success"
            }
          ]
        }
      }
    }
  },
  created() {
    this.getTableActions();
    this.getHeaderActions();
    this.loadData(10, 1);
  }
};
</script>

<style>
</style>
