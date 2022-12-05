using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels;

namespace AoW.WPF.Infrastructure.DataMessage
{
    internal class WorkwearDataMessage : MyMVVM.DataTransfer.DataMessage
    {
        private readonly StaffViewModel _staffViewModel;
        private readonly Staff _staff;

        public WorkwearDataMessage(StaffViewModel staffViewModel, Staff staff)
        {
            _staffViewModel = staffViewModel;
            _staff = staff;
        }
        public StaffViewModel StaffViewModel { get; }
        public Staff Staff { get; }
    }
}
