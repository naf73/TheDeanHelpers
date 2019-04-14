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
                
                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    DataTemplate dataTemplate = new DataTemplate();

                    FrameworkElementFactory _template = new FrameworkElementFactory(typeof(StackPanel));
                    _template.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

                    FrameworkElementFactory _firstTemplateChild = new FrameworkElementFactory(typeof(CheckBox));
                    _firstTemplateChild.SetValue(CheckBox.IsThreeStateProperty, false);
                    _firstTemplateChild.SetValue(CheckBox.IsCheckedProperty, true);
                    _firstTemplateChild.SetValue(CheckBox.NameProperty, string.Format("checkBox_{0}", column.DisplayIndex));
                    _firstTemplateChild.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(CheckBox_Click));

                    FrameworkElementFactory _secondTemplateChild = new FrameworkElementFactory(typeof(Label));
                    _secondTemplateChild.SetValue(Label.NameProperty, "label");
                    _secondTemplateChild.SetValue(Label.ContentProperty, column.Header);
                    _secondTemplateChild.AddHandler(Label.MouseDoubleClickEvent, new MouseButtonEventHandler(Header_Click));

                    _template.AppendChild(_firstTemplateChild);
                    _template.AppendChild(_secondTemplateChild);

                    dataTemplate.VisualTree = _template;
                    column.HeaderTemplate = dataTemplate;
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            MessageBox.Show(checkBox.IsChecked.ToString());
        }

        private void Header_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(((Label)sender).Content.ToString());
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
                DataTable table = new DataTable();
                table = (DataTable)DataGridTable.DataContext;
                foreach (DataGridColumn column in DataGridTable.Columns)
                {
                    StackPanel stackPanel = column.HeaderTemplate.LoadContent() as StackPanel;
                    CheckBox box = FindVisualChildByName<CheckBox>(stackPanel, string.Format("checkBox_{0}", column.DisplayIndex));
                    Label label = FindVisualChildByName<Label>(stackPanel, "label");

                    if (box.IsChecked == true)
                    {
                        MessageBox.Show(label.Content.ToString());
                    }

                    foreach (var item in stackPanel.Children)
                    {
                        if (item is CheckBox)
                        {
                            MessageBox.Show(string.Format("{0} {1}", ((CheckBox)item).Name, ((CheckBox)item).IsChecked));
                            if (((CheckBox)item).IsChecked == false)
                            {
                                MessageBox.Show(column.Header.ToString());
                            }
                        }
                    }

                    // -- --

                    table.Columns[(string)column.Header].SetOrdinal(column.DisplayIndex);
                }
                expoter.ExportToFileXLSX(saveFileDialog.FileName, table);
                MessageBox.Show("Экпорт завершен");
            }
        }

        #endregion

        #region Methods

        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }


        #endregion
    }
}
