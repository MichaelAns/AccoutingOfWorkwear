using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Infrastructure.DataMessage;
using AoW.WPF.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using MyMVVM.Commands;
using MyMVVM.Navigation.Navigators;
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
        public WorkwearViewModel(IRenavigator renavigator)
        {
            // Получение данных из Контейнера данных
            var dataMessage = AowDataContainer.GetDataContainer().GetDataMessage();
            _staffViewModel = dataMessage.StaffViewModel;
            _staff = dataMessage.Staff;

            _renavigator = renavigator;
            CancelCommand = new RelayCommand(CancelExecute, (obj) => true);
            ExtraditionCommand = new RelayCommand(ExtraditionExecute, ExtraditionCanExecute);

            UpdateListsAsync();
            
        }
        private readonly IRenavigator _renavigator;

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
        public ReceiptInfo FinishedSelectedItem
        {
            get => _finishedSelectedItem;
            set => Set(ref _finishedSelectedItem, value);
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
        /// Действие команды на выдачу одежды
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
            try
            {
                await Task.Run(() =>
                {
                    SelectedItem.Remains -= _ExtraditionCount;

                    using (var dbContext = new AowDbContextFactory().CreateDbContext())
                    {
                        // создание новой выдачи
                        var extradition = new ExtraditionInfo()
                        {
                            Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                            Staff = dbContext.Staff.FirstOrDefault(s => s.Id == _staff.Id),
                            Term = _Term,
                            WorkWear = dbContext.Workwear.FirstOrDefault(w => w.Id == SelectedItem.Workwear.Id)
                        };

                        // добавление записи
                        dbContext.Add(extradition);

                        // обновление поставки
                        var updatedReceipt = dbContext.ReceiptInfo.FirstOrDefault(e => e.Id == SelectedItem.Id);
                        updatedReceipt.Remains = SelectedItem.Remains;

                        Thread.Sleep(3000);
                        dbContext.SaveChanges();
                    }
                });
                MessageBox.Show("Изменения внесены в базу данных!");
            }
            catch(NullReferenceException nullRefExc)
            {
                MessageBox.Show(nullRefExc.Message);
            }
            catch(ArgumentNullException nullExc)
            {
                MessageBox.Show(nullExc.Message);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
                        
        #endregion

        /// <summary>
        /// Переключение на StaffViewModel
        /// </summary>
        private void BackToStaff()
        {
            _renavigator.Renavigate();
        }

        /// <summary>
        /// Обновление списков закончившееся и обычной одежды
        /// </summary>
        private async void UpdateListsAsync()
        {
            await Task.Run(() =>
            {
                // проверка на получение Items
                var flag = true;
                while (flag)
                {
                    flag = Items is null ? true: false;
                }

                FinishedWorkwear = Items.Where(r => r.Remains <= 0).ToList();
                Items = Items.Where(r => r.Remains > 0).ToList();
            });
        }

        protected override async Task<ICollection> Get()
        {
            var items = new List<ReceiptInfo>();
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.ReceiptInfo.Include(w => w.Workwear).Include(p => p.Provider).ToList();
            }
        }
    }
}
