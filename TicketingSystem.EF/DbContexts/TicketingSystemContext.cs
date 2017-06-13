using System.Data.Entity;
using TicketingSystem.Core.Entities;

namespace TicketingSystem.EF.DbContexts
{
    public class TicketingSystemContext : DbContext
    {
        public TicketingSystemContext(string connString) : base(connString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<SeatPosition> SeatPositions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
