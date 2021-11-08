﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfTest.Infrastructure.Commands;
using WpfTest.Interfaces;
using WpfTest.Models;
using WpfTest.ViewModels.Base;

namespace WpfTest.ViewModels
{
    class MainViewModel : ViewModel
    {
        private IRepository<Table> _repository;
        private bool _canUpload = true;
        public bool CanUpload
        {
            get => _canUpload;
            set => Set(ref _canUpload, value);
        }

        private string _status = "Готов!";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
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
        private string _id1;
        public string Id1
        {
            get => _id1;
            set => Set(ref _id1, value);
        }
        private string _id2;
        public string Id2
        {
            get => _id2;
            set => Set(ref _id2, value);
        }
        
        //сравненение
        private ICommand _comparasionCommand;
        public ICommand ComparasionCommand => _comparasionCommand 
            ??= new LambdaCommand(OnComparasionCommandExecuted, CanComparasionCommandExecuted);
        private bool CanComparasionCommandExecuted(object p) => true;
        private void OnComparasionCommandExecuted(object p)
        {
            if (int.TryParse(Id1, out int id1) && int.TryParse(Id2, out int id2))
            {
                var first = GetById(id1);
                var second = GetById(id2);
                if (first == null || second == null)
                    return;
                var result = Comparasion(first, second);
                DataSources = new List<Table>() { first, second, result };
                Id1 = "";
                Id2 = "";
                CanUpload = false;
            }
        }
        private Table GetById(int id) => _repository.Get(id);
        private Table Comparasion(Table first, Table second)
        {
            Table result = new Table()
            {
                x2 = ComparasingStringsAsDouble(first.x2, second.x2),
                x3 = ComparasingStringsAsDouble(first.x3, second.x3),
                x4 = ComparasingStringsAsDouble(first.x4, second.x4),
                x5 = ComparasingStringsAsDouble(first.x5, second.x5),
                x6 = ComparasingStringsAsDouble(first.x6, second.x6),
                x7 = ComparasingStringsAsDouble(first.x7, second.x7),
                x8 = ComparasingStringsAsDouble(first.x8, second.x8),
                x9 = ComparasingStringsAsDouble(first.x9, second.x9),
                x10 = ComparasingStringsAsDouble(first.x10, second.x10),
                x11 = ComparasingStringsAsDouble(first.x11, second.x11),
                x12 = ComparasingStringsAsDouble(first.x12, second.x12),
                x13 = ComparasingStringsAsDouble(first.x13, second.x13),
                x14 = ComparasingStringsAsDouble(first.x14, second.x14),
            };
            return result;
        }
        private string ComparasingStringsAsDouble(string s1, string s2)
        {
            double x = double.Parse(s1) - double.Parse(s2);
            return x.ToString();
        }

        //сброс
        private ICommand _resetCommand;
        public ICommand ResetSearchCommand => _resetCommand
            ??= new LambdaCommand(OnResetSearchCommandExecuted, CanResetSearchCommandExecuted);
        private bool CanResetSearchCommandExecuted(object p) => true;
        private void OnResetSearchCommandExecuted(object p)
        {
            X1a = "";
            X1b = "";
            X1c = "";
            X1d = "";
            Id1 = "";
            Id2 = "";
            IdForDelete = "";
            ReloadDataSources();
        }

        //Поиск
        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand
            ??= new LambdaCommand(OnSearchCommandExecuted, CanSearchCommandExecuted);
        private bool CanSearchCommandExecuted(object p) => true;
        private void OnSearchCommandExecuted(object p)
        {
            //все возможные комбинации поиска через четыре поля, методом перебора
            var data = new List<Table>();
            if (IsNotNull(X1a) && IsNotNull(X1b) && IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1b.Contains(X1b) && x.x1c.Contains(X1c) && x.x1d.Contains(X1d)).ToList();

            if (IsNotNull(X1a) && IsNotNull(X1b) && IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1b.Contains(X1b) && x.x1c.Contains(X1c)).ToList();

            if (IsNotNull(X1a) && IsNotNull(X1b) && !IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1b.Contains(X1b) && x.x1d.Contains(X1d)).ToList();

            if (IsNotNull(X1a) && !IsNotNull(X1b) && IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1c.Contains(X1c) && x.x1d.Contains(X1d)).ToList();

            if (!IsNotNull(X1a) && IsNotNull(X1b) && IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1b.Contains(X1b) && x.x1c.Contains(X1c) && x.x1d.Contains(X1d)).ToList();

            if (IsNotNull(X1a) && IsNotNull(X1b) && !IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1b.Contains(X1b)).ToList();

            if (IsNotNull(X1a) && !IsNotNull(X1b) && IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1c.Contains(X1c)).ToList();

            if (!IsNotNull(X1a) && IsNotNull(X1b) && IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1b.Contains(X1b) && x.x1c.Contains(X1c)).ToList();

            if (IsNotNull(X1a) && !IsNotNull(X1b) && !IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a) && x.x1d.Contains(X1d)).ToList();

            if (!IsNotNull(X1a) && IsNotNull(X1b) && !IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1b.Contains(X1b) && x.x1d.Contains(X1d)).ToList();

            if (!IsNotNull(X1a) && !IsNotNull(X1b) && IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1c.Contains(X1c) && x.x1d.Contains(X1d)).ToList();

            if (IsNotNull(X1a) && !IsNotNull(X1b) && !IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1a.Contains(X1a)).ToList();

            if (!IsNotNull(X1a) && IsNotNull(X1b) && !IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1b.Contains(X1b)).ToList();

            if (!IsNotNull(X1a) && !IsNotNull(X1b) && IsNotNull(X1c) && !IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1c.Contains(X1c)).ToList();

            if (!IsNotNull(X1a) && !IsNotNull(X1b) && !IsNotNull(X1c) && IsNotNull(X1d))
                data = _repository.Items.Where(x => x.x1d.Contains(X1d)).ToList();

            if (!IsNotNull(X1a) && !IsNotNull(X1b) && !IsNotNull(X1c) && !IsNotNull(X1d))
                return;

            if (data.Count > 0)
            {
                DataSources = data;
                CanUpload = true;
            }
        }
        private bool IsNotNull(string s) => !string.IsNullOrWhiteSpace(s);

        //загрузить файл
        private ICommand _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand
            ??= new LambdaCommand(OnOpenFileCommandExecuted, CanOpenFileCommandExecute);
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
        }
        private void ChangeData(IEnumerable<Table> data)
        {
            int numsRecords = 0,
                countUpdate = 0,
                countInsert = 0;
            foreach (Table t in data)
            {
                SaveData save = new SaveData(_repository, t);
                ReloadDataSources();

                if (save.IsUpdate)
                    countUpdate++;
                else
                    countInsert++;
            }
            numsRecords = _repository.Items.Count();
            Status = $"Записей в таблице {numsRecords} | "
                    + $"Обновлено {countUpdate} | "
                    + $"Добавлено {countInsert}";
        }
        private bool CanOpenFileCommandExecute(object p) => true;

        //данные для вывода в таблице
        private IEnumerable<Table> _dataSources;
        public IEnumerable<Table> DataSources
        {
            get => _dataSources;
            set => Set(ref _dataSources, value);
        }
        private void ReloadDataSources()
        {
            DataSources = _repository.Items.ToList();
            CanUpload = true;
        }

        //сохранение измененных данных в БД
        private ICommand _saveFromDataGridCommand;
        public ICommand SaveFromDataGridCommand => _saveFromDataGridCommand
            ??= new LambdaCommand(OnSaveFromDataGridCommandExecuted, CanSaveFromDataGridCommandExecuted);
        private bool CanSaveFromDataGridCommandExecuted(object p) => true;
        private void OnSaveFromDataGridCommandExecuted(object p)
        {
            var count = _repository.SaveChanges();
            Status = $"Изменено {count} записей";
        }

        //поле Id для удаления
        private string _idForDelete;
        public string IdForDelete
        {
            get => _idForDelete;
            set => Set(ref _idForDelete, value);
        }
        //команда удаления
        private ICommand _deleteByIdCommand;
        public ICommand DeleteByIdCommand => _deleteByIdCommand
            ??= new LambdaCommand(OnDeleteByIdCommandExecuted, CanDeleteByIdCommandExecuted);
        private bool CanDeleteByIdCommandExecuted(object p) => true;
        private void OnDeleteByIdCommandExecuted(object p)
        {
            if (int.TryParse(IdForDelete, out int id))
            {
                if (_repository.Remove(id))
                {
                    Status = $"Удален {id}";
                    IdForDelete = "";
                    ReloadDataSources();
                }
                else
                {
                    Status = $"Запись с {id} не найдена";
                }
            }
        }

        private ICommand _uploadCommand;
        public ICommand UploadCommand => _uploadCommand
            ??= new LambdaCommand(OnUploadCommandExecuted, CanUploadCommandExecuted);
        private bool CanUploadCommandExecuted(object p) => CanUpload;
        private void OnUploadCommandExecuted(object p)
        {
            DataToXML toXML = new DataToXML(DataSources);
            Status = toXML.Create() ? "XML создан" : "XML не был создан";
        }

        public MainViewModel(IRepository<Table> repository)
        {
            _repository = repository;
            ReloadDataSources();
        }
    }
}
