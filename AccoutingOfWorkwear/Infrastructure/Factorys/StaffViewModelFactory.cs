using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.Navigation.Navigators;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class StaffViewModelFactory : IViewModelFactory<StaffViewModel>
    {
        private readonly IRenavigator _renavigator;

        public StaffViewModelFactory(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public StaffViewModel CreateViewModel()
        {
            return new StaffViewModel(_renavigator);
        }
    }
}
