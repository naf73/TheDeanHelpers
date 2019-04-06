using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers;
using TheDeanHelpers.Model;

namespace IntegratedTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestExpoter
    {
        [TestMethod]
        public void TestMethodExportToFileXLSX()
        {
            #region Arrange

            string pathFile = Path.Combine(Path.GetTempPath(), "test.xls");
            CSVFile doc = CreateDoc();
            Expoter expoter = new Expoter();

            #endregion

            #region Action

            expoter.ExportToFileXLSX(pathFile, doc);

            #endregion

            #region Output

            Console.WriteLine(pathFile);

            #endregion

            #region Post

            //if (File.Exists(pathFile)) File.Delete(pathFile);

            #endregion
        }

        private CSVFile CreateDoc()
        {
            int columnsCount = 3;
            int rowsCount = 10;
            CSVFile doc = new CSVFile();
            Random rnd = new Random();

            for (int i = 0; i < columnsCount; i++)
            {
                doc.Columns.Add(new Column()
                {
                    Id = i,
                    Name = string.Format("Столбец {0}", i),
                    IsActive = true
                });
            }

            for (int j = 0; j < rowsCount; j++)
            {
                Row row = new Row()
                {
                    Id = j
                };
                int i = 0;
                foreach(var column in doc.Columns)
                {
                    row.Cells.Add(new Cell()
                    {
                        ColumnId = i,
                        RowId = j,
                        Value = string.Format("Значение ({0} {1})", i, j)
                    });
                    i++;
                }
                doc.Rows.Add(row);
            }

            return doc;
        }
    }
}
