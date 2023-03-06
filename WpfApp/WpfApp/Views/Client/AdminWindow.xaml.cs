using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
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
    public partial class AdminWindow : Window
    { 
        ClientDataApi context;

        public AdminWindow()
        {
            InitializeComponent();
            context = new ClientDataApi();
            
            btnLoadClient.Click += delegate
            {
                clientsDataGrid.ItemsSource = context.GetClients();
            };

            btnAddClient.Click += delegate
            {
                AddClient addClient = new AddClient();
                addClient.Show();
            };

            btnEditClient.Click += delegate
            {
                Models.Client client = (Models.Client)clientsDataGrid.SelectedItem;
                EditClient editClient = new EditClient(context.GetClient(client.Id));
                editClient.Show();
            };
        }

        private void btnDeleteClient(object sender, RoutedEventArgs e)
        {
            Models.Client client = ((FrameworkElement)sender).DataContext as Models.Client;
            context.DeleteClient(client.Id);
        }
    }
}
