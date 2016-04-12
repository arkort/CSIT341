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
            while (true)
            {
                var conString = "Data Source=alexey\\sqlexpress;Initial Catalog=\"Recruitment Agency\";Integrated Security=True";
                ILogic logic = new Logic();

                logic.Backup(conString);
                Console.Write("Backup completed. If you want to quit, enter q. If you want to backup another database, press any other key: ");

                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}