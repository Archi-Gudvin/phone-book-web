using phone_book.AuthoClientApp;
using phone_book.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Data
{  
    public class EFUserData : IUserData
    {
        private readonly ApplicationContext Context;

        public EFUserData(ApplicationContext context)
        {
            this.Context = context;
        }

        public IEnumerable<User> Get()
        {
            return this.Context.Users;
        }

        public User Get(int id)
        {
            return this.Context.Users.Find(id);
        }

        public async Task Update(User updatedUser)
        {
            User currentUser = Get(updatedUser.Id);
            currentUser.Name = updatedUser.Name;
            currentUser.Email = updatedUser.Email;

            Context.Users.Update(currentUser);
            await Context.SaveChangesAsync();
        }

        public User GetUserByEmail(string email)
        {
            var users = Context.Users.Where(e => e.Email == email);

            User user = new User();

            foreach (var item in users)
            {
                user.Id = item.Id;
                user.Name = item.Name;
                user.Email = item.Email;
                user.Password = item.Password;
            }

            return user;
        }
    }
}
