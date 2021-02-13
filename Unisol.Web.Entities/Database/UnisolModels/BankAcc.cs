using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankAcc
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Address { get; set; }
        public string AccNumber { get; set; }
        public decimal? StartBal { get; set; }
        public bool? ReceiveCash { get; set; }
        public bool? Payments { get; set; }
        public string AssetAcc { get; set; }
        public string Btname { get; set; }
        public string Notes { get; set; }
        public bool? AccClosed { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? AllowedOnCashPay { get; set; }
        public bool? AllowedAlpha { get; set; }
        public bool? BankingAvailable { get; set; }
        public decimal? MaxPayAmount { get; set; }
    }
}
