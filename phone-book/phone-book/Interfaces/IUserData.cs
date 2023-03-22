using phone_book.AuthoClientApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Interfaces
{
    public interface IUserData
    {
        /// <summary>
        /// Метод получения коллекции зарегистрированных пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> Get();

        /// <summary>
        /// Метод получения конкретного зарегистрированного пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Get(int id);

        /// <summary>
        /// Метод обновления данных зарегистрированного пользователя
        /// </summary>
        /// <param name="user"></param>
        Task Update(User user);
    }
}
