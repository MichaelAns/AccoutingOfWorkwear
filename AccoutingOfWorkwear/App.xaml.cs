using AccoutingOfWorkwear.Windows;
using AoW.EntityFramework.Date;
using AoW.WPF.Infrastructure.Factorys;
using AoW.WPF.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using MyMVVM.Navigation.Factory;
using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;
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
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AowDbContextFactory>(); 
            services.AddSingleton<IViewModelAbstractFactory, AowViewModelAbstractFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<ViewModel, StaffViewModel>();
            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
