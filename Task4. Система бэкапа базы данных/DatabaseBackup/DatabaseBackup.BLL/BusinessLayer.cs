using DatabaseBackup.ContractsBLL;
using DatabaseBackup.ContractsDAL;
using DatabaseBackup.DAL;
using System;

namespace DatabaseBackup.BLL
{
    public class BusinessLayer : IBusinessLayer
    {
        IDataAccessLayer dal = new DataAccessLayer();

        public void Backup()
        {
            dal.BackupDatabase();
        }

        public void Connect(string connectionString)
        {
            string temp = "Data Source=(local); Database=AdventureWorks2012; Integrated Security=True; Asynchronous Processing=true;";
            dal.ConnectToDatabase(temp);
        }

        public void Restore(string backupFileName)
        {
            dal.RestoreDatabase(backupFileName);
        }
    }
}
