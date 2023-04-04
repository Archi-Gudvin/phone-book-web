using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp.Models;
using WpfApp.Data;
using Microsoft.EntityFrameworkCore;
using WpfApp.Interfaces;
using WpfApp.Views;

namespace WpfApp.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        static ApplicationContext context = new ApplicationContext();
        private IClientData clientData = new EFClientData(context);

        private Client selectedClient;
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        public ObservableCollection<Client> Clients { get; set; }

        public ClientViewModel()
        {
            context.Clients.Load();
            Clients = context.Clients.Local.ToObservableCollection();
        }

        /// <summary>
        /// Конкретный клиент
        /// </summary>
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        /// <summary>
        /// Команда добавления клиента
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      ClientWindow clientWindow = new ClientWindow(new Client());
                      if (clientWindow.ShowDialog() == true)
                      {
                          Client client = clientWindow.Client;

                          clientData.Create(client);
                      }
                  }));
            }
        }

        /// <summary>
        /// Команда редактирования
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      selectedItem = selectedClient;
                      Client? client = selectedItem as Client;
                      if (client == null) return;

                      //создаем выбранного клиента
                      Client vm = new Client
                      {
                          Id = client.Id,
                          LastName = client.LastName,
                          FirstName = client.FirstName,
                          Patronymic = client.Patronymic,
                          PhoneNumber = client.PhoneNumber,
                          Address = client.Address,
                          Desciption = client.Desciption
                      };

                      //передаем выбранного клиента в окно редактирования
                      ClientWindow clientWindow = new ClientWindow(vm);

                      if (clientWindow.ShowDialog() == true)
                      {
                          //присваиваем новые значения
                          client.LastName = clientWindow.Client.LastName;
                          client.FirstName = clientWindow.Client.FirstName;
                          client.Patronymic = clientWindow.Client.Patronymic;
                          client.PhoneNumber = clientWindow.Client.PhoneNumber;
                          client.Address = clientWindow.Client.Address;
                          client.Desciption = clientWindow.Client.Desciption;
                          clientData.Update(client);
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
                      selectedItem = selectedClient;
                      Client? client = selectedItem as Client;
                      if (client == null) return;
                      clientData.Delete(client.Id);
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
