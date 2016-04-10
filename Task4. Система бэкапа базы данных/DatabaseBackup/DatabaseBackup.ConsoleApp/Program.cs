using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
using System;
using System.Data;

namespace DatabaseBackup.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ILogic logic = new Logic();
            logic.Backup(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ComicsCatalogue;Integrated Security=True");
        }
    }
}