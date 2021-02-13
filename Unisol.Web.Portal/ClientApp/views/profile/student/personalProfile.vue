<template>
  <div class="page-body">
    <loading-spinner :loading="loading"></loading-spinner>
    <div class="card" v-if="!loading">
      <div class="card-header">Personal Information</div>
      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">REGISTRATION NUMBER</div>
          <div class="col-md-6">{{ ": "+ personalData.admnNo }}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">NAME</div>
          <div class="col-md-6">{{ ": "+ personalData.names }}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">PROGRAMME</div>
          <div class="col-md-6">{{ ": "+ personalData.programme }}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">NATIONAL ID</div>
          <div class="col-md-6">{{ ": "+ personalData.nationalId}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">DATE OF BIRTH</div>
          <div class="col-md-6">{{ ": "+ personalData.dob}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">GENDER</div>
          <div class="col-md-6">{{ ": "+ personalData.gender}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">MARITAL STATUS</div>
          <div class="col-md-6">{{ ": "+ personalData.marital}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">NATIONALITY</div>
          <div class="col-md-6">{{ ": "+ personalData.nationality}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">RELIGION</div>
          <div class="col-md-6">{{ ": "+ personalData.religion}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">SOURCE</div>
          <div class="col-md-6">{{ ": "+ personalData.source}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">DISABILITY</div>
          <div class="col-md-6">{{ ": "+ personalData.disability}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="!loading && !isEditContacts">
      <div class="card-header">
        <div class="row">
          <div class="col-md-9">
            <h5>Contacts</h5>
          </div>
          <div class="col-md-2">
            <li v-if="!isEditDependants && !isEditOthers && !isEditEmergency && !isEmbu"
              class="btn btn-primary btn-round pull-right waves-effect waves-light"
              @click="editContacts"
            >Edit</li>
          </div>
        </div>
      </div>
      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">TELEPHONE NUMBER</div>
          <div class="col-md-6">{{ ": "+ personalData.telno}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">EMAIL</div>
          <div class="col-md-6">{{ ": "+ personalData.email}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">HOME ADDRESS</div>
          <div class="col-md-6">{{ ": "+ personalData.homeaddress}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">COUNTY</div>
          <div class="col-md-6">{{ ": "+ personalData.county}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">DOMICILE</div>
          <div class="col-md-6">{{ ": "+ personalData.domicile}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">SUBCOUNTY</div>
          <div class="col-md-6">{{ ": "+ personalData.subCounty}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">CONSTITUENCY</div>
          <div class="col-md-6">{{ ": "+ personalData.constituency}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="isEditContacts">
      <div class="card-header">Edit Contacts</div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Telephone number"
                  placeholder="Telephone number"
                  v-model="contactDetails.telno"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Email"
                  placeholder="Email"
                  v-model="contactDetails.email"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Home Address"
                  placeholder="Home Address"
                  v-model="contactDetails.homeaddress"
                />
              </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="COUNTY"
                  placeholder="COUNTY"
                  v-model="personalData.county"
                  disabled
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="DOMICILE"
                  placeholder="DOMICILE"
                  v-model="personalData.domicile"
                  disabled
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="SUBCOUNTY"
                  placeholder="SUBCOUNTY"
                  v-model="personalData.subCounty"
                  disabled
                />
              </div>
              
            </div>
            <div class="row">
                <div class="col-md-4">
                <fg-input
                  type="text"
                  label="CONSTITUENCY"
                  placeholder="CONSTITUENCY"
                  v-model="personalData.constituency"
                  disabled
                />
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10"></div>
          <div>
            <ul role="menu" aria-label="Pagination">
              <div
                class="btn btn-primary btn-round waves-effect waves-light"
                :loading="submitting"
                @click="updateContacts()"
              >Update</div>&nbsp;
              <div
                class="btn btn-inverse btn-round pull-right waves-effect waves-light"
                @click="isEditContacts = false"
              >Cancel</div>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <div class="card" v-if="!loading && !isEditEmergency">
      <div class="card-header">
        <div class="row">
          <div class="col-md-9">
            <h5>Emergency Contacts</h5>
          </div>
          <div class="col-md-2">
            <li v-if="!isEditContacts && !isEditOthers && !isEditDependants"
              class="btn btn-primary btn-round pull-right waves-effect waves-light"
              @click="editEmergency"
            >Edit</li>
          </div>
        </div>
      </div>
      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">Name</div>
          <div class="col-md-6">{{ ": "+ personalData.emname}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Relationship</div>
          <div class="col-md-6">{{ ": "+ personalData.emrel}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">TelNo</div>
          <div class="col-md-6">{{ ": "+ personalData.emtel}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Email</div>
          <div class="col-md-6">{{ ": "+ personalData.ememail}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Address</div>
          <div class="col-md-6">{{ ": "+ personalData.emaddress}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Remarks</div>
          <div class="col-md-6">{{ ": "+ personalData.emremarks}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="isEditEmergency">
      <div class="card-header">Edit Emergency contacts</div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Name"
                  placeholder="Name"
                  v-model="contactDetails.emergencyName"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Relationship"
                  placeholder="Relationship"
                  v-model="contactDetails.emergencyRelationShip"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Tel No"
                  placeholder="Tel No"
                  v-model="contactDetails.emergencyTelNo"
                />
              </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Email"
                  placeholder="Email"
                  v-model="contactDetails.emergencyEmail"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Address"
                  placeholder="Address"
                  v-model="contactDetails.emergencyAddress"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Remarks"
                  placeholder="Remarks"
                  v-model="contactDetails.emergencyRemarks"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10"></div>
          <div>
            <ul role="menu" aria-label="Pagination">
              <div
                class="btn btn-primary btn-round waves-effect waves-light"
                :loading="submitting"
                @click="updateContacts()"
              >Update</div>&nbsp;
              <div
                class="btn btn-inverse btn-round pull-right waves-effect waves-light"
                @click="isEditEmergency = false"
              >Cancel</div>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <div class="card" v-if="!loading && dependants && !isEditDependants">
      <div class="card-header">
        <div class="row">
          <div class="col-md-9">
            <h5>Dependants</h5>
          </div>
          <div class="col-md-2">
            <li v-if="!isEditContacts && !isEditOthers && !isEditEmergency"
              class="btn btn-primary btn-round pull-right waves-effect waves-light"
              @click="editDependants"
            >Edit</li>
          </div>
        </div>
      </div>
      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">Name</div>
          <div class="col-md-6">{{ ": "+ dependants.names}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Relationship</div>
          <div class="col-md-6">{{ ": "+ dependants.relationship}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Gender</div>
          <div class="col-md-6">{{ ": "+ dependants.gender}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Tel No.</div>
          <div class="col-md-6">{{ ": "+ dependants.tel}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Occupation</div>
          <div class="col-md-6">{{ ": "+ dependants.occupation}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Notes</div>
          <div class="col-md-6">{{ ": "+ dependants.notes}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="isEditDependants">
      <div class="card-header">Edit Dependants</div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Name"
                  placeholder="Name"
                  v-model="contactDetails.dependantName"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Relationship"
                  placeholder="Relationship"
                  v-model="contactDetails.dependantRelationShip"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Gender"
                  placeholder="Gender"
                  v-model="contactDetails.dependantGender"
                />
              </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Tel No."
                  placeholder="Tel No"
                  v-model="contactDetails.dependantTelNo"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Occupation"
                  placeholder="Occupation"
                  v-model="contactDetails.dependantOccupation"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Notes"
                  placeholder="Notes"
                  v-model="contactDetails.dependantNotes"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10"></div>
          <div>
            <ul role="menu" aria-label="Pagination">
              <div
                class="btn btn-primary btn-round waves-effect waves-light"
                :loading="submitting"
                @click="updateContacts()"
              >Update</div>&nbsp;
              <div
                class="btn btn-inverse btn-round pull-right waves-effect waves-light"
                @click="isEditDependants = false"
              >Cancel</div>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <div class="card" v-if="!loading && !isEditOthers">
      <div class="card-header">
        <div class="row">
          <div class="col-md-9">
            <h5>Other Details</h5>
          </div>
          <div class="col-md-2">
            <li v-if="!isEditDependants && !isEditContacts && !isEditEmergency"
              class="btn btn-primary btn-round pull-right waves-effect waves-light"
              @click="editOthers"
            >Edit</li>
          </div>
        </div>
      </div>
      <div class="card-block">
        <div class="row col-md-12">
          <div class="col-md-3">Language</div>
          <div class="col-md-6">{{ ": "+ personalData.language}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Medical</div>
          <div class="col-md-6">{{ ": "+ personalData.special}}</div>
        </div>
        <div class="row col-md-12">
          <div class="col-md-3">Co-Curricular</div>
          <div class="col-md-6">{{ ": "+ personalData.activity}}</div>
        </div>
      </div>
    </div>

    <div class="card" v-if="isEditOthers">
      <div class="card-header">Edit Other Details</div>
      <div class="card-block">
        <div class="row">
          <div class="col-md-12">
            <div class="row">
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Language"
                  placeholder="Language"
                  v-model="contactDetails.language"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Medical"
                  placeholder="Medical"
                  v-model="contactDetails.medical"
                />
              </div>
              <div class="col-md-4">
                <fg-input
                  type="text"
                  label="Co-Curricular"
                  placeholder="Co-Curricular"
                  v-model="contactDetails.activity"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10"></div>
          <div>
            <ul role="menu" aria-label="Pagination">
              <div
                class="btn btn-primary btn-round waves-effect waves-light"
                :loading="submitting"
                @click="updateContacts()"
              >Update</div>&nbsp;
              <div
                class="btn btn-inverse btn-round pull-right waves-effect waves-light"
                @click="isEditOthers = false"
              >Cancel</div>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import DateFomatter from "../../../components/constants/DateFomatter";
export default {
  data() {
    return {
      user: {},
      contactDetails: {},
      personalData: {},
      dependants: {},
      settings: JSON.parse(localStorage.getItem("settings")),
      loading: false,
      isEmbu: false,
      isEditContacts: false,
      isEditEmergency: false,
      isEditDependants: false,
      isEditOthers: false,
      editOperation: 1,
      submitting: false
    }; 
  },
  methods: {
    editContacts() {
      this.editOperation = 1
      this.isEditContacts = true;
      this.contactDetails.AdmnNo = this.user.username;
      this.contactDetails.telno = this.personalData.telno;
      this.contactDetails.homeaddress = this.personalData.homeaddress;
      this.contactDetails.email = this.personalData.email;
    },
    editEmergency(){
      this.editOperation = 4
      this.isEditEmergency = true
      this.contactDetails.AdmnNo = this.user.username;
      this.contactDetails.emergencyName = this.personalData.emname
      this.contactDetails.emergencyRelationShip = this.personalData.emrel
      this.contactDetails.emergencyTelNo = this.personalData.emtel
      this.contactDetails.emergencyEmail = this.personalData.ememail
      this.contactDetails.emergencyAddress = this.personalData.emaddress
      this.contactDetails.emergencyRemarks = this.personalData.emremarks
    },
    editDependants(){
      this.editOperation = 2
      this.isEditDependants = true
      this.contactDetails.dependantName = this.dependants.names
      this.contactDetails.dependantRelationShip = this.dependants.relationship
      this.contactDetails.dependantGender = this.dependants.gender
      this.contactDetails.dependantTelNo = this.dependants.tel
      this.contactDetails.dependantOccupation = this.dependants.occupation
      this.contactDetails.dependantNotes = this.dependants.notes
      this.contactDetails.AdmnNo = this.user.username;
    },
    editOthers(){
      this.editOperation = 3
      this.isEditOthers = true
      this.contactDetails.AdmnNo = this.user.username;
      this.contactDetails.language = this.personalData.language
      this.contactDetails.medical = this.personalData.special
      this.contactDetails.activity = this.personalData.activity
    },
    updateContacts() {
      this.submitting = true;
      this.$http.post(`profile/editStudentProfile?editOperation=${this.editOperation}`, this.contactDetails)
        .then(response => {
          if (response.data.success) {
            this.submitting = false;
            this.isEditContacts = false;
            this.isEditDependants = false; 
            this.isEditOthers = false;
            this.isEditEmergency = false
            this.loadPersonalInfo();

            this.$toastr("success", "Success");
          } else {
            this.$toastr("success", response.data.message);
            this.loadPersonalInfo();
          }
        })
        .catch(e => {
          this.submitting = false;
          this.$toastr("error", e.message);
        });
    },
    loadPersonalInfo() {
      this.loading = true;
      this.$http
        .get("profile/getStudentData?userCode=" + this.user.username)
        .then(result => {
          if (result.data.success) {
            this.personalData = result.data.data.register;
            this.dependants = result.data.data.dependants;
            this.personalData.dob = DateFomatter.ReturnDate(
              this.personalData.dob
            );
            this.personalData.createdate = DateFomatter.ReturnDate(
              this.personalData.createdate
            );
          } else {
            this.$toastr("error", result.data.message);
          }
          this.loading = false;
        })
        .catch(error => {
          this.loading = false;
          this.$toastr("error", error.message);
        });
    }
  },
  created() {
    this.user = this.$baseRead("user");
    this.isEmbu = this.settings.initials == "UOEM"
    this.loadPersonalInfo();
  }
};
</script>
<style scoped>
.list-group-item {
  border-left: none !important;
  border-right: none !important;
}
.col-md-3 {
  font-weight: bold;
}
</style>
