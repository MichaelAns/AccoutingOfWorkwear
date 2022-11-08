using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AoW.WPF.ViewModels
{
    internal class StaffViewModel : Base.TableViewModel<Staff>
    {
        public StaffViewModel()// : base()
        {
            LoadAsync();
        }

        

        #region загрузка данных 
        

        protected override void SetList(AowDbContext dbContext)
        {
            Items = new(dbContext.Staff);
        }
        
        private async void LoadAsync()
        {
            Get().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    _allItems = (List<Staff>)task.Result;
                    Items = _allItems;
                }
            });
        }
        private async Task<ICollection> Get()
        {
            using (var dbContext = _aowDbContextFactory.CreateDbContext())
            {
                return new List<Staff>(dbContext.Staff);
            }
        }
        #endregion


    }
}
