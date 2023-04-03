using WpfApp.AuthoClientApp;
using System.Collections.Generic;

namespace WpfApp.Interfaces
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
        void Update(User user);

        /// <summary>
        /// Метод получения пользователя по Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);
    }
}
