namespace DatabaseBackup.ContractsDAL
{
    public interface IDao
    {
        void Backup(string conString);

        void Restore(System.DateTime date);
    }
}