using AoW.WPF.Infrastructure.Enums;
using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.ViewModelBase;
using System;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class AowViewModelFactory : IViewModelFactory
    {  
        private readonly CreateViewModel<StaffViewModel> _createStaffViewModel;
        private readonly CreateViewModel<WorkwearViewModel> _createWorkwearViewModel;

        public AowViewModelFactory(CreateViewModel<StaffViewModel> createStaffViewModel,
            CreateViewModel<WorkwearViewModel> createWorkwearViewModel)
        {
            _createStaffViewModel = createStaffViewModel;
            _createWorkwearViewModel = createWorkwearViewModel;
        }

        public ViewModel GetViewModel(object? parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Staff:
                        return _createStaffViewModel();
                    case ViewType.Workwear:
                        return _createWorkwearViewModel();
                    default:
                        throw new Exception();
                }
            }
            else
            {
                throw new Exception("parameter is not ViewType");
            }
        }
    }
}
