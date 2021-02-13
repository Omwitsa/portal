using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Sor
{
   public class SorItemModel
    {
        public decimal Quantity { get; set; }
        public string Unitmeasure { get; set; }
        public decimal Unitamount { get; set; }
        public decimal Totalamount { get; set; }
        public string Description { get; set; }
    }
}
