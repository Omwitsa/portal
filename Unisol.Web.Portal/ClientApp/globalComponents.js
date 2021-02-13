import fgInput from 'components/data/FormgroupInput.vue'
import DataTable from 'components/data/DataTable'
import LoadingSpinner from 'components/data/LoadingSpinner'
import SmallSpinner from 'components/data/SmallSpinner'
import AddonInput from 'components/data/AddonInput.vue'
import SubmitButton from 'components/data/SubmitButton.vue'
import ListButton from 'components/data/ListButton.vue'
/**
 * You can register global components here and use them as a plugin in your main Vue instance
 */

const GlobalComponents = {
    install(Vue) {
        Vue.component('fg-input', fgInput)
        Vue.component('data-table', DataTable)
        Vue.component('loading-spinner', LoadingSpinner)
        Vue.component('small-spinner', SmallSpinner)
        Vue.component('ao-input', AddonInput)
        Vue.component('submit-button', SubmitButton)
        Vue.component('list-button', ListButton)
    }
} 

export default GlobalComponents