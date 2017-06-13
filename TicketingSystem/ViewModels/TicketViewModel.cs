using System;
using System.ComponentModel;

namespace TicketingSystem.ViewModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }

        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Ticket Description")]
        public string TicketTypeDescription { get; set; }

        [DisplayName("Seat Position")]
        public string SeatPosition { get; set; }

        [DisplayName("Price")]
        public decimal TicketPrice { get; set; }
    }
}