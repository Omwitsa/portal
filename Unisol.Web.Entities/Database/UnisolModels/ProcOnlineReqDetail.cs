using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcOnlineReqDetail
    {
        public int Id { get; set; }
        public string ReqRef { get; set; }
        public decimal? Qty { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Amount { get; set; }
        public string UoM { get; set; }
    }
}
