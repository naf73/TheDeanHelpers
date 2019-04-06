using System.Collections.Generic;

namespace TheDeanHelpers.Model
{
    internal class Row
    {
        private List<Cell> _cells;

        public int Id { get; set; }

        internal List<Cell> Cells { get => _cells; set => _cells = value; }
    }
}