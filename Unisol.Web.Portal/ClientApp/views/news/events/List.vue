<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <data-table
      v-if="!loading"
      :data="events"
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
import END_POINTS from "../../../components/constants/EndPoints";
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
  data() {
    return {
      events: null,
      loading: true,
      settings: {},
      user: {},
      title: "Events",
      subTitle: "List Of Events.",
      user: this.$baseRead("user"),
      tableActions: [],
      headerActions: [],
      columns: [
        {
          name: "Events Title"
        },
        {
          name: "Start Date"
        },
        {
          name: "End Date"
        },
        {
          name: "Events Venue"
        }
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
          END_POINTS.GETEVENTS +
            itemsPerPage +
            "&offset=" +
            offset +
            "&userCode=" +
            this.user.username
        )
        .then(result => {
          this.events = [];
          var info = result.data.data;
          info.forEach(element => {
            var item = {
              id: element.id,
              eventstitle: this.stripContent(element.eventTitle).substr(0,50) + '...',
              startdate: DateFomatter.ReturnDate(element.eventStartDate),
              enddate: DateFomatter.ReturnDate(element.eventEndDate),
              eventsvenue: this.stripContent(element.eventVenue).substr(0,20) + '...',
              //eventstype: element.portaleventsType.eventsTypeName,
              //status: element.eventsStatus == 1 ? "Active" : "Inactive"
            };
            this.events.push(item);
          });
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
            .get("events/deleteEvents/?id=" + item.id)
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
    },
    getTableAction(){
      this.tableActions = [
        {
          name: "Details",
          icon: "details",
          type: "link",
          path: "details",
          design: "success"
        },
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "events/edit",
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
       if(this.user.role != 1){
          if(!this.settings.isGenesis){
            this.tableActions = [
              {
                name: "Details",
                icon: "details",
                type: "link",
                path: "details",
                design: "success"
              }
            ]
          }
        }
    },
    getHeaderActions() {
      if (this.user.role != 3) {
        this.headerActions = [
            {
              name: "Add",
              icon: "plus",
              type: "link",
              path: "events/add-events",
              design: "primary"
            }
          ];

          if(this.user.role == 2){
            if(this.settings.initials == "UOEM"){
              this.headerActions = []
            }
          }
      } 
      else {
        var details = this.tableActions[0];
        this.tableActions = [];
        this.tableActions.push(details);
      }
    },
  },
  created() {
    this.user = this.$baseRead("user");
    this.settings = JSON.parse(localStorage.getItem("settings"));
    this.loadData(10, 1);
    this.getHeaderActions();
    this.getTableAction();
  }
};
</script>

<style>
</style>
