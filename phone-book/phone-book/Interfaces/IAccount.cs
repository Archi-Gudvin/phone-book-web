using Microsoft.AspNetCore.Identity;
using phone_book.AuthoClientApp;
using phone_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Создание нового пароля
        /// </summary>
        /// <returns></returns>
        string GetNewPassword();

        /// <summary>
        /// Метод сброса пароля
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ResetPassword(User user, string email);

        /// <summary>
        /// Метод изменения пароля
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        bool ChangePassword(int id, string NewPassword);
    }
}
