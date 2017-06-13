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
    public class UserManagerTests
    {
        private IRepositoryFactory _repositoryFactory = Substitute.For<IRepositoryFactory>();
        private IWritableRepository<User> _userRepo = Substitute.For<IWritableRepository<User>>();

        [Test]
        public void GetWillReturnUser()
        {
            _repositoryFactory.CreateWritable<User>()
                .Returns(_userRepo);
            var user = new User
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User1",
                EmailAddress = "testuser1@test.com"
            };
            _userRepo.GetOrDefault(Arg.Any<Expression<Func<User, bool>>>())
                .Returns(user);
            var _sut = new UserManager(_repositoryFactory);
            var result = _sut.Get(x => x.Id == 1);
            result.Should().NotBeNull();
            result.FirstName.Should().Be(user.FirstName);
            result.LastName.Should().Be(user.LastName);
            result.EmailAddress.Should().Be(user.EmailAddress);
        }
    }
}
