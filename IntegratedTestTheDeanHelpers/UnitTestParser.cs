using System;
using System.Collections;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers;
using TheDeanHelpers.Model;

namespace IntegratedTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestParser
    {
        [TestMethod]
        public void TestDownload()
        {
            #region Arrange

            string pathDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathFile = Path.Combine(Directory.GetParent(pathDir).Parent.FullName, "Rabbits", "test.csv");
            Parser parser = new Parser();
            CSVFile expectedDoc = CreateDoc();
            CSVFile actualDoc = new CSVFile();

            #endregion

            #region Action

            actualDoc = parser.Download(pathFile);

            #endregion
            
            #region Output

            ShowCSVFile(actualDoc);

            Console.WriteLine("=================================");

            ShowCSVFile(expectedDoc);

            #endregion

            #region Assert

            Assert.IsTrue(expectedDoc.Equals(actualDoc));

            #endregion
        }

        private void ShowCSVFile(CSVFile doc)
        {
            Console.WriteLine("Path: {0}", doc.Path);
            string header = string.Empty;
            foreach (var column in doc.Columns)
            {
                header += column.Name + " | ";
            }
            Console.WriteLine(header);

            foreach (var row in doc.Rows)
            {
                string line = string.Empty;
                foreach (var cell in row.Cells)
                {
                    line += cell.Value + " | ";
                }
                Console.WriteLine(line);
            }
        }

        private CSVFile CreateDoc()
        {
            int columnsCount = 3;
            int rowsCount = 30;
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
                foreach (var column in doc.Columns)
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
