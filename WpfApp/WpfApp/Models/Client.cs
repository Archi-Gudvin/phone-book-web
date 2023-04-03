using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Models
{
    public class Client : INotifyPropertyChanged
    {
        string lastname;
        string firstName;
        string? patronymic;
        string phoneNumber;
        string address;
        string? desciption;


        /// <summary>
        /// ID клиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }


        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string? Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Описание клиента
        /// </summary>
        public string? Desciption
        {
            get { return desciption; }
            set
            {
                desciption = value;
                OnPropertyChanged("Desciption");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
