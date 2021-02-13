using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Studstatement
    {
        public int Id { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? SortDate { get; set; }
        public string Term { get; set; }
        public string Type { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}
