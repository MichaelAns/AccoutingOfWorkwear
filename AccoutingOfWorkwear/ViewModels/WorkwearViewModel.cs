﻿using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using MyMVVM.ViewModelBase;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : BaseEntityViewModel<WorkWear>
    {
        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.WorkWear.ToList();
            }
        }
    }
}
