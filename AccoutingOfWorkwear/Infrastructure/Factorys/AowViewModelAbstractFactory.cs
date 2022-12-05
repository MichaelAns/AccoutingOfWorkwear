using AoW.WPF.Infrastructure.Enums;
using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.ViewModelBase;
using System;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class AowViewModelAbstractFactory : IViewModelAbstractFactory
    {
        // Фабрики
        private readonly IViewModelFactory<StaffViewModel> _staffViewModelFactory;
        private readonly IViewModelFactory<WorkwearViewModel> _workwearViewModelFactory;

        public AowViewModelAbstractFactory(IViewModelFactory<StaffViewModel> staffViewModelFactory, 
            IViewModelFactory<WorkwearViewModel> workwearViewModelFactory)
        {
            _staffViewModelFactory = staffViewModelFactory;
            _workwearViewModelFactory = workwearViewModelFactory;
        }

        public ViewModel GetViewModel(object? parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Staff:
                        return _staffViewModelFactory.CreateViewModel();
                    case ViewType.Workwear:
                        return _workwearViewModelFactory.CreateViewModel();
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
