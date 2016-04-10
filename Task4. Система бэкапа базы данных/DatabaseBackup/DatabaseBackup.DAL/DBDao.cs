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
            IEnumerable<Table> tables;
            IEnumerable<Procedure> procedures;
            IEnumerable<Synonym> synonyms;
            List<Constraint> constraints;
            IEnumerable<View> views;
            IEnumerable<Function> functions;
            IEnumerable<Sequence> sequences;
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                tables = this.GetTables(connection);

                procedures = this.GetStoredProcedures(connection);

                constraints = new List<Constraint>(this.GetForeignKeyConstraints(connection));
                constraints.AddRange(this.GetPrimaryKeyConstraints(connection));
                constraints.AddRange(this.GetUniqueConstraints(connection));

                synonyms = this.GetSynonyms(connection);

                views = this.GetViews(connection);

                functions = this.GetFunctions(connection);

                sequences = this.GetSequences(connection);
            }

            this.CreateBackupFile(tables, procedures, constraints, synonyms, views, functions, sequences);
        }

        public void Restore(DateTime date)
        {
            throw new NotImplementedException();
        }

        private void CreateBackupFile(IEnumerable<Table> tables, IEnumerable<Procedure> procedures, IEnumerable<Constraint> constraints, IEnumerable<Synonym> synonyms, IEnumerable<View> views, IEnumerable<Function> functions, IEnumerable<Sequence> sequences)
        {
            var curDate = DateTime.Now;
            using (var sqlFile = new StreamWriter($"backup_{curDate: dd-MM-yyyy_HH-mm}.sql"))
            {
                sqlFile.WriteLine($"/* Database backup ({curDate: dd-MM-yyyy_HH-mm}) */");
                sqlFile.WriteLine();

                this.WriteTablesCreation(tables, sqlFile);
                sqlFile.WriteLine();

                this.WriteViews(views, sqlFile);
                sqlFile.WriteLine();

                this.WriteSynonyms(synonyms, sqlFile);
                sqlFile.WriteLine();

                this.WriteProcedures(procedures, sqlFile);
                sqlFile.WriteLine();

                this.WriteFunctions(functions, sqlFile);
                sqlFile.WriteLine();

                this.WriteSequences(sequences, sqlFile);
                sqlFile.WriteLine();

                this.WriteTableData(tables, sqlFile);
                sqlFile.WriteLine();

                this.WriteConstraints(constraints, sqlFile);
                sqlFile.WriteLine();
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

        private IEnumerable<Data> GetData(SqlConnection connection, Table table)
        {
            var sqlCommandStr = $"SELECT {string.Join(", ", table.Columns.Select(x => x.Name))} FROM {table.Name}";
            var data = new List<Data>();
            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tempData = new Data();
                        tempData.NameValue = new Dictionary<string, string>();
                        tempData.TableName = table.Name;
                        tempData.TableSchema = table.Schema;
                        int counter = 0;
                        foreach (var column in table.Columns)
                        {
                            if (reader[counter] is DBNull)
                            {
                                tempData.NameValue.Add(column.Name, "NULL");
                                continue;
                            }

                            switch (column.DataType)
                            {
                                case "binary":
                                case "varbinary":
                                case "image":
                                case "rowversion":
                                case "timestamp":
                                    tempData.NameValue.Add(column.Name, $"'0x{BitConverter.ToString((byte[])reader[counter]).Replace("-", string.Empty)}'");
                                    break;

                                case "bigint":
                                case "bit":
                                case "decimal":
                                case "float":
                                case "int":
                                case "money":
                                case "numeric":
                                case "real":
                                case "smallint":
                                case "smallmoney":
                                case "tinyint":
                                    tempData.NameValue.Add(column.Name, reader[counter].ToString());
                                    break;

                                case "nchar":
                                case "ntext":
                                case "nvarchar":
                                    tempData.NameValue.Add(column.Name, $"'n{reader[counter].ToString()}'");
                                    break;

                                case "char":
                                case "text":
                                case "varchar":
                                    tempData.NameValue.Add(column.Name, $"'{reader[counter].ToString()}'");
                                    break;

                                case "date":
                                    tempData.NameValue.Add(column.Name, $"'{reader.GetDateTime(counter).ToShortDateString()}'");
                                    break;

                                case "datetime":
                                    tempData.NameValue.Add(column.Name, $"'{reader.GetDateTime(counter).ToString("dd-MM-YYYY HH:mm:ss.fffffff")}'");
                                    break;

                                case "datetime2":
                                    tempData.NameValue.Add(column.Name, $"'{reader.GetDateTime(counter).ToString("dd-MM-YYYY HH:mm:ss.fffffff")}'");
                                    break;

                                case "datetimeoffset":
                                    tempData.NameValue.Add(column.Name, $"'{reader.GetDateTime(counter).ToString("dd-MM-YYYY HH:mm:ss.fffffff zzz")}'");
                                    break;

                                case "time":
                                    tempData.NameValue.Add(column.Name, $"'{reader.GetTimeSpan(counter)}'");
                                    break;

                                case "uniqueidentifier":
                                    tempData.NameValue.Add(column.Name, $"{reader.GetGuid(counter).ToString()}'");
                                    break;

                                default:
                                    break;
                            }
                            counter++;
                        }

                        data.Add(tempData);
                    }
                }
            }

            return data;
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

        private IEnumerable<Function> GetFunctions(SqlConnection connection)
        {
            var functions = new List<Function>();
            string sqlCommandStr = Essentials.getAllFunctionsQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    functions.Add(new Function
                    {
                        Definition = reader.GetString(0),
                    });
                }
            }

            return functions;
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

        private IEnumerable<Sequence> GetSequences(SqlConnection connection)
        {
            string sqlCommandStr = Essentials.getAllSequencesQuery;
            var sequences = new List<Sequence>();

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    sequences.Add(new Sequence
                    {
                        Schema = reader.GetString(0),
                        Name = reader.GetString(1),
                        DataType = reader.GetString(2),
                        StartValue = reader.GetInt64(3),
                        Increment = reader.GetInt64(4),
                        MinValue = reader.GetInt64(5),
                        MaxValue = reader.GetInt64(6),
                        IsCached = reader.GetBoolean(7),
                    });
                }
            }

            return sequences;
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
                        Definition = reader.GetString(0),
                    });
                }
            }

            return procedures;
        }

        private IEnumerable<Synonym> GetSynonyms(SqlConnection connection)
        {
            var synonyms = new List<Synonym>();
            string sqlCommandStr = Essentials.getAllSynonymsQuery;
            char[] trimChars = new char[] { '[', ']' };
            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var catalogueSchemaObject = reader.GetString(1).Split('.');
                    synonyms.Add(new Synonym
                    {
                        Name = reader.GetString(0).Trim(trimChars),
                        Catalogue = catalogueSchemaObject[0].Trim(trimChars),
                        ObjectName = catalogueSchemaObject[2].Trim(trimChars),
                        Schema = catalogueSchemaObject[1].Trim(trimChars),
                    });
                }
            }

            return synonyms;
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
                table.Columns = this.GetColumns(connection, table);
                table.Data = this.GetData(connection, table);
            }

            return tables;
        }

        private IEnumerable<Constraint> GetUniqueConstraints(SqlConnection connection)
        {
            var uniqueConstraints = new List<UniqueConstraint>();
            string sqlCommandStr = Essentials.getAllUniqueConstraintsQuery;

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

        private IEnumerable<View> GetViews(SqlConnection connection)
        {
            var views = new List<View>();
            string sqlCommandStr = Essentials.getAllViewsQuery;

            using (SqlCommand command = new SqlCommand(sqlCommandStr, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    views.Add(new View
                    {
                        Definition = reader.GetString(0),
                    });
                }
            }

            return views;
        }

        private void WriteConstraints(IEnumerable<Constraint> constraints, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* FK constraints */");
            foreach (var constraint in constraints)
            {
                sqlFile.WriteLine(constraint);
                sqlFile.WriteLine("GO");
            }
        }

        private void WriteFunctions(IEnumerable<Function> functions, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Functions */");
            foreach (var function in functions)
            {
                sqlFile.WriteLine(function);
                sqlFile.WriteLine("GO");
            }
        }

        private void WriteProcedures(IEnumerable<Procedure> procedures, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Stored procedures */");

            foreach (var procedure in procedures)
            {
                sqlFile.WriteLine(procedure);
                sqlFile.WriteLine("GO;");
            }
        }

        private void WriteSequences(IEnumerable<Sequence> sequences, StreamWriter sqlFile)
        {
            foreach (var sequence in sequences)
            {
                sqlFile.WriteLine(sequence);
                sqlFile.WriteLine("GO");
            }
        }

        private void WriteSynonyms(IEnumerable<Synonym> synonyms, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Synonyms */");
            foreach (var synonym in synonyms)
            {
                sqlFile.WriteLine(synonym);
                sqlFile.WriteLine("GO");
            }
        }

        private void WriteTableData(IEnumerable<Table> tables, StreamWriter sqlFile)
        {
            sqlFile.WriteLine("/* Data */");

            foreach (var table in tables)
            {
                foreach (var dataPiece in table.Data)
                {
                    sqlFile.WriteLine(dataPiece);
                    sqlFile.WriteLine("GO");
                }
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
                    string allowNull = column.IsNullable ? "NULL" : "NOT NULL";
                    string defaultValue = column.Default == null ? String.Empty : "DEFAULT" + column.Default;
                    sqlFile.WriteLine($"\t[{column.Name}] {column.DataType} {allowNull} {defaultValue},");
                }

                sqlFile.WriteLine(");");
                sqlFile.WriteLine("GO;");
            }
        }

        private void WriteViews(IEnumerable<View> views, StreamWriter sqlFile)
        {
            foreach (var view in views)
            {
                sqlFile.WriteLine(view);
                sqlFile.WriteLine("GO");
            }
        }
    }
}