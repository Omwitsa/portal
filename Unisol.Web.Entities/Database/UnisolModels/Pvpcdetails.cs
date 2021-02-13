using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pvpcdetails
    {
        public string Pcref { get; set; }
        public string VoucherNo { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public int Id { get; set; }
    }
}
