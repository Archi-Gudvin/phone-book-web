using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp.Views
{ 
    public partial class ClientWindow : Window
    {
        public Models.Client Client = new Models.Client();

        public ClientWindow(Models.Client client)
        {
            InitializeComponent();
            Client = client;
            btnAdd.Click += (o,e) =>
            {
                Client.LastName = txtLastName.Text;
                Client.FirstName = txtFirstName.Text;
                Client.Patronymic = txtPatronymic.Text;
                Client.PhoneNumber = txtPhoneNumber.Text;
                Client.Address = txtAddress.Text;
                Client.Desciption = txtDesciption.Text;

                DialogResult = true;
            };
            DataContext = Client;
        } 
    }
}
