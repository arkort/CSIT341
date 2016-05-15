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
            CountExtensions(dir);
            foreach (var dires in dir.EnumerateDirectories())
            {
                Direct(dires.FullName);
            }
        }

        static IEnumerable<FileInfo> CountExtensions(DirectoryInfo d)
        {
            var filesCollection = d.EnumerateFiles();
            foreach (var file in filesCollection)
            {
                if (countFilesExtensions.ContainsKey(Path.GetExtension(file.FullName)))
                    countFilesExtensions[Path.GetExtension(file.FullName)]++;
                else
                    countFilesExtensions.Add(Path.GetExtension(file.FullName), 1);
                countAllFiles++;
            }
            return filesCollection;
        }



        static void WriteDictionary()
        {
            countFilesExtensions = countFilesExtensions.OrderByDescending(pair => pair.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            using (StreamWriter write = new StreamWriter("output.txt"))
            {
                foreach (var q in countFilesExtensions)
                {
                    if (!string.IsNullOrEmpty(q.Key))
                        write.WriteLine(q.Key.Remove(0, 1) + "#" + q.Value.ToString() + "#" + 100 * (double)q.Value / countAllFiles);
                }
            }

        }


        static void Main(string[] args)
        {
            using (StreamReader read = new StreamReader("input.txt"))
                Direct(read.ReadLine());
            WriteDictionary();
        }
    }
}

