using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phone_book.Interfaces;
using phone_book.Models;
using phone_book.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace phone_book.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientData clientData;
        private readonly ApplicationContext context;

        public ClientController(IClientData ClientData, ApplicationContext Context)
        {
            this.clientData = ClientData;
            this.context = Context;
        }

        [HttpGet]
        public IActionResult Index(SortState sortOrder = SortState.LastNameAsc)
        {
            //сортировка по полям
            IQueryable<Client> clients = context.Clients;
            ViewData["LastNameSort"] = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
            ViewData["FirstNameSort"] = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
            ViewData["PatronymicSort"] = sortOrder == SortState.PatronymicAsc ? SortState.PatronymicDesc : SortState.PatronymicAsc;


            clients = sortOrder switch
            {
                SortState.LastNameDesc => clients.OrderByDescending(s => s.LastName),
                SortState.FirstNameAsc => clients.OrderBy(s => s.FirstName),
                SortState.FirstNameDesc => clients.OrderByDescending(s => s.FirstName),
                SortState.PatronymicAsc => clients.OrderBy(s => s.Patronymic),
                SortState.PatronymicDesc => clients.OrderByDescending(s => s.Patronymic),

                _ => clients.OrderBy(s => s.LastName),
            };

            return View(clients.AsNoTracking().ToList());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(clientData.Get(id));
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Create(Client model)
        {
            if (model.LastName != null && model.FirstName != null && model.PhoneNumber != null && model.Address != null)
            {
                var client = new Client()
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Patronymic = model.Patronymic,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Desciption = model.Desciption,
                };

                await clientData.Create(client);

                return Redirect("~/");
            }
            else ModelState.AddModelError("", "Не все поля заполнены");

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            return View(clientData.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(Client model)
        {
            if (model.LastName != null && model.FirstName != null && model.PhoneNumber != null && model.Address != null)
            {
                var client = new Client()
                {
                    Id = model.Id,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Patronymic = model.Patronymic,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Desciption = model.Desciption,
                };

                await clientData.Update(client);

                return Redirect("~/");
            }
            else ModelState.AddModelError("", "Не все поля заполнены");

            return View(model);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await clientData.Delete(id);

            return Redirect("~/");
        }
    }
}
