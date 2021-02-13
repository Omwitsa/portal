using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeSysSetup
    {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public string SubTitle { get; set; }
        public string Location { get; set; }
        public string Contacts { get; set; }
        public string AlbumPath { get; set; }
        public string Smtpserver { get; set; }
        public string Thankyou { get; set; }
        public bool? Lock { get; set; }
        public DateTime? LockDate { get; set; }
        public string Vatno { get; set; }
        public string Pinno { get; set; }
        public string Misdb { get; set; }
        public bool? PrintReceipt { get; set; }
        public bool? PrintDeposit { get; set; }
        public bool? OpenCashDrawer { get; set; }
        public string Bcode { get; set; }
        public bool? Aname { get; set; }
        public string Payecategory { get; set; }
    }
}
