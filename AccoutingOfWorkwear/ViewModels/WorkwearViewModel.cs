using MVVM.Commands;
using MVVM.ViewModel;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : ViewModel
    {
        public ICommand UpdateCurrentViewModelCommand { get; set; }
        void fikalis(object obj) => MainViewModel.Navigator.CurrentViewModel = new StaffViewModel();

        public WorkwearViewModel()
        {
            UpdateCurrentViewModelCommand = new RelayCommand((obj) => MainViewModel.Navigator.CurrentViewModel = new StaffViewModel(), (obj) => true);
            
        }
    }
}
