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
using WpfApp.AuthoClientApp;

namespace WpfApp.Views.User
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public AuthoClientApp.User User = new AuthoClientApp.User();

        public UserWindow(AuthoClientApp.User user)
        {
            InitializeComponent();
            User = user;
            btnSend.Click += (o, e) =>
            {
                User.Name = txtName.Text;
                User.Email = txtEmail.Text;

                DialogResult = true;
            };

            DataContext = User;
        }
    }
}
