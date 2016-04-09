using System.Collections.Generic;

namespace DatabaseBackup.Entities
{
    public abstract class Constraint
    {
        public List<string> Columns { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }
        public string TableSchema { get; set; }
    }
}