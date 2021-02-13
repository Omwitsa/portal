using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Cmoney
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
