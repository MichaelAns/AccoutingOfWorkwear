using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using MyMVVM.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : BaseEntityViewModel<ReceiptInfo>
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
        /// Информация о спецодежде
        /// </summary>
        private List<WorkWear> _workwear;

        /// <summary>
        /// Информация о производителях
        /// </summary>
        private List<Provider> _providers;

        #region Отмена выдачи одежды

        public ICommand CancelCommand { get; }

        private void CancelExecute(object obj)
        {
            MainViewModel.Navigator.CurrentViewModel = _staffViewModel;
        }

        #endregion


        #region Загрузка данных



        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.ReceiptInfo.Include(w => w.Workwear).Include(p => p.Provider).ToList();
            }
        }

        #endregion
    }
}
