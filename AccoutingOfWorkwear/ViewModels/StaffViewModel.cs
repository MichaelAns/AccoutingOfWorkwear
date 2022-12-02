using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using MyMVVM.Commands;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class StaffViewModel : BaseEntityViewModel<Staff>
    {
        public StaffViewModel()
        {
            SelectWorkwearCommand = new RelayCommand(SelectWorkwearExecute, SelectWorkwearCanExecute);
        }

        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.Staff.ToList();
            }
        } 
        
        #region Выбор одежды

        // свойство
        public ICommand SelectWorkwearCommand { get; }    

        // метод
        private void SelectWorkwearExecute(object obj)
        {
            //MainViewModel.Navigator.CurrentViewModel = new WorkwearViewModel(this, SelectedItem);
        }

        // проверка
        private bool SelectWorkwearCanExecute(object obj)
        {
            // если есть выделенный элемент
            return SelectedItem is not null;
        }

        #endregion
    }
}
