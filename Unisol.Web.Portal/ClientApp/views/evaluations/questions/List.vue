<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <data-table v-if="!loading" 
        :data="usergroups" 
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

export default {
  data() {
    return {
      usergroups: null,
      loading: true,
      title: 'User Groups',
      subTitle: 'List of user groups.',
      pageSize: 15,
      currentPage: 1,
      tableActions: [
        {
          name: 'Edit',
          icon: 'edit',
          type: 'link',
          path: 'user-groups/edit',
          design: 'success'
        },
        {
          name: 'Delete',
          type: 'button',
          icon: 'trash',
          path: 'delete',
          design: 'danger'
        },
        {
          name: 'Activate / Disable',
          type: 'button',
          icon: 'lock',
          path: 'status',
          design: 'warning'
        }
      ],
      headerActions: [
        {
          name: 'Add',
          icon: 'plus',
          type: 'link',
          path: 'user-groups/add',
          design: 'primary'
        }
        
      ],
      columns: [
        {
          name: 'Group Name',
          type:'text'
        },
        {
          name: 'Status',
          type:'code'
        },
        {
          name: 'Role',
          type:'badge'
        },
        {
          name: 'Default',
          type:'badge'
        },
        {
          name: 'Privileges',
          type:'text'
        }
      ],
      pagination: {
        total: 0,
      }
    }
  },

  methods: {
     loadData(itemsPerPage, pageNumber) {
      this.loading = true
      var offset = 0

      if (pageNumber > 1) 
        offset = itemsPerPage * (pageNumber - 1)

      this.$http.get(
        "usergroups/pages/?itemsPerPage=" + itemsPerPage + "&offset=" + offset + ""
        )
        .then(result => {
          this.usergroups = []
           var info = result.data.data
          info.forEach(element => {
            var item = {
              id: element.id,
              groupname: element.groupName,
              status: element.status ? "Active" : "Disabled",
              role: element.role,
              default: element.isDefault ,
              privileges: (element.privileges) ? element.privileges.length : '' ,
            }
            this.usergroups.push(item)
          })
          this.pagination.total = result.data.totalItems
          this.pagination.current = pageNumber
        })
        .catch(error => {
        })
      this.loading = false
    },
    buttonEvent (item, action) {
      switch (action) {
        case 'delete':
          alert('deleted')
          break
        case 'status':
          var activity = 'disabled'
          if(item.status)
            activity = 'activated'
          alert(activity)
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
