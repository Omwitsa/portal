using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Sor
{
    public class CreateSorModel
    {
        public SorDetailsModel Details { get; set; }
        public List<SorItemModel> Items { get; set; }
    }
}
