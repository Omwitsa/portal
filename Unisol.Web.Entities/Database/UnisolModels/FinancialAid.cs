﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FinancialAid
    {
        public string Names { get; set; }
        public string Address { get; set; }
        public string Teld { get; set; }
        public string Tele { get; set; }
        public string Telm { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool? DefFinAid { get; set; }
        public bool? Closed { get; set; }
    }
}
