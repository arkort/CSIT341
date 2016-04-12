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

        public void Backup(string conString)
        {
            dal.Backup(conString);
        }

        public void Restore(System.DateTime date)
        {
            dal.Restore(date);
        }

        public IEnumerable<string> ShowDatabasesNames(string conString)
        {
            return dal.ShowDatabases(conString);
        }
    }
}