﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PocancelDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Code { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? GrossAmount { get; set; }
    }
}
