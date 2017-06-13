using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TicketingSystem.Domain.Interfaces;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketManager _ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        public ActionResult Index()
        {
            var tickets = _ticketManager.Tickets()
                .Select(x => new TicketViewModel
                {
                    TicketId = x.Id,
                    PurchaseDate = x.PurchaseDate,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    EmailAddress = x.User.EmailAddress,
                    TicketTypeDescription = x.TicketType.Description,
                    TicketPrice = x.TicketType.Price,
                    SeatPosition = x.TicketType.SeatPosition.Description
                })
                .ToList();
            var ticketIndexViewModel = new TicketIndexViewModel
            {
                Tickets = tickets
            };
            return View(ticketIndexViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ticket = _ticketManager.Get(x => x.Id == id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            var ticketViewModel = new TicketViewModel
            {
                TicketId = ticket.Id,
                PurchaseDate = ticket.PurchaseDate,
                FirstName = ticket.User.FirstName,
                LastName = ticket.User.LastName,
                EmailAddress = ticket.User.EmailAddress,
                TicketTypeDescription = ticket.TicketType.Description,
                TicketPrice = ticket.TicketType.Price,
                SeatPosition = ticket.TicketType.SeatPosition.Description
            };
            return View(ticketViewModel);
        }
    }
}
