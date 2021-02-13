using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.News
{
    public class NewsTypeViewModel
    {
        public int ?Id { get; set; }
        public string NewsTypeName { set; get; }
        public bool Status { set; get; }
    }
}
