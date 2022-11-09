using MVVM.ViewModel;
using Navigation.Commands;
using Navigation.Factory;
using System.Windows.Input;

namespace Navigation.Navigators
{
    public class Navigator : ViewModel, INavigator
    {
        private ViewModel _currentViewModel;
        private IViewModelFactory _viewModelFactory;

        #region Конструкторы
        public Navigator(ViewModel currentViewModel, IViewModelFactory viewModelFactory)
        {
            _currentViewModel = currentViewModel;
            _viewModelFactory = viewModelFactory;
        }
        #endregion

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this, _viewModelFactory);
    }
}
