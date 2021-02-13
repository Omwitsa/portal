using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Customers
    {
        public string Ref { get; set; }
        public string Names { get; set; }
        public string RelationD { get; set; }
        public string CustomerType { get; set; }
        public string Address { get; set; }
        public string Paddress { get; set; }
        public string Contact { get; set; }
        public string Teld { get; set; }
        public string Tele { get; set; }
        public string Telm { get; set; }
        public string Fax { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string Provider { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool? Notify { get; set; }
        public string Terms { get; set; }
        public decimal? Discount { get; set; }
        public bool? NoTax { get; set; }
        public bool? Closed { get; set; }
        public string Araccount { get; set; }
    }
}
