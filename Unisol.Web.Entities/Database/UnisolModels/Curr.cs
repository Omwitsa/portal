﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Curr
    {
        public string Code { get; set; }
        public string Names { get; set; }
        public bool? Local { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}