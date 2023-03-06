using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using phone_book.Data;
using phone_book.Interfaces;
using phone_book.Models;

namespace phone_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientData ClientData;

        public ClientsController(IClientData ClientData)
        {
            this.ClientData = ClientData;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return ClientData.Get();
        }

        // GET api/Clients/5
        [HttpGet("{id}", Name = "Get")]
        public Client Get(int id)
        {
            return ClientData.Get(id);
        }

        // POST api/Clients
        [HttpPost]
        public void Post(string lastName, string firstName, string patronymic, string phoneNumber,
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

            ClientData.Create(client);
        }

        // PUT api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, string lastName, string firstName, string patronymic, string phoneNumber,
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

            ClientData.Update(client);
        }

        // DELETE api/Clients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ClientData.Delete(id);
        }
    }
}
