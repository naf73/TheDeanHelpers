using Microsoft.Win32;
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV file|*.csv"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                DataGridTable.DataContext = parser.Download(openFileDialog.FileName);
                ContextMenu contextMenu = new ContextMenu();
                MenuItem Item = new MenuItem()
                {
                    Header = "Rename",
                };
                Item.Click += MenuItem_Click;
                contextMenu.Items.Add(Item);

                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    CheckBox checkBox = new CheckBox()
                    {
                        IsThreeState = false,
                        Content = column.Header as string,
                        Margin = new Thickness(5),
                        IsChecked = true,
                        ContextMenu = contextMenu
                    };
                    column.Header = checkBox;                    
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((ContextMenu)((MenuItem)sender).Parent).PlacementTarget as CheckBox;
            DataTable table = (DataTable)DataGridTable.DataContext;

            DataColumn dataColumn = table.Columns[checkBox.Content.ToString()];

            WindowRename windowRename = new WindowRename();                       
            if(windowRename.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(windowRename.Rename))
                {
                    checkBox.Content = windowRename.Rename;
                    dataColumn.ColumnName = windowRename.Rename;
                }
            }
        }

        /// <summary>
        /// Событие нажатия кнопки "Экспорт XLS-файл"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportXLS_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel file|*.xls|Excel file|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                DataTable table = (DataTable)DataGridTable.DataContext;

                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    CheckBox checkBox = column.Header as CheckBox;
                    table.Columns[checkBox.Content.ToString()].SetOrdinal(column.DisplayIndex);
                }

                DataTable exportTable = new DataTable();
                exportTable = table.Copy();

                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    CheckBox checkBox = column.Header as CheckBox;
                    if (checkBox.IsChecked == false)
                    {
                        exportTable.Columns.Remove(exportTable.Columns[checkBox.Content.ToString()]);
                    }
                }

                expoter.ExportToFileXLSX(saveFileDialog.FileName, exportTable);

                MessageBox.Show("Экпорт завершен");
            }
        }

        #endregion

        #region Methods

        #endregion

    }
}
