using System.Collections.Generic;

namespace TicketingSystem.ViewModels
{
    public class TicketIndexViewModel
    {
        public List<TicketViewModel> Tickets { get; set; }
        public string PurchaseDateLabel {
            get {
                return "Purchase Date";
            }
        }
        public string FirstNameLabel {
            get
            {
                return "First Name";
            }
        }
        public string LastNameLabel {
            get
            {
                return "Last Name";
            }
        }
        public string EmailAddressLabel {
            get
            {
                return "Email Address";
            }
        }
        public string TicketTypeDescriptionLabel {
            get
            {
                return "Ticket Description";
            }
        }
        public string TicketPriceLabel {
            get
            {
                return "Price";
            }
        }
        public string SeatPositionLabel {
            get
            {
                return "Seat Position";
            }
        }
    }
}