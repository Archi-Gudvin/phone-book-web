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

        public IActionResult Get(int id)
        {
            return View(userData.Get(id));
        }  
    }
}
