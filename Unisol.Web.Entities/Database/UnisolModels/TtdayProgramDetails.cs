﻿using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtdayProgramDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Type { get; set; }
        public DateTime? Stime { get; set; }
        public DateTime? Etime { get; set; }
    }
}
