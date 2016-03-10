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

                if(ext.Length == 0) continue;

                if (extStats.ContainsKey(ext))
                {
                    extStats[ext]++;
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
            string[] files = null;

            try
            {
                files = Directory.GetFiles(File.ReadAllText(inputFile), "*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                GetStatsOnExtensions(files);
            }
        }
    }
}