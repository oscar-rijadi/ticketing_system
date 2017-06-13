using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Web.Mvc;
using TicketingSystem.Controllers;
using TicketingSystem.Domain.Interfaces;

namespace TicketingSystem.Tests.Controllers
{
    public class UserControllerTests
    {
        private UserController _sut;

        [SetUp]
        public void Setup()
        {
            var mockUserManager = Substitute.For<IUserManager>();
            _sut = new UserController(mockUserManager);
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

        [Test]
        public void EditPassingZeroWillReturnHttpNotFound()
        {
            var actual = _sut.Edit(0);
            actual.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
