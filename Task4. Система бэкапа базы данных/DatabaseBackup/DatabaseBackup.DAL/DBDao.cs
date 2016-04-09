using DatabaseBackup.ContractsDAL;
using DatabaseBackup.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

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
                var fkConstraints = this.GetForeignKeyConstraints(connection);
                this.CreateBackupFile(tables, procedures, fkConstraints);
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

        private void CreateBackupFile(IEnumerable<Table> tables, IEnumerable<Procedure> procedures, IEnumerable<ForeignKeyConstraint> fkConstraints)
        {
            var curDate = DateTime.Now;
            using (var sqlFile = new StreamWriter($"backup_{curDate: dd-MM-yyyy_HH-mm}.sql"))
            {
                sqlFile.WriteLine($"/* Database backup ({curDate: dd-MM-yyyy_HH-mm}) */");

                sqlFile.WriteLine();

                sqlFile.WriteLine("/* Tables */");

                foreach (var table in tables)
                {
                    sqlFile.WriteLine($"CREATE TABLE [{table.Name}].[{table.Schema}] (");

                    foreach (var column in table.Columns)
                    {
                        string allowNull = (column.IsNullable == "YES") ? "NULL" : "NOT NULL";
                        string defaultValue = (column.Default == null) ? String.Empty : "DEFAULT" + column.Default;
                        sqlFile.WriteLine($"\t[{column.Name}] {column.DataType} {allowNull} {defaultValue},");
                    }

                    sqlFile.WriteLine(");");
                    sqlFile.WriteLine("GO;");
                }

                sqlFile.WriteLine();

                sqlFile.WriteLine("/* Stored procedures */");

                foreach (var procedure in procedures)
                {
                    sqlFile.WriteLine(procedure.Definition);
                    sqlFile.WriteLine("GO;");
                }

                sqlFile.WriteLine();

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
        }

        private IEnumerable<Column> GetColumns(SqlConnection connection, Table table)
        {
            string sqlCommandStr = @"SELECT COLUMN_NAME, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, COLLATION_NAME
                                            FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @tableSchema AND TABLE_NAME = @tableName";
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
                            IsNullable = reader.GetString(2),
                            DataType = reader.GetString(3),
                            CharactersMaxLength = (reader.IsDBNull(4)) ? -1 : reader.GetInt32(4),
                            CollationName = (reader.IsDBNull(5)) ? null : reader.GetString(5),
                        });
                    }
                }
            }

            return columns;
        }

        private IEnumerable<ForeignKeyConstraint> GetForeignKeyConstraints(SqlConnection connection)
        {
            var foreignKeyConstraints = new List<ForeignKeyConstraint>();
            string sqlCommandStr = @"SELECT
	                                    FK_Schema = FK.TABLE_SCHEMA,
                                        FK_Table = FK.TABLE_NAME,
                                        FK_Column = CU.COLUMN_NAME,
                                        PK_Schema = PK.TABLE_SCHEMA,
	                                    PK_Table = PK.TABLE_NAME,
                                        PK_Column = PT.COLUMN_NAME,
                                        Constraint_Name = C.CONSTRAINT_NAME,
		                                On_Delete = C.DELETE_RULE,
		                                On_Update = C.UPDATE_RULE
                                    FROM
                                        INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK
                                        ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK
                                        ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU
                                        ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                    INNER JOIN (
                                                SELECT
                                                    i1.TABLE_NAME,
                                                    i2.COLUMN_NAME
                                                FROM
                                                    INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2
                                                    ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE
                                                    i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                                ) PT
                                        ON PT.TABLE_NAME = PK.TABLE_NAME";

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    foreignKeyConstraints.Add(new ForeignKeyConstraint
                    {
                        ForeignTableSchema = reader.GetString(0),
                        ForeignTableName = reader.GetString(1),
                        ForeignTableColumn = reader.GetString(2),
                        PrimaryTableSchema = reader.GetString(3),
                        PrimaryTableName = reader.GetString(4),
                        PrimaryTableColumn = reader.GetString(5),
                        ConstraintName = reader.GetString(6),
                        OnDeleteRule = reader.GetString(7),
                        OnUpdateRule = reader.GetString(8),
                    });
                }
            }

            return foreignKeyConstraints;
        }

        private IEnumerable<Procedure> GetStoredProcedures(SqlConnection connection)
        {
            var procedures = new List<Procedure>();
            string sqlCommandStr = @"SELECT ROUTINE_NAME, ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES
                                        WHERE ROUTINE_TYPE = 'PROCEDURE'";

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
            using (SqlCommand command = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection))
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
    }
}