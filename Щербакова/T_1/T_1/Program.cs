using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace T_1
{
    class T_1
    {
        static void Main()
        {
            using (StreamReader Input = new StreamReader("input.txt"))
            {
                string path = Input.ReadLine();
                FileDirection(path);
            }
            WriteResult();
        }

        static Dictionary<string, int> count = new Dictionary<string, int>();
        static double Files = 0;
        static void FileDirection(string name)
        {
            DirectoryInfo direction = new DirectoryInfo(name);
            Write(direction);
            foreach (var a in direction.EnumerateDirectories())
                FileDirection(a.FullName);


        }
        static IEnumerable<FileInfo> Write(DirectoryInfo type)
        {
            var array = type.EnumerateFiles();
            foreach (var a in array)
            {
                if (count.ContainsKey(Path.GetExtension(a.FullName)))
                    count[Path.GetExtension(a.FullName)]++;
                else
                    count.Add(Path.GetExtension(a.FullName), 1);
                Files++;
            }
            return array;
        }
        static void WriteResult()
        {
            using (StreamWriter Output = new StreamWriter("output.txt"))
            {
                foreach (var a in count.OrderByDescending(pair => pair.Value))
                {

                    if (!String.IsNullOrEmpty(a.Key))
                        Output.WriteLine("File Type:{0} # Amount: <{1}># % of total amount<{2:F3}>",
                            a.Key.Remove(0, 1),a.Value.ToString(), (double)a.Value / Files);
                }
            }
        }
    }
}