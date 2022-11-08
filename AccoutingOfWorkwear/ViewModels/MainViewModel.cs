using AoW.WPF.Infrastructure.Navigators;
using MVVM.ViewModel;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator(new StaffViewModel());
    }
}
