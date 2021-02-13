using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Library;
using Unisol.Web.Entities.Database.LibraryModels;

namespace Unisol.Web.Api.StudentUtilities
{
	public class Library
	{
		private LibraryAPIdbContext _libContext;
		private string _message = "";
		public Library(LibraryAPIdbContext libContext)
		{
			_libContext = libContext;
		}

		public ReturnData<List<dynamic>> GetCurrentIssues(string usercode)
		{
			_message = "Sorry, You have not borrowed any items.";
			var borrower = _libContext.Borrowers.FirstOrDefault(b => b.CardNumber == usercode);
			if(borrower == null)
				return new ReturnData<List<dynamic>>
				{
					Success = false,
					Message = "Sorry, We could not find your username, Please contact School Admin.",
				};

			var issues = _libContext.Issues.Where(i => i.BorrowerNumber == borrower.BorrowerNumber && i.ReturnDate == null).ToList();
			return FormatIssues(issues);
		}

		public ReturnData<List<dynamic>> GetOldIssues(string usercode)
		{
			_message = "Sorry, We could not find your borrowing history.";

			var borrower = _libContext.Borrowers.FirstOrDefault(b => b.CardNumber == usercode);
			if (borrower == null)
				return new ReturnData<List<dynamic>>
				{
					Success = false,
					Message = "Sorry, We could not find your username, Please contact School Admin.",
				};
			var issues = _libContext.Issues.Where(i => i.BorrowerNumber == borrower.BorrowerNumber && i.ReturnDate < DateTime.Now).ToList();
			return FormatIssues(issues);
		}

		private ReturnData<List<dynamic>> FormatIssues(List<Issue> issues)
		{
			if (issues.Count() < 1)
				return new ReturnData<List<dynamic>>
				{
					Success = false,
					Message = _message,
				};

			var items = new List<dynamic>();
			foreach (var issue in issues)
			{
				var accountLine = _libContext.AccountLines.FirstOrDefault(l => l.BorrowerNumber == issue.BorrowerNumber && l.ItemNumber == issue.ItemNumber);
				var amount = 0m;
				var outStanding = 0m;
				if (accountLine != null)
				{
					amount = accountLine.Amount ?? 0;
					outStanding = accountLine.AmountOutstanding ?? 0;
				}

				var days = GetNumberOfDays(issue.IssueDate, issue.ReturnDate, issue.DueDate);

				items.Add(new
				{
					Title = GetItemTitle(issue.ItemNumber),
					IssueDate = String.Format("{0:dd/MM/yyyy}", issue.IssueDate),
					DueDate = String.Format("{0:dd/MM/yyyy}", issue.DueDate),
					ReturnDate = String.Format("{0:dd/MM/yyyy}", issue.ReturnDate),
					Amount = string.Format("KES {0:N2}", amount),
					AmountOutstanding = string.Format("KES {0:N2}", outStanding),
					BookNumber = issue.ItemNumber,
					days.DaysRemaining,
					days.DaysLate
				});
			} 

			return new ReturnData<List<dynamic>>
			{
				Success = true,
				Message = "Borrowed items found",
				Data = items
			};
		}

		private string GetItemTitle(int? ItemNumber)
		{
			var bookname = _libContext.Items
					.Join(_libContext.Biblio,
						item => item.BiblioNumber,
						biblio => biblio.BiblioNumber,
						(item, biblio) => new { Item = item, Biblio = biblio }
					).FirstOrDefault(i => i.Item.ItemNumber == ItemNumber)?.Biblio.Title;

			return bookname;
		}
		
		private DaysViewModel GetNumberOfDays(DateTime? IssueDate, DateTime? returnDate, DateTime? dueDate)
		{
			var dateOfIssue = IssueDate ?? DateTime.Now;
			var date = returnDate ?? DateTime.Now;
			var deadline = dueDate ?? DateTime.Now;

			var remainingDays = deadline.Subtract(DateTime.Now).Days;
			remainingDays = remainingDays < 0 ? 0 : remainingDays;

			var daysLate = date.Subtract(deadline).Days;
			daysLate = daysLate < 0 ? 0 : daysLate;

			return new DaysViewModel
			{
				DaysRemaining = string.Format("{0:N0}", remainingDays),
				DaysLate = string.Format("{0:N0}", daysLate)
			};
		}
	}
}
