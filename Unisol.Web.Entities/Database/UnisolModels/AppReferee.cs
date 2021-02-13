using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AppReferee
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Names { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
