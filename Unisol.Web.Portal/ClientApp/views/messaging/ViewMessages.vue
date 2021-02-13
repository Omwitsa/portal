<template>
    <div class="page-body">
        <div class="card">
            <div class="card-header" v-for="(message, index) in messages" :key="index">
                <h5>{{message.subject}}</h5>
                <div class="card-header-right">
                     <span>{{"From: " + message.from}}</span>
                    <span class="badge badge-primary">{{message.date}}</span>
                </div>
            </div>

            <div class="card-block" v-for="(message, index) in messages" :key="index">
                <div v-html="message.message"></div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            user: this.$baseRead('user'),
            messages: {}
        }
    },
    created(){
        this.messages = this.$route.params.message
    },
    methods: {
        
    }
}
</script>
<style>

</style>
