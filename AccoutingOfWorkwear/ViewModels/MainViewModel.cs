using AoW.WPF.Infrastructure.Factorys;
using MVVM.ViewModel;
using Navigation.Navigators;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public static INavigator Navigator { get; set; } = new Navigator(new StaffViewModel(), new AowViewModelFactory());
        
    }
}
