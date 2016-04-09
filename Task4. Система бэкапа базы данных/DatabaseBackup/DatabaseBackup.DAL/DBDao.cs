using DatabaseBackup.ContractsDAL;
using DatabaseBackup.Entities;
using DatabaseBackup.Essential;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace DatabaseBackup.DAL
{
    public class DBDao : IDao
    {
        public void Backup(string conString)
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var tables = this.GetTables(connection);
                var procedures = this.GetStoredProcedures(connection);
                var constraints = new List<Constraint>(this.GetForeignKeyConstraints(connection));
                constraints.AddRange(this.GetPrimaryKeyConstraints(connection));
                constraints.AddRange(this.GetUniqueConstraints(connection));

                this.CreateBackupFile(tables, procedures, constraints);
            }
        }

        public void Restore(DateTime date)
        {
            throw new NotImplementedException();
        }

        private static void GetData()
        {
            //
        }

        private static void WriteConstraints(IEnumerable<Constraint> fkConstraints, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* FK constraints */");
            foreach (var fkConstraint in fkConstraints)
            {
                sqlFile.WriteLine($"ALTER TABLE [{fkConstraint.PrimaryTableSchema}].[{fkConstraint.PrimaryTableName}]");
                sqlFile.WriteLine($"ADD CONSTRAINT [{fkConstraint.ConstraintName}]");
                sqlFile.WriteLine($"FOREIGN KEY ({fkConstraint.PrimaryTableColumn})");
                sqlFile.WriteLine($"REFERENCES [{fkConstraint.ForeignTableSchema}].[{fkConstraint.ForeignTableName}]([{fkConstraint.ForeignTableColumn}])");
                sqlFile.WriteLine($"ON DELETE {fkConstraint.OnDeleteRule}");
                sqlFile.WriteLine($"ON UPDATE {fkConstraint.OnUpdateRule};");
                sqlFile.WriteLine("GO");
                sqlFile.WriteLine();
            }
        }

        private void CreateBackupFile(IEnumerable<Table> tables, IEnumerable<Procedure> procedures, IEnumerable<Constraint> constraints)
        {
            var curDate = DateTime.Now;
            using (var sqlFile = new StreamWriter($"backup_{curDate: dd-MM-yyyy_HH-mm}.sql"))
            {
                sqlFile.WriteLine($"/* Database backup ({curDate: dd-MM-yyyy_HH-mm}) */");
                sqlFile.WriteLine();
                this.WriteTablesCreation(tables, sqlFile);
                sqlFile.WriteLine();
                this.WriteProcedures(procedures, sqlFile);
                sqlFile.WriteLine();
                WriteConstraints(constraints, sqlFile);
                sqlFile.WriteLine();
            }
        }

        private IEnumerable<Column> GetColumns(SqlConnection connection, Table table)
        {
            string sqlCommandStr = Essentials.getAllColumnsFromATableQuery;
            var columns = new List<Column>();

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            {
                command.Parameters.AddWithValue("@tableSchema", table.Schema);
                command.Parameters.AddWithValue("@tableName", table.Name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(new Column
                        {
                            Name = reader.GetString(0),
                            Default = (reader.IsDBNull(1)) ? null : reader.GetString(1),
                            IsNullable = reader.GetString(2) == "YES" ? true : false,
                            DataType = reader.GetString(3),
                            CharactersMaxLength = (reader.IsDBNull(4)) ? -1 : reader.GetInt32(4),
                            CollationName = (reader.IsDBNull(5)) ? null : reader.GetString(5),
                        });
                    }
                }
            }

            return columns;
        }

        private IEnumerable<Constraint> GetForeignKeyConstraints(SqlConnection connection)
        {
            var foreignKeyConstraints = new List<ForeignKeyConstraint>();
            string sqlCommandStr = Essentials.getAllForeignKeysQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var constraintName = reader["Constraint_Name"] as string;
                    var primaryTableColumnName = reader["PK_Column"] as string;
                    var foreignTableColumnName = reader["FK_Column"] as string;
                    var element = foreignKeyConstraints.FirstOrDefault(x => x.Name == constraintName);

                    if (element != null)
                    {
                        element.PrimaryTableColumns.Add(primaryTableColumnName);
                        element.Columns.Add(foreignTableColumnName);
                        continue;
                    }

                    var foreignTableName = reader["FK_Table"] as string;
                    var foreignTableSchema = reader["FK_Schema"] as string;
                    var primaryTableSchema = reader["PK_Schema"] as string;
                    var primaryTableName = reader["PK_Table"] as string;
                    var onDeleteRule = reader["On_Delete"] as string;
                    var onUpdateRule = reader["On_Update"] as string;

                    foreignKeyConstraints.Add(new ForeignKeyConstraint
                    {
                        Name = constraintName,
                        PrimaryTableColumns = new List<string> { primaryTableColumnName },
                        PrimaryTableName = primaryTableName,
                        PrimaryTableSchema = primaryTableSchema,
                        TableName = foreignTableName,
                        TableSchema = foreignTableSchema,
                        Columns = new List<string> { foreignTableColumnName },
                        OnDeleteRule = onDeleteRule,
                        OnUpdateRule = onUpdateRule,
                    });
                }
            }

            return foreignKeyConstraints;
        }

        private IEnumerable<Constraint> GetPrimaryKeyConstraints(SqlConnection connection)
        {
            var primaryKeyConstraints = new List<PrimaryKeyConstraint>();
            string sqlCommandStr = Essentials.getAllPrimaryKeyConstraintsQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var constraintName = reader["CONSTRAINT_NAME"] as string;
                    var primaryTableSchema = reader["TABLE_SCHEMA"] as string;
                    var primaryTableName = reader["TABLE_NAME"] as string;
                    var primaryTableColumnName = reader["COLUMN_NAME"] as string;

                    var element = primaryKeyConstraints.FirstOrDefault(x => x.Name == constraintName);

                    if (element != null)
                    {
                        element.Columns.Add(primaryTableColumnName);
                        continue;
                    }

                    primaryKeyConstraints.Add(new PrimaryKeyConstraint
                    {
                        Name = constraintName,
                        Columns = new List<string> { primaryTableColumnName },
                        TableName = primaryTableName,
                        TableSchema = primaryTableSchema,
                    });
                }
            }

            return primaryKeyConstraints;
        }

        private IEnumerable<Procedure> GetStoredProcedures(SqlConnection connection)
        {
            var procedures = new List<Procedure>();
            string sqlCommandStr = Essentials.getAllStoredProceduresQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    procedures.Add(new Procedure
                    {
                        Name = reader.GetString(0),
                        Definition = reader.GetString(1),
                    });
                }
            }

            return procedures;
        }

        private IEnumerable<Table> GetTables(SqlConnection connection)
        {
            var tables = new List<Table>();
            using (SqlCommand command = new SqlCommand(Essentials.getAllTablesQuery, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(new Table
                    {
                        Schema = reader.GetString(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            foreach (var table in tables)
            {
                table.Columns = GetColumns(connection, table);
            }

            return tables;
        }

        private IEnumerable<Constraint> GetUniqueConstraints(SqlConnection connection)
        {
            var uniqueConstraints = new List<UniqueConstraint>();
            string sqlCommandStr = Essentials.getAllPrimaryKeyConstraintsQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var constraintName = reader["CONSTRAINT_NAME"] as string;
                    var primaryTableSchema = reader["TABLE_SCHEMA"] as string;
                    var primaryTableName = reader["TABLE_NAME"] as string;
                    var primaryTableColumnName = reader["COLUMN_NAME"] as string;

                    var element = uniqueConstraints.FirstOrDefault(x => x.Name == constraintName);

                    if (element != null)
                    {
                        element.Columns.Add(primaryTableColumnName);
                        continue;
                    }

                    uniqueConstraints.Add(new UniqueConstraint
                    {
                        Name = constraintName,
                        Columns = new List<string> { primaryTableColumnName },
                        TableName = primaryTableName,
                        TableSchema = primaryTableSchema,
                    });
                }
            }

            return uniqueConstraints;
        }

        private void WriteProcedures(IEnumerable<Procedure> procedures, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Stored procedures */");

            foreach (var procedure in procedures)
            {
                sqlFile.WriteLine(procedure.Definition);
                sqlFile.WriteLine("GO;");
            }
        }

        private void WriteTablesCreation(IEnumerable<Table> tables, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Tables */");

            foreach (var table in tables)
            {
                sqlFile.WriteLine($"CREATE TABLE [{table.Schema}].[{table.Name}] (");

                foreach (var column in table.Columns)
                {
                    string allowNull = (column.IsNullable == "YES") ? "NULL" : "NOT NULL";
                    string defaultValue = (column.Default == null) ? String.Empty : "DEFAULT" + column.Default;
                    sqlFile.WriteLine($"\t[{column.Name}] {column.DataType} {allowNull} {defaultValue},");
                }

                sqlFile.WriteLine(");");
                sqlFile.WriteLine("GO;");
            }
        }
    }
}