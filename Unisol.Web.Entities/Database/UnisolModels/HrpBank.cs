using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpBank
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Scode { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
