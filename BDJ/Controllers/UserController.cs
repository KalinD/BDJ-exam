using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDJ.Data;
using BDJ.Models;
using BDJ.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDJ.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            UsersIndexViewModel model = new UsersIndexViewModel(){ 
                Users = userService.GetAll().Select(u => new UserIndexViewModel(){ 
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    IsAdmin = userService.IsAdmin(u)
                }).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id) { 
            userService.Delete(userService.GetById(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(UserCreateViewModel model) { 
            User user = new User() { 
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.Password
            };
            userService.Create(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id) {
            User user = userService.GetById(id);
            UserEditViewModel model = new UserEditViewModel() { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Id = user.Id
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(UserEditViewModel model)
        {
            User user = new User(){ 
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Id = model.Id
            };

            userService.Update(user);

            return RedirectToAction("Index");
        }
    }
}