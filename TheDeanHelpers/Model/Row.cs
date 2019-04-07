using System;
using System.Collections.Generic;

namespace TheDeanHelpers.Model
{
    public class Row : IEquatable<Row>
    {
        public Row()
        {
            Id = 0;
            Cells = new List<Cell>();
        }
        public int Id { get; set; }
        public List<Cell> Cells { get; set; }

        public bool Equals(Row other)
        {
            if (this.Id != other.Id) return false;
            if (this.Cells.Count != other.Cells.Count) return false;
            for (int i = 0; i < this.Cells.Count; i++)
            {
                if (!this.Cells[i].Equals(other.Cells[i])) return false;
            }
            return true;
        }
    }
}