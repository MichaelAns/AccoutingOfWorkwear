using AoW.WPF.Infrastructure.Factorys;
using MVVM.ViewModel;
using Navigation.Navigators;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        static StaffViewModel staff = new();
        static AowViewModelFactory factory = new();
        //public INavigator Navigator { get; set; } = new Navigator(new StaffViewModel(), new AowViewModelFactory());
        public INavigator Navigator { get; set; } = new Navigator(staff, factory);

    }
}
