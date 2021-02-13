using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ImprestDisbDetail
    {
        public int Id { get; set; }
        public string ImpRef { get; set; }
        public string PayeeRef { get; set; }
        public string Names { get; set; }
        public decimal? Amount { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public bool? BankTransfer { get; set; }
        public bool? Printed { get; set; }
        public string ImpId { get; set; }
    }
}
