using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Views;
using MVVM.Commands;
using MVVM.ViewModel;
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
            UpdateCurrentViewModelCommand = new RelayCommand((obj) => MainViewModel.Navigator.CurrentViewModel = new WorkwearViewModel(), (obj) => true);
        }

        public List<Staff> Staff { get => _staff; set => Set(ref _staff, value); }
        public Staff SelectedItem { get => _selectedItem; set => Set(ref _selectedItem, value); }

        #region загрузка данных       
        
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
        private async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return new List<Staff>(dbContext.Staff);
            }
        }
        #endregion

        //public ICommand UpdateCurrentViewModelCommand => MainViewModel.Navigator.UpdateCurrentViewModelCommand;
        public ICommand UpdateCurrentViewModelCommand { get; set; }


    }
}
