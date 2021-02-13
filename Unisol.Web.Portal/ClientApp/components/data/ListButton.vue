<template>
    <div class="btn-group dropdown-split-primary">
        <button type="button" 
        class="btn btn-primary btn-sm dropdown-toggle dropdown-toggle-split"
        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <!-- <icon icon="cogs" />  -->
        <!-- <span class="sr-only">Toggle {{title}}</span> -->
        {{title}}
        </button>
        
        <div class="dropdown-menu">
            <a 
            v-for="(act, index) in actions" 
            :key="index" 
            class="dropdown-item"
            @click="activate(act)">
            {{act.name}}</a>
        </div>
    </div>
</template>
<script>
export default {
    props: {
        actions: Array,
        title: {
            type: String, 
            default: 'Actions'
        },
        item: Object
    },
    methods: {
        activate (activity) {
            if(activity.type == 'link') {
                var location = activity.path + '/' + this.item.id
                this.$router.push({ path: location })
            } else if(activity.type == 'button') {
                this.$emit("listButtonEvent", this.item, activity.path)
            }
        }
    }
}
</script>