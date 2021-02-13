using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class SectionSearchViewModel
    {
        public string SearchString { get; set; }
        public TargetDepartmentLevel TargetType  { get; set; }
    }

    //all=0,year=1,department=2,programme=3,class=5
    public enum TargetDepartmentLevel
    {
        All=0,
        Year=1,
        Faculty = 2,//school
        Department = 3,//
        Program = 4,
        Class = 5,
        Student = 6
    }
}
