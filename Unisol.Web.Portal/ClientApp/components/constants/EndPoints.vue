<script>
    const NEWS = "news" 
    const EVENTS = "events"
    /*evalutions urls*/  
    const EVALUATIONS = "evaluations"
    const CURRENTEVALUATIONS = "currentevaluations"
    const ADMINRESPONSE = "AdminEvaluationsResponse"
    const EVALUATIONSECTIONS = "EvaluationQuestions"
    const EVALUATIONQUESTIONS = "EvaluationSections"
    const CLAIMS = "Claims";
    const IMPREST = "imprest";
    const ACADEMICYEARS = "EvaluationSections"

    var roles = [
        {
            name: 'Admin',
            value: 1
        },
        {
            name: 'Staff',
            value: 2
        },
        {
            name: 'Student',
            value: 3
        }
    ]
    var departmentLevels = [
        {
            name: 'All',
            value: 0
        },
        {
            name: 'Year',
            value: 1
        },
        {
            name: 'faculty',
            value: 2
        },
        {
            name: 'department',
            value: 3
        },
        {
            name: 'programme',
            value: 4
        },
        {
            name: 'class',
            value: 5
        },
        {
            name: 'student',
            value: 6
        }
    ]

    export default {
        /*===================news urls=====================*/
        GETNEWS: NEWS + "/" + "getNews/?itemsPerPage=",
        GETNEWSTYPES: NEWS + "/" + "getnewstypes",
        GETNEWSDETAILS: NEWS + "/" + "getnewsdetails",
        ADDNEWS: NEWS + "/" + "addNews",
        ADDNEWSTYPES: NEWS + "/" + "addnewstypes",
        CHECKNEWSTYPE: NEWS + "/" + "checknewstype",

        /* =============== events urls ========================= */
        GETEVENTS: EVENTS + "/" + "getevents/?itemsPerPage=",
        ADDEVENTS: EVENTS + "/" + "addEvents",
        GETEVENTSDETAILS: EVENTS + "/" + "geteventdetails",
        /*==================evaluation urls ==================*/
        GETEVALUATION: EVALUATIONS + "/" + "getevaluations",
        GETEVALUATIONINFO: EVALUATIONS + "/" + "getevaluationinfo",
        ADDEVALUTIONS: EVALUATIONS + "/" + "addevaluation",

        GETEVALUATIONSECTIONS: EVALUATIONSECTIONS + "/" + "getsections",
        ADDEVALUATIONSECTIONS: EVALUATIONSECTIONS + "/" + "addsection",

        GETEVALUATIONQUESTIONS: EVALUATIONQUESTIONS + "/" + "getquestions",
        ADDEVALUATIONQUESTIONS: EVALUATIONQUESTIONS + "/" + "addquestion",

        GETSEARCHLEVELS: CURRENTEVALUATIONS + "/" + "SearchEvaluationTarget",
        GETACADEMICYEARS: CURRENTEVALUATIONS + "/" + "GetAcademicYears",
        GETSEMESTERS: CURRENTEVALUATIONS + "/" + "GetSemester",
        SAVECURRENTEVALUATIONS: CURRENTEVALUATIONS + "/" + "SaveCurrentEvaluation",
        GETCURRENTEVALUATIONS: CURRENTEVALUATIONS + "/" + "GetCurrentEvaluations",
        SAVEACTIVEEVALUATIONS: CURRENTEVALUATIONS + "/" + "SaveActiveEvaluation",
        DELETECURRENTEVALUATION: CURRENTEVALUATIONS + "/" + "DeleteCurrentEvaluation",
        GETCURRENTEVALUATION: CURRENTEVALUATIONS + "/" + "GetCurrentEvaluationInfo",

        GETRESPONDEDUNITS: ADMINRESPONSE + "/" + "GetEvaluationRespondedUnits/?currentActiveEvaluationId=",

        //claims links
        GETCLAIMSUMMARY: CLAIMS + "/" + "GetEmployeeClaimSummary",
        GETCLAIMTERMS: CLAIMS + "/" + "GetEmployeeTermsForClaim",
        GETCLAIMUNITS: CLAIMS + "/" + "GetUnitsForAddingClaim",
        GETCLAIMDETAILS: CLAIMS + "/" + "GetClaimDetails",
        GETCLAIMRATES: CLAIMS + "/" + "GetClaimRates",
        ADDCLAIM: CLAIMS + "/" + "SaveEmployeeClaimDetails",

        //add imprest
        ADDIMPREST: IMPREST + "/" + "saveImprest",
        GETIMPREST: IMPREST + "/" + "getImprest",

        ReturnDate: function (date) {
            date = new Date(date);
            var monthNames = [
                "January", "February", "March",
                "April", "May", "June", "July",
                "August", "September", "October",
                "November", "December"
            ];

            var day = date.getDate();
            var monthIndex = date.getMonth();
            var year = date.getFullYear();

            return day + ' ' + monthNames[monthIndex].substring(0, 3) + ' ' + year;
        },
        ROLES: function(user){
            if(user.genesisUser){
                roles.splice(2,1);
            }
            return roles
        },
        DEPARTMENTLEVELS: departmentLevels,

        numberToEnglish: function (n, custom_join_character="") {
            var string = n.toString()
            var stringWithCents = string.split('.')
            var nemeric = this.converter(stringWithCents[0]).reverse().join(' ')
            var decimalPoint = ""

            if(stringWithCents.length > 1){
                stringWithCents[1] = stringWithCents[1].length < 2 ? stringWithCents[1] + "0" : stringWithCents[1]
                stringWithCents[1] = stringWithCents[1].length > 2 ? stringWithCents[1].substr(0, 2) : stringWithCents[1]
                if(stringWithCents[1] != "00"){
                   decimalPoint = `${this.converter(stringWithCents[1]).reverse().join(' ')} CENTS`
                }
            }
            
            return `${nemeric.toUpperCase()} ${decimalPoint.toUpperCase()} ONLY`
        },

        converter(n, custom_join_character=""){
             var string = n.toString(),
                   units, tens, scales, start, end, chunks, chunksLen, chunk, ints, i, word, words;

               var and = custom_join_character || 'and';

               /* Is number zero? */
               if (parseInt(string) === 0) {
                   return 'zero';
               }
                 
               /* Array of... units as words */
               units = ['', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];

               /* Array of tens as words */
               tens = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

               /* Array of scales as words */
               scales = ['', 'thousand', 'million', 'billion', 'trillion', 'quadrillion', 'quintillion', 'sextillion', 'septillion', 'octillion', 'nonillion', 'decillion', 'undecillion', 'duodecillion', 'tredecillion', 'quatttuor-decillion', 'quindecillion', 'sexdecillion', 'septen-decillion', 'octodecillion', 'novemdecillion', 'vigintillion', 'centillion'];

               /* Split user arguemnt into 3 digit chunks from right to left */
               start = string.length;
               chunks = [];

               while (start > 0) {
                   end = start;
                   chunks.push(string.slice((start = Math.max(0, start - 3)), end));
               }

               /* Check if function has enough scale words to be able to stringify the user argument */
               chunksLen = chunks.length;
               if (chunksLen > scales.length) {
                   return '';
               }

               /* Stringify each integer in each chunk */
               words = [];
               for (i = 0; i < chunksLen; i++) {
                   chunk = parseInt(chunks[i]);

                   if (chunk) {

                       /* Split chunk into array of individual integers */
                       ints = chunks[i].split('').reverse().map(parseFloat);

                       /* If tens integer is 1, i.e. 10, then add 10 to units integer */
                       if (ints[1] === 1) {
                           ints[0] += 10;
                       }

                       /* Add scale word if chunk is not zero and array item exists */
                       if ((word = scales[i])) {
                           words.push(word);
                       }

                       /* Add unit word if array item exists */
                       if ((word = units[ints[0]])) {
                           words.push(word);
                       }

                       /* Add tens word if array item exists */
                       if ((word = tens[ints[1]])) {
                           words.push(word);
                       }

                       /* Add 'and' string after units or tens integer if: */
                       if (ints[0] || ints[1]) {

                           /* Chunk has a hundreds integer or chunk is the first of multiple chunks */
                           if (ints[2] || !i && chunksLen) {
                               words.push(and);
                           }

                       }

                       /* Add hundreds word if array item exists */
                       if ((word = units[ints[2]])) {
                           words.push(word + ' hundred');
                       }

                   }

               }
            return words;
        }
    }
</script>

