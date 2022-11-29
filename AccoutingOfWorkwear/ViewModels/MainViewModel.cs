﻿using AoW.WPF.Infrastructure.Factorys;
using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;

namespace AoW.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public static INavigator Navigator { get; set; } = new Navigator(new StaffViewModel(), new AowViewModelFactory());
    }
}