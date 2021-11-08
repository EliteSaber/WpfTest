using System.Windows.Input;
using WpfTest.Infrastructure.Commands;
using WpfTest.Interfaces;
using WpfTest.Models;
using WpfTest.ViewModels.Base;

namespace WpfTest.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Сведения о дебиторской и кредиторской задолженности";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private ViewModel _currentModel;
        public ViewModel CurrentModel
        {
            get => _currentModel;
            set => Set(ref _currentModel, value);
        }

        private bool _canClickInsert = true;
        public bool CanClickInsert
        {
            get => _canClickInsert;
            set => Set(ref _canClickInsert, value);
        }
        private bool _canClickMain = true;
        public bool CanClickMain
        {
            get => _canClickMain;
            set => Set(ref _canClickMain, value);
        }

        private ICommand _showMainViewCommand;
        public ICommand ShowMainViewCommand => _showMainViewCommand
            ??= new LambdaCommand(OnShowMainViewCommandExecuted, CanShowMainViewCommandExecuted);
        private bool CanShowMainViewCommandExecuted(object arg) => CanClickMain;
        private void OnShowMainViewCommandExecuted(object obj)
        {
            CanClickMain = false;
            CanClickInsert = true;
            CurrentModel = new MainViewModel(_table);
        }
        private ICommand _showInsertViewCommand;
        public ICommand ShowInsertViewCommand => _showInsertViewCommand
            ??= new LambdaCommand(OnShowInsertViewCommandExecuted, CanShowInsertViewCommandExecuted);
        private bool CanShowInsertViewCommandExecuted(object arg) => CanClickInsert;
        private void OnShowInsertViewCommandExecuted(object obj)
        {
            CanClickInsert = false;
            CanClickMain = true;
            CurrentModel = new InsertViewModel(_table);
        }

        private string _text = "Пусто";
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        private readonly IRepository<Table> _table;
        public MainWindowViewModel(IRepository<Table> table)
        {
            _table = table;
        }
    }
}
