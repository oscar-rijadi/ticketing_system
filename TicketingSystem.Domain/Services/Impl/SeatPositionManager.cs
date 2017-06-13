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
    public class SeatPositionManager : ISeatPositionManager
    {
        private readonly IWritableRepository<SeatPosition> _seatPositionRepo;

        public SeatPositionManager()
            : this(new ConfigSettingsProvider())
        {
        }

        public SeatPositionManager(IConfigProvider config): this(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(config)))
        {
        }

        public SeatPositionManager(IRepositoryFactory repositoryFactory)
        {
            Contract.Assert(repositoryFactory != null, "IRepositoryFactory cannot be null");
            _seatPositionRepo = repositoryFactory.CreateWritable<SeatPosition>();
        }

        public SeatPosition Get(Expression<Func<SeatPosition, bool>> predicate)
        {
            var seatPosition = _seatPositionRepo.GetOrDefault(predicate);
            if (seatPosition == null)
            {
                throw new Exception();
            }

            return seatPosition;
        }

        public IEnumerable<SeatPosition> SeatPositions(Expression<Func<SeatPosition, bool>> predicate = null)
        {
            var seatPositionQueryable = _seatPositionRepo.Select();
            return predicate != null ? seatPositionQueryable.Where(predicate) : seatPositionQueryable;
        }
    }
}
