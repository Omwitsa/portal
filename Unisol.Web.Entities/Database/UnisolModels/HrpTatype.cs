﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpTatype
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Category { get; set; }
        public string Bcolor { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
