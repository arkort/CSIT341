using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task1
{
    class Program
    {
        static int Files = 0;
        static Dictionary<string, int> counter = new Dictionary<string, int>();        

        static void location(string str)
        {
            DirectoryInfo direct = new DirectoryInfo(str);
            Write(direct);
            foreach (var item in direct.EnumerateDirectories())
            {
                location(item.FullName);
            }
        }
        static IEnumerable<FileInfo> Write(DirectoryInfo name)
        {
            var array = name.EnumerateFiles();
            foreach (var item in array)
            {
                if (counter.ContainsKey(Path.GetExtension(item.FullName)))
                    counter[Path.GetExtension(item.FullName)]++;
                else
                    counter.Add(Path.GetExtension(item.FullName), 1);
                Files++;

            }
            return array;
        }

        static void Main()
        {
            using (StreamReader read = new StreamReader("input.txt"))
            {
                string key = read.ReadLine();
                location(key);
            }
            {
                using (StreamWriter write = new StreamWriter("output.txt"))
                {
                    foreach (var item in counter.OrderByDescending(pair => pair.Value))
                    {

                        if (!String.IsNullOrEmpty(item.Key))
                            write.WriteLine("<{0}>#<{1}>#<{2:F4}>", item.Key.Remove(0, 1), item.Key, (double)item.Value / Files);
                    }
                }
            }
        }
    }
}