using System.Collections.Generic;

namespace TheDeanHelpers.Model
{
    public class Row
    {
        private List<Cell> _cells;

        public int Id { get; set; }

        public List<Cell> Cells { get; set; }
    }
}