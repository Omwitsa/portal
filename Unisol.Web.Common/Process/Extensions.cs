using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Unisol.Web.Common.Process
{
    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string stringComparison )
        {
            if (string.IsNullOrEmpty(stringComparison))
            {
                return true;
            }
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return text.ToLower().Contains(stringComparison.ToLower());
        }
    }
}
