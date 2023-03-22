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
        string GetNewPassword();
        bool ChangePassword(User user, string email);
    }
}
