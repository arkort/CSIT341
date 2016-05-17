using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Program
    {
        static Dictionary<string, int> count = new Dictionary<string, int>();
        static double Files = 0;
        static void FileDirection(string name)
        {
            DirectoryInfo direction = new DirectoryInfo(name);
            Write(direction);
            foreach (var q in direction.EnumerateDirectories())
            {
                FileDirection(q.FullName);
            }

        }
        static IEnumerable<FileInfo> Write(DirectoryInfo type)
        {
            var array = type.EnumerateFiles();
            foreach (var q in array)
            {
                if (count.ContainsKey(Path.GetExtension(q.FullName)))
                    count[Path.GetExtension(q.FullName)]++;
                else
                    count.Add(Path.GetExtension(q.FullName), 1);
                Files++;

            }
            return array;
        }
        static void Result()
        {
            using (StreamWriter output1 = new StreamWriter(@"output.txt"))
            {
                foreach (var q in count.OrderByDescending(pair => pair.Value))
                {

                    if (!String.IsNullOrEmpty(q.Key))
                        output1.WriteLine("Type: " + q.Key.Remove(0, 1) + ", count: " + q.Value.ToString() + ", percentage share: " + ((double)q.Value / Files));
                }
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader Input_File = new StreamReader(@"input.txt"))
            {
                string path = Input_File.ReadLine();
                FileDirection(path);
            }
            Result();
        }
    }
}
