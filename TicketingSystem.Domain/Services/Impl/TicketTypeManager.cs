using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Db;
using TicketingSystem.Core.Db.Interfaces;
using TicketingSystem.Core.Entities;
using TicketingSystem.Core.Interfaces;
using TicketingSystem.Domain.Interfaces;
using TicketingSystem.EF.DbContexts;
using TicketingSystem.EF.Factories;

namespace TicketingSystem.Domain.Services.Impl
{
    public class TicketTypeManager : ITicketTypeManager
    {
        private readonly IWritableRepository<TicketType> _ticketTypeRepo;

        public TicketTypeManager()
            : this(new ConfigSettingsProvider())
        {
        }

        public TicketTypeManager(IConfigProvider config): this(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(config)))
        {
        }

        public TicketTypeManager(IRepositoryFactory repositoryFactory)
        {
            Contract.Assert(repositoryFactory != null, "IRepositoryFactory cannot be null");
            _ticketTypeRepo = repositoryFactory.CreateWritable<TicketType>();
        }

        public TicketType Get(Expression<Func<TicketType, bool>> predicate)
        {
            var ticketType = _ticketTypeRepo.GetOrDefault(predicate);
            if (ticketType == null)
            {
                throw new Exception();
            }

            return ticketType;
        }

        public IEnumerable<TicketType> TicketTypes(Expression<Func<TicketType, bool>> predicate = null)
        {
            var ticketTypeQueryable = _ticketTypeRepo.Select();
            return predicate != null ? ticketTypeQueryable.Where(predicate) : ticketTypeQueryable;
        }
    }
}
