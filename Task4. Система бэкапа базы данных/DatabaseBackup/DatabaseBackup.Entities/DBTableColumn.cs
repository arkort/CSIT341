namespace DatabaseBackup.Entities
{
    public class DBTableColumn
    {
        public DBTableColumn(string columnName, string columnDefault, string isNullable, string dataType, int characterMaxLength, string collationName)
        {
            this.ColumnName = columnName;
            this.ColumnDefault = columnDefault;
            this.IsNullable = isNullable;
            this.DataType = dataType;
            this.CharacterMaxLength = characterMaxLength;
            this.CollationName = collationName;
        }

        public string ColumnName
        {
            get; set;
        }

        public string ColumnDefault
        {
            get; set;
        }

        public string IsNullable
        {
            get; set;
        }

        public string DataType
        {
            get; set;
        }

        public int CharacterMaxLength
        {
            get; set;
        }

        public string CollationName
        {
            get; set;
        }
    }
}
