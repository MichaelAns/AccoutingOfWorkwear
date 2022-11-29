using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using AoW.WPF.Views;
using MyMVVM.Commands;
using MyMVVM.ViewModelBase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class StaffViewModel : BaseEntityViewModel<Staff>
    {
        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.Staff.ToList();
            }
        }
    }
}
