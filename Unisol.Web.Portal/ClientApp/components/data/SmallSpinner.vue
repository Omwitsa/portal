<template>
    <icon icon="spinner" v-if="isloading" pulse/>  
</template>
<script>
export default {
    props: {
        loading: {
            type: Boolean, 
            default: true
        },
    },
    computed: {
        isloading () {
            return this.loading
        }
    }
}
</script>

