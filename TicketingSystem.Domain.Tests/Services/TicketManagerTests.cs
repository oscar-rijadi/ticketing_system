using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using TicketingSystem.Core.Db.Interfaces;
using TicketingSystem.Core.Entities;
using TicketingSystem.Domain.Services.Impl;

namespace TicketingSystem.Domain.Tests.Services
{
    public class TicketManagerTests
    {
        private IRepositoryFactory _repositoryFactory = Substitute.For<IRepositoryFactory>();
        private IWritableRepository<Ticket> _ticketRepo = Substitute.For<IWritableRepository<Ticket>>();

        [Test]
        public void GetWillReturnTicket()
        {
            _repositoryFactory.CreateWritable<Ticket>()
                .Returns(_ticketRepo);
            var ticket = new Ticket
            {
                Id = 1,
                UserId = 1,
                TicketTypeId = 2
            };
            _ticketRepo.GetOrDefault(Arg.Any<Expression<Func<Ticket, bool>>>())
                .Returns(ticket);
            var _sut = new TicketManager(_repositoryFactory);
            var result = _sut.Get(x => x.Id == 1);
            result.Should().NotBeNull();
            result.UserId.Should().Be(ticket.UserId);
            result.TicketTypeId.Should().Be(ticket.TicketTypeId);
        }
    }
}
