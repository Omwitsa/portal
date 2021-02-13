using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ReceiptBookOtherDetail
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
    }
}
