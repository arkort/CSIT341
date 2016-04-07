namespace DatabaseBackup.ContractsBLL
{
    public interface IBusinessLayer
    {
        void Connect(string connectionString);
        void Backup();
        void Restore();
    }
}
