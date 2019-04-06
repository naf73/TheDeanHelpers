using System.Collections.Generic;

namespace TheDeanHelpers.Model
{
    public class Row
    {
        public Row()
        {
            Cells = new List<Cell>();
        }
        public int Id { get; set; }
        public List<Cell> Cells { get; set; }
    }
}