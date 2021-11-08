using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTest.Infrastructure.Commands;
using WpfTest.Interfaces;
using WpfTest.Models;
using WpfTest.ViewModels.Base;

namespace WpfTest.ViewModels
{
    class InsertViewModel : ViewModel
    {
        private IRepository<Table> _repository;

        private string _status = "Готов!";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        
        private IEnumerable<Table> _dataSource;
        public IEnumerable<Table> DataSource
        {
            get => _dataSource;
            set => Set(ref _dataSource, value);
        }
        //очистка введенных данных
        private ICommand _clearDataCommand;
        public ICommand ClearDataCommand => _clearDataCommand
            ??= new LambdaCommand(OnClearDataCommandExecuted, CanClearDataCommandExecuted);
        private bool CanClearDataCommandExecuted(object p) => true;
        private void OnClearDataCommandExecuted(object p) => ClearDataSource();
        private void ClearDataSource()
        {
            DataSource = new List<Table>() { new Table
            {
                x1a = "",
                x1b = "",
                x1c = "",
                x1d = "",
                x2 = "",
                x3 = "",
                x4 = "",
                x5 = "",
                x6 = "",
                x7 = "",
                x8 = "",
                x9 = "",
                x10 = "",
                x11 = "",
                x12 = "",
                x13 = "",
                x14 = ""
            } };
        }

        //сохранение введенных данных
        private ICommand _insertDataCommand;
        public ICommand InsertDataCommand => _insertDataCommand
            ??= new LambdaCommand(OnInsertDataCommandExecuted, CanInsertDataCommandExecuted);
        private bool CanInsertDataCommandExecuted(object p)
        {
            //все поля дожны быть заполнены
            var record = DataSource.FirstOrDefault();
            bool cannot = string.IsNullOrWhiteSpace(record.x1a)
                || string.IsNullOrWhiteSpace(record.x1b)
                || string.IsNullOrWhiteSpace(record.x1c)
                || string.IsNullOrWhiteSpace(record.x1d)
                || string.IsNullOrWhiteSpace(record.x2)
                || string.IsNullOrWhiteSpace(record.x3)
                || string.IsNullOrWhiteSpace(record.x4)
                || string.IsNullOrWhiteSpace(record.x5)
                || string.IsNullOrWhiteSpace(record.x6)
                || string.IsNullOrWhiteSpace(record.x7)
                || string.IsNullOrWhiteSpace(record.x8)
                || string.IsNullOrWhiteSpace(record.x9)
                || string.IsNullOrWhiteSpace(record.x10)
                || string.IsNullOrWhiteSpace(record.x11)
                || string.IsNullOrWhiteSpace(record.x12)
                || string.IsNullOrWhiteSpace(record.x13)
                || string.IsNullOrWhiteSpace(record.x14);
            return !cannot;
        }
        private void OnInsertDataCommandExecuted(object p)
        {
            SaveData save = new SaveData(_repository, DataSource.First());
            int numsRecords = _repository.Items.Count();

            int countUpdate = 0,
                countInsert = 0;
            if (save.IsUpdate)
                countUpdate++;
            else
                countInsert++;

            Status = $"Записей в таблице {numsRecords} | "
                + $"Обновлено {countUpdate} | "
                + $"Добавлено {countInsert}";
        }
        
        public InsertViewModel(IRepository<Table> repository)
        {
            _repository = repository;
            ClearDataSource();
        }
    }
}
