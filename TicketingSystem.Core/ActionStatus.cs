using System.Linq;
using TicketingSystem.Core.Enums;

namespace TicketingSystem.Core
{
    public class ActionStatus
    {
        public bool Succeeded { get; set; }
        public ILookup<ErrorMessageType, string> Errors { get; set; }
    }
}
