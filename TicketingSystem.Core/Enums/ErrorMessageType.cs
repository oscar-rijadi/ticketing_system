using System.ComponentModel;

namespace TicketingSystem.Core.Enums
{
    public enum ErrorMessageType
    {
        [Description("General Error")]
        None,
        [Description("ASP.NET Identity Validation Error")]
        IdentityValidation,
        RegistrationFailed
    }
}
