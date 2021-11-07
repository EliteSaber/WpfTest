using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfTest.Infrastructure.Commands;
using WpfTest.Interfaces;
using WpfTest.Models;
using WpfTest.ViewModels.Base;

namespace WpfTest.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Тест";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        /// <summary>Статус программы</summary>
        private string _status = "Готов!";
        /// <summary>Статус программы</summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        private string _text = "Пусто";
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        private string _x1a;
        public string X1a
        {
            get => _x1a;
            set => Set(ref _x1a, value);
        }
        private string _x1b;
        public string X1b
        {
            get => _x1b;
            set => Set(ref _x1b, value);
        }
        private string _x1c;
        public string X1c
        {
            get => _x1c;
            set => Set(ref _x1c, value);
        }
        private string _x1d;
        public string X1d
        {
            get => _x1d;
            set => Set(ref _x1d, value);
        }
        public ICommand SearchCommand { get; }
        private bool CanSearchCommandExecuted(object p) => true;
        private void OnSearchCommandExecuted(object p)
        {
            if(IsNotNull(X1a) && IsNotNull(X1b) && IsNotNull(X1c) && IsNotNull(X1d))
            {
                var data = _table.Items.Where(x => x.x1a.Equals(X1a) && x.x1b.Equals(X1b) && x.x1c.Equals(X1c) && x.x1d.Equals(X1d));
                if (data != null)
                    DataSources = data;
            }
        }
        private bool IsNotNull(string s) => !string.IsNullOrWhiteSpace(s);
        public ICommand OpenFileCommand { get; }
        private void OnOpenFileCommandExecuted(object p)
        {
            IDialogService dialog = new DefaultDialogService();
            List<string> text = new List<string>();
            if (dialog.OpenFileDialog())
            {
                IFileService txt = new TxtFileService();
                text = txt.Open(dialog.FilePath);
            }
            DataFromFile data = new DataFromFile(text);
            ChangeData(data.Full);
            /*_text = "";
            int countUpdate = 0,
                countInsert = 0;
            foreach (Table t in data.Full)
            {
                var record = _table
                    .Items
                    .FirstOrDefault(x => x.x1a.Equals(t.x1a) && x.x1b.Equals(t.x1b) && x.x1c.Equals(t.x1c) && x.x1d.Equals(t.x1d));
                if (record != null)
                {
                    record.x2 = t.x2;
                    record.x3 = t.x3;
                    record.x4 = t.x4;
                    record.x5 = t.x5;
                    record.x6 = t.x6;
                    record.x7 = t.x7;
                    record.x8 = t.x8;
                    record.x9 = t.x9;
                    record.x10 = t.x10;
                    record.x11 = t.x11;
                    record.x12 = t.x12;
                    record.x13 = t.x13;
                    record.x14 = t.x14;
                    _table.Update(record);
                    countUpdate++;
                }
                else
                {
                    _table.Add(t);
                    countInsert++;
                }
                ReloadDataSources();
                var numsRecords = _table.Items.Count();
                Text = $"Записей в таблице {numsRecords}\r\n"
                    + $"Обновлено {countUpdate} записей\r\n"
                    + $"Добавлено {countInsert} записей";

                //Text += $"{t.x1a} {t.x1b} {t.x1c} {t.x1d} {t.x2} {t.x3} {t.x4} {t.x5} {t.x6} {t.x7} {t.x8} {t.x9} {t.x10} {t.x11} {t.x12} {t.x13} {t.x14}\r\n";
            }*/
        }
        private void ChangeData(IEnumerable<Table> data)
        {
            int countUpdate = 0,
                countInsert = 0;
            foreach (Table t in data)
            {
                if (_table.Items.FirstOrDefault(x => x.Equals(t)) != null)
                    continue;
                var record = _table
                    .Items
                    .FirstOrDefault(x => x.x1a.Equals(t.x1a) && x.x1b.Equals(t.x1b) && x.x1c.Equals(t.x1c) && x.x1d.Equals(t.x1d));
                if (record != null)
                {
                    record.x2 = t.x2;
                    record.x3 = t.x3;
                    record.x4 = t.x4;
                    record.x5 = t.x5;
                    record.x6 = t.x6;
                    record.x7 = t.x7;
                    record.x8 = t.x8;
                    record.x9 = t.x9;
                    record.x10 = t.x10;
                    record.x11 = t.x11;
                    record.x12 = t.x12;
                    record.x13 = t.x13;
                    record.x14 = t.x14;
                    _table.Update(record);
                    countUpdate++;
                }
                else
                {
                    _table.Add(t);
                    countInsert++;
                }
                ReloadDataSources();
                var numsRecords = _table.Items.Count();
                Text = $"Записей в таблице {numsRecords}\r\n"
                    + $"Обновлено {countUpdate} записей\r\n"
                    + $"Добавлено {countInsert} записей";
            }
        }
        private bool CanOpenFileCommandExecute(object p) => true;

        private IEnumerable<Table> _dataSources;
        public IEnumerable<Table> DataSources
        {
            get => _dataSources;
            set => Set(ref _dataSources, value);
        }
        private void ReloadDataSources()
        {
            DataSources = _table.Items.ToList();
        }
        public ICommand SaveFromDataGridCommand { get; }
        private bool CanSaveFromDataGridCommandExecuted(object p) => true;
        private void OnSaveFromDataGridCommandExecuted(object p)
        {
            //ChangeData(DataSources);
            var count = _table.SaveChanges();
            Text = $"Изменено {count} записей";
            //DataSources = _table.Items.ToList();
        }
        /*public ICommand OutputDataCommand { get; }
        private bool CanOutputDataCommandExecuted(object p) => true;
        private void OnOutputDataCommandExecuted(object p)
        {
            DataSources = _table.Items.ToList();
        }*/
        /*public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;*/
        private readonly IRepository<Table> _table;
        public MainWindowViewModel(IRepository<Table> table)
        {
            _table = table;
            DataSources = table.Items.ToList();
            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            OpenFileCommand = new LambdaCommand(OnOpenFileCommandExecuted, CanOpenFileCommandExecute);
            SaveFromDataGridCommand = new LambdaCommand(OnSaveFromDataGridCommandExecuted, CanSaveFromDataGridCommandExecuted);
        }
    }
}
