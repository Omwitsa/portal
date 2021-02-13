using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustTaxWh
    {
        public int Id { get; set; }
        public string CertNo { get; set; }
        public string InvRef { get; set; }
        public string TaxType { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Adate { get; set; }
        public string Notes { get; set; }
    }
}
