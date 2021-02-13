using System;

namespace Unisol.Web.Common.ViewModels.Finance
{
    public class StudentStatement
    {
        public string AdmnNo { get; set; }
        public string Term { get; set; }
        public DateTime? Rdate { get; set; }
        public string Type { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Notes { get; set; }
    }
}
