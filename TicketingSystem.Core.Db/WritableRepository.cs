using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Core.Db.Interfaces;

namespace TicketingSystem.Core.Db
{
    public class WritableRepository<TContext, TEntity> : Repository<TContext, TEntity>, IWritableRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public WritableRepository(TContext context)
            : base(context)
        {
        }

        public void Add(TEntity entity)
        {
            var set = this.Context.Set<TEntity>();
            set.Add(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public TEntity Create()
        {
            return this.Context.Set<TEntity>().Create();
        }

        public void Save(TEntity entity, bool isNew)
        {
            var set = this.Context.Set<TEntity>();
            AddOrAttach(isNew, set, entity);

            this.Context.SaveChanges();
        }

        public void Save(IEnumerable<TEntity> entities, bool isNew)
        {
            var set = this.Context.Set<TEntity>();
            foreach (var e in entities)
            {
                AddOrAttach(isNew, set, e);
            }

            this.Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
            this.Context.SaveChanges();
        }

        public void DeleteChildEntity<TChild>(TChild entity) where TChild : class
        {
            this.Context.Set<TChild>().Remove(entity);
            this.Context.SaveChanges();
        }

        public void DeleteChildEntities<TChild>(ICollection<TChild> items, Func<TChild, bool> predicate) where TChild : class
        {
            if (items == null)
            {
                return;
            }

            var targets = items.Where(predicate.Invoke).ToList();
            var set = this.Context.Set<TChild>();

            foreach (var item in targets)
            {
                items.Remove(item);
                set.Remove(item);
            }

            this.Context.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var set = this.Context.Set<TEntity>();
            var targets = set.Where(predicate);

            set.RemoveRange(targets);

            this.Context.SaveChanges();
        }

        private void AddOrAttach(bool isNew, IDbSet<TEntity> set, TEntity e)
        {
            if (isNew)
            {
                set.Add(e);
            }
            else
            {
                set.Attach(e);
                this.Context.Entry<TEntity>(e).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
