<template>
    <div class="page-body">
        <loading-spinner :loading="loading"></loading-spinner>
        <div class="card"  v-if="!loading">
            <div class="card-header">
                <h5>Personal Details</h5>
            </div>

            <div class="card-block" v-if="isAdmin">
                <ul class="list-group">
                    <li class="list-group-item" style="border-top: none;">
                       <div class="row col-md-12">
                            <div class="col-md-3">EMPLOYEE NUMBER</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.empNo)}}</div>
                       </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">NAME</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.names)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">GENDER</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.gender) }}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">DEPARTMENT</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.department)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">SECTION</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.section)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">LOCATION</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.location)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">ID NUMBER</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.idno)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">                      
                        <div class="row col-md-12">
                            <div class="col-md-3">HIRE DATE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.hdate)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">DATE OF BIRTH</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.dob)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">MARITAL STATUS</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.marital)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">KRA PIN</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.pin)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">NHIF</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.nhif)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">NSSF</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.nssf)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">RACE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.race)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">RELIGION</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.religion)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">SPOUSE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.spouse)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">DISABILTY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.disability)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">VISA</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.visa)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">LICENCE NUMBER</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.licNo)}}</div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">PCODE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.pcode)}}</div>
                        </div>
                    </li>
                    
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">JOB CATEGORY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.jobCat)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">EMPLOYEMENT CATEGORY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.empCat)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">SUPERVISOR</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.supervisor)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">PERSONNEL</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.personnel)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">CREATED DATE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.rdate)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">ACADEMIC RANK</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.academicRank)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">DIVISION</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.division)}}</div>
                        </div>
                    </li>
                   <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">ADATE</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.adate)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">LEAVE GROUP</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.leaveGroup)}}</div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>

        <div class="card"  v-if="!loading && !isEditContacts">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-9"> <h5> Contacts</h5> </div>
                    <div class="col-md-2">
                        <li class="btn btn-primary btn-round btn-sm pull-right waves-effect waves-light" @click="editContacts">Edit</li>
                    </div>
                </div>
            </div>
                <div class="card-block">
                <ul class="list-group">
                    <li class="list-group-item" style="border-top: none;">
                        <div class="row col-md-12">
                            <div class="col-md-3">CELL</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.cell)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">COUNTRY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.country)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">ADDRESS</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.address)}}</div>
                        </div>
                    </li> <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">CITY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.city)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">COUNTY</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.county)}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">EMAIL</div>
                            <div class="col-md-6">{{ ": "+ getData(personalData.pemail)}}</div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>

        <div class="card" v-if="isEditContacts">
            <div class="card-header">
                Edit Contacts
            </div>

            <div class="card-block">
                <div class="row"> 
                    <div class="col-md-12">
                        <fg-input
                            type="text"
                            label="Telephone number"
                            placeholder = "Telephone number"
                            v-model="contactDetails.Cell"
                        /> 
                        <fg-input
                            type="text"
                            label="COUNTRY"
                            placeholder = "COUNTRY"
                            v-model="contactDetails.Country"
                        />
                        <fg-input
                            type="text"
                            label="ADDRESS"
                            placeholder = "ADDRESS"
                            v-model="contactDetails.Address"
                        />
                        <fg-input
                            type="text"
                            label="CITY"
                            placeholder = "CITY"
                            v-model="contactDetails.City"
                        />  
                         <fg-input
                            type="text"
                            label="COUNTY"
                            placeholder = "COUNTY"
                            v-model="contactDetails.County"
                        />
                    </div>                  
                </div>
               <div class="row">
                   <div class="col-md-10"></div>
                   <div>
                        <ul role="menu" aria-label="Pagination">
                            <li class="btn btn-sm btn-primary" :loading="submitting" @click="updateContacts()">Update</li> 
                            <li class="btn btn-sm btn-inverse" @click ="isEditContacts = false">Cancel</li>
                        </ul>
                   </div>
               </div>
            </div>
        </div>

        <!-- <div class="card" v-if="!loading">
            <div class="card-header">
                <h5> Emergency cotacts</h5>
            </div>
            <div class="card-block">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">HOME ADDRESS</div>
                            <div class="col-md-6">{{ ": "+ personalData.homeaddress}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">COUNTY</div>
                            <div class="col-md-6">{{ ": "+ personalData.county}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">DOMICILE</div>
                            <div class="col-md-6">{{ ": "+ personalData.domicile}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">SUBCOUNTY</div>
                            <div class="col-md-6">{{ ": "+ personalData.subCounty}}</div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row col-md-12">
                            <div class="col-md-3">CONSTITUENCY</div>
                            <div class="col-md-6">{{ ": "+ personalData.constituency}}</div>
                        </div>
                    </li>
                </ul>
            </div>
        </div> -->
    </div>
</template>
<script>
import DateFomatter from "../../../components/constants/DateFomatter"
export default {
    data() {
        return {
            user: {},
            personalData: {},
            contactDetails: {},
            loading: false,
            isEditContacts: false,
            submitting: false,
            isAdmin: false
        }
    },
    methods: {
        getData(val){
            if(!val) val = "Not found"
            return val
        },
        editContacts(){
            this.isEditContacts = true 
            this.contactDetails.EmpNo = this.user.username   
            this.contactDetails.Cell = this.personalData.cell
            this.contactDetails.Country = this.personalData.country
            this.contactDetails.Address = this.personalData.address
            this.contactDetails.City = this.personalData.city
            this.contactDetails.County = this.personalData.county
        },  
        updateContacts(){
            this.submitting = true
            this.$http
            .post("profile/editStaffProfile", this.contactDetails)
            .then(response => {
            if (response.data.success) {
                this.submitting = false;
                this.isEditContacts = false;
                this.loadPersonalInfo();

                this.$toastr("success", "Success")
            } else {
                this.$toastr("error", response.data.message)
            }
            })
            .catch(e => {
                this.submitting = false
            this.$toastr("error", e.message)
            })
        },
        loadPersonalInfo(){
            if(this.user.role == 1) this.isAdmin = true
            this.loading = true
            this.$http
            .get("profile/getStaffData?userCode=" + this.user.username)
            .then(result => {
                if (result.data.success) {
                    // result.data.data.academicRank = "N/A"
                    this.personalData = result.data.data
                    this.personalData.hdate = DateFomatter.ReturnDate(this.personalData.hdate)
                    this.personalData.dob = DateFomatter.ReturnDate(this.personalData.dob)
                    this.personalData.rdate = DateFomatter.ReturnDate(this.personalData.rdate)
                    this.personalData.adate = DateFomatter.ReturnDate(this.personalData.adate)
                } else {
                    if(this.user.role == 2){
                        this.$toastr("error", result.data.message)
                    }
                }
                this.loading = false
            })
            .catch(error => {
                this.loading = false
                this.$toastr("error", error.message)
            })
        }
    },
    created() {
        this.user =  this.$baseRead('user')
        this.loadPersonalInfo()
    }
}
</script>
<style scoped>
.list-group-item{
    border-left : none !important;
    border-right : none !important;
  
}
.col-md-3{
    font-weight: bold;
}
</style>
