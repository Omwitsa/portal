using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Fyear
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal? CloseBal { get; set; }
        public string Notes { get; set; }
    }
}
