using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Schools
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string College { get; set; }
        public string DeanUserName { get; set; }
    }
}
