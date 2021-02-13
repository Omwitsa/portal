using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ExamSlip
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Term { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
