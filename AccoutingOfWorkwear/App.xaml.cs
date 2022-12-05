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
            services.AddSingleton<IViewModelFactory, AowViewModelFactory>();

            services.AddSingleton<CreateViewModel<MainViewModel>>(services =>
            {
                return () => services.GetRequiredService<MainViewModel>();
            });            

            services.AddSingleton<CreateViewModel<WorkwearViewModel>>(services =>
            {
                /*return () => new WorkwearViewModel(
                    new ViewModelDelegatingRenavigator<MainViewModel>(
                        services.GetRequiredService<INavigator>(),
                        services.GetRequiredService<CreateViewModel<MainViewModel>>()));*/
                return () => new WorkwearViewModel(
                    new ViewModelDelegatingRenavigator<StaffViewModel>(
                        services.GetRequiredService<INavigator>(),
                        services.GetRequiredService<CreateViewModel<StaffViewModel>>()));
            });

            services.AddSingleton<CreateViewModel<StaffViewModel>>(services =>
            {
                return () => services.GetRequiredService<StaffViewModel>();
            });

            services.AddSingleton<StaffViewModel>(services => new StaffViewModel(
                    new ViewModelDelegatingRenavigator<WorkwearViewModel>(
                        services.GetRequiredService<INavigator>(),
                        services.GetRequiredService<CreateViewModel<WorkwearViewModel>>())));

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<ViewModel, MainViewModel>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
