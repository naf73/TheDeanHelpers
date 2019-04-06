using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeanHelpers.Model
{
    public class CSVFile
    {
        private List<Row> rows;

        private List<Column> columns;

        public string Path { get; set; }

        internal List<Row> Rows { get => rows; set => rows = value; }

        internal List<Column> Columns { get => columns; set => columns = value; }

    }
}
