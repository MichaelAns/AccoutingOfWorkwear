using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : ViewModel
    {
        public ICommand UpdateCurrentViewModelCommand => MainViewModel.Navigator.UpdateCurrentViewModelCommand;

        public WorkwearViewModel()
        {
                        
        }
    }
}
