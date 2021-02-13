<template>

    <fieldset  id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
        <fg-input type="text"
                  label="Evaluation Name"
                  placeholder="Evaluation Name"
                  v-model="evaluation.evaluationName" />
        <fg-input type="text"
                  label="Description"
                  placeholder="Name"
                  v-model="evaluation.evaluationDesc" />

        
        
    </fieldset>

</template>

<script>
    export default {
        data() {
            return {

            }
        }
        ,props: {
            evaluation: {}
        }
    }
</script>