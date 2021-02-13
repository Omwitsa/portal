<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{title}}</h5>
                <span v-if="subTitle">{{subTitle}}</span>
            </div>
        </div>

        <div class="card-block">
            <loading-spinner :loading="loading"></loading-spinner>
            <div class="row">
                <div class="col-md-12">
                    <div id="wizardc">
                        <section>
                            <form class="wizard-form wizard clearfix" id="design-wizard" action="#" role="application">
                                <div class="steps clearfix">
                                    <ul role="tablist">
                                        <li role="tab" :class="step == 1 ? 'first current' : 'first done'" aria-disabled="false" aria-selected="true">
                                        <a>
                                            <span v-if="step==1" class="current-info audible">current step: </span>
                                            <span class="number">Notes</span> 
                                        </a>
                                        </li>
                                        
                                        <li role="tab" :class="step == 2 ? 'current last' : 'done last'" aria-disabled="true">
                                        <a> 
                                            <span v-if="step==2" class="current-info audible">current step: </span>
                                            <span class="number">Add Item</span> 
                                        </a>
                                        </li>
                                    </ul>
                                </div>

                                <div class="content clearfix">
                                    <h3 id="design-wizard-h-0" tabindex="-1" class="title"></h3>
                                    <fieldset v-if="step==1" id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false" >
                                        <div class="row">
                                            <div class="col-md-1"></div>
                                            <div class="col-md-10">
                                                <div class="form-group"><br><br>
                                                <label for="exampleFormControlTextarea1"><h4>Notes</h4></label>
                                                <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" v-model="IRRequest.notes"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>

                                    <h3 id="design-wizard-h-1" tabindex="-1" class="title"></h3>
                                    <fieldset v-if="step==2" id="design-wizard-p-1" role="tabpanel" aria-labelledby="design-wizard-h-1" class="body current" aria-hidden="false" >
                                        <div v-if="isAddIR"  class="row">
                                            <div class="col-md-2"></div>
                                            <div class="col-md-8">
                                               <div class="row">
                                                    <div class="col-md-2">Qty
                                                    </div>
                                                    
                                                    <div class="col-md-8">
                                                    <input class="form-control border-input" v-model="IRRequest.quantity" type="number" min="0" oninput="validity.valid||(value='');"><br>
                                                    </div>
                                                </div>
<!-- 
                                                <div class="row">
                                                    <div class="col-md-2">Cost
                                                    </div>
                                                    <div class="col-md-8">
                                                    <input class="form-control border-input" v-model="IRRequest.unitamount" type="number" min="0" oninput="validity.valid||(value='');"><br>
                                                    </div>
                                                </div> -->

                                                <div class="row">
                                                    <div class="col-md-2">Description</div>
                                                    <div class="col-md-8">
                                                        <div class="form-group"> 
                                                            <v-select v-model="IRRequest.description" :options=irDescriptions @input="onChange($event)"></v-select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- <div class="row">
                                                    <div class="col-md-2">Amount</div>
                                                    <div class="col-md-8">
                                                        <button disabled="disabled" type="button" class="btn btn-secondary btn-block">{{totalAmount}}</button>
                                                    </div>
                                                </div><br> -->

                                                <div class="row">
                                                    <div class="col-md-2">UoM</div>
                                                    <div class="col-md-8">
                                                        <div class="form-group">
                                                            <v-select v-model="IRRequest.unitmeasure" :options=uom></v-select>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div><br>
                                        
                                        <div class="row">
                                            <div class="col-md-10"></div>
                                            <div class="col-md-2">
                                                <li class="btn btn-primary btn-round  pull-right waves-effect waves-light" @click="getAddState">{{btnText}}</li>
                                            </div>
                                        </div>
                                    
                                        <div v-if="!isAddIR" class="card-block table-border-style">
                                            <div class="table-responsive">
                                                <table class="table table-hover table-sm">
                                                    <thead class="table-primary text-white">
                                                        <th v-for="(column, index) in columns" :key="index"
                                                        @click="sortTable.sort(concatenateHeader(column.name))">
                                                            {{column.name}}
                                                            <span class="arrow" :class="sortTable.currentSortDir"></span>
                                                        </th>

                                                        <th v-if="tableActions.length > 0">Actions</th>
                                                    </thead>

                                                    <tbody>
                                                        <tr v-for="(item,index) in sortedItems" :key="index">
                                                            <td v-for="(column,index) in columns" :key="index" v-if="hasValue(item, column)" v-html="itemValue(item, column)">
                                                            </td>
                                                            <!-- <td v-if="tableActions.length > 0">
                                                                <list-button 
                                                                :item="item" 
                                                                :index="index" 
                                                                :actions="tableActions"
                                                                v-on:listButtonEvent="buttonEvent"
                                                                ></list-button>
                                                            </td> -->
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>

                                <div class="actions clearfix">
                                    <ul role="menu" aria-label="Pagination">
                                        <li v-if="step<2" class="btn btn-primary btn-round waves-effect waves-light " @click="next()">Next</li> 
                                        <li v-if="isNewIR" class="btn btn-inverse btn-round waves-effect waves-light " @click="previous()">Previous</li>

                                        <li v-if="step==2">
                                            <submit-button v-if="submitItemsPresent" title="Finish" 
                                            styling="btn btn-primary btn-round waves-effect waves-light "
                                            :loading="submitting" v-on:submit="save"></submit-button>
                                        </li>
                                    </ul>
                                </div>
                            </form>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import SortTable from "../../components/constants/SortTable"
export default {
    data(){
        return {
            subTitle: "",
            title: "", 
            loading: true,
            step: 1,
            IRRequest: {},
            uom: [],
            submitting: false,
            isCurrentView: false,
            procItems: [],
            irDescriptions: [],
            btnText: "Add Item",
            isNewIR: false,
            isAddIR: false,
            details: {},
            sortTable: SortTable,
            tableActions: [],
            submitItemsPresent: false,
            user: this.$baseRead('user'),
            IRitems: [],
            columns: [
                {
                name: "Quantity",
                },
                {
                name: "Description",
                },
                {
                name: "Unit of Measure",
                }
                // {
                // name: "Unit Amount",
                // },
                // {
                // name: "Total Amount",
                // }
            ],
        }
    },
    created(){
        this.loading = false
        this.IRRequest = JSON.parse(localStorage.getItem('raisedIr'))
        if(this.IRRequest.component == 'view') {
            this.title = "View IR"
            this.subTitle = "IR Items"
            this.isCurrentView = true
            this.step =2 
            this.viewIrItems()
        }
        if(this.step == 1){
            this.loading = false
        }
        this.getRaisedIr()
    },
    computed: {
        totalAmount: function () {
            return this.IRRequest.totalamount = this.IRRequest.quantity * this.IRRequest.unitamount 
        },
        sortedItems:function() {
            return this.IRitems.sort((a,b) => {
                let modifier = 1;
                if(this.sortTable.currentSortDir === 'dsc') modifier = -1;
                if(a[this.sortTable.currentSort] < b[this.sortTable.currentSort]) return -1 * modifier;
                if(a[this.sortTable.currentSort] > b[this.sortTable.currentSort]) return 1 * modifier;
                return 0;
            });
        }
    },
    methods: {
        viewIrItems(){
            this.loading = true
            this.$http.get("ir/getIRItems/?reqref=" + this.IRRequest.reference)
                .then(result => {
                    result.data.data.forEach(element => {
                        element.quantity = element.qty,
                        element.unitofmeasure = element.uoM,
                        element.unitamount = element.cost,
                        element.totalamount = element.amount,
                        element.description = element.description
                    })

                    this.IRitems = result.data.data
                    this.loading = false
                })
                .catch(error => {
                    this.loading = false
                })
            localStorage.removeItem("raisedIr")
        },
        onChange(event) {
            var items = event.split(':')
            var procItems = this.procItems.filter(function(item) {
                return item.code == items[0];
            });
            procItems.forEach(element => {
              this.uom.push(element.uom);
            });
        },
        hasValue (item, column) {
            return item[this.concatenateHeader(column.name)] !== 'undefined'
        },
        itemValue (item, column) {
            var value = item[this.concatenateHeader(column.name)]
            var display = ''
            switch (column.type) {
                case 'text':
                display = value 
                break;
                
                case 'currency':
                display = '<span class="text-right">'+value+'</span>' 
                break;

                case 'centered':
                display = '<span class="text-center">'+value+'</span>' 
                break;

                case 'numeric':
                display = '<span class="text-center">'+value+'</span>' 
                break;

                case 'badge':
                display = '<label class="label label-primary">'+value+'</label>' 
                break;
                
                case 'code':
                display = '<code>'+value+'</code>' 
                break;
            
                default:
                display =  value 
                    break;
            }
            return display
        },
        next: function() {
            this.isNewIR= true
            this.subTitle = "Add IR Items"
            this.step += 1
        },
        previous: function() {
            if(this.IRRequest.component == 'view') {
                this.step = 2
            }
            else{
                if (this.step > 1) {            
                    this.step -= 1           
                }
            }
        },
        concatenateHeader (column) {
            var columnArray = column.split(' ')
            if(columnArray.length > 1) column = columnArray.join("")
            return column.toLowerCase()
        },
        getAddState: function() { 
           this.btnText = "Save"
            if(this.isAddIR){
                if(!this.IRRequest.quantity || this.IRRequest.quantity < 1){
                    this.$toastr("error", "Quantity must be greater than zero")
                    return
                }

                if(!this.IRRequest.description){
                    this.$toastr("error", "Kindly provide item description")
                    return
                }

                this.isAddIR = false
                this.submitItemsPresent = true
                this.btnText = "Add Item"
                var IRitem = {
                    "quantity":  this.IRRequest.quantity,
                    "unitofmeasure": this.IRRequest.unitmeasure,
                    "unitamount": this.IRRequest.unitamount ? this.IRRequest.unitamount : "0",
                    "totalamount": this.IRRequest.totalamount ? this.IRRequest.totalamount : "0",
                    "description": this.IRRequest.description
                }
                this.details = {  
                    "Notes": this.IRRequest.notes,
                    "Usercode": this.user.username
                }

                if(this.isCurrentView){
                    this.IRitems = []
                    this.isCurrentView = false
                }

                this.IRitems.push(IRitem)

                this.IRRequest.quantity = ""
                this.IRRequest.unitamount = ""
                this.IRRequest.description = ""
                this.IRRequest.unitmeasure = ""
                this.totalAmount = ""
            }else{
                this.isAddIR = true
                this.btnText = "Save"
            }
        },
        save() {
            this.submitting = true
            this.submitItemsPresent = false
            this.IRitems.forEach(element => {
                element.unitmeasure = element.unitofmeasure
            });
            var ir = {
                "details":  this.details,
                "items": this.IRitems
            }
            this.$http
                .post("ir/createIR?usercode="+this.user.username, ir)
                .then(response => {
                if (response.data.success) {
                    this.$toastr("success", "Success")
                    this.$router.replace({ name: "internal-requisition" })
                } else {
                    this.$toastr("error", response.data.message)
                }
                    this.submitting = false
                })
                .catch(e => {
                this.$toastr("error", e.message)
                })

            this.loading = false
            localStorage.removeItem("raisedIr")
        },

        getRaisedIr(){
            this.$http.get("ir/getIR/?usercode=" + this.user.username)
            .then(result => {
                if (result.data.success) {
                    this.procItems = result.data.data.procItems
                    this.procItems.forEach(element => {
                        this.irDescriptions.push(`${element.code}: ${element.description}`);
                    });
                } 
                else {
                    this.$toastr("error", result.data.message);
                    if (result.data.notAuthenticated) {
                    this.$router.replace({ name: "401-forbidden" });
                    }
                }
                this.loading = false;
            })
            .catch(error => {
                this.loading = false;
            });
        }
    }
}
</script>
<style scoped>
.wizard {
  display: block;
  width: 100%;
  overflow: hidden;
}
.roleBtn {
  color: #fff;
}
/* Accessibility */
.wizard > .steps .current-info,
.tabcontrol > .steps .current-info {
  position: absolute;
  left: -999em;
}

.wizard > .content > .title,
.tabcontrol > .content > .title {
  position: absolute;
  left: -999em;
}

.wizard > .steps .number {
  font-size: 1.3em;
}

.wizard > .steps > ul > li {
  width: 50%;
}

.wizard > .steps > ul > li,
.wizard > .actions > ul > li {
  float: left;
}

.wizard > .steps a,
.wizard > .steps a:hover,
.wizard > .steps a:active {
  display: block;
  width: auto;
  margin: 0 0.5em 0.5em;
  padding: 1em 1em;
  text-decoration: none;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .steps .current a,
.wizard > .steps .current a:hover,
.wizard > .steps .current a:active {
  background: #2184be;
  color: #fff;
  cursor: default;
}

.wizard > .steps .done a,
.wizard > .steps .done a:hover,
.wizard > .steps .done a:active {
  background: #9dc8e2;
  color: #fff;
}

.wizard > .steps .error a,
.wizard > .steps .error a:hover,
.wizard > .steps .error a:active {
  background: #ff3111;
  color: #fff;
}

.wizard > .content {
  background: #fff;
  display: block;
  margin: 0.5em;
  min-height: 28em;
  position: relative;
  width: auto;

  -webkit-border-radius: 5px;
  -moz-border-radius: 5px;
  border-radius: 5px;
}

.wizard > .content > .body {
  float: left;
  position: absolute;
  width: 95%;
  height: 95%;
  padding: 2.5%;
}

.wizard > .actions {
  position: relative;
  display: block;
  text-align: right;
  width: 100%;
}

.wizard > .actions > ul {
  display: inline-block;
  text-align: right;
}

.wizard > .actions > ul > li {
  margin: 0 0.5em;
}
</style>