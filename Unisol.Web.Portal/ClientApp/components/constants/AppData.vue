<script>
import DateFomatter from "./DateFomatter";
    export default {   
        getFileName: function (featureName, userName) {
           var fileName = featureName + "-"+userName+"-"+DateFomatter.ReturnDate(new Date())
            return fileName
        },
    }
</script>