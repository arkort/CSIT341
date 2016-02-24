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
        static void GetAllFiles(List<string> ListFiles, string RootPath)
        {
            Queue<string> list = new Queue<string>();
            List<string> AllDirectories = new List<string>();
            list.Enqueue(RootPath);
            AllDirectories.Add(RootPath);

            while (list.Count != 0)
            {
                string c = list.Dequeue();
                if (Directory.GetDirectories(c) != null)
                {
                    foreach (string S in Directory.GetDirectories(c))
                    {
                        AllDirectories.Add(S);
                        list.Enqueue(S);
                    }
                }
            }

            foreach (string S in AllDirectories)
            {
                ListFiles.AddRange(Directory.GetFiles(S));
            }
        }

        static void Main(string[] args)
        {
            using (StreamReader inFile = new StreamReader("input.txt"))
            {
                using (StreamWriter outFile = new StreamWriter("output.txt", false))
                {
                    List<string> ListFiles = new List<string>();
                    string RootPath = inFile.ReadLine();

                    GetAllFiles(ListFiles, RootPath);

                    int FilesCount = ListFiles.Count;
                    var a = ListFiles.Select(s => Path.GetExtension(s)).Select(s => s.Remove(0, 1)).GroupBy(s=>s)
                        .Select(s => new { elem = s, Count = s.Count() })
                        .OrderByDescending(s => s.Count);

                    foreach (var S in a)
                    {
                         outFile.WriteLine("{0}#{1}#{2:P1}", S.elem.Key, S.Count, (double)S.Count / FilesCount);
                    }
                }
            }
        }
    }
}
