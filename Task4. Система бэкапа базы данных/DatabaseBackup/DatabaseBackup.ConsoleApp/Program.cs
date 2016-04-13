using System;
using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;

namespace DatabaseBackup.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            ILogic logic = new Logic();
            foreach (var database in logic.ShowDatabasesLocalInstance(@"(localdb)\mssqllocaldb"))
            {
                Console.WriteLine(database);
            }

            logic.BackupLocalInstance(@"(localdb)\mssqllocaldb", "ComicsCatalogue");
            Console.WriteLine("Backup completed.");
        }
    }
}