using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static List<string> AllDirectories = new List<string>();
        static Dictionary<string, int> AllFiles = new Dictionary<string, int>();

        static void DirectoryStatistic(string InFile)
        {
            AllDirectories = Directory.GetDirectories(InFile).ToList();

            foreach (var item in AllDirectories)
            {
                if (Directory.GetFiles(item) != null)
                {
                    foreach (var val in Directory.GetFiles(item))
                    {
                        string type = Path.GetExtension(val);
                        if (AllFiles.ContainsKey(type))
                        {
                            AllFiles[type] += 1;
                        }
                        else
                        {
                            AllFiles.Add(Path.GetExtension(val), 1);
                        }
                    }
                }
            }            
        }

        static void Main(string[] args)
        {
            string InFile = null;
            int _counter = 0;

            try
            {
                StreamReader sr = new StreamReader("input.txt");

                InFile = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("Невозможно произвести чтение с файла.");
                Console.WriteLine(e.Message);
                return;
            }            

            DirectoryStatistic(InFile);
            
            foreach (var item in AllFiles)
            {
                _counter += item.Value;
            }

            var result = AllFiles.OrderByDescending(a => a.Value);

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (var item in result)
                {
                    if (!String.IsNullOrEmpty(item.Key))
                    {
                        sw.WriteLine("{0} # {1} # {2:0.0}", item.Key.Remove(0, 1), item.Value, 100 * (double)item.Value / _counter);
                    }
                }
            }
        }
    }
}