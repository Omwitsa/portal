using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChqSettings
    {
        public int Id { get; set; }
        public int? PaperW { get; set; }
        public int? PaperH { get; set; }
        public int? DateT { get; set; }
        public int? DateL { get; set; }
        public int? PayeeT { get; set; }
        public int? PayeeL { get; set; }
        public int? PayeeW { get; set; }
        public string PayeeP { get; set; }
        public string PayeeS { get; set; }
        public int? WordsW { get; set; }
        public int? WordsH { get; set; }
        public int? WordsT { get; set; }
        public int? WordsL { get; set; }
        public int? WordsD { get; set; }
        public string WordsP { get; set; }
        public int? FigT { get; set; }
        public int? FigL { get; set; }
        public int? FigW { get; set; }
        public string FigP { get; set; }
        public string FigS { get; set; }
        public int? Fsize { get; set; }
        public bool? PreviewB4print { get; set; }
    }
}
