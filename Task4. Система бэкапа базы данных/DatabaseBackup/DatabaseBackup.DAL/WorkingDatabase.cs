using System.Data.SqlClient;

namespace DatabaseBackup.DAL
{
    class WorkingDatabase
    {
        private string connectionString;

        public WorkingDatabase(string connectionString)
        {
            this.connectionString = connectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }

        public void Backup()
        {
            //
        }

        public void Restore(string sqlDump)
        {
            // Execute sqlDump
        }

        private void getTables()
        {
            //
        }

        private void getData()
        {
            //
        }

        private void getStoredProcedures()
        {
            //
        }
    }
}
