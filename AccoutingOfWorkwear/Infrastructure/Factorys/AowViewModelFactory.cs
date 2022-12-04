using AoW.WPF.Infrastructure.Enums;
using AoW.WPF.ViewModels;
using MyMVVM.Navigation.Factory;
using MyMVVM.ViewModelBase;
using System;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class AowViewModelFactory : IViewModelAbstractFactory
    {
        public ViewModel GetViewModel(object? parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Staff:
                        return new StaffViewModel();
                    default:
                        throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
