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

                return Redirect("~/Admin/");
            }
            else ModelState.AddModelError("", "Не все поля заполнены");

            return View(model);
        }
    }
}
