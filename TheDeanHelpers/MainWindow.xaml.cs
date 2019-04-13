using Microsoft.Win32;
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
using TheDeanHelpers.Model;

namespace TheDeanHelpers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        
        Parser parser = new Parser();
        CSVFile doc = new CSVFile();
        ExportXLS xdox = new ExportXLS();
        Exporter exporter = new Exporter();



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
            if (openFileDialog.ShowDialog() == true)
            {
                doc = parser.Download(openFileDialog.FileName);
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
            if (saveFileDialog.ShowDialog() == true)
            {
                xdox = exporter.ExportToFileXLSX(saveFileDialog.FileName);
            }

        }

        #endregion

        #region Methods

        #endregion
    }
}
