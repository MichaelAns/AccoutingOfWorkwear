using AccoutingOfWorkwear.Windows;
using AoW.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AccoutingOfWorkwear
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            base.OnStartup(e);
        }
    }
}
