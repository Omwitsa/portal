<template>

    <fieldset id="design-wizard-p-0" role="tabpanel" aria-labelledby="design-wizard-h-0" class="body current" aria-hidden="false">
        <fg-input type="text"
                  label="Question"
                  placeholder="Question "
                  v-model="questions.questionDesc" />


       
    </fieldset>

</template>

<script>
    export default {
        data() {
            return {

            }
        }
        ,props: {
            questions: {}
        }
    }
</script>