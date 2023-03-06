using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phone_book.Interfaces;
using phone_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace phone_book.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientData clientData;

        public ClientController(IClientData ClientData)
        {
            this.clientData = ClientData;
        }

        public IActionResult Index()
        {
            return View(clientData.Get());
        }

        [HttpGet]
        public IActionResult AllClientData(int id)
        {
            return View(clientData.Get(id));
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult Create(string lastName, string firstName, string patronymic, string phoneNumber,
            string address, string description)
        {
            var client = new Client()
            {
                LastName = lastName,
                FirstName = firstName,
                Patronymic = patronymic,
                PhoneNumber = phoneNumber,
                Address = address,
                Desciption = description,
            };

            clientData.Create(client);

            return Redirect("~/");
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult EditClient(int id)
        {
            return View(clientData.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult Update(int id, string lastName, string firstName, string patronymic, string phoneNumber,
            string address, string description)
        {
            var client = new Client()
            {
                Id = id,
                LastName = lastName,
                FirstName = firstName,
                Patronymic = patronymic,
                PhoneNumber = phoneNumber,
                Address = address,
                Desciption = description,
            };

            clientData.Update(client);

            return Redirect("~/");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            clientData.Delete(id);

            return Redirect("~/");
        }
    }
}
