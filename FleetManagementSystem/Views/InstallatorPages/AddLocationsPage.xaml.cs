﻿using FleetManagementSystem.ViewModels.InstallatorPagesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FleetManagementSystem.Views.InstallatorPages
{
    /// <summary>
    /// Logika interakcji dla klasy AddLocationsPage.xaml
    /// </summary>
    public partial class AddLocationsPage : Page
    {
        public AddLocationsPage(AddLocationsPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
