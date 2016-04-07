using DatabaseBackup.ContractsDAL;

namespace DatabaseBackup.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        WorkingDatabase workingDatabase;

        public void ConnectToDatabase(string connectionString)
        {
            workingDatabase = new WorkingDatabase(connectionString);
        }

        public void BackupDatabase()
        {
            workingDatabase.Backup();
        }

        public void RestoreDatabase(string backupFileName)
        {
            string sqlDump = getBackupFileContent(backupFileName);
            workingDatabase.Restore(sqlDump);
        }

        private string getBackupFileContent(string filename)
        {
            // open and read file
            return "CREATE table1";
        }
    }
}
