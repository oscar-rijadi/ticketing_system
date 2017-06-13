using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Web.Mvc;
using TicketingSystem.Controllers;
using TicketingSystem.Domain.Interfaces;

namespace TicketingSystem.Tests.Controllers
{
    public class TicketControllerTests
    {
        private TicketController _sut;

        [SetUp]
        public void Setup()
        {
            var mockTicketManager = Substitute.For<ITicketManager>();
            _sut = new TicketController(mockTicketManager);
        }

        [Test]
        public void IndexWillReturnViewResult()
        {
            var actual = _sut.Index();
            actual.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void DetailsPassingNullWillReturnHttpStatusCodeResult()
        {
            var actual = _sut.Details(null);
            actual.Should().BeOfType<HttpStatusCodeResult>();
        }

        [Test]
        public void DetailsPassingZeroWillReturnHttpNotFound()
        {
            var actual = _sut.Details(0);
            actual.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
