using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeanHelpers.Model
{
    public class CSVFile
    {

        public string Path { get; set; }

        public List<Row> Rows { get; set; }

        public List<Column> Columns { get; set; }

    }
}
