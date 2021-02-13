using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ExamLog
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Term { get; set; }
        public string Subject { get; set; }
        public string MarkType { get; set; }
        public string Personnel { get; set; }
        public string Computer { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Macaddress { get; set; }
    }
}
