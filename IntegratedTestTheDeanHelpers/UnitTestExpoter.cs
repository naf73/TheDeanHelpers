using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace IntegratedTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestExpoter
    {
        [TestMethod]
        public void TestMethodExportToFileXLSX()
        {


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
                }
                doc.Rows.Add(row);
            }

            return doc;
        }
    }
}
