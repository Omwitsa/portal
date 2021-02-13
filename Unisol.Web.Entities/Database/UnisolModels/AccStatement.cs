using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AccStatement
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public DateTime? Rdate { get; set; }
        public string Rmonth { get; set; }
        public string Description { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}
