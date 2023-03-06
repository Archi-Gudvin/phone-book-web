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

namespace WpfApp.Views.Client
{
    public partial class EditClient : Window
    {
        private static int IdClient = 0;

        ClientDataApi context;

        public EditClient(Models.Client client)
        { 
            InitializeComponent();
            context = new ClientDataApi();
            IdClient = client.Id; 
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            if (txtLastname != null && txtFirstname != null && txtPhoneNumber != null && txtAddress != null)
            {
                var client = new Models.Client()
                {
                    Id = IdClient,
                    LastName = txtLastname.Text,
                    FirstName = txtFirstname.Text,
                    Patronymic = txtPatronymic.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Address = txtAddress.Text,
                    Desciption = txtDescription.Text
                };

                context.UpdateClient(client);

                IdClient = 0;
            }
            else MessageBox.Show("Не все поля заполнены");

        }
    }
}
