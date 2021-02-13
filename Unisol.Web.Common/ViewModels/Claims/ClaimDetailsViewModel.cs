using System;
using System.Collections.Generic;
using System.Text;
namespace Unisol.Web.Common.ViewModels.Claims
{
    public class ClaimDetailsViewModel
    {
        /*
         * totalAmount: 250000
            quantity: 5
            semester: SEMESTER 2 2018/2019
            claimRates: TEACHING CLAIM-01
            rateAmount: 50000
         */
        public decimal? TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int ClaimId { get; set; }
        public string Semester { get; set; }

        public string ClaimRates { get; set; }
        public string Notes { get; set; }
        public string PayAccount { get; set; }
        public string UserCode { get; set; }
        public bool RequireUnit { get; set; }
        public List<ClaimRequestUnit> ClaimRequestUnits { get; set; }
        public decimal RateAmount { get; set; }
    }
    /*
     * quantity: quantity,
            code: data.Code,
            rate: $("#unit").text(),
            rateAmount: $("#rateAmount").val(),
            total: total
     */
    public class MainClaim
    {
        public List<ClaimDetailsViewModel> MainClaimObject { get; set; }

    }
    public class ClaimRequestUnit
    {
        public int Quantity { get; set; }
        public string Code { get; set; }
        public string Rate { get; set; }
        public int RateAmount { get; set; }
        public int Total { get; set; }
    }
}
