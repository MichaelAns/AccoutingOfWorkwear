using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models.Base;
using MVVM.Commands;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AoW.WPF.ViewModels.Base
{
    internal class TableViewModel<TModel>: ViewModel  
        where TModel : BaseEntity, new()
    {
        //для обращения к бд
        protected readonly AowDbContextFactory _aowDbContextFactory;
        //все записи
        protected List<TModel> _allItems;
        //id измененных записей         
        protected List<int> _updatedItemsIds;
        //фильтр
        //protected string _filter;

        //
        private List<TModel> _items;
        private TModel _selectedItem;

        #region Свойства
        public List<TModel> Items
        {
            get => _items;
            set => Set(ref _items, value);              
            /*set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }*/
        }

        public TModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    _updatedItemsIds.Add(_selectedItem.Id);
                }
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        #endregion

        #region Операции с данными

        #region Команды
        public Command AddNewRecord { get; }
        public Command DeleteSelectedItem { get; }
        public Command CommitChanges { get; set; }

        #endregion

        #region Методы


        // сохранить изменения в БД
        private void Commit(object obj)
        {
            try
            {
                List<TModel> dbData;
                var itemsIds = Items.Select(x => x.Id);

                //удаление из базы записей, удаленных с компьютера
                using (var dbContext = _aowDbContextFactory.CreateDbContext())
                {
                    dbContext.Set<TModel>().RemoveRange(dbContext.Set<TModel>().Where( x => !itemsIds.Contains(x.Id)));
                    dbData = dbContext.Set<TModel>().ToList();
                    dbContext.SaveChanges();

                    //добавление и обновление записей
                    foreach (var item in Items)
                    {
                        // добавление записи, если ее нет в БД
                        if (!dbData.Any(x => object.Equals(x.Id, item.Id)))
                        {                            
                            dbContext.Set<TModel>().Add(item);
                        }
                    }

                    // обновление выбранных записей
                    dbContext.UpdateRange(Items.Where(x => _updatedItemsIds.Contains(x.Id)));
                    _updatedItemsIds.Clear();

                    dbContext.SaveChanges();
                }
                MessageBox.Show("Выполнено");
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        // добавление записи
        private void AddRecord(object obj)
        {
            if (Items.Count != 0)
            {
                Items.Add(new TModel() { Id = MaxId() + 1 });
            }
            else
            {
                Items.Add(new TModel() { Id = 0 });
            }
        }

        private int MaxId()
        {
            int max = Items[0].Id;
            foreach (var item in Items)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            return max;
        }

        // удаление выбранной записи
        private void DeleteItem(object obj)
        {
            if (Items.Count != 0 && SelectedItem != null)
            {
                var previousItemIndex = Items.IndexOf(SelectedItem) - 1;
                if (previousItemIndex >= 0 && previousItemIndex < Items.Count)
                {
                    var beforeSelectedItem = Items[previousItemIndex];
                    Items.Remove(SelectedItem);
                    SelectedItem = beforeSelectedItem;
                }
                else
                {
                    Items.Remove(SelectedItem);
                }
            }
        }
        #endregion

        #endregion

        // загрузка данных
        private async void Load()
        {
            await Task.Run(() =>
            {
                using (var dbContext = _aowDbContextFactory.CreateDbContext())
                {
                    //Items = new(dbContext.Staff);
                    SetList(dbContext);
                }
            });
        }

        virtual protected void SetList(AowDbContext dbContext) { }

        public TableViewModel()
        {
            _aowDbContextFactory = new();
            _updatedItemsIds = new();
            DeleteSelectedItem = new RelayCommand(DeleteItem, obj => true);
            AddNewRecord = new RelayCommand(AddRecord, obj => true);
            CommitChanges = new RelayCommand(Commit, obj => true);
            //Load();
        }
    }
}
