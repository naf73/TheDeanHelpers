using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeanHelpers.Model
{
    class ExportXLS
    {
        public ExportXLS()
        {
            Columns = new List<Column>();
            Rows = new List<Row>();
        }

        public string Path { get; set; }
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }
    }
}
