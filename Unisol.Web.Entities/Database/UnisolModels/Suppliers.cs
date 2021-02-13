using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Suppliers
    {
        public string Ref { get; set; }
        public string Names { get; set; }
        public string Address { get; set; }
        public string Teld { get; set; }
        public string Tele { get; set; }
        public string Telm { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PinNo { get; set; }
        public string VatNo { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public string Notes { get; set; }
        public string Terms { get; set; }
        public decimal? Discount { get; set; }
        public bool? NoTax { get; set; }
        public bool? Closed { get; set; }
        public string SupplierType { get; set; }
        public bool? Hold { get; set; }
    }
}
