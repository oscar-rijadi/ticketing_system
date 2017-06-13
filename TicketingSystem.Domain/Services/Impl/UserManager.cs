using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using TicketingSystem.Core;
using TicketingSystem.Core.Db;
using TicketingSystem.Core.Db.Interfaces;
using TicketingSystem.Core.Entities;
using TicketingSystem.Core.Interfaces;
using TicketingSystem.Domain.Interfaces;
using TicketingSystem.EF.DbContexts;
using TicketingSystem.EF.Factories;

namespace TicketingSystem.Domain.Services.Impl
{
    public class UserManager : IUserManager
    {
        private readonly IWritableRepository<User> _userRepo;

        public UserManager()
            : this(new ConfigSettingsProvider())
        {
        }

        public UserManager(IConfigProvider config): this(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(config)))
        {
        }

        public UserManager(IRepositoryFactory repositoryFactory)
        {
            Contract.Assert(repositoryFactory != null, "IRepositoryFactory cannot be null");
            _userRepo = repositoryFactory.CreateWritable<User>();
        }

        public User Get(Expression<Func<User, bool>> predicate)
        {
            var user = _userRepo.GetOrDefault(predicate);
            if (user == null)
            {
                throw new Exception();
            }

            return user;
        }

        public IEnumerable<User> Users(Expression<Func<User, bool>> predicate = null)
        {
            var userQueryable = _userRepo.Select();
            return predicate != null ? userQueryable.Where(predicate) : userQueryable;
        }

        public ActionStatus Save(User user)
        {
            var isNew = true;
            var entity = user.Id > 0 ? _userRepo.GetOrDefault(x => x.Id == user.Id) : _userRepo.GetOrDefault(x => x.EmailAddress == user.EmailAddress);
            if (entity != null)
            {
                isNew = false;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
            }
            else
            {
                entity = user;
            }

            var result = new ActionStatus();
            try
            {
                _userRepo.Save(entity, isNew);
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                var error = new List<string> { ex.StackTrace };
            }
            return result;
        }
    }
}
