using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.Domain.Interfaces
{
    public interface ITicketTypeManager
    {
        TicketType Get(Expression<Func<TicketType, bool>> predicate);
        IEnumerable<TicketType> TicketTypes(Expression<Func<TicketType, bool>> predicate = null);
    }
}
