using AccoutingOfWorkwear.Windows;
using AoW.EntityFramework.Date;
using AoW.WPF.Infrastructure.Factorys;
using AoW.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using MyMVVM.Navigation.Navigators;
using System;
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
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<AowDbContextFactory>();

            services.AddScoped<MainViewModel>();
            //services.AddSingleton<Navigator, AowViewModelFactory>();
        }
    }
}
