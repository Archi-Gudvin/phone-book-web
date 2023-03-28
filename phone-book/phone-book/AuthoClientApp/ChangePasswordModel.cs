using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.AuthoClientApp
{
    public class ChangePasswordModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текущий пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        /// <summary>
        /// Повтор нового пароля
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
