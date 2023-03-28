using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using phone_book.Data;
using phone_book.AuthoClientApp;
using phone_book.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using phone_book.Services;
using phone_book.Interfaces;
using Microsoft.AspNetCore.Http;

namespace RolesApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext _context;
        private readonly IUserData userData;
        private readonly IAccount account;

        public AccountController(ApplicationContext Context, IUserData UsertData, IAccount Account)
        {
            this._context = Context;
            this.userData = UsertData;
            this.account = Account;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Name = model.Name, Password = model.Password };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Client");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Client");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Client");
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult ChangePassword(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            if (model.Id != 0 && model.OldPassword != null && model.NewPassword != null && model.ConfirmPassword != null)
            {
                var user = userData.Get(model.Id);

                if (model.NewPassword == model.ConfirmPassword && model.OldPassword == user.Password)
                {
                    if (account.ChangePassword(model.Id, model.NewPassword))
                    {
                        return Redirect("~/");
                    }
                    else return NotFound();
                }
                else ModelState.AddModelError("", "Пароли не совпадают");
            }
            else ModelState.AddModelError("", "Не все поля заполнены");

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(int id, string email)
        {
            if (ModelState.IsValid)
            {
                var user = userData.Get(id);

                if (user != null)
                {
                    if (account.ResetPassword(user, email))
                    {
                        EmailService emailService = new EmailService();
                        await emailService.SendEmailAsync(email, "Change Password",
                            $"Ваш новый пароль: {user.Password}");

                        return View("ChangePasswordConfirmation");
                    }
                    else return NotFound();
                }
                else
                {
                    return NotFound();
                }
            }

            return RedirectToAction("Login", "Account");
        }
    }
}