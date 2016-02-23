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
        static List<Tuple<int, string>> copy = new List<Tuple<int, string>>();
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
            foreach (var item in counter)
            {
                copy.Add(Tuple.Create(item.Value, item.Key));
            }
            copy.Sort();
            copy.Reverse();
            using (StreamWriter write = new StreamWriter("output.txt"))
            {
                foreach (var item in copy)
                {
                    write.WriteLine("<{0}>#<{1}>#<{2:F4}>", item.Item2, item.Item1, (double)item.Item1 / allFiles);
                }

            }
        }
        static void Main()
        {
            Directory(@"C:\Users\Артем\Documents\Visual Studio 2015\Projects");
            Write();
        }
    }
}
