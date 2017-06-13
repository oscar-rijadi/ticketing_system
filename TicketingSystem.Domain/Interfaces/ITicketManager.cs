using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.Domain.Interfaces
{
    public interface ITicketManager
    {
        Ticket Get(Expression<Func<Ticket, bool>> predicate);
        IEnumerable<Ticket> Tickets(Expression<Func<Ticket, bool>> predicate = null);
    }
}
