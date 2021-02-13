using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Unisol.Web.Common.Process
{
    public static class DecryptMarks
    {
        public static string DecryptMarksColumn(string unitvalue)
        {
            var icNewText = "";
            var decode = "";
            string textv = WebUtility.HtmlDecode(Regex.Replace(unitvalue, "<[^>]*(>|$)", string.Empty));
            string textt = unitvalue.Trim();
            int textl = textt.Length;
            for (int i = 1; i < textl + 1; i++)
            {
                string icchar = textt.Substring(i - 1, 1);

                char myChar = Convert.ToChar(icchar);
                char b = myChar;
                int n = b;

                if (n >= 192 && n <= 217)
                {
                    n = (char)(n - 127);
                }

                if (n >= 218 && n <= 243)
                {
                    n = (char)(n - 121);
                }

                if (n >= 244 && n <= 253)
                {
                    n = (char)(n - 196);
                }

                if (n == 32)
                {
                    n = (char)(32);
                }

                var t = Convert.ToChar(n);
                icNewText = icNewText + t;

                decode = icNewText;
            }

            return decode;
        }
    }
}
