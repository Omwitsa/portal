using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Assets
    {
        public string AssetNo { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string AssetCat { get; set; }
        public string AssetLoc { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNo { get; set; }
        public string Status { get; set; }
        public decimal? Pprice { get; set; }
        public string OldInvNo { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? CapitalDate { get; set; }
        public string BusinessArea { get; set; }
        public string Plant { get; set; }
        public string LicenseNo { get; set; }
        public string PersonnelNo { get; set; }
        public string Fund { get; set; }
        public string FunctionalArea { get; set; }
        public string GrantNo { get; set; }
        public string SubClass { get; set; }
        public string AssetType { get; set; }
        public string ControlAssign { get; set; }
        public string CountryOrigin { get; set; }
        public string AcqYear { get; set; }
        public string InsType { get; set; }
        public string InsComp { get; set; }
        public string PolicyNo { get; set; }
        public string InsText { get; set; }
        public string Room { get; set; }
        public string Notes { get; set; }
        public DateTime? Wdate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime? Pdate { get; set; }
        public string OrderNo { get; set; }
        public bool? Disposed { get; set; }
        public bool? Lost { get; set; }
    }
}
