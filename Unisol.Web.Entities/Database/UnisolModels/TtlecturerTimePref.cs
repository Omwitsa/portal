﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtlecturerTimePref
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Rday { get; set; }
        public string TimePref { get; set; }
        public string Notes { get; set; }
    }
}
