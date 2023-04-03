using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp.Models;
using WpfApp.Data;
using Microsoft.EntityFrameworkCore;
using WpfApp.Views.Client;
using WpfApp.Interfaces;

namespace WpfApp.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        ApplicationContext context = new ApplicationContext();
        private IClientData clientData;

        private Client selectedClient;
        //RelayCommand? addCommand;
        //RelayCommand? editCommand;
        //RelayCommand? deleteCommand;

        public ObservableCollection<Client> Clients { get; set; }

        public ClientViewModel(IClientData  ClientData)
        {
            this.clientData = ClientData;
        }

        public ClientViewModel()
        {
            context.Clients.Load();
            Clients = context.Clients.Local.ToObservableCollection();
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        //// команда добавления
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        //return addCommand ??
        //        //  (addCommand = new RelayCommand((o) =>
        //        //  {
        //        //      ClientWindow clientWindow = new ClientWindow(new Client());
        //        //      if (clientWindow.ShowDialog() == true)
        //        //      {
        //        //          Client client = clientWindow.Client;
        //        //          clientData.Create(client);
        //        //      }
        //        //  }));
        //    }
        //}

        //// команда редактирования
        //public RelayCommand EditCommand
        //{
        //    //get
        //    //{
        //    //    //return editCommand ??
        //    //    //  (editCommand = new RelayCommand((selectedItem) =>
        //    //    //  {
        //    //    //      // получаем выделенный объект
        //    //    //      User? user = selectedItem as User;
        //    //    //      if (user == null) return;

        //    //    //      User vm = new User
        //    //    //      {
        //    //    //          Id = user.Id,
        //    //    //          Name = user.Name,
        //    //    //          Age = user.Age
        //    //    //      };
        //    //    //      UserWindow userWindow = new UserWindow(vm);


        //    //    //      if (userWindow.ShowDialog() == true)
        //    //    //      {
        //    //    //          user.Name = userWindow.User.Name;
        //    //    //          user.Age = userWindow.User.Age;
        //    //    //          db.Entry(user).State = EntityState.Modified;
        //    //    //          db.SaveChanges();
        //    //    //      }
        //    //    //  }));
        //    //}
        //}

        // команда удаления
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return deleteCommand ??
        //          (deleteCommand = new RelayCommand((selectedItem) =>
        //          {
        //              // получаем выделенный объект
        //              Client? client = selectedItem as Client;
        //              if (client == null) return;
        //              clientData.Delete(client.Id);
        //          }));
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
