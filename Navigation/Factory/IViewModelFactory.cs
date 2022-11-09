using MVVM.ViewModel;

namespace Navigation.Factory
{
    public interface IViewModelFactory
    {
        public ViewModel GetViewModel(object? parameter);
    }
}
