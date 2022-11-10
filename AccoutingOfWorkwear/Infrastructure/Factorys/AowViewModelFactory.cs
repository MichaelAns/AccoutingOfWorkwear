using AoW.WPF.Infrastructure.Enums;
using AoW.WPF.ViewModels;
using MVVM.ViewModel;
using Navigation.Factory;
using System;

namespace AoW.WPF.Infrastructure.Factorys
{
    internal class AowViewModelFactory : IViewModelFactory
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
                    case ViewType.Workwear:
                        return new WorkwearViewModel();
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
