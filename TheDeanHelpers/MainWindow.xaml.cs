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
        string PathFile = string.Empty;

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
                PathFile = openFileDialog.FileName;
                DataGridTable.DataContext = parser.Preview(PathFile);
                ContextMenu contextMenu = new ContextMenu();
                MenuItem Item = new MenuItem()
                {
                    Header = "Rename",
                };
                Item.Click += MenuItem_Click;
                contextMenu.Items.Add(Item);

                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    DataTable table = (DataTable)DataGridTable.DataContext;
                    DataColumn dataColumn = table.Columns[(string)column.Header];
                    StackPanel panel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };
                    CheckBox checkBox = new CheckBox()
                    {
                        IsThreeState = false,                        
                        Margin = new Thickness(5),
                        IsChecked = true,
                        ContextMenu = contextMenu,
                        Tag = dataColumn.ColumnName
                    };
                    panel.Children.Add(checkBox);
                    Label label = new Label()
                    {
                        Content = dataColumn.Caption
                    };
                    panel.Children.Add(label);
                    column.Header = panel; 
                    
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((ContextMenu)((MenuItem)sender).Parent).PlacementTarget as CheckBox;

            WindowRename windowRename = new WindowRename();                       
            if(windowRename.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(windowRename.Rename))
                {
                    checkBox.Content = windowRename.Rename;
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
                using (DataTable table = parser.Download(PathFile))
                {
                    foreach (DataGridColumn column in DataGridTable.Columns)
                    {
                        CheckBox checkBox = ((StackPanel)column.Header).Children[0] as CheckBox;
                        Label label= ((StackPanel)column.Header).Children[1] as Label;

                        table.Columns[(string)checkBox.Tag].SetOrdinal(column.DisplayIndex);
                        table.Columns[(string)checkBox.Tag].Caption = label.Content.ToString();
                    }

                    DataTable exportTable = new DataTable();
                    exportTable = table.Copy();

                    foreach (DataGridColumn column in DataGridTable.Columns)
                    {
                        CheckBox checkBox = ((StackPanel)column.Header).Children[0] as CheckBox;
                        if (checkBox.IsChecked == false)
                        {
                            exportTable.Columns.Remove(exportTable.Columns[(string)checkBox.Tag]);
                        }
                    }

                    expoter.ExportToFileXLSX(saveFileDialog.FileName, exportTable);

                    MessageBox.Show("Экпорт завершен");
                }

            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
