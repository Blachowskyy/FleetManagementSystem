using FleetManagementSystem.ViewModels;
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

namespace FleetManagementSystem.Views.MainPages
{
    /// <summary>
    /// Logika interakcji dla klasy ForkliftsLiveMonitoringPage.xaml
    /// </summary>
    public partial class ForkliftsLiveMonitoringPage : Page
    {
        public ForkliftsLiveMonitoringPage(ForkliftsLiveMonitoringPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
