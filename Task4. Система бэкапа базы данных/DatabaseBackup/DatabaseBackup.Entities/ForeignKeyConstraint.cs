using System.Collections.Generic;
using System.Linq;

namespace DatabaseBackup.Entities
{
    public class ForeignKeyConstraint : Constraint
    {
        public string OnDeleteRule { get; set; }
        public string OnUpdateRule { get; set; }
        public List<string> PrimaryTableColumns { get; set; }
        public string PrimaryTableName { get; set; }
        public string PrimaryTableSchema { get; set; }

        public override string ToString()
        {
            return $"ALTER TABLE [{this.TableSchema}].[{this.TableName}] ADD CONSTRAINT {this.Name} FOREIGN KEY({string.Join(", ", this.Columns)}) REFERENCES [{this.PrimaryTableSchema}].[{this.PrimaryTableName}]({string.Join(", ", this.Columns)})";
        }
    }
}