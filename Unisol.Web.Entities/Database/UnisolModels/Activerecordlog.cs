using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Activerecordlog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public string Model { get; set; }
        public int? IdModel { get; set; }
        public string Field { get; set; }
        public DateTime Creationdate { get; set; }
        public string Userid { get; set; }
    }
}
