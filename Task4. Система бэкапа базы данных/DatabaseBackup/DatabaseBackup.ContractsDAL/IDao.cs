using System.Collections.Generic;

namespace DatabaseBackup.ContractsDAL
{
    public interface IDao
    {
        void Backup(string conString, string databaseName);

        void Restore(System.DateTime date);

        IEnumerable<string> ShowDatabases(string conString);
    }
}