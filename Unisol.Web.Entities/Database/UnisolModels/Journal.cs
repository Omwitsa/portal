using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Journal
    {
        public int Id { get; set; }
        public string LedgerFrom { get; set; }
        public string ProjectFrom { get; set; }
        public string AccountFrom { get; set; }
        public string DeptFrom { get; set; }
        public string CampusFrom { get; set; }
        public string LedgerTo { get; set; }
        public string ProjectTo { get; set; }
        public string AccountTo { get; set; }
        public string DeptTo { get; set; }
        public string CampusTo { get; set; }
        public decimal? Amount { get; set; }
        public string Reference { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Jvno { get; set; }
        public string RecurInterval { get; set; }
        public DateTime? RecurSdate { get; set; }
        public DateTime? RecurEdate { get; set; }
        public int? RecurNo { get; set; }
        public bool? Revaluation { get; set; }
    }
}
