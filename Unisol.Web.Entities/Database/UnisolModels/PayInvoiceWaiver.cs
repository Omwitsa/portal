using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayInvoiceWaiver
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string InvRef { get; set; }
        public string Department { get; set; }
        public string Campus { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Adate { get; set; }
        public string Notes { get; set; }
    }
}
