namespace DatabaseBackup.Entities
{
    public class DBTable
    {
        public System.Collections.Generic.IEnumerable<DBColumn> Columns { get; set; }

        public string Name { get; set; }

        public string Schema { get; set; }
    }
}