using Airplane.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Airplane.Domain.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}