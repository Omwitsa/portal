<template>
    <div class="page-body">

        <loading-spinner :loading="loading"></loading-spinner>
        
        <data-table v-if="!loading" 
        :data="forecasts" 
        :columns="columns" 
        :tableActions="tableActions" 
        :headerActions="headerActions" 
        :subTitle="subTitle" 
        :title="title"
        :pagination="pagination"
        ></data-table>
    </div>
    <!-- <div>
        <template v-if="forecasts">
            <nav aria-label="...">
                <ul class="pagination justify-content-center">
                    <li :class="'page-item' + (currentPage == 1 ? ' disabled' : '')">
                        <a class="page-link" href="#" tabindex="-1" @click="loadPage(currentPage - 1)">Previous</a>
                    </li>
                    <li :class="'page-item' + (n == currentPage ? ' active' : '')" v-for="(n, index) in totalPages" :key="index">
                        <a class="page-link" href="#" @click="loadPage(n)">{{n}}</a>
                    </li>
                    <li :class="'page-item' + (currentPage < totalPages ? '' : ' disabled')">
                        <a class="page-link" href="#" @click="loadPage(currentPage + 1)">Next</a>
                    </li>
                </ul>
            </nav>
        </template>
    </div> -->
</template>

<script>
import { apiUtility } from "../store/api.js"

export default {
  computed: {
    totalPages: function() {
      return Math.ceil(this.total / this.pageSize)
    }
  },

  data() {
    return {
      forecasts: null,
      loading: true,
      title: "Weather forecast",
      subTitle: "This component demonstrates fetching data from the server.",
      total: 0,
      pageSize: 15,
      currentPage: 1,
      tableActions: [
        {
          name: "Edit",
          icon: "fa fa-pencil",
          type: "link",
          path: "edit",
          design: "success"
        },
        {
          name: "Delete",
          type: "button",
          icon: "fa fa-trash",
          path: "delete",
          design: "danger"
        }
      ],
      headerActions: [
        {
          name: "Add",
          icon: "fa fa-plus",
          type: "link",
          path: "add",
          design: "primary"
        },
        {
          name: "Import",
          type: "button",
          icon: "fa fa-download",
          path: "import",
          design: "inverse"
        }
      ],
      columns: [
        {
          name: "Date Created"
        },
        {
          name: "Summary"
        },
        {
          name: "Celcius"
        },
        {
          name: "Farhenheit"
        }
      ],
      pagination: {}
    }
  },

  methods: {
     loadPage(page) {
      this.loading = true
      this.currentPage = page
      var from = (page - 1) * this.pageSize
      var to = from + this.pageSize
      this.$http
        .get(`weather/forecasts?from=${from}&to=${to}`)
        .then(result => {
          this.forecasts = []
          var info = result.data.forecasts
          info.forEach(element => {
            var item = {
              datecreated: element.dateFormatted,
              summary: element.summary,
              celcius: element.temperatureC,
              farhenheit: element.temperatureF
            }
            this.forecasts.push(item)
          })
          this.pagination.total = result.data.total
        })
        .catch(error => {
          this.$toastr("error", error.message)
        })
      this.loading = false
    }
  },

   created() {
    this.loadPage(1)
  }
}
</script>

<style>
</style>
