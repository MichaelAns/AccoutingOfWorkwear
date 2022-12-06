using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using AoW.WPF.Infrastructure.DataMessage;
using AoW.WPF.ViewModels.Base;
using MyMVVM.Commands;
using MyMVVM.DataTransfer;
using MyMVVM.Navigation.Navigators;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoW.WPF.ViewModels
{
    internal class StaffViewModel : BaseEntityViewModel<Staff>
    {
        public StaffViewModel(IRenavigator renavigator)
        {
            SelectWorkwearCommand = new RelayCommand(SelectWorkwearExecute, SelectWorkwearCanExecute);
            _renavigator = renavigator;
        }
        private readonly IRenavigator _renavigator;

        protected override async Task<ICollection> Get()
        {
            using (var dbContext = new AowDbContextFactory().CreateDbContext())
            {
                return dbContext.Staff.ToList();
            }
        } 
        
        #region Выбор одежды

        // свойство
        public ICommand SelectWorkwearCommand { get; }    

        // метод
        private void SelectWorkwearExecute(object obj)
        {
            var dataMessage = new WorkwearDataMessage(
                this, 
                SelectedItem);
            var container = AowDataContainer.GetDataContainer();
            container.SendDataMessage(dataMessage);
            _renavigator.Renavigate();
        }

        // проверка
        private bool SelectWorkwearCanExecute(object obj)
        {
            // если есть выделенный элемент
            return SelectedItem is not null;
        }

        #endregion
    }
}
