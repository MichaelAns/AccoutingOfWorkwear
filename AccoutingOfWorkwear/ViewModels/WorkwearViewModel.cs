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
        /// Закончившаяся спецодежда
        /// </summary>
        #region Закончившаяся спецодежда
        private List<ReceiptInfo> _finishedWorkwear;

        public List<ReceiptInfo> FinishedWorkwear
        {
            get => _finishedWorkwear;
            set => Set(ref _finishedWorkwear, value);
        }

        private ReceiptInfo _finishedSelectedItem;
        public  ReceiptInfo FinishedSelectedItem
        {
            get => _finishedSelectedItem;
            set => Set(ref _finishedSelectedItem, _finishedSelectedItem = value);
        }
        #endregion

        #region Отмена выдачи одежды

        public ICommand CancelCommand { get; }

        private void CancelExecute(object obj)
        {
            MainViewModel.Navigator.CurrentViewModel = _staffViewModel;
        }

        #endregion


        


        protected override async Task<ICollection> Get()
        {
            var items = new List<ReceiptInfo>();
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                items = dbContext.ReceiptInfo.Include(w => w.Workwear).Include(p => p.Provider).ToList();
            }
            _finishedWorkwear = items.Where(r => r.Remains < 0).ToList();
            return items.Where(r => r.Remains > 0).ToList();
        }
    }
}
