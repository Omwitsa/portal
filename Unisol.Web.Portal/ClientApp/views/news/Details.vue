<template>
<div class="page-body">
    <div class="col-lg-12 " style="padding: 0px 0px;">
        <div class="card user-card">
            <div class="card-header">
                <h5>{{title}}</h5>
            </div>
            <div class="card-block">
                <div class="top-cap-text" v-html="news.newsBody"></div>
            </div>
            <div class="card-footer">
                News Type: <div class="m-r-30 badge badge-primary">{{news.portalNewsType.newsTypeName}}</div>
                Date Created: <div class="m-r-30 badge badge-primary">{{NewDateCreated}}</div>
            </div>
        </div>
    </div>
</div>
</template>
<script>
import END_POINTS from "../../components/constants/EndPoints"
import DateFomatter from "../../components/constants/DateFomatter"
export default {
  data() {
    return {
      news: {},
      roles: END_POINTS.ROLES,
      subTitle: "",
      NewDateCreated: ""
    }
  },
  created() {
    if (this.$route.params.id) {
      this.edit = true     
      this.getNewsDetails(this.$route.params.id)  
    }
  },
  methods: {
    getNewsDetails(id) {
      this.$http
        .get(END_POINTS.GETNEWSDETAILS + "/?id=" + id)
        .then(response => {
          this.news = {}
          if (response.data.success) {
            this.news = response.data.data
            this.NewDateCreated = DateFomatter.ReturnDate(this.news.dateCreated)
          } else {
            this.$toastr("error", response.data.message)
          }
        })
        .catch(e => {
          this.$toastr("error", e.message)
        })
    },
    routeTo(to) {
      if (to) {
        this.$router.replace({ name: to })
      }
    },
  },
  computed: {
    title() {
        return 'Details: ' + this.news.newsTitle
    },
  }
}
</script>

<style>
</style>