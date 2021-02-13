using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeUsers
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Names { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public bool? Administrator { get; set; }
        public bool? Sales { get; set; }
        public bool? AccTopUp { get; set; }
        public bool? MoneyTransfer { get; set; }
        public bool? MemRegister { get; set; }
        public bool? Barcode { get; set; }
        public bool? Items { get; set; }
        public bool? ItemPrices { get; set; }
        public bool? ItemStatus { get; set; }
        public bool? Reports { get; set; }
        public string Cafeteria { get; set; }
        public bool? Stock { get; set; }
        public bool? FacilityBooking { get; set; }
    }
}
