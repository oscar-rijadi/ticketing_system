using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.EF.Migrations
{
    internal class Seeds
    {
        public static List<SeatPosition> SampleSeatPositions(DbContexts.TicketingSystemContext context)
        {
            var seatPositions = new List<SeatPosition>();
            if (!context.SeatPositions.Any(s => s.Description == "Front"))
            {
                seatPositions.Add(new SeatPosition
                {
                    Description = "Front"
                });
            }
            if (!context.SeatPositions.Any(s => s.Description == "Middle"))
            {
                seatPositions.Add(new SeatPosition
                {
                    Description = "Middle"
                });
            }
            if (!context.SeatPositions.Any(s => s.Description == "Back"))
            {
                seatPositions.Add(new SeatPosition
                {
                    Description = "Back"
                });
            }
            return seatPositions;
        }

        public static List<TicketType> SampleTicketTypes(DbContexts.TicketingSystemContext context)
        {
            var ticketTypes = new List<TicketType>();
            if (!context.TicketTypes.Any(t => t.Description == "Normal Front Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Front"),
                    Description = "Normal Front Ticket",
                    Price = 100
                });
            }
            if (!context.TicketTypes.Any(t => t.Description == "Normal Middle Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Middle"),
                    Description = "Normal Middle Ticket",
                    Price = 80
                });
            }
            if (!context.TicketTypes.Any(t => t.Description == "Normal Back Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Back"),
                    Description = "Normal Back Ticket",
                    Price = 50
                });
            }
            if (!context.TicketTypes.Any(t => t.Description == "Promo Front Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Front"),
                    Description = "Promo Front Ticket",
                    Price = 90
                });
            }
            if (!context.TicketTypes.Any(t => t.Description == "Promo Middle Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Middle"),
                    Description = "Promo Middle Ticket",
                    Price = 70
                });
            }
            if (!context.TicketTypes.Any(t => t.Description == "Promo Back Ticket"))
            {
                ticketTypes.Add(new TicketType
                {
                    SeatPosition = context.SeatPositions.FirstOrDefault(s => s.Description == "Back"),
                    Description = "Promo Back Ticket",
                    Price = 40
                });
            }
            return ticketTypes;
        }

        public static List<User> SampleUsers(DbContexts.TicketingSystemContext context)
        {
            var users = new List<User>();
            if (!context.Users.Any(t => t.EmailAddress == "testuser1@test.com"))
            {
                users.Add(new User
                {
                    FirstName = "Test",
                    LastName = "User1",
                    EmailAddress = "testuser1@test.com"
                });
            }
            if (!context.Users.Any(t => t.EmailAddress == "testuser2@test.com"))
            {
                users.Add(new User
                {
                    FirstName = "Test",
                    LastName = "User2",
                    EmailAddress = "testuser2@test.com"
                });
            };
            return users;
        }

        public static List<Ticket> SampleTickets(DbContexts.TicketingSystemContext context)
        {
            var tickets = new List<Ticket>();
            var testUser1 = context.Users.FirstOrDefault(x => x.EmailAddress == "testuser1@test.com");
            var testUser2 = context.Users.FirstOrDefault(x => x.EmailAddress == "testuser2@test.com");
            var normalFrontTicket = context.TicketTypes.FirstOrDefault(x => x.Description == "Normal Front Ticket");
            var normalBackTicket = context.TicketTypes.FirstOrDefault(x => x.Description == "Normal Back Ticket");
            var promoFrontTicket = context.TicketTypes.FirstOrDefault(x => x.Description == "Promo Front Ticket");
            var promoMiddleTicket = context.TicketTypes.FirstOrDefault(x => x.Description == "Promo Middle Ticket");
            if (testUser1 != null)
            {
                if (normalFrontTicket != null)
                {
                    if (!context.Tickets.Any(t => t.UserId == testUser1.Id && t.TicketTypeId == normalFrontTicket.Id))
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = testUser1.Id,
                            TicketTypeId = normalFrontTicket.Id,
                            PurchaseDate = DateTime.UtcNow
                        });
                    }
                }
                if (normalBackTicket != null)
                {
                    if (!context.Tickets.Any(t => t.UserId == testUser1.Id && t.TicketTypeId == normalBackTicket.Id))
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = testUser1.Id,
                            TicketTypeId = normalBackTicket.Id,
                            PurchaseDate = DateTime.UtcNow
                        });
                    }
                }
            };
            if (testUser2 != null)
            {
                if (promoFrontTicket != null)
                {
                    if (!context.Tickets.Any(t => t.UserId == testUser2.Id && t.TicketTypeId == promoFrontTicket.Id))
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = testUser2.Id,
                            TicketTypeId = promoFrontTicket.Id,
                            PurchaseDate = DateTime.UtcNow
                        });
                    }
                }
                if (promoMiddleTicket != null)
                {
                    if (!context.Tickets.Any(t => t.UserId == testUser2.Id && t.TicketTypeId == promoMiddleTicket.Id))
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = testUser2.Id,
                            TicketTypeId = promoMiddleTicket.Id,
                            PurchaseDate = DateTime.UtcNow
                        });
                    }
                }
            };
            return tickets;
        }
    }
}
