using AoW.EntityFramework.Models.Base;
using MyMVVM.ViewModelBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels.Base
{
    internal abstract class BaseEntityViewModel<Model> : ViewModel
        where Model : BaseEntity
    {
        public BaseEntityViewModel()
        {
            LoadAsync();
        }

        private List<Model> _models;
        private Model _selectedItem;

        /// <summary>
        /// Список всех записей
        /// </summary>
        public List<Model> Items
        {
            get => _models;
            set => Set(ref _models, value);
        }

        /// <summary>
        /// Выделенная запись из списка
        /// </summary>
        public Model SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        /// <summary>
        /// Асинхронная загрузка данных из БД
        /// </summary>
        private async void LoadAsync()
        {
            Get().ContinueWith(async task =>
            {
                if (task.Exception == null)
                {
                    Items = (List<Model>)task.Result;
                }
            });
        }

        /// <summary>
        /// Способ получения данных из БД
        /// </summary>
        /// <returns></returns>
        protected abstract Task<ICollection> Get();

        /// <summary>
        /// Команда переключения модели представления
        /// </summary>
        public ICommand UpdateCurrentViewModelCommand => MainViewModel.Navigator.UpdateCurrentViewModelCommand;
    }
}
