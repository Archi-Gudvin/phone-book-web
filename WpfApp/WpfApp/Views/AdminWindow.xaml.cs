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
using WpfApp.ViewModel;

namespace WpfApp.Views.Client
{
    public partial class AdminWindow : Window
    { 

        public AdminWindow()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        } 
    }
}
