<template>

    <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
        <fg-input type="text"
                  label="Section Name"
                  placeholder="Section Name"
                  v-model="sections.sectionName" />
        <fg-input type="text"
                  label="Description"
                  placeholder="Evaluation Desc"
                  v-model="sections.sectionDesc" />

    </fieldset>

</template>
<script>
    export default {
        data() {
            return {

            }
        }
        ,props: {
            sections: {}
        }
    }
</script>