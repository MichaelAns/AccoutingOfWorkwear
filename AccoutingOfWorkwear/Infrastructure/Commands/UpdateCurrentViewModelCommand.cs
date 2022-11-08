using AoW.WPF.Infrastructure.Enums;
using AoW.WPF.Infrastructure.Navigators;
using AoW.WPF.ViewModels;
using MVVM.Commands;

namespace AoW.WPF.Infrastructure.Commands
{
    internal class UpdateCurrentViewModelCommand : Command
    {
        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType)parameter;
                switch(viewType)
                {
                    case ViewType.Staff:
                        _navigator.CurrentViewModel = new StaffViewModel();
                        break;
                    case ViewType.ReceiptInfo:
                        break;
                    case ViewType.Provider:
                        break;
                    case ViewType.Workwear:
                        break;
                    case ViewType.ExtraditionInfo:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
