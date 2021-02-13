using System.Collections.Generic;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.ViewModels.Memo
{
	public class MemoViewModel
	{
		public ImprestMemo ImprestMemo { get; set; }
		public List<ImprestMemoDetail> ImprestMemoDetail { get; set; }
	}
}
