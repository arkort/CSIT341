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
            dal.Backup($"Server={address};Database={databaseName};User Id={username};Password={password}");
        }

        public void BackupLocalInstance (string address, string databaseName)
        {
            dal.Backup($@"Data Source={address};Initial Catalog=""{databaseName}"";Integrated Security=True");
        }


        public void Restore(System.DateTime date)
        {
            dal.Restore(date);
        }

        public IEnumerable<string> ShowDatabases(string address, string username, string password)
        {
            return dal.ShowDatabases($"Server={address};Database=master;User Id=myUsername;Password=myPassword");
        }

        public IEnumerable<string> ShowDatabasesLocalInstance(string address)
        {
            return dal.ShowDatabases($@"Data Source={address};Initial Catalog=master;Integrated Security=True");
        }
    }
}