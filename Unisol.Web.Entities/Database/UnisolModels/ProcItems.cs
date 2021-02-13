using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcItems
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public string ItemType { get; set; }
        public string ItemLoc { get; set; }
        public string ItemCat { get; set; }
        public decimal? MinStock { get; set; }
        public decimal? MaxStock { get; set; }
        public decimal? Reorder { get; set; }
        public string DimUnit { get; set; }
        public string ItemWidth { get; set; }
        public string ItemLength { get; set; }
        public string Wunit { get; set; }
        public string ItemWeight { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public string Account { get; set; }
        public string Personnel { get; set; }
    }
}
