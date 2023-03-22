﻿using Microsoft.AspNetCore.Identity;
using phone_book.AuthoClientApp;
using phone_book.Data;
using phone_book.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Models
{
    public class AccountModel : IAccount
    {
        //TODO: реализовать хеширование паролей

        private readonly ApplicationContext Context;

        public AccountModel(ApplicationContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Метод генерации пароля
        /// </summary>
        /// <returns></returns>
        public string GetNewPassword()
        {
            string NewPassword = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            Random rnd = new Random();
            for (int i = 0; i < 10; i = i + 1)
            {
                NewPassword += arr[rnd.Next(0, 57)];
            }

            return NewPassword;
        }

        /// <summary>
        /// Метод изменения пароля
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ChangePassword(User user, string email)
        {
            if (user.Email == email)
            {
                var NewPassword = GetNewPassword();

                user.Password = NewPassword;
                Context.Users.Update(user);
                this.Context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
