﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BudgetProj
    {
        public int Ref { get; set; }
        public string Fyear { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string Personnel { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
    }
}
