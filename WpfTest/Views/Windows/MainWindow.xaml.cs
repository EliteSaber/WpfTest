using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTest.Interfaces;
using WpfTest.Models;

namespace WpfTest
{
    public partial class MainWindow : Window
    {
        //private readonly IRepository<Models.Table> _table;
        public MainWindow()
        {
            InitializeComponent();
            //_table = table;
            //btn_openFile.Click += Btn_openFile_Click;
        }

        //private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    string headername = e.Column.Header.ToString();
        //    if (headername == "Id")
        //    {
        //        e.Column.IsReadOnly = true;
        //        //e.Column.Visibility = Visibility.Hidden;
        //    }
        //}
        /*private void Btn_openFile_Click(object sender, RoutedEventArgs e)
{
   IDialogService dialog = new DefaultDialogService();
   List<string> text = new List<string>();
   if(dialog.OpenFileDialog())
   {
       IFileService txt = new TxtFileService();
       text = txt.Open(dialog.FilePath);
   }
   List<Data> datas = new List<Data>();
   foreach(string line in text)
   {
       List<string> splitted = line.Split('|').ToList();
       Data data = new Data(splitted);
       datas.Add(data);
   }
   foreach(string s in datas[0].Line)
   {
       //textBlock.Text += s + "\n";
   }
   //textBlock.Text += "End";
}*/
    }
}
