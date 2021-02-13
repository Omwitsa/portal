import NavMenu from './NavMenu.vue'

const NavMenuStore = {
    navmenuLinks: [
        {
            display: 'Dashboards',
            icon: 'fa fa-home',
            children: [
                {
                    display: 'Student Dashboard',
                    path: 'student-dashboard'
                },
                {
                    display: 'Admin Dashboard',
                    path: 'home'
                },
            ]
        },
        {
            display: 'Data Centre',
            icon: 'fa fa-bank',
            children: [
                {
                    display: 'Counter',
                    path: 'counter'
                },
                {
                    display: 'Data',
                    path: 'fetch-data'
                },
            ]
        }    
    ],
}

const NavMenuPlugin = {

    install(Vue) {
        Vue.mixin({
            data() {
                return {
                    navmenuStore: NavMenuStore
                }
            }
        })

        Object.defineProperty(Vue.prototype, '$navmenu', {
            get() {
                return this.$root.navmenuStore
            }
        })
        Vue.component('nav-menu', NavMenu)
    }
}

export default NavMenuPlugin