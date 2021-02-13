using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.ViewModels.Users
{
	public class UserViewModel
	{
		public UserViewModel()
		{

		}
		public UserViewModel(HrpEmployee employee)
		{
			Id = employee.EmpNo;
			RefNo = employee.EmpNo;
			Names = employee.Names;
			NationalId = employee.Idno;
			Gender = employee.Gender;
			Nationality = employee.Country;
			Telno = employee.Cell;
			County = employee.County;
			Email = employee.Wemail;
			Programme = employee.Department;
			Closed = employee.Terminated;
			Type = "Lecturer";
		}

		public UserViewModel(Register register)
		{
			Id = $"{register.Id}";
			RefNo = register.AdmnNo;
			Names = register.Names;
			NationalId = register.NationalId;
			Gender = register.Gender;
			Nationality = register.NationalId;
			Telno = register.Telno;
			County = register.County;
			Email = register.Email;
			Programme = register.Programme;
			Closed = register.Closed;
			Type = "Student";
		}

		public string Id { get; set; }
		public string RefNo { get; set; }
		public string Names { get; set; }
		public string Firstname => Split().FirstOrDefault();
		public string Lastname => Split().LastOrDefault();
		public string NationalId { get; set; }
		public string Gender { get; set; }
		public string Nationality { get; set; }
		public string Telno { get; set; }
		public string County { get; set; }
		public string Email { get; set; }
		public string Programme { get; set; }
		public bool? Closed { get; set; }
		public string Type { get; set; }


		private List<string> Split()
		{
			if (string.IsNullOrEmpty(Names))
				return new List<string>(); ;

			var parts = Names.Split(new char[] { ' ' }, 2).ToList();
			if (parts.Count.Equals(1))
				parts.Add(string.Empty);
			return parts.ToList();
		}
	}
}
