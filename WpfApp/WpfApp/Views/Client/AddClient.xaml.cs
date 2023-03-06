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

namespace WpfApp.Views.Client
{ 
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
            ClientDataApi context = new ClientDataApi();

            btnAddClient.Click += delegate
            {
                if (txtLastname != null && txtFirstname != null && txtPhoneNumber != null && txtAddress != null)
                {
                    context.AddClient(new Models.Client()
                    {
                        LastName = txtLastname.Text,
                        FirstName = txtFirstname.Text,
                        Patronymic = txtPatronymic.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Address = txtAddress.Text,
                        Desciption = txtDescription.Text
                    });

                } else MessageBox.Show("Не все поля заполнены");

                txtLastname.Text = "";
                txtFirstname.Text = "";
                txtPatronymic.Text = "";
                txtPhoneNumber.Text = "";
                txtAddress.Text = "";
                txtDescription.Text = "";
            };
        }
    }
}
