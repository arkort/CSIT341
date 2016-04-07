namespace DatabaseBackup.ContractsDAL
{
    public interface IDataAccessLayer
    {
        void ConnectToDatabase(string connectionString);
        void BackupDatabase();
        void RestoreDatabase(string filename);
    }
}
