using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class EvaluationQuestionOption
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }=DateTime.Now;
        public int EvaluationQuestionId { get; set; }
        public string QuestionOption { get; set; }

        /*
         this property is just here for
         testing purpose,should be removed later
         */

        public bool? OptionResponse { get; set; }
        public bool QuestionOptionStatus { get; set; } = true;
    }
}
