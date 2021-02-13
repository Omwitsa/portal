<template>
    <div class="page-body">
        <div class="card" v-if="hasCleared">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2">
                        <button class="btn btn-primary btn-sm" @click="printCertificate()">
                            <i class="fa fa-print" style="color:white;"></i> print
                        </button>
                    </div>
                </div>
            </div>

            <div class="card-block" id="certificate">
                <div class="row">
                    <di4 class="col-md-4"></di4>
                    <div class="col-md-4 text-center">
                        <img :src="settings.logoImageUrl" :alt="settings.initials" width="40%" />
                    </div>
                </div>

                <div class="row" v-if="user.role === 3 && settings.initials != 'KIBU'">
                    <div class="col-md-12 text-center">
                        <h3>{{userDetails.orgName}}</h3><br>
                        <h5>{{certificateType}}</h5><br>
                        <p><i>This is to certify that Mr. / Miss/Mrs./Dr.</i></p>
                        <h5>{{userDetails.names}}</h5><hr>
                        <p>of Registration Number</p>
                        <strong>{{userDetails.userName}}</strong><hr>
                        <p>Cleared from the university on</p>
                        <strong>{{userDetails.finalDate}}</strong> <hr>
                        <p>Faculty / Institution / School</p>
                        <strong>{{userDetails.school}}</strong><br><br><br><br><br>

                        <div class="row">
                            <div class="col-md-4">
                                ______________________________ <br>
                                COLLEGE REGISTRAR
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                ______________________________ <br>
                                DATE
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" v-if="user.role === 3 && settings.initials == 'KIBU'">
                    <div class="col-md-12 text-center">
                        <h3>{{userDetails.orgName}}</h3><hr>
                        <h4>{{certificateType}}</h4>
                        <p>This is to confirm that:</p>
                        <h5>{{userDetails.names}} ({{userDetails.userName}})</h5>
                        <p>Holder of National Identity Card Number {{userDetails.nationalId}} was a student of {{userDetails.orgName}} with effect from {{userDetails.admissionDate}} up </p>
                        <p>to {{userDetails.finalDate}} in the {{userDetails.school}} taking {{userDetails.porgramme}} .The student has cleared with all </p>
                        <p>respective offices thus is authorized to pick his/her  certificate and transcripts.</p>
                        <p>This Certificate has been issued without any erasure or alteration whatsoever.</p>
                        <p>Signed for and on behalf of {{userDetails.orgName}}.</p><br>
                    </div>
                    
                    <div class="clearanceSignature">
                         &nbsp;&nbsp;&nbsp; ______________________________
                        <h5>&nbsp;&nbsp;&nbsp; REGISTRAR ACADEMIC AFFAIRS</h5>
                    </div>
                </div>
               
               <div class="row" v-if="user.role === 2">
                    <div class="col-md-12 text-center">
                        <h3>{{userDetails.orgName}}</h3><hr>
                        <h4>{{certificateType}}</h4>
                        <p>This is to confirm that:</p>
                        <h5>{{userDetails.names}} ({{userDetails.userName}})</h5>
                        <p>Holder of National Identity Card Number {{userDetails.nationalId}} was employed in the employment of {{userDetails.orgName}} with effect from </p>
                        <p>{{userDetails.admissionDate}} up to {{userDetails.finalDate}} on {{userDetails.employmentCategory}} terms as an</p>
                        <p> {{userDetails.jobTitle}} scale {{userDetails.rank}} ({{userDetails.department}} Department) stationed at {{userDetails.location}}</p>
                        <p>This Certificate has been issued without any erasure or alteration whatsoever.</p>
                        <p>Signed for and on behalf of {{userDetails.orgName}}.</p><br>
                    </div>
                   <div class="clearanceSignature">
                        &nbsp;&nbsp;&nbsp; ______________________________
                        <h5>&nbsp;&nbsp;&nbsp; Prof. Donald Namasaka Siamba</h5>
                        <h5>&nbsp;&nbsp;&nbsp; DEPUTY VICE CHANCELLOR (ADMINISTRATION, FINANCE & DEVELOPMENT)</h5>
                   </div>
                </div>
            </div>
        </div>

        <div class="card" v-if="!hasCleared">
            <div class="card-block alert-warning">
                <div> &nbsp;
                    <h5 class="text-center"> <i class="fa fa-exclamation-circle fa-5x"></i><br> To get your certificate, your clearance must have been approved </h5> 
                    &nbsp;
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import DateFomatter from "../../components/constants/DateFomatter";
export default {
    data() {
        return {
            userDetails: {},
            certificateType: "",
            user: this.$baseRead("user"),
            settings : JSON.parse(localStorage.getItem("settings")),
            hasCleared : false,
        }
    },
    methods: {
        getCertificateDetails(){
            var isStudent = this.user.role == 3 ? true : false
			this.$http.get("clearances/getCertificateDetails?usercode="+ this.user.username + "&isStudent="+isStudent)
			.then(result => {
                this.certificateType = result.data.certificateType
                this.certificateType = this.user.role == 2 ? "Certificate of Service" : this.certificateType
                result.data.usersDetails.certificateDetails.admissionDate = DateFomatter.ReturnDate(result.data.usersDetails.certificateDetails.admissionDate)
                result.data.usersDetails.certificateDetails.finalDate = DateFomatter.ReturnDate(result.data.usersDetails.certificateDetails.finalDate)
                this.userDetails = result.data.usersDetails.certificateDetails
                this.hasCleared = result.data.usersDetails.hasCleared
			})
			.catch(error => {
			    this.$toastr("error", error.message);
			});
        },
        printCertificate(){
            this.$htmlToPaper("certificate");
        }
    },
    created() {
		this.getCertificateDetails();
	}
}
</script>

<style>
    .clearanceSignature {
		margin-left: 10%
	}

    .certHeader{
        background-color:#e5e9d1
    }

    /* hr{
        background-color:#0a6eff;
        height:3px
    } */
</style>
