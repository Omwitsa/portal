using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChqLog
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string Payee { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public string Personnel { get; set; }
        public string Computer { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Notes { get; set; }
    }
}
