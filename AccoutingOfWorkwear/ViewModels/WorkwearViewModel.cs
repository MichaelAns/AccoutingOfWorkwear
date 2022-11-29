using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using MyMVVM.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : BaseEntityViewModel<WorkWear>
    {
        public WorkwearViewModel(StaffViewModel staffViewModel, Staff staff)
        {
            _staffViewModel = staffViewModel;
            CancelCommand = new RelayCommand(CancelExecute, (obj) => true);
            _staff = staff; 
        }

        // StaffViewModel для возращения назад
        private readonly StaffViewModel _staffViewModel;

        /// <summary>
        /// Cотрудник, которому выдают СО
        /// </summary>
        private readonly Staff _staff;

        /// <summary>
        /// Информация о поставках
        /// </summary>
        private List<ExtraditionInfo> _extraditionInfo;


        #region Отмена выдачи одежды

        public ICommand CancelCommand { get; }

        private void CancelExecute(object obj)
        {
            MainViewModel.Navigator.CurrentViewModel = _staffViewModel;
        }

        #endregion

        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.WorkWear.ToList();
            }
        }
    }
}
