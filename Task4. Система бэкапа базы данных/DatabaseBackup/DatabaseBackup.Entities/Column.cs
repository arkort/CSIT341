namespace DatabaseBackup.Entities
{
    public class Column
    {
        public int CharactersMaxLength { get; set; }

        public string CollationName { get; set; }

        public string DataType { get; set; }
        public string Default { get; set; }
        public bool IsNullable { get; set; }
        public string Name { get; set; }
    }
}