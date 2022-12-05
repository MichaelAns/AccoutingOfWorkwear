using AccoutingOfWorkwear.Windows;
using AoW.EntityFramework.Date;
using AoW.WPF.Infrastructure.Factorys;
using AoW.WPF.ViewModels;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AowDbContextFactory>();
            
            services.AddSingleton<IViewModelAbstractFactory, AowViewModelAbstractFactory>();
            /*services.AddSingleton<IViewModelFactory<StaffViewModel>, StaffViewModelFactory>();
            services.AddSingleton<IViewModelFactory<WorkwearViewModel>, WorkwearViewModelFactory>();*/

            services.AddSingleton<IViewModelFactory<MainViewModel>, MainViewModelFactory>();
            services.AddSingleton<IViewModelFactory<WorkwearViewModel>, WorkwearViewModelFactory>();

            services.AddSingleton<IViewModelFactory<StaffViewModel>>((services) =>
            new StaffViewModelFactory(new ViewModelFactoryRenavigator<WorkwearViewModel>(
                services.GetRequiredService<INavigator>(), services.GetRequiredService<IViewModelFactory<WorkwearViewModel>>())));

            /*services.AddSingleton<IViewModelFactory<WorkwearViewModel>>((services) =>
            new WorkwearViewModelFactory(new ViewModelFactoryRenavigator<MainViewModel>(
                services.GetRequiredService<INavigator>(), services.GetRequiredService<IViewModelFactory<MainViewModel>>())));*/

            services.AddSingleton<IViewModelFactory<WorkwearViewModel>>((services) =>
            new WorkwearViewModelFactory(new ViewModelFactoryRenavigator<MainViewModel>(
                services.GetRequiredService<INavigator>(), services.GetRequiredService<IViewModelFactory<MainViewModel>>())));

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<ViewModel, MainViewModel>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
