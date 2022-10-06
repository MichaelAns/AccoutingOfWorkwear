using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Views;
using System.Threading.Tasks;

namespace AoW.WPF.ViewModels
{
    internal class StaffViewModel : Base.TableViewModel<Staff>
    {
        public StaffViewModel() : base()
        {
            //Load();
        }

        // загрузка данных 
        private async void Load()
        {
            await Task.Run(() =>
            {
                using (var dbContext = _aowDbContextFactory.CreateDbContext())
                {
                    Items = new(dbContext.Staff);
                }
            });
        }
    }
}
