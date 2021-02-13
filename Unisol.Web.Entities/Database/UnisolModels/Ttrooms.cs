using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Ttrooms
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public string Building { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string RoomType { get; set; }
        public int? Capacity { get; set; }
        public string Size { get; set; }
        public bool? Exam { get; set; }
        public int? ExamCapacity { get; set; }
        public string RoomFeatures { get; set; }
        public string SharedDepartment { get; set; }
        public string Xcoord { get; set; }
        public string Ycoord { get; set; }
        public bool? Closed { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
