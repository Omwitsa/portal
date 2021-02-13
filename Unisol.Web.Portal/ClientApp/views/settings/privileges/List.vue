<template>

    <div class="page-body">
      <div class="card-block">
        <div class="dt-responsive table-responsive">

        <loading-spinner :loading="loading"></loading-spinner>
        
        <data-table v-if="!loading" 
        :data="privileges" 
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
      </div>
    </div>
    
</template>

<script>
export default {
  data() {
    return {
      privileges: null,
      loading: true,
      title: "Privileges",
      subTitle: "List of privileges.",
      tableActions: [
        {
          name: "Edit",
          icon: "edit",
          type: "link",
          path: "privileges/edit",
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
          path: "privileges/add",
          design: "primary"
        }
      ],
      columns: [
        {
          name: "Name",
          type:"text"
        },
        {
          name: "Action",
          type:"code"
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
      var offset = 0

      if (pageNumber > 1) 
        offset = itemsPerPage * (pageNumber - 1)

      this.$http
        .get(
          "privileges/pages/?itemsPerPage=" + itemsPerPage + "&offset=" + offset + ""
        )
        .then(result => {
          this.privileges = []
          var info = result.data.data
          info.forEach(element => {
            var item = {
              id: element.id,
              name: element.privilegeName,
              action: element.action,
            }
            this.privileges.push(item)
          })
          this.pagination.total = result.data.totalItems
          this.pagination.current = pageNumber
        })
        .catch(error => {
          this.$toastr('error', error.message)
        })
      this.loading = false
    },
    buttonEvent (item, action) {
      switch (action) {
        case "delete":
          swal({
            title: "Are you sure you want to delete?",
            icon: "warning",
            buttons: true,
            dangerMode: false
          }).then(action => {
            if (action) {
              this.$toastr("success", "Deleted")
            }
          })
          break
        default:
          break
      }
    },
  },
  created() {
    this.loadData(10, 1)
  }
}
</script>

<style>
</style>
