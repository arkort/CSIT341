using DatabaseBackup.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DatabaseBackup.DAL
{
    class WorkingDatabase
    {
        private string connectionString;
        List<DBTable> tables;
        List<DBProcedure> procedures;

        public WorkingDatabase(string connectionString)
        {
            this.connectionString = connectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }

            this.tables = new List<DBTable>();
            this.procedures = new List<DBProcedure>();
        }

        public void Backup()
        {
            getTables();
            getStoredProcedures();
            createBackupFile();
        }

        public void Restore(string sqlDump)
        {
            // Execute sqlDump
        }

        private void createBackupFile()
        {
            using (var sqlFile = new StreamWriter("temp.sql"))
            {
                sqlFile.WriteLine("/* Database backup ({0}) */", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                sqlFile.WriteLine();

                sqlFile.WriteLine("/* Tables */");

                foreach (var table in this.tables)
                {
                    sqlFile.WriteLine("CREATE TABLE [{0}].[{1}] (", table.Name, table.Schema);

                    foreach (var column in table.Columns)
                    {
                        string allowNull = (column.IsNullable == "YES") ? "NULL" : "NOT NULL";
                        string defaultValue = (column.ColumnDefault == null) ? String.Empty : "DEFAULT" + column.ColumnDefault;
                        sqlFile.WriteLine("\t[{0}] {1} {2} {3},", column.ColumnName, column.DataType, allowNull, defaultValue);
                    }

                    sqlFile.WriteLine(");");
                    sqlFile.WriteLine("GO;");
                }

                sqlFile.WriteLine();

                sqlFile.WriteLine("/* Stored procedures */");

                foreach (var procedure in this.procedures)
                {
                    sqlFile.WriteLine(procedure.Definition);
                    sqlFile.WriteLine("GO;");
                }
            }
        }

        // TODO: Get constraints
        private void getTables()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableSchema = reader.GetString(0);
                        string tableName = reader.GetString(1);

                        this.tables.Add(new DBTable(tableSchema, tableName));
                    }
                }

                foreach (var table in tables)
                {
                    string sqlCommandStr = @"SELECT COLUMN_NAME, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, COLLATION_NAME
                                            FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @tableSchema AND TABLE_NAME = @tableName";

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

                                table.Columns.Add(new DBTableColumn(columnName, columnDefault, isNullable, dataType, characterMaxLength, collationName));
                            }
                        }
                    }
                }
            }
        }

        private void getData()
        {
            //
        }

        private void getStoredProcedures()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlCommandStr = @"SELECT ROUTINE_NAME, ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES
                                        WHERE ROUTINE_TYPE = 'PROCEDURE'";

                using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string procedureName = reader.GetString(0);
                        string procedureDefinition = reader.GetString(1);

                        this.procedures.Add(new DBProcedure(procedureName, procedureDefinition));
                    }
                }
            }
        }
    }
}
