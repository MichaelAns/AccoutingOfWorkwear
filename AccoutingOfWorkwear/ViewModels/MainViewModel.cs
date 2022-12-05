using AoW.WPF.Infrastructure.Enums;
using MyMVVM.Navigation;
using MyMVVM.Navigation.Factory;
using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public MainViewModel(INavigator navigator, IViewModelFactory viewModelAbstractFactory)
        {
            Navigator = navigator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelAbstractFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Staff);
        }

        public INavigator Navigator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
    }
}
