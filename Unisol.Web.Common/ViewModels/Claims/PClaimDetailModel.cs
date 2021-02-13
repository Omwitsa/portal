using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Claims
{
    /// <summary>
    /// Incase the claim has units,they are represented with this class
    /// </summary>
    public class PClaimDetailModel
    {
        public string PCRef { get; set; }
        public string PayAccount { get; set; }
        public string Code { get; set; }
        public decimal Rate { get; set; }
        public string Units { get; set; }
        public decimal Qty { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
    }
}
