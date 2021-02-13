<template>
    <div :class="styling" @click="submit">
        <icon v-if="loading" icon="spinner" pulse/>
        <icon v-if="displayIcon" :icon="icon" />
        {{title}}
    </div>
</template>
<script>
export default {
  props: {
    actions: Array,
    icon: null,
    title: {
      type: String,
      default: "Save"
    },
    styling: {
      type: String,
      default: "btn btn-sm btn-primary"
    },
    loading: false
  },
  computed: {
    displayIcon () {
        if (this.icon && !this.loading) {
            return true
        }
        return false
    }
  },
  methods: {
    submit(activity) {
      this.$emit("submit", this.item, activity.path)
    }
  }
}
</script>
<style scoped>
</style>


