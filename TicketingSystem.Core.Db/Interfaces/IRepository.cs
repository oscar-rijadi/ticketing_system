using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TicketingSystem.Core.Db.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Select();
        IList<T> SelectByQuery<T>(string commandText, params object[] parameters) where T : class;
        IList<T> SelectByQuery<T>(int commandTimeout, string commandText, params object[] parameters) where T : class;
    }
}
