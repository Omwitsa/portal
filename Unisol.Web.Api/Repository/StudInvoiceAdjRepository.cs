using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
    public class StudInvoiceAdjRepository : GenericRepository<StudInvoiceAdj>, IStudInvoiceAdjRepository
    {
        private UnisolAPIdbContext _context;
        public StudInvoiceAdjRepository(UnisolAPIdbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<StudInvoiceAdj> GetStudInvoiceAdj(string userCode)
        {
            var invoiceAdj = _context.StudInvoiceAdj.Where(a => a.AdmnNo == userCode)
                .Select(a => new StudInvoiceAdj
                {
                    Ref = a.Ref,
                    Term = a.Term,
                    Rdate = a.Rdate,
                    Notes = a.Notes,
                    Amount = a.Amount
                }).OrderByDescending(a => a.Ref);

            return invoiceAdj;
        }
    }
}
