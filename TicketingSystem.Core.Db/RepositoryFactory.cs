using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TicketingSystem.Core.Db.Interfaces;

namespace TicketingSystem.Core.Db
{
    public class RepositoryFactory<TContext> : IRepositoryFactory
        where TContext : DbContext
    {
        private readonly TContext _context;

        public RepositoryFactory(IDbContextFactory<TContext> contextFactory)
        {
            _context = contextFactory.Create();
        }

        public IRepository<T> CreateReadable<T>() where T : class
        {
            return new Repository<TContext, T>(_context);
        }

        public IWritableRepository<T> CreateWritable<T>() where T : class
        {
            return new WritableRepository<TContext, T>(_context);
        }

        public IDbCommandReader CreateCommandReader()
        {
            return new DbCommandReader<TContext>(_context);
        }

        public RepositoryFactory()
        {
            _context = Activator.CreateInstance<TContext>();
        }
    }
}
