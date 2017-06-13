using System.Data.Entity.Migrations;

namespace TicketingSystem.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContexts.TicketingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(DbContexts.TicketingSystemContext context)
        {
            context.SeatPositions.AddRange(
                Seeds.SampleSeatPositions(context)
            );

            context.SaveChanges();

            context.TicketTypes.AddRange(
                Seeds.SampleTicketTypes(context)
            );

            context.SaveChanges();

            context.Users.AddRange(
                Seeds.SampleUsers(context)
            );

            context.SaveChanges();

            context.Tickets.AddRange(
                Seeds.SampleTickets(context)
            );

            context.SaveChanges();
        }
    }
}
