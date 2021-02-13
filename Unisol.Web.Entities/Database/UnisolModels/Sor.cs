using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Sor
    {
        public int ?Id { get; set; }
        public int quantity { get; set; }
        public string unitmeasure { get; set; }
        public double unitamount { get; set; }
        public double totalamount { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
    }
}