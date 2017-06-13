using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.Domain.Interfaces
{
    public interface ISeatPositionManager
    {
        SeatPosition Get(Expression<Func<SeatPosition, bool>> predicate);
        IEnumerable<SeatPosition> SeatPositions(Expression<Func<SeatPosition, bool>> predicate = null);
    }
}
