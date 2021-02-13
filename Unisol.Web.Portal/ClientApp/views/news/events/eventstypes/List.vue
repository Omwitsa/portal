<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table v-if="!loading" 
          :data="eventsTypes" 
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
import END_POINTS from "../../../../components/constants/EndPoints"
import DateFomatter from "../../../../components/constants/DateFomatter"
export default {
  data() {
    return {
      eventsTypes: [],
      loading: true,
      title: "Events categories",
      dateFomatter: DateFomatter,
      subTitle: "List of events categories.",
      tableActions: [
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "event-categories/edit",
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
          path: "event-categories/add",
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
          name: "Date Created"
        }
      ],
      pagination: {
        total: 0
      }
    }
  },

  methods: {
    loadData(itemsPerPage, pageNumber) {
      this.loading = true
      var count = 0
      this.$http
        .get("events/geteventstypes")
        .then(result => {
          this.eventsTypes = []
          if (result.data.success) {
            result.data.data.forEach(element => {
            var item = {
              no: ++count,
              id: element.id,
              name: element.eventTypeName,
              datecreated: this.dateFomatter.ReturnDate(element.dateCreated)
            }
            this.eventsTypes.push(item)
          })
          } else {
            this.$toastr("error", result.data.message);
            if (result.data.notAuthenticated) {
              this.$router.replace({ name: "401-forbidden" });
            }
          }

        })
        .catch(error => {
          this.$toastr("error", error.message)
        })
      this.loading = false
    },
    buttonEvent(item, action) {
      switch (action) {
        case "delete":
          this.$http.get("events/deleteEventsType/?id="+ item.id)
            .then(response => {
                if (response.data.success) {
                    this.$toastr("success", response.data.message)
                } else {
                    this.$toastr("error", response.data.message)
                }
                this.loadData(10, 1)
            })
            .catch(e => {
                this.$toastr("error", e.message)
            })
          break
        default:
          break
      }
    }
  },
  created() {
    this.user = this.$baseRead('user')
    this.loadData(10, 1)
  }
}
</script>

<style>
</style>
