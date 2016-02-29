using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADO.NET_1
{
    class Program
    {
        static Dictionary<string, int> counter = new Dictionary<string, int>();
        static int allFiles = 0;

        static void Directory(string name)
        {
            DirectoryInfo dir = new DirectoryInfo(name);
            Record(dir);
            foreach (var item in dir.EnumerateDirectories())
            {
                Directory(item.FullName);
            }

        }
        static IEnumerable<FileInfo> Record(DirectoryInfo name)
        {
            var array = name.EnumerateFiles();
            foreach (var item in array)
            {
                if (counter.ContainsKey(Path.GetExtension(item.FullName)))
                    counter[Path.GetExtension(item.FullName)]++;
                else
                    counter.Add(Path.GetExtension(item.FullName), 1);
                allFiles++;

            }
            return array;
        }
        static void Write()
        {
         
           
            using (StreamWriter write = new StreamWriter("output.txt"))
            {
                foreach (var item in counter.OrderByDescending(pair => pair.Value))
                {

                    if (!String.IsNullOrEmpty(item.Key))
                        write.WriteLine("<{0}>#<{1}>#<{2:F4}>", item.Key.Remove(0, 1), item.Key, (double)item.Value / allFiles);
                }

            }
        }
        static void Main()
        {
            using (StreamReader read = new StreamReader("input.txt"))
            {
                string key = read.ReadLine();
                Directory(key);
            }
            Write();


        }
    }
}
