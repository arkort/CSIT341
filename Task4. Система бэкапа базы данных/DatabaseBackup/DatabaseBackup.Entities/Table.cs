using System.Collections.Generic;

namespace DatabaseBackup.Entities
{
    public class Table
    {
        public System.Collections.Generic.IEnumerable<Column> Columns { get; set; }
        public IEnumerable<Data> Data { get; set; }
        public string Name { get; set; }
        public string Schema { get; set; }
    }
}