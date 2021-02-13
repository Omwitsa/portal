using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private UnisolAPIdbContext _context;
		private DbSet<T> _entities;
		public GenericRepository(UnisolAPIdbContext _context)
		{
			this._context = _context;
			_entities = _context.Set<T>();
		}

		public void Add(T entity)
		{
			_entities.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_entities.AddRange(entities);
		}

		public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
		{
			return _entities.Where(predicate);
		}

		public IEnumerable<T> GetAll()
		{
			return _entities;
		}

		public T GetFirstOrDefault()
		{
			return _entities.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			_entities.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_entities.RemoveRange(entities);
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			return _entities.FirstOrDefault(predicate);
		}

		public bool GetAny(Expression<Func<T, bool>> predicate)
		{
			return _entities.Any(predicate);
		}

		public bool GetAny()
		{
			return _entities.Any();
		}
	}

}
