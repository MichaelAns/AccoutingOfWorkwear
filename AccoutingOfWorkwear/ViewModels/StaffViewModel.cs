using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Views;
using MyMVVM.Commands;
using MyMVVM.ViewModelBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    public class StaffViewModel : ViewModel
    {
        private List<Staff> _staff;
        private Staff _selectedItem;
        public StaffViewModel()
        {
            LoadAsync();
        }

        /// <summary>
        /// Список сотрудников
        /// </summary>
        public List<Staff> Staff
        {
            get => _staff;
            set => Set(ref _staff, value);
        }

        /// <summary>
        /// Выделенный сотрудник
        /// </summary>
        public Staff SelectedItem 
        { 
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        #region загрузка данных       

        /// <summary>
        /// Асинхронная загрузка данных из базы данных
        /// </summary>
        private async void LoadAsync()
        {
            Get().ContinueWith(async task =>
            {
                if (task.Exception == null)
                {
                    Staff = (List<Staff>)task.Result;
                }
            });
        }

        /// <summary>
        /// Получение списка сотрудников из базы
        /// </summary>
        /// <returns>Список сотрудников</returns>
        private async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return new List<Staff>(dbContext.Staff);
            }
        }
        #endregion
                
        public ICommand UpdateCurrentViewModelCommand => MainViewModel.Navigator.UpdateCurrentViewModelCommand;


    }
}
