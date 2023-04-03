using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WpfApp.AuthoClientApp
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
