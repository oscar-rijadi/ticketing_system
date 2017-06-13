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
    public class TicketManager : ITicketManager
    {
        private readonly IWritableRepository<Ticket> _ticketRepo;

        public TicketManager()
            : this(new ConfigSettingsProvider())
        {
        }

        public TicketManager(IConfigProvider config): this(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(config)))
        {
        }

        public TicketManager(IRepositoryFactory repositoryFactory)
        {
            Contract.Assert(repositoryFactory != null, "IRepositoryFactory cannot be null");
            _ticketRepo = repositoryFactory.CreateWritable<Ticket>();
        }

        public Ticket Get(Expression<Func<Ticket, bool>> predicate)
        {
            var ticket = _ticketRepo.GetOrDefault(predicate);
            if (ticket == null)
            {
                throw new Exception();
            }

            return ticket;
        }

        public IEnumerable<Ticket> Tickets(Expression<Func<Ticket, bool>> predicate = null)
        {
            var ticketQueryable = _ticketRepo.Select();
            return predicate != null ? ticketQueryable.Where(predicate) : ticketQueryable;
        }
    }
}
