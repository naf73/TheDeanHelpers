using System;

namespace TheDeanHelpers.Model
{
    public class Column : IEquatable<Column>
    {
        public Column()
        {
            Id = 0;
            Name = string.Empty;
            IsActive = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public bool Equals(Column other)
        {
            return this.Id == other.Id &&
                   this.Name == other.Name &&
                   this.IsActive == other.IsActive;
        }
    }
}