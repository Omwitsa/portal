using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChequesTax
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string Bank { get; set; }
        public bool? BankTransfer { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public bool? Printed { get; set; }
        public string ChequeNo { get; set; }
    }
}
