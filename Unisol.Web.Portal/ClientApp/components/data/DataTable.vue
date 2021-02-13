<template>
  <div class="card">
    <div class="card-header">
      <div class="row">
        <div class="col-md-7">
          <h5>{{title}}</h5>
          <span v-if="subTitle">{{subTitle}}</span>
        </div>
        <div class="col-md-2">
          <button v-if="confirmAccounts" class="btn btn-primary btn-round waves-effect waves-light" @click="accountsConfimation()">{{btnConfirm}}</button>
        </div>
        <div class="col-md-3">
          <submit-button 
          v-if="updateEmails"
          styling="btn btn-primary btn-round waves-effect waves-light" 
          :loading="submitting" 
          :title="btnUpdateEmails"
          v-on:submit="updateErpEmails" />
          <!-- <button v-if="updateEmails" class="btn btn-primary btn-round waves-effect waves-light" @click="updateErpEmails()">{{btnUpdateEmails}}</button> -->
        
          <!-- <button v-if="updateEmails" class="btn btn-primary btn-round waves-effect waves-light" @click="updateErpEmails()">{{btnUpdateEmails}}</button> -->
        </div>
      </div>
    </div>
    <div class="card-block">
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 pull-left">
          <div v-if="!confirmAll">
            <router-link
              v-for="(button,index) in headerActions"
              :to="button.path"
              :key="index"
              :class="btnStyling(button.design)"
            >
              <icon :icon="button.icon" />
              {{ button.name }}
            </router-link>
          </div>
        </div>

        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 offset-md-2">
          <div class="input-group">
            <input
              type="text"
              v-model="searchText"
              @keyup="getText"
              class="form-control"
              placeholder="Search here"
            />
            <span class="input-group-append">
              <label class="input-group-text">Search</label>
            </span>
          </div>
        </div>
      </div>
    </div>

    <div class="card-block table-border-style">
      <div class="table-responsive">
        <table class="table table-hover table-sm custom-data-table">
          <!-- <table id="order-table" class="table table-styling"> -->
          <thead class="table-primary text-white">
            <th
              v-for="(column, index) in columns"
              :key="index"
              @click="sortTable.sort(concatenateHeader(column.name))"
            >
              {{column.name}}
              <span class="arrow" :class="sortTable.currentSortDir"></span>
            </th>
            <th v-if="tableActions.length > 0">Actions</th>
          </thead>
          <tbody>
            <tr
              v-for="(item,index) in sortedItems"
              :key="index"
              :style="styleRow(item.tableRowColor)"
            >
              <td
                v-for="(column,index) in columns"
                :key="index"
                v-if="hasValue(item, column)"
                v-html="itemValue(item, column)"
              ></td>
              <td v-if="tableActions.length > 0">
                <list-button :item="item" :actions="tableActions" v-on:listButtonEvent="relay"></list-button>
              </td>
            </tr>
          </tbody>
          <tfoot class="table-primary text-white" v-if="showFooter">
            <th v-for="(column,index) in columns" :key="index">{{column.name}}</th>
            <th v-if="tableActions.length > 0">Actions</th>
          </tfoot>
        </table>
      </div>
    </div>

    <div class="card-footer">
      <paginate
        prev-text="Previous"
        container-class="pagination pull-right"
        page-class="page-item"
        prev-class="page-item"
        next-class="page-item"
        prev-link-class="page-link"
        next-link-class="page-link"
        page-link-class="page-link"
        :click-handler="goToPage"
        :page-count="totalPages"
      ></paginate>
      <div class="pull-left">
        <select v-model="itemsPerPage" v-on:change="changeItems" class="form-control">
          <option selected :value="5">5</option>
          <option :value="10">10</option>
          <option :value="50">50</option>
          <option :value="100">100</option>
        </select>
        <label>Page {{totalPages}} Size:{{itemsPerPage}}</label>
      </div>
    </div>
  </div>
</template>
<script>
import ListButton from "./ListButton";
import SortTable from "../constants/SortTable";
// import { EventBus } from '../../app.js';
export default {
  data() {
    return {
      sortTable: SortTable,
      searchText: "",
      btnConfirm: "Unconfirmed accounts",
      btnUpdateEmails: "Update Emails from ERP",
      submitting:false,
      confirmAll: false
    };
  },
  components: {
    ListButton
  },
  props: {
    tableActions: Array,
    headerActions: Array,
    pagination: Object,
    title: {
      type: String,
      default: ""
    },
    itemsPerPage: {
      type: Number,
      default: 10
    },
    columns: Array,
    data: Array,
    subTitle: {
      type: String,
      default: ""
    },
    showFooter: {
      type: Boolean,
      default: false
    },
    color: String,
    confirmAccounts: Boolean,
    updateEmails: Boolean,
  },
  computed: {
    totalPages: function() {
      return Math.ceil(this.pagination.total / this.itemsPerPage);
    },
    sortedItems: function() {
      if (this.data) {
        return this.data.sort((a, b) => {
          let modifier = 1;
          if (this.sortTable.currentSortDir === "dsc") modifier = -1;
          if (a[this.sortTable.currentSort] < b[this.sortTable.currentSort])
            return -1 * modifier;
          if (a[this.sortTable.currentSort] > b[this.sortTable.currentSort])
            return 1 * modifier;
          return 0;
        });
      }
    }
  },
  methods: {
    accountsConfimation(){
      if(this.confirmAll){
        this.confirmAllAccounts();
      }
      
      this.btnConfirm = "Confirm All";
      this.confirmAll = true;
      var Unconfirmed = true;
      this.$emit("loadData", this.itemsPerPage, this.pagination.current, Unconfirmed);
    },
    updateErpEmails(){
      this.submitting = true
      this.$http.get("users/updatePortalEmails")
      .then(response => {
        this.submitting = false
        if (response.data.success) {
          this.$toastr("success", response.data.message);
        } else {
          this.$toastr("error", response.data.message);
        }
        this.$emit("loadData", this.itemsPerPage, this.pagination.current);
      })
      .catch(e => {
        this.submitting = false
        this.$toastr("error", e.message);
      });
    },
    confirmAllAccounts(){
      this.$http.get("users/adminconfirmpassword")
      .then(response => {
        if (response.data.success) {
          this.confirmAll = false;
          this.btnConfirm = "Unconfirmed accounts";
          this.$toastr("success", response.data.message);
        } else {
          this.$toastr("error", response.data.message);
        }
        this.$emit("loadData", this.itemsPerPage, this.pagination.current);
      })
      .catch(e => {
        this.$toastr("error", e.message);
      });
    },
    getText() {
      this.$emit("searchByText", this.searchText);
    },
    hasValue(item, column) {
      return item[this.concatenateHeader(column.name)] !== "undefined";
    },
    btnStyling(design) {
      return `btn btn-${design} btn-round waves-effect waves-light pull-left`;
    },
    styleRow(color) {
      return ` background-color: ${color}`;
    },
    itemValue(item, column) {
      var itemVal = this.concatenateHeader(column.name);
      var value = item[this.concatenateHeader(column.name)];
      var display = "";
      switch (column.type) {
        case "text":
          display =  '<span class="text-right">' + value + "</span>";;
          break;

        case "currency":
          display = '<span class="text-right">' + value + "</span>";
          break;

        case "centered":
          display = '<span class="text-right">' + value + "</span>";
          break;

        case "numeric":
          display = '<span class="text-right">' + value + "</span>";
          break;

        case "badge":
          display = '<label class="label label-primary">' + value + "</label>";
          break;

        case "code":
          display = "<code>" + value + "</code>";
          break;
        case "story":
          display = "<small>" + value + "</small>";
          break;

        default:
          display = value;
          break;
      }
      return display;
    },
    changeItems() {
      this.goToPage(this.pagination.current);
    },
    goToPage(pageNum) {
      this.$emit("loadData", this.itemsPerPage, pageNum);
    },
    relay(item, action) {
      this.$emit("buttonEvent", item, action);
    },
    concatenateHeader(column) {
      column = column.replace(" ", "")
      column = column.replace("/", "")
      column = column.replace("(", "")
      column = column.replace(")", "")
      return column.toLowerCase();
    }
  }
};
</script>
<style>
.arrow {
  display: inline-block;
  vertical-align: middle;
  width: 0;
  height: 0;
  margin-left: 5px;
  opacity: 0.66;
}

.arrow.asc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-bottom: 4px solid #fff;
}

.arrow.dsc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-top: 4px solid #fff;
}
.custom-data-table {
  min-height: 130px;
}
</style>
