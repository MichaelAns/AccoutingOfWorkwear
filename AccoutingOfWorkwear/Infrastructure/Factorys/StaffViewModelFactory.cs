using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class StaffViewModelFactory : IViewModelFactory<StaffViewModel>
    {
        public StaffViewModel CreateViewModel()
        {
            return new StaffViewModel();
        }
    }
}
