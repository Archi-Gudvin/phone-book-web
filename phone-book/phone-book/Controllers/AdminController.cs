using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phone_book.Interfaces;

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
    }
}
