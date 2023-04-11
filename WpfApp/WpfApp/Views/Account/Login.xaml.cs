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

namespace WpfApp.Views.Account
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public LoginModel loginModel = new LoginModel();

        public bool Result { get; set; }

        public Login()
        {
            InitializeComponent();
            btnLogin.Click += (o, e) =>
            {
                if (txtEmail != null && txtPassword != null)
                {
                    if (true)
                    {
                        DataContext = loginModel;
                        DialogResult = true;
                    }
                   
                }
                else MessageBox.Show("Не все поля заполнены");
            };

            btnRegister.Click += (o, e) =>
            {

            };
        }
    }
}
