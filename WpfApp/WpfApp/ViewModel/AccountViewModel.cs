using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WpfApp.Data;
using WpfApp.Interfaces;
using WpfApp.Views.Account;
using WpfApp.Views;
using WpfApp.AuthoClientApp;

namespace WpfApp.ViewModel
{
    class AccountViewModel : INotifyPropertyChanged
    {
        static ApplicationContext context = new ApplicationContext();
        private IUserData userData = new EFUserData(context);

        RelayCommand? loginCommand;
        RelayCommand? registerCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand((o) =>
                  {
                      Login loginWindow = new Login();
                      
                      if (loginWindow.ShowDialog() == true)
                      {
                          User user = userData.GetUserByEmail(loginWindow.loginModel.Email);

                          if (user == null)
                          {
                              loginWindow.loginModel.Email = null;
                          }
                          else 
                          {
                          }
                      }
                  }));
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                  (registerCommand = new RelayCommand((o) =>
                  {
                      Register registerWindow = new Register();
                      if (registerWindow.ShowDialog() == true)
                      {

                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
