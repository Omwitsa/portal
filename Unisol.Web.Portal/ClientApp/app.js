import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import NavMenu from 'components/navmenu'
import GlobalComponents from './globalComponents'
import Paginate from 'vuejs-paginate'
import VueToastr from '@deveodk/vue-toastr'
import '@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css'
import VueSwal from 'vue-swal'
import VueSweetalert2 from 'vue-sweetalert2'
import BasePlugin from 'components/constants/BasePlugin'
import VJstree from 'vue-jstree'
import datepicker from 'vue-bootstrap-datetimepicker';
import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
import vSelect from 'vue-select'
import VueHtmlToPaper from 'vue-html-to-paper';
import IdleVue from 'idle-vue';
// import JsonExcel from 'vue-json-excel'

const ax = axios.create({
    baseURL: window.location.origin + "/api/"
})

ax.interceptors.request.use(function (config) {
  var u=localStorage.getItem("user")
  var user = (u.length>5) ? JSON.parse(atob(u)) : null
  if (user) {
    var token = user.token 
    config.headers.Authorization = `Bearer ${token}`
    return config
  } else {
    return config
  }
}, function (err) {
  return Promise.reject(err)
})

ax.interceptors.response.use(undefined, err => { 
  var data = {}
  if (typeof err.response !== 'undefined') {
    switch (err.response.status) {
      case 401:
        data.message = err.response.status + ' - ' + 'You are not authorised to perform this action'
        break

      case 404:
        data.message = err.response.status + ' - ' + 'Seems your connection is lost'
        break

      case 403:
        data.message = err.response.status + ' - ' + 'You are not authorised to perform this action'
        break

      case 500:
      data.message = 'Forbidden request'
        // data.message = err.response.status + ' - ' + 'Forbidden request'
        break

      default:
        if (typeof err.response.data === 'object') {
          data.message = err.response.status + ' ' + err.response.data.err || err.response.data.message
        } else {
          data.message = err.response.status + '- Something went wrong. Please try again.'
        }
        break
    }
  } else {
    data.message = 'An error occured attempting to execute the request. Please check your internet connection'
  }
  return Promise.reject(data)
})

const options = {
  name: '_blank',
  specs: [
    'fullscreen=yes',
    'titlebar=yes',
    'scrollbars=yes'
  ],
  styles: [
    'https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css',
    'https://unpkg.com/kidlat-css/css/kidlat.css'
  ]
}

Vue.use(VueHtmlToPaper, options)
Vue.prototype.$http = ax

Vue.use(BasePlugin) 
Vue.use(GlobalComponents)
Vue.use(pdfMake)
Vue.use(pdfFonts)
Vue.use(VJstree)
Vue.use(datepicker)
Vue.component('paginate', Paginate)
Vue.component('icon', FontAwesomeIcon)
Vue.component('v-select', vSelect)
Vue.use(VueSwal)
Vue.use(VueSweetalert2)
Vue.use(NavMenu)
// Vue.component('downloadExcel', JsonExcel)

Vue.use(VueToastr, {
  defaultPosition: 'toast-top-center',
  defaultType: 'info',
  defaultTimeout: 5000
  //https://github.com/Deveodk/vue-toastr
})

export const EventBus = new Vue();

Vue.use(IdleVue, {
  eventEmitter: EventBus,
  idleTime: 1000 * 60 * 10
})

sync(store, router)

const app = new Vue({
  store,
  router, 
  ...App
})

export {
  app,
  router,
  store
}
