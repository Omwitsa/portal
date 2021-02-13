using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudInvoiceAdjCredit
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string AdmnNo { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
    }
}
