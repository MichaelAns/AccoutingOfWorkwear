using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class WorkwearViewModelFactory : IViewModelFactory<WorkwearViewModel>
    {
        public WorkwearViewModel CreateViewModel()
        {
            return new WorkwearViewModel();
        }
    }
}
