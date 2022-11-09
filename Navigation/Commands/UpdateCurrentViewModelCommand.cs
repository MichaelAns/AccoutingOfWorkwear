using MVVM.Commands;
using Navigation.Factory;
using Navigation.Navigators;

namespace Navigation.Commands
{
    public class UpdateCurrentViewModelCommand : Command
    {
        private INavigator _navigator;
        private IViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }


        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => _navigator.CurrentViewModel = _viewModelFactory.GetViewModel(parameter);
    }
}
