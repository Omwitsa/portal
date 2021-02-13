using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class EvaluationViewModel
    {
        public int? Id { get; set; }

        public PartialEvaluationViewModel Evaluation { get; set; }

        public List<PartialSectionViewModel> Sections { get; set; } 
    }
    public class PartialEvaluationViewModel
    {
        public string EvaluationName { get; set; }
        public string EvaluationDesc { get; set; }
    }
    public class PartialSectionViewModel 
    {
        public string SectionName { get; set; }
        public string SectionDesc { get; set; }
        public List<PartialQuestionViewModel> Questions { get; set; }
       
    }
    public class PartialQuestionViewModel
    {
        public string Question { get; set; }
		public QuestionType? QuestionType { get; set; }
		public string MultiAnswers { get; set; }
	}
	public class QuestionResponse
	{
		public string Question { get; set; }
		public int StronglyAgree { get; set; }
		public int Agree { get; set; }
		public int Uncertain { get; set; }
		public int StronglyDisagree { get; set; }
		public int Disagree { get; set; }
		public List<string> TextResponse { get; set; }
		public QuestionType? QuestionType { get; set; }
		public double Mean { get; set; }
		public int TotalQuestions { get; set; }
		public int Students { get; set; }
	}
	public class EvaluationSectionResponse
	{
		public List<QuestionResponse> QuestionResponses { get; set; }
		public string SectionName { get; set; }
		public int StronglyAgree { get; set; }
		public int Agree { get; set; }
		public int Uncertain { get; set; }
		public int StronglyDisagree { get; set; }
		public int Disagree { get; set; }
		public double Mean { get; set; }
		public int Questions { get; set; }
		public int Students { get; set; }
	}
}
