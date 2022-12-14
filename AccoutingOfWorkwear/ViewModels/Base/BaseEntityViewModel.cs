using AoW.EntityFramework.Models.Base;
using MyMVVM.Navigation.Navigators;
using MyMVVM.ViewModelBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AoW.WPF.ViewModels.Base
{
    internal abstract class BaseEntityViewModel<Model> : ViewModel
        where Model : BaseEntity
    {
        public BaseEntityViewModel()
        {
            LoadAsync();
            //_renavigator = renavigator;
        }

        private List<Model> _models;
        private Model _selectedItem;
        //protected IRenavigator _renavigator;
        private Visibility _progressBarVisibility;
        private Visibility _listBoxVisibility;

        public Visibility ProgressBarVisibility
        {
            get => _progressBarVisibility;
            set => Set(ref _progressBarVisibility, value);
        }
        public Visibility ListBoxVisibility
        {
            get => _listBoxVisibility;
            set => Set(ref _listBoxVisibility, value);
        }

        private void BeginAnimation()
        {
            ProgressBarVisibility = Visibility.Visible;
            ListBoxVisibility = Visibility.Collapsed;
        }
        private void EndAnimation()
        {
            ProgressBarVisibility = Visibility.Collapsed;
            ListBoxVisibility = Visibility.Visible;
        }

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
        /// Асинхронная загрузка данных
        /// </summary>
        private void LoadAsync()
        {
            Get().ContinueWith(async task =>
            {
                BeginAnimation();
                Thread.Sleep(5000);
                if (task.Exception == null)
                {
                    Items = (List<Model>)task.Result;                    
                }
                EndAnimation();
            });
        }

        /// <summary>
        /// Получение данных из БД
        /// </summary>
        /// <returns></returns>
        protected abstract Task<ICollection> Get();

    }
}
