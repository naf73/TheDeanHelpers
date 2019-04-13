﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using DataTable = System.Data.DataTable;

namespace TheDeanHelpers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        private DataTable doc = new DataTable();
        Parser parser = new Parser();
        Expoter expoter = new Expoter();

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Событие нажатия кнопки "Открыть CSV-файл"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCSV_Click(object sender, RoutedEventArgs e)
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                DataGridTable.DataContext = parser.Download(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Событие нажатия кнопки "Экспорт XLS-файл"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportXLS_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file|*.xls|Excel file|*.xlsx";
            if(saveFileDialog.ShowDialog() == true)
            {
                DataTable table = new DataTable();
                table = (DataTable)DataGridTable.DataContext;
                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    table.Columns[(string)column.Header].SetOrdinal(column.DisplayIndex);
                }
                expoter.ExportToFileXLSX(saveFileDialog.FileName, table);
            }
            MessageBox.Show("Экпорт завершен");
        }

        #endregion

        #region Methods

        #endregion
    }
}
