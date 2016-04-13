using System;
using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
using System.IO;

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

            logic.BackupLocalInstance(@"UNEXPIRIENCE", "Store");
            Console.WriteLine("Backup completed.");
        }
    }
}