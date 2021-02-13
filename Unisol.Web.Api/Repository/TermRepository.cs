using System;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class TermRepository : GenericRepository<Term>, ITermRepository
	{
		private UnisolAPIdbContext _context;
		public TermRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}

		public string GetTermByDate(string studentclass, DateTime serverdate)
		{
			var term = _context.Class
					.Join(_context.Term,
						studentClassJoin => studentClassJoin.Term,
						t => t.Type,
						(studentClassJoin, t) => new { t.Names, t.Starts, t.Ends, t.TermAlias, t.Type, studentClassJoin.Id })
					.FirstOrDefault(c => c.Id.CaseInsensitiveContains(studentclass) &&
						(c.Starts <= serverdate.Date && c.Ends >= serverdate.Date));
			if (term == null)
				return "";

			return term.Names;
		}
	}
}
