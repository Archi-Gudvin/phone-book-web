using phone_book.Interfaces;
using phone_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Data
{
    public class EFClientData : IClientData
    {
        private readonly ApplicationContext Context;

        public EFClientData(ApplicationContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Client> Get()
        {
            return this.Context.Clients;
        }

        public Client Get(int id)
        {
            return this.Context.Clients.Find(id);
        }

        public void Create(Client client)
        {
            Context.Clients.Add(client);
            Context.SaveChanges();
        }

        public void Update(Client updatedUser)
        {
            Client currentUser = Get(updatedUser.Id);
            currentUser.LastName = updatedUser.LastName;
            currentUser.FirstName = updatedUser.FirstName;
            currentUser.Patronymic = updatedUser.Patronymic;
            currentUser.PhoneNumber = updatedUser.PhoneNumber;
            currentUser.Address = updatedUser.Address;
            currentUser.Desciption = updatedUser.Desciption;

            Context.Clients.Update(currentUser);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Client client = Get(id);

            if (client != null)
            {
                Context.Clients.Remove(client);
                Context.SaveChanges();
            } 
        }
    }
}
