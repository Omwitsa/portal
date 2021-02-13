using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Users
{
	public class ValidationResult
	{
		public ValidationResult() => Valid = false;
		public bool Valid { get; set; }
		public string Errors { get; set; }
	}

	public enum DataType
	{
		Default = 0,
		Integer = 1,
		Decimal = 2,
		Float = 3,
		Email = 4,
		Password = 5
	}
}
