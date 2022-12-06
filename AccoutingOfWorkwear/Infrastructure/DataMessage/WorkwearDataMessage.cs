using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels;

namespace AoW.WPF.Infrastructure.DataMessage
{
    internal class WorkwearDataMessage
    {
        public WorkwearDataMessage(StaffViewModel staffViewModel, Staff staff)
        {
            StaffViewModel = staffViewModel;
            Staff = staff;
        }

        public StaffViewModel StaffViewModel { get; }
        public Staff Staff { get; } 
    }
}
