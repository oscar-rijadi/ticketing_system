using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.Domain.Interfaces
{
    public interface IUserManager
    {
        User Get(Expression<Func<User, bool>> predicate);
        IEnumerable<User> Users(Expression<Func<User, bool>> predicate = null);
        ActionStatus Save(User user);
    }
}
