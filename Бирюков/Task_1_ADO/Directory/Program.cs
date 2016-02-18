using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryName
{
    class Program
    {
        static Dictionary<string, int> countFilesExtensions = new Dictionary<string, int>();
        static int countAllFiles = 0;

        static void Direct(string nameOfDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(nameOfDirectory);
            Ret(dir);
            foreach (var dires in dir.EnumerateDirectories())
            {
                Direct(dires.FullName);
            }
        }

        static IEnumerable<FileInfo> Ret(DirectoryInfo d)
        {
            var a = d.EnumerateFiles();
            foreach (var q in a)
            {
                if (countFilesExtensions.ContainsKey(Path.GetExtension(q.FullName)))
                    countFilesExtensions[Path.GetExtension(q.FullName)]++;
                else
                    countFilesExtensions.Add(Path.GetExtension(q.FullName), 1);
                countAllFiles++;
            }
            return a;            
        }

        static void WriteDictionary()
        {
            using (StreamWriter write = new StreamWriter("output.txt"))
            {
                foreach (var q in countFilesExtensions)
                {
                    write.WriteLine(q.Key.Remove(0, 1) + "#" + q.Value.ToString() + "#" + 100 * (double)q.Value / countAllFiles);
                }
            }

        }


        static void Main(string[] args)
        {
            Direct(@"C:\Users\AlexeyB\Desktop\q");
            WriteDictionary();
        }
    }
}
