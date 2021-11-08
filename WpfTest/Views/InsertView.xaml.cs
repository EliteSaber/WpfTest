﻿using System;
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
