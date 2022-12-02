using AoW.WPF.Infrastructure.Factorys;
using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
        }

        public INavigator Navigator { get; set; }// = new Navigator(new StaffViewModel(), new AowViewModelFactory());
    }
}
