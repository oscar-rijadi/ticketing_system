using FluentAssertions;
using NUnit.Framework;
using System.Web.Mvc;
using TicketingSystem.Controllers;

namespace TicketingSystem.Tests.Controllers
{
    public class HomeControllerTests
    {
        private HomeController _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new HomeController();
        }

        [Test]
        public void IndexWillReturnViewResult()
        {
            var actual = _sut.Index();
            actual.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void AboutWillReturnViewResult()
        {
            var actual = _sut.About();
            actual.Should().BeOfType<ViewResult>();
        }
    }
}
