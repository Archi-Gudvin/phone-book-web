using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.AuthoClientApp
{
    public class FogotPasswordModel
    {
        /// <summary>
        /// Email пользователя
        /// </summary>
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
    }
}
