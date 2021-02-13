using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.Utilities
{
    public static class ProcessDates
    {
        public static string ReturnMonthName(int month)
        {
            var monthsArray=new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July ",
                "August",
                "September",
                "October",
                "November",
                "December",
            };
            return monthsArray[month-1];
        }
    }
}
