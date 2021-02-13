using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SysSetupMore
    {
        public int Id { get; set; }
        public string DeliverTo { get; set; }
        public string ReqOn { get; set; }
        public string PostatusStart { get; set; }
        public string PostatusFinal { get; set; }
        public bool? ChangeCost { get; set; }
        public bool? PrintHeader { get; set; }
        public decimal? TopMargin { get; set; }
        public string Salutation { get; set; }
        public string Posign { get; set; }
        public string Pofooter { get; set; }
        public string Pvfooter { get; set; }
        public bool? PvprintHeader { get; set; }
        public decimal? PvtopMargin { get; set; }
        public string Cpvfooter { get; set; }
        public bool? CpvprintHeader { get; set; }
        public decimal? CpvtopMargin { get; set; }
        public string ReqReqOn { get; set; }
        public bool? ReqPrintHeader { get; set; }
        public decimal? ReqTopMargin { get; set; }
        public string ReqFooter { get; set; }
        public bool? InvPrintHeader { get; set; }
        public decimal? InvTopMargin { get; set; }
        public string InvFooter { get; set; }
        public bool? PinvPrintHeader { get; set; }
        public decimal? PinvTopMargin { get; set; }
        public string PinvFooter { get; set; }
        public bool? CdmprintHeader { get; set; }
        public decimal? CdmtopMargin { get; set; }
        public string Cdmfooter { get; set; }
        public bool? DbmprintHeader { get; set; }
        public decimal? DbmtopMargin { get; set; }
        public string Dbmfooter { get; set; }
        public bool? ImpSurPrintHeader { get; set; }
        public decimal? ImpSurTopMargin { get; set; }
        public string ImpSurFooter { get; set; }
        public string OnlineReqFooter { get; set; }
        public string CheckOut { get; set; }
        public string CheckIn { get; set; }
        public int? QuoteValidity { get; set; }
        public string ChqSchFooter { get; set; }
        public string DepMethod { get; set; }
        public string LeaveFooter { get; set; }
        public string Hecategory { get; set; }
        public bool? TamanualClockIn { get; set; }
        public string TtstudNumberToBeUsed { get; set; }
        public int? TtminBlockTime { get; set; }
        public bool? TtignoreStudyTime { get; set; }
        public bool? TtignoreExamTime { get; set; }
        public bool? TtscheduleWithoutRoom { get; set; }
    }
}
