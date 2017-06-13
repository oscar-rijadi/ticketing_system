using TicketingSystem.Core.Entities.Common;

namespace TicketingSystem.Core.Entities
{
    public class TicketType : EntityValue
    {
        public int SeatPositionId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual SeatPosition SeatPosition { get; set; }
    }
}
