using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingSystem.Core.Db.Interfaces
{
    public interface IWritableRepository<T> : IRepository<T>, IDisposable where T : class
    {
        void Add(T entity);
        T Create();
        void Delete(T entity);
        void DeleteChildEntities<T2>(ICollection<T2> items, Func<T2, bool> predicate) where T2 : class;
        void DeleteChildEntity<TChild>(TChild entity) where TChild : class;
        void Save();
        void Save(T entity, bool isNew);
        void Save(IEnumerable<T> entities, bool isNew);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
