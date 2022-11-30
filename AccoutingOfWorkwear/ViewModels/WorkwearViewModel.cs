using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using MyMVVM.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class WorkwearViewModel : BaseEntityViewModel<ReceiptInfo>
    {
        public WorkwearViewModel(StaffViewModel staffViewModel, Staff staff)
        {
            _staffViewModel = staffViewModel;            
            _staff = staff;
            CancelCommand = new RelayCommand(CancelExecute, (obj) => true);
            ExtraditionCommand = new RelayCommand(ExtraditionExecute, ExtraditionCanExecute);
        }

        /// <summary>
        /// Срок выдачи одежды. Пусть будет три
        /// </summary>
        private const int _Term = 3;

        /// <summary>
        /// Количество выдаваемой одежды
        /// </summary>
        private const int _ExtraditionCount = 1;

        // StaffViewModel для возращения назад
        private readonly StaffViewModel _staffViewModel;

        /// <summary>
        /// Cотрудник, которому выдают СО
        /// </summary>
        private readonly Staff _staff;


        #region Закончившаяся спецодежда

        /// <summary>
        /// Закончившаяся спецодежда
        /// </summary>
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
            BackToStaff();
        }

        #endregion

        #region Выдача одежды 

        /// <summary>
        /// Команда на выдачу
        /// </summary>
        public ICommand ExtraditionCommand { get; }

        /// <summary>
        /// Выдача одежды
        /// </summary>
        /// <param name="obj"></param>
        private void ExtraditionExecute(object obj)
        {
            ExtraditionAsync();
            BackToStaff();
        }
        
        // если есть выделенный элемент
        private bool ExtraditionCanExecute(object obj)
        {
            return SelectedItem is not null;
        }

        /// <summary>
        /// Асинхронная выдача одежды 
        /// </summary>
        private async void ExtraditionAsync()
        {
            // создание новой выдачи
            var extradition = new ExtraditionInfo()
            {
                Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                /*Staff = new()
                {
                    Id = _staff.Id,
                    FirstName = _staff.FirstName,
                    SecondName = _staff.SecondName,
                    LastName = _staff.LastName,
                    Post = _staff.Post,
                    Profession = _staff.Profession
                },*/
                Staff = _staff,
                Term = _Term,
                WorkWear = SelectedItem.Workwear
                /*WorkWear = new()
                {
                    Id = SelectedItem.Workwear.Id,
                    Name = SelectedItem.Workwear.Name,
                    Price = SelectedItem.Workwear.Price,
                    Type = SelectedItem.Workwear.Type
                }*/
            };

            SelectedItem.Remains -= _ExtraditionCount;

            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                //dbContext.ExtraditionInfo.Add(extradition);

                // обновление поставки
                /*var receipt = dbContext.ReceiptInfo.FirstOrDefault(r => r.Id == SelectedItem.Id);
                receipt = SelectedItem;*/
                dbContext.ReceiptInfo.Update(SelectedItem);

                dbContext.SaveChanges();
            }

            MessageBox.Show("Изменения внесены в базу данных!");
        }
                
        #endregion

        /// <summary>
        /// Переключение на StaffViewModel
        /// </summary>
        private void BackToStaff()
        {
            MainViewModel.Navigator.CurrentViewModel = _staffViewModel;
        }

        protected override async Task<ICollection> Get()
        {
            var items = new List<ReceiptInfo>();
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                items = dbContext.ReceiptInfo.Include(w => w.Workwear).Include(p => p.Provider).ToList();
            }
            FinishedWorkwear = items.Where(r => r.Remains < 0).ToList();
            return items.Where(r => r.Remains > 0).ToList();
        }
    }
}
