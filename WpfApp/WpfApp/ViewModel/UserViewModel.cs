using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WpfApp.AuthoClientApp;
using WpfApp.Data;
using WpfApp.Interfaces;
using WpfApp.Views.User;

namespace WpfApp.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        static ApplicationContext context = new ApplicationContext();
        private IUserData userData = new EFUserData(context);

        private User selectedUser;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        public ObservableCollection<User> Users { get; set; }

        public UserViewModel()
        {
            context.Users.Load();
            Users = context.Users.Local.ToObservableCollection();
        }

        /// <summary>
        /// Конкретный пользователь
        /// </summary>
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        /// <summary>
        /// Команда редактирования пользователя
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      selectedItem = selectedUser;
                      User? user = selectedItem as User;
                      if (user == null) return;

                      //создаем выбранного клиента
                      User vm = new User
                      {
                          Id = user.Id,
                          Name = user.Name,
                          Email = user.Email
                      };

                      //передаем выбранного клиента в окно редактирования
                      UserWindow userWindow = new UserWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          //присваиваем новые значения
                          user.Name = userWindow.User.Name;
                          user.Email = userWindow.User.Email;
                          
                          userData.Update(user);
                      }
                  }));
            }
        }


        /// <summary>
        /// Команда удаления
        /// </summary>
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      selectedItem = selectedUser;
                      User? user = selectedItem as User;
                      if (user == null) return;
                      context.Users.Remove(user);
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
