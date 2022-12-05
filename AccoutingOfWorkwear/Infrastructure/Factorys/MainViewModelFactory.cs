using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.Navigation.Navigators;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class MainViewModelFactory : IViewModelFactory<MainViewModel>
    {
        private readonly INavigator _navigator;
        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;

        public MainViewModelFactory(INavigator navigator, IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public MainViewModel CreateViewModel()
        {
            return new MainViewModel(_navigator, _viewModelAbstractFactory);
        }
    }
}
