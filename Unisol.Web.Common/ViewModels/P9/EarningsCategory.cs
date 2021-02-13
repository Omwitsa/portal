using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.P9
{
    public class EarningCategoryViewModel
    {
        public double TotalEarning { get; set; } = 0.0;
        public double Tax { get; set; } = 0.0;
        public double Benefits { get; set; } = 0.0;
        public double Pension { get; set; } = 0.0;
        public double HouseOfQuarter { get; set; } = 0.0;
        public double GrossIncome { get; set; } = 0.0;
		public bool IsRegularEmployee { get; set; }
	}

   
}