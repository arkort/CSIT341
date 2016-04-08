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
                var tables = GetTables(connection);
                var procedures = GetStoredProcedures(connection);
                CreateBackupFile(tables, procedures);
            }
        }

        public void Restore(DateTime date)
        {
            throw new NotImplementedException();
        }

        private static void CreateBackupFile(IEnumerable<DBTable> tables, IEnumerable<DBProcedure> procedures)
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
            }
        }

        private static IEnumerable<DBColumn> GetColumns(SqlConnection connection, DBTable table)
        {
            string sqlCommandStr = @"SELECT COLUMN_NAME, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, COLLATION_NAME
                                            FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @tableSchema AND TABLE_NAME = @tableName";
            var columns = new List<DBColumn>();

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            {
                command.Parameters.AddWithValue("@tableSchema", table.Schema);
                command.Parameters.AddWithValue("@tableName", table.Name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        string columnDefault = (reader.IsDBNull(1)) ? null : reader.GetString(1);
                        string isNullable = reader.GetString(2);
                        string dataType = reader.GetString(3);
                        int characterMaxLength = (reader.IsDBNull(4)) ? -1 : reader.GetInt32(4);
                        string collationName = (reader.IsDBNull(5)) ? null : reader.GetString(5);

                        columns.Add(new DBColumn
                        {
                            Name = columnName,
                            Default = columnDefault,
                            IsNullable = isNullable,
                            DataType = dataType,
                            CharactersMaxLength = characterMaxLength,
                            CollationName = collationName,
                        });
                    }
                }
            }

            return columns;
        }

        private static void GetData()
        {
            //
        }

        private static IEnumerable<DBProcedure> GetStoredProcedures(SqlConnection connection)
        {
            var procedures = new List<DBProcedure>();
            string sqlCommandStr = @"SELECT ROUTINE_NAME, ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES
                                        WHERE ROUTINE_TYPE = 'PROCEDURE'";

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string procedureName = reader.GetString(0);
                    string procedureDefinition = reader.GetString(1);

                    procedures.Add(new DBProcedure
                    {
                        Name = procedureName,
                        Definition = procedureDefinition,
                    });
                }
            }

            return procedures;
        }

        // TODO: Get constraints
        private static IEnumerable<DBTable> GetTables(SqlConnection connection)
        {
            var tables = new List<DBTable>();
            using (SqlCommand command = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableSchema = reader.GetString(0);
                    string tableName = reader.GetString(1);

                    tables.Add(new DBTable
                    {
                        Schema = tableSchema,
                        Name = tableName
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