using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Core.Entities;
using TicketingSystem.Domain.Interfaces;
using TicketingSystem.EF.DbContexts;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        public ActionResult Index()
        {
            var users = _userManager.Users()
                .Select(x => new UserViewModel
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress
                })
                .ToList();
            var userIndexViewModel = new UserIndexViewModel
            {
                Users = users
            };
            return View(userIndexViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = GetUserViewModel((int)id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress
                };
                _userManager.Save(entity);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = GetUserViewModel((int)id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress
                };
                _userManager.Save(entity);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        private UserViewModel GetUserViewModel(int userId)
        {
            var user = _userManager.Get(x => x.Id == userId);
            if (user == null)
            {
                return null;
            }
            var userViewModel = new UserViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress
            };
            return userViewModel;
        }
    }
}
