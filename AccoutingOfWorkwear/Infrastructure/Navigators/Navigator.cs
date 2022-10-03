using AoW.WPF.Infrastructure.Commands;
using MVVM.ViewModel;
using System.Windows.Input;

namespace AoW.WPF.Infrastructure.Navigators
{
    internal class Navigator : ViewModel, INavigator
    {
        private ViewModel _currentViewModel;
        
        #region Конструкторы
        public Navigator() { }
        public Navigator(ViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
        }
        #endregion

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
