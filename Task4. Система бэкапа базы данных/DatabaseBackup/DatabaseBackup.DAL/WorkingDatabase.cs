using DatabaseBackup.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseBackup.DAL
{
    class WorkingDatabase
    {
        private string connectionString;
        List<DBTable> tables;

        public WorkingDatabase(string connectionString)
        {
            this.connectionString = connectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }

            this.tables = new List<DBTable>();
        }

        public void Backup()
        {
            getTables();
        }

        public void Restore(string sqlDump)
        {
            // Execute sqlDump
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
            //
        }
    }
}
