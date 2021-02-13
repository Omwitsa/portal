using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class EvaluationQuestionResponseOption
    {
        public int Id { get; set; }
        public int EvaluationQuestionResponseId { get; set; }
        public int EvaluationQuestionOptionId { get; set; }
        public string OptionName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        
    }
}