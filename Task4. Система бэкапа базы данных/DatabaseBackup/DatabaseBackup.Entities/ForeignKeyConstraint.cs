namespace DatabaseBackup.Entities
{
    public class ForeignKeyConstraint
    {
        public string ConstraintName { get; set; }

        public string ForeignTableColumn { get; set; }
        public string ForeignTableName { get; set; }
        public string ForeignTableSchema { get; set; }
        public string PrimaryTableColumn { get; set; }
        public string PrimaryTableName { get; set; }
        public string PrimaryTableSchema { get; set; }
    }
}