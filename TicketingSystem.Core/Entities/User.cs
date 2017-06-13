using System.Collections.Generic;
using TicketingSystem.Core.Entities.Common;

namespace TicketingSystem.Core.Entities
{
    public class User : EntityValue
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
