<template>
    <div v-if="isloading" class="text-center">
            
            <h1><icon icon="spinner" pulse/></h1>  
            <p>Loading...</p>
    </div>
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

