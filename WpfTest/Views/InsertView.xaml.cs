using System.Windows;
using System.Windows.Controls;

namespace WpfTest.Views
{
    /// <summary>
    /// Логика взаимодействия для InsertView.xaml
    /// </summary>
    public partial class InsertView : UserControl
    {
        public InsertView()
        {
            InitializeComponent();
        }

        private void InsertGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();
            if (headername == "Id")
            {
                e.Column.IsReadOnly = true;
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
