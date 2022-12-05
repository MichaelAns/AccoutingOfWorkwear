using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.Navigation.Navigators;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class WorkwearViewModelFactory : IViewModelFactory<WorkwearViewModel>
    {
        private readonly IRenavigator _renavigator;

        public WorkwearViewModelFactory(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public WorkwearViewModel CreateViewModel()
        {
            return new WorkwearViewModel(_renavigator);
        }
    }
}
