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
                string TempDirectory = list.Dequeue();
                if (Directory.GetDirectories(TempDirectory) != null)
                {
                    foreach (string OneDirectory in Directory.GetDirectories(TempDirectory))
                    {
                        AllDirectories.Add(OneDirectory);
                        list.Enqueue(OneDirectory);
                    }
                }
            }

            foreach (string Director in AllDirectories)
            {
                ListFiles.AddRange(Directory.GetFiles(Director));
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
                    var ChangedListFiles = ListFiles.Select(s => Path.GetExtension(s)) //taking all extensions
                        .Select(s => s.Remove(0, 1)).GroupBy(s=>s) //then remove "." before every extension and set sorting criterion
                        .Select(s => new { elem = s, Count = s.Count() }) //transforming from "exe" to -> "exe; exe.Count" etc.
                        .OrderByDescending(s => s.Count);  //sort descending

                    foreach (var iterator in ChangedListFiles)
                    {
                         outFile.WriteLine("{0}#{1}#{2:P1}", iterator.elem.Key, iterator.Count, (double)iterator.Count / FilesCount); 
                    }
                }
            }
        }
    }
}
