using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Unisol.Web.Api.IRepository
{
	public interface IGenericRepository<T> where T : class
	{
		T GetFirstOrDefault();
		T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
		bool GetAny(Expression<Func<T, bool>> predicate);
		bool GetAny();
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
