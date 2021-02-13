using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudFeesBalances
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
