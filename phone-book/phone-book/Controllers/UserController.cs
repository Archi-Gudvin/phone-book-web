using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phone_book.AuthoClientApp;
using phone_book.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        private readonly IUserData userData;

        public UserController(IUserData UsertData)
        {
            this.userData = UsertData;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string email = HttpContext.User.Identity.Name;
            return View(userData.GetUserByEmail(email));
        }

        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            if (model.Email != null && model.Name != null)
            {
                var user = new User()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Name = model.Name,
                };

                await userData.Update(user);

                return Redirect("~/");
            }
            else ModelState.AddModelError("", "Не все поля заполнены");

            return View(model);
        }
    }
}
