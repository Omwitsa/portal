<template>
  <div class="form-group">
    <div class="input-group mb-3">
      <div class="input-group-prepend">
        <span class="input-group-text"><i :class="addonIcon"></i></span>
      </div>

      <input class="form-control border-input"
        v-bind="$attrs"
        :value="value"
        :type="type"
        @input="updateValue($event.target.value)"
        v-on:input="model=$event.target.value">
    </div>
  </div>
</template>

<script>
  export default {
    inheritAttrs: false,
    props: {
      value: [String, Number],
      label: String,
      type: String,
      addon: String
    },
    computed:{
        addonIcon () {
            return 'fa fa-'+this.addon
        }
    },
    methods: {
      updateValue (value) {
        this.$emit('input', String(value))
      }
    }
  }
</script>

<style>

</style>