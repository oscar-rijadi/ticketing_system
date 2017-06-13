using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Core.Db.Interfaces;

namespace TicketingSystem.Core.Db
{
    public class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext Context;

        public Repository(TContext context)
        {
            this.Context = context;
        }

        public IQueryable<TEntity> Select()
        {
            return this.Context.Set<TEntity>();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var ctx = this.Context;
            var set = ctx.Set<TEntity>();

            return set.Single(predicate);
        }

        public TEntity GetOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var ctx = this.Context;
            var set = ctx.Set<TEntity>();

            return set.SingleOrDefault(predicate);
        }

        public TEntity GetByPrimaryKey(object[] keyValues)
        {
            return this.Context.Set<TEntity>().Find(keyValues);
        }

        public IList<T> SelectByQuery<T>(string commandText, params object[] parameters) where T : class
        {
            var objCtx = ((IObjectContextAdapter)this.Context).ObjectContext;
            return objCtx.ExecuteStoreQuery<T>(commandText, parameters).ToList();
        }

        public IList<T> SelectByQuery<T>(int commandTimeout, string commandText, params object[] parameters) where T : class
        {
            var objCtx = ((IObjectContextAdapter)this.Context).ObjectContext;
            objCtx.CommandTimeout = commandTimeout;
            return objCtx.ExecuteStoreQuery<T>(commandText, parameters).ToList();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var ctx = this.Context;
            var set = ctx.Set<TEntity>();

            return set.FirstOrDefault(predicate);
        }

        // TODO:  Use or lose.
        public void Dispose()
        {
        }
    }
}
