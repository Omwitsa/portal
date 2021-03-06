﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pvdetail
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNumber { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public string TaxName { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public string Notes { get; set; }
        public string FeeName { get; set; }
        public decimal? FeeAmount { get; set; }
    }
}
