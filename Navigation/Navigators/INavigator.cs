using MVVM.ViewModel;
using System.Windows.Input;

namespace Navigation.Navigators
{
    public interface INavigator
    {
        ViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
