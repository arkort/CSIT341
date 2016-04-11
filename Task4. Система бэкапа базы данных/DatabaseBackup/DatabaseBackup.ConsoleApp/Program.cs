using DatabaseBackup.BLL;
using DatabaseBackup.ContractsBLL;
using System;
using System.Data;
using System.Linq;

namespace DatabaseBackup.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var conString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ComicsCatalogue;Integrated Security=True";
                ILogic logic = new Logic();
                var databasesNames = logic.ShowDatabasesNames(conString).ToList();

                if (databasesNames.Count == 0)
                {
                    Console.WriteLine("No databases to backup");
                    return;
                }

                for (int i = 0; i < databasesNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {databasesNames[i]}");
                }

                Console.Write("Enter the number of a database to backup: ");

                int number = -1;

                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be a positive integer");
                    continue;
                }

                if (number - 1 >= databasesNames.Count || number - 1 < 0)
                {
                    Console.WriteLine("There is no database with the entered number. Please, try again");
                }

                logic.Backup(conString, databasesNames[number - 1]);
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