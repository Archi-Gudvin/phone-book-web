﻿using System;
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
using WpfApp.ViewModel;

namespace WpfApp.Views.Client
{ 
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        } 
    }
}