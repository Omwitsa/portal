<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header">
                <h5>{{ title }}</h5>
                <span v-if="subTitle">{{ subTitle }}</span>
            </div>

            <div class="card-block" v-if="!isDetails">
                <div class="row">
                    <div class="col-md-2">
                        Type
                    </div>
                    <div class="col-md-4">
                        <v-select
                            :options="types"
                            v-model="publication.type"
                        ></v-select>
                    </div>

                    <div class="col-md-2">
                        Title
                    </div>
                    <div class="col-md-4">
                        <input v-model="publication.title" type="text" class="form-control"/>
                    </div>
                </div><br>
                
                <div v-if="publication.type">
                    <div class="row">
                        <div class="col-md-2">
                            Publication Year
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.year" type="text" class="form-control"/>
                            <!-- <date-picker v-model="publication.year" minimum-view="year"></date-picker> -->
                        </div>

                        <div class="col-md-2">
                            Link
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.Url" type="text" class="form-control"/>
                        </div>
                    </div><br>

                    <div class="row" v-if="publication.type == 'Book' || publication.type == 'Book chapter'">
                        <div class="col-md-2">
                            Book ISBN
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.bookISBN" type="text" class="form-control"/>
                        </div>

                        <div class="col-md-2">
                            Publisher
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.publisher" type="text" class="form-control"/>
                        </div>
                    </div> <br>

                    <div class="row">
                        <div class="col-md-2">
                            Upload File
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <input class="form-control" type="file"  @change="fileChanged">
                            </div>
                        </div>

                        <div class="col-md-2" v-if="publication.type == 'Book'">
                            Place of publication
                        </div>
                        <div class="col-md-4" v-if="publication.type == 'Book'">
                            <input v-model="publication.publicationPlace" type="text" class="form-control"/>
                        </div>

                        <div class="col-md-2" v-if="publication.type == 'Article'">
                            Journal Title
                        </div>
                        <div class="col-md-4" v-if="publication.type == 'Article'">
                            <input v-model="publication.journalTitle" type="text" class="form-control"/>
                        </div>

                        <div class="col-md-2" v-if="publication.type == 'Book chapter'">
                            Book Title
                        </div>
                        <div class="col-md-4" v-if="publication.type == 'Book chapter'">
                            <input v-model="publication.bookTitle" type="text" class="form-control"/>
                        </div>
                    </div><br>

                    <div class="row" v-if="publication.type == 'Book chapter'">
                        <div class="col-md-2">
                            From Page
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.fromPage" type="text" class="form-control"/>
                        </div>

                        <div class="col-md-2">
                            To Page
                        </div>
                        <div class="col-md-4">
                            <input v-model="publication.toPage" type="text" class="form-control"/>
                        </div>
                    </div><br>
                </div>
            </div>

            <div class="card-footer" v-if="!isDetails">
                <div class="pull-right">
                <button
                    class="btn btn-primary btn-round waves-effect waves-light" 
                    :loading="submitting"
                    @click.prevent="save"
                >Submit</button>
                </div>
            </div>

            <div class="card-block" v-if="isDetails" > 
                <div class="row">
                    <div class="col-md-12">
                        <p><strong>Title: </strong>{{publication.title}}</p>
                        <p><strong>Type: </strong>{{publication.type}}</p>
                        <p><strong>Author: </strong>{{publication.name}}({{publication.author}})</p>
                        <p><strong>Year: </strong>{{publication.year}}</p>
                        <p v-if="publication.fromPage"><strong>From Page: </strong> {{publication.fromPage}}</p>
                        <p v-if="publication.toPage"><strong>To Page: </strong>{{publication.toPage}}</p>
                        <p v-if="publication.publisher"><strong>Publisher: </strong>{{publication.publisher}}</p>
                        <p v-if="publication.publicationPlace"><strong>Place of publication: </strong>{{publication.publicationPlace}}</p>
                        <p v-if="publication.bookISBN"><strong>Book ISBN: </strong>{{publication.bookISBN}}</p>
                        <p v-if="publication.journalTitle"><strong>Journal Title: </strong>{{publication.journalTitle}}</p>
                        <p v-if="publication.bookTitle"><strong>Book Title: </strong>{{publication.bookTitle}}</p>
                        <button v-if="publication.fileUrl" @click="download()">Download Document</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return { 
            title : "Add Publication",
            subTitle : "",
            submitting: false,
            publication: {},
            isDetails: false,
            submitting: false,
            user: this.$baseRead('user'),
            types: ['Book', 'Book chapter', 'Article', 'Journal', 'Autography']
        }
    },
    methods: {
        download(){
            var url = `${window.location.origin}/${this.publication.fileUrl}`
            window.open(url, "_blank");
        },
        fileChanged(event) {
            this.publication.documents = event.target.files[0]
        },
        uploadDocument(){
            const formData = new FormData()
            formData.append("publication", this.publication.documents, this.publication.documents.name)
            this.$http.post(`research/uploadDocument?usercode=${this.user.username}&operation=publication`, formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }})
            .then(response => {
                this.submitting = false
                if (response.data.success) {
                } else {
                    this.$toastr("error", response.data.message)
                }
            })
            .catch(e => {
                this.submitting = false
                this.$toastr("error", e.message)
            })
        },
        save(){
            this.submitting = true;
            this.publication.author = this.user.username
            this.$http.post("research/createPublication", this.publication)
            .then(response => {
                this.submitting = false;
                if (response.data.success) {
                    if(this.publication.documents){
                        this.uploadDocument()
                    }
                    this.$toastr('success', response.data.message);
                    this.$router.replace({ name: 'publication' });
                } else {
                    this.$toastr('error', response.data.message);
                }
            })
            .catch(e => {
                this.submitting = false;
                this.$toastr('error', e.message);
            });
        }
    },
    created(){
        if(this.$route.params.id){
            this.isDetails = true
            this.title = 'Details'
            this.publication = this.$route.params
        }
    }
}
</script>

<style>

</style>
