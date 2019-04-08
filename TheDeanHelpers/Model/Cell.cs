using System;

namespace TheDeanHelpers.Model
{
    public class Cell:IEquatable<Cell>
    {
        public Cell()
        {
            ColumnId = 0;
            RowId = 0;
            Value = string.Empty;
        }
        public int ColumnId { get; set; }
        public int RowId { get; set; }
        public string Value { get; set; }

        public bool Equals(Cell other) 
        {
            return ColumnId == other.ColumnId &&
                RowId == other.RowId &&
                Value == other.Value;
        }
    }
}