using System.Collections.Generic;

namespace TicketingSystem.ViewModels
{
    public class UserIndexViewModel
    {
        public List<UserViewModel> Users { get; set; }
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
    }
}