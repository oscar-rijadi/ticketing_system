using TicketingSystem.Core.Interfaces;
namespace TicketingSystem.Core.Entities.Common
{
    public abstract class EntityValue : IEntity
    {
        public virtual int Id { get; set; }
    }
}
