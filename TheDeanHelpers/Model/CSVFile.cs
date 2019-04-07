using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeanHelpers.Model
{
    public class CSVFile : IEquatable<CSVFile>
    {
        public CSVFile()
        {
            Path = string.Empty;
            Columns = new List<Column>();
            Rows = new List<Row>();
        }

        public string Path { get; set; }
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }

        public bool Equals(CSVFile other)
        {
            if (this.Path != other.Path) return false;
            if (this.Columns.Count != other.Columns.Count) return false;
            if (this.Rows.Count != other.Rows.Count) return false;

            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (!this.Columns[i].Equals(other.Columns[i])) return false;
            }

            for (int j = 0; j < this.Rows.Count; j++)
            {
                if (!this.Rows[j].Equals(other.Rows[j])) return false; 
            }

            return true;
        }
    }
}
