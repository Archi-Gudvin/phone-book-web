using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace phone_book.Models
{
    public class Client
    {
        //TODO: обработать уникальность номера телефона и email

        public int Id { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указан номер  телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; }
        public string Desciption { get; set; }
    }
}