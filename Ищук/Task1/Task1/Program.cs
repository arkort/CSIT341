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
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");

            string InFile = sr.ReadToEnd();

            List<string> AllDirectories = new List<string>();
            AllDirectories = Directory.GetDirectories(InFile).ToList();
            Dictionary<string, int> AllFiles = new Dictionary<string, int>();
            int count = 0;
            foreach (var item in AllDirectories)
            {
                if (Directory.GetFiles(item) != null)
                {
                    int len = Directory.GetFiles(item).Length;
                    string[] FilesMas = new string[len];
                    FilesMas = Directory.GetFiles(item);
                    foreach (var val in FilesMas)
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

            foreach (var item in AllFiles)
            {
                count += item.Value;
            }

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (var item in AllFiles)
                {
                    if (!string.IsNullOrEmpty(item.Key))
                    {
                        sw.WriteLine("{0} # {1} # {2:0.0}", item.Key.Remove(0, 1), item.Value, 100 * (double)item.Value / count);
                    }
                }
            }
        }
    }
}