using System;
using System.Collections.Generic;
using DatabaseBackup.ContractsBLL;
using DatabaseBackup.ContractsDAL;
using DatabaseBackup.DAL;

namespace DatabaseBackup.BLL
{
    public class Logic : ILogic
    {
        private IDao dal = new DBDao();

        public void Backup(string address, string databaseName, string username, string password)
        {
            this.dal.Backup($"Server={address};Database={databaseName};User Id={username};Password={password}");
        }

        public void BackupLocalInstance (string address, string databaseName)
        {
            this.dal.Backup($@"Data Source={address};Initial Catalog=""{databaseName}"";Integrated Security=True");
        }


        public void Restore(System.DateTime date)
        {
            this.dal.Restore(date);
        }

        public IEnumerable<string> ShowDatabases(string address, string username, string password="")
        {
            return password == "" ? this.dal.ShowDatabases($"Server={address};User Id=myUsername;") : this.dal.ShowDatabases($"Server={address};User Id=myUsername;Password=myPassword");
        }

        public IEnumerable<string> ShowDatabasesLocalInstance(string address)
        {
            return this.dal.ShowDatabases($@"Data Source={address};Integrated Security=True");
        }
    }
}