using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudentStatementModelVirtual
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Term { get; set; }
        public DateTime? Rdate { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        public Decimal? Debit { get; set; }
        public Decimal? Credit { get; set; }
        public Decimal? Balance { get; set; }
        public string Notes { get; set; }
    }

}

