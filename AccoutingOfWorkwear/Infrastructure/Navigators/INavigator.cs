using MVVM.ViewModel;
using System.Windows.Input;

namespace AoW.WPF.Infrastructure.Navigators
{
    internal interface INavigator
    {
        ViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
