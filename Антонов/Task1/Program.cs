using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static string inputFile = "input.txt";
        static string outputFile = "output.txt";

        static void GetStatsOnExtensions(string[] files)
        {
            var extStats = new Dictionary<string, int>();

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file);

                if(extStats.ContainsKey(ext))
                {
                    extStats[ext] += 1;
                }
                else
                {
                    extStats.Add(ext, 1);
                }
            }

            using (StreamWriter output = new StreamWriter(outputFile))
            {
                foreach (var item in extStats.OrderByDescending(pair => pair.Value))
                {
                    output.WriteLine("{0}#{1}#{2:0.0}%", item.Key.Remove(0, 1), item.Value, 100 * (double)item.Value / files.Length);
                }
            }
        }

        static void Main()
        {
            string[] files = new string[0];

            try
            {
                files = Directory.GetFiles(File.ReadAllText(inputFile), "*", SearchOption.AllDirectories);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка. Файл не найден.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка. Нет доступа к директории или файлу.");
            }
            
            GetStatsOnExtensions(files);
        }
    }
}