<script>
    export default { 
        currentSort: 'name',
        currentSortDir: 'asc',
        sort:function(s) {
            //if s == current sort, reverse
            if(s === this.currentSort) {
            this.currentSortDir = this.currentSortDir==='asc'?'dsc':'asc';
            }
            this.currentSort = s;
        },
    }
</script>