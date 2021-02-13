using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustItems
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public string Category { get; set; }
        public string Uom { get; set; }
        public string Account { get; set; }
        public bool? AllowDiscount { get; set; }
        public bool? Taxable { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
