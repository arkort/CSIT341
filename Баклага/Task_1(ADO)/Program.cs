using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Task_1_ADO_
{
    class Task_1
    {
        static void Main()
        {
            using (StreamReader Input_File = new StreamReader(@"C:\Users\Artem\Desktop\input.txt"))
            {
                string path = Input_File.ReadLine();
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
            foreach (var q in direction.EnumerateDirectories())
            {
                FileDirection(q.FullName);
            }

        }
        static IEnumerable<FileInfo> Write (DirectoryInfo type)
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
        static void WriteResult()
        {
          using (StreamWriter Output_File = new StreamWriter(@"C:\Users\Artem\Desktop\output.txt"))
            {
                foreach (var q in count.OrderByDescending(pair => pair.Value))
                {

                    if (!String.IsNullOrEmpty(q.Key))
                       Output_File.WriteLine("File Type:{0} # Amount: <{1}># % of total amount<{2:F3}>", q.Key.Remove(0, 1), q.Value.ToString(), (double)q.Value / Files);
                }
            }
        }
    }
}