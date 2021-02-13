using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    [Table("StudClearance")]
    public class StudClearance
    {
        [Key]
        public string AdmnNo { get; set; }
        public string Status { get; set; }
        public DateTime Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public string Comments { get; set; }
    }
}
