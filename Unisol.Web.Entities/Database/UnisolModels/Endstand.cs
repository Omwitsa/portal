using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Endstand
    {
        public int Id { get; set; }
        public string Matrikelnummer { get; set; }
        public string Begriff { get; set; }
        public string Thema { get; set; }
        public string Art { get; set; }
        public string Partitur { get; set; }
        public string Klasse { get; set; }
        public string Ebene { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? Zeit { get; set; }
        public string Benutzer { get; set; }
        public string Ref { get; set; }
    }
}
