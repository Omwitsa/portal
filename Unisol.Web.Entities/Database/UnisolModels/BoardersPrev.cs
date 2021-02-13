using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BoardersPrev
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Hostel { get; set; }
        public string Term { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
