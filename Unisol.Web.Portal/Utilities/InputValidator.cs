using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unisol.Web.Common.ViewModels.Users;

namespace Unisol.Web.Portal.Utilities
{
	public class InputValidator
	{
		public ValidationResult Validate(List<Tuple<string, string, DataType>> requiredFields)
		{
			var response = new ValidationResult();
			foreach (Tuple<string, string, DataType> tuple in requiredFields)
			{
				var error = $"{tuple.Item1} is required";

				if (string.IsNullOrEmpty(tuple.Item2))
				{
					response.Errors = "Validation failed: " + error;
					response.Valid = false;
					return response;
				}

				var dataType = tuple.Item3;
				var value = tuple.Item2;
				switch (dataType)
				{
					case DataType.Integer:
						response = ParseInt(value, response, tuple);
						if (!response.Valid) return response;
						break;
					case DataType.Decimal:
						response = ParseDecimal(value, response, tuple);
						if (!response.Valid) return response;
						break;
					case DataType.Float:
						response = ParseFloat(value, response, tuple);
						if (!response.Valid) return response;
						break;
					case DataType.Email:
						response = CheckEmail(value, response, tuple);
						if (!response.Valid) return response;
						break;
					case DataType.Password:
						response = CheckPassword(value, response, tuple);
						if (!response.Valid) return response;
						break;
				}
			}
			response.Valid = true;
			return response;
		}

		private static ValidationResult ParseInt(string value, ValidationResult response, Tuple<string, string, DataType> tuple)
		{
			try
			{
				if (int.Parse(value).GetType() != typeof(int))
				{
					response.Valid = false;
					response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
					return response;
				}
				response.Valid = true;
				return response;
			}
			catch (Exception)
			{
				response.Valid = false;
				response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
				return response;
			}
		}

		private static ValidationResult ParseDecimal(string value, ValidationResult response, Tuple<string, string, DataType> tuple)
		{
			try
			{
				if (decimal.Parse(value).GetType() != typeof(decimal))
				{
					response.Valid = false;
					response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
					return response;
				}
				response.Valid = true;
				return response;
			}
			catch (Exception)
			{
				response.Valid = false;
				response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
				return response;
			}
		}

		private static ValidationResult ParseFloat(string value, ValidationResult response, Tuple<string, string, DataType> tuple)
		{
			try
			{
				if (decimal.Parse(value).GetType() != typeof(decimal))
				{
					response.Valid = false;
					response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
					return response;
				}
				response.Valid = true;
				return response;
			}
			catch (Exception)
			{
				response.Valid = false;
				response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
				return response;
			}
		}

		private ValidationResult CheckEmail(string value, ValidationResult response, Tuple<string, string, DataType> tuple)
		{
			if (!Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
			{
				response.Valid = false;
				response.Errors = $"{tuple.Item1} is not a valid {tuple.Item3}";
				return response;
			}

			response.Valid = true;
			return response;
		}

		private static ValidationResult CheckPassword(string value, ValidationResult response, Tuple<string, string, DataType> tuple)
		{
			try
			{
				value = value ?? "null";
				if (value.Length < 6)
				{
					response.Valid = false;
					response.Errors = $"{tuple.Item1} should not be less than 6 characters";
					return response;
				}

				response.Valid = true;
				return response;
			}
			catch (Exception)
			{
				response.Valid = false;
				response.Errors = $"{tuple.Item1} is not of datatype {tuple.Item3}";
				return response;
			}
		}
	}
}
