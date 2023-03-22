using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using phone_book.AuthoClientApp;
using phone_book.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserData userData;

        public AdminController(IUserData UsertData)
        {
            this.userData = UsertData;
        }

        public IActionResult Index()
        {
            return View(userData.Get());
        }

        public IActionResult Get(int id)
        {
            return View(userData.Get(id));
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string email)
        {
            var user = new User()
            {
                Id = id,
                Email = email,
                Name = name,
            };

            userData.Update(user);

            return Redirect("~/Admin/");
        }

        [HttpPost]
        public IActionResult ResetPassword(string password)
        {
            return Redirect("~/Admin/");
        }
    }
}
