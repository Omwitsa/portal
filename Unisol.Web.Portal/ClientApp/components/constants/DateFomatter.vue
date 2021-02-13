<script>
import moment from 'moment'
    export default {   
        ReturnDate: function (dateCreated, dateFormat='DD MMM YYYY') {
            let date = new Date(dateCreated);
            const formattedDate = moment(date).format(dateFormat)
            return formattedDate
        },
    }
</script>

