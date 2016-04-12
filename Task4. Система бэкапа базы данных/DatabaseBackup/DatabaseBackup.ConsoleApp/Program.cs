using System;
using System.Data;
using System.Linq;
using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;

namespace DatabaseBackup.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var conString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ComicsCatalogue;Integrated Security=True";
            ILogic logic = new Logic();

            logic.Backup(conString);
            Console.Write("Backup completed.");
        }
    }
}