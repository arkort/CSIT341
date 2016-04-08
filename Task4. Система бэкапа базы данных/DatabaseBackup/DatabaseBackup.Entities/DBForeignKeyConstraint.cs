namespace DatabaseBackup.Entities
{
    public class DBForeignKeyConstraint
    {
        public string ConstraintName
        {
            get; set;
        }

        public string PrimaryTableName
        {
            get; set;
        }

        public string PrimaryTableSchema
        {
            get; set;
        }

        public string PrimaryTableColumn
        {
            get; set;
        }

        public string ForeignTableName
        {
            get; set;
        }

        public string ForeignTableSchema
        {
            get; set;
        }

        public string ForeignTableColumn
        {
            get; set;
        }

        public DBForeignKeyConstraint(string constraintName,
            string primaryTableSchema, string primaryTableName, string primaryTableColumn,
            string foreignTableSchema, string foreignTableName, string foreignTableColumn)
        {
            this.ConstraintName = constraintName;

            this.PrimaryTableSchema = primaryTableSchema;
            this.PrimaryTableName = primaryTableName;
            this.PrimaryTableColumn = primaryTableColumn;

            this.ForeignTableSchema = foreignTableSchema;
            this.ForeignTableName = foreignTableName;
            this.ForeignTableColumn = foreignTableColumn;
        }
    }
}
