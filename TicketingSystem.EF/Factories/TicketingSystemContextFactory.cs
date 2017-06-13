using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using TicketingSystem.Core.Interfaces;
using TicketingSystem.EF.DbContexts;

namespace TicketingSystem.EF.Factories
{
    public class TicketingSystemContextFactory : IDbContextFactory<TicketingSystemContext>
    {
        private readonly string _connectionString;

        public TicketingSystemContextFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TicketingSystemConnection"].ConnectionString;            
        }

        public TicketingSystemContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TicketingSystemContextFactory(IConfigProvider config)
        {
            _connectionString = config.GetConnectionString("TicketingSystemConnection");            
            Contract.Assert(_connectionString != null, string.Format("Connection string not configured ('{0}')", "TicketingSystemConnection"));
        }

        public TicketingSystemContext Create()
        {
            return new TicketingSystemContext(_connectionString);
        }
    }
}
