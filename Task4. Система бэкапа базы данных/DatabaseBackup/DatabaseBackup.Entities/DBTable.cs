using System.Collections.Generic;

namespace DatabaseBackup.Entities
{
    public class DBTable
    {
        public string Schema
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public List<DBTableColumn> Columns
        {
            get; set;
        }

        public DBTable(string schema, string name)
        {
            this.Schema = schema;
            this.Name = name;

            this.Columns = new List<DBTableColumn>();
        }
    }
}
