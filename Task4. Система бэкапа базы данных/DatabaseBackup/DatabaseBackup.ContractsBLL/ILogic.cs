namespace DatabaseBackup.ContractsBLL
{
    public interface ILogic
    {
        void Backup(string conString);

        void Restore(System.DateTime date);
    }
}