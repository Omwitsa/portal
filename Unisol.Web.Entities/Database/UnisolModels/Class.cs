using System;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Class
    {
        public string Id { get; set; }
        public string Programme { get; set; }
        public string Term { get; set; }
        public DateTime? Starts { get; set; }
        public DateTime? Ends { get; set; }
        public DateTime? Cdate { get; set; }
        public string ClassType { get; set; }
        public string Campus { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public string Ayduration { get; set; }
        public int? MaxUnits { get; set; }
        public string CurriculumCycle { get; set; }
    }
}
