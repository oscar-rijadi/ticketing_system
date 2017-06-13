using System;
using TicketingSystem.Core.Entities.Common;

namespace TicketingSystem.Core.Entities
{
    public class Ticket : EntityValue
    {
        public DateTime PurchaseDate { get; set; }
        public int UserId { get; set; }
        public int TicketTypeId { get; set; }

        public virtual User User { get; set; }
        public virtual TicketType TicketType { get; set; }
    }
}
