using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeanHelpers.Model;

namespace TheDeanHelpers.Helpers
{
    public class Mock
    {
        public CSVFile CreateDoc()
        {
            int columnsCount = 3;
            int rowCount = 10;
            CSVFile doc = new CSVFile();
            for (int i = 0; i < columnsCount; i++)
            {
                doc.Columns.Add(new Column()
                {
                    Id = i,
                    Name = string.Format("Cтолбец {0}", i),
                    IsActive = true

                });
                
            }
            for (int j = 0; j < rowCount; j++)
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
                        Value = string.Format("Значение({0} {1})", i, j)
                    });
                    i++;
                }
                doc.Rows.Add(row);
            }

            return doc;
        }
    }
}
