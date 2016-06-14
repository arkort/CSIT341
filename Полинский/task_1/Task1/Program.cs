using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace Task1
{
    class Program
    {
        static IEnumerable<String> GetFileExtensions(string pathToDirectory)
        {
            string[] directories = null;
            string[] files = null;
            try
            {
                directories = Directory.GetDirectories(pathToDirectory);
                files = Directory.GetFiles(pathToDirectory);
            }
            catch (Exception e)
            {
            }
            if (files != null)
            {
                foreach (var file in files)
                {
                    yield return file;
                }
            }
            if (directories != null)
            {
                foreach (var directory in directories)
                {
                    foreach (var rec_action in GetFileExtensions(directory))
                    {
                        yield return rec_action;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader input = new StreamReader("input.txt"))
            using (StreamWriter output = new StreamWriter("output.txt"))           
            {
                string path = input.ReadLine();
                IEnumerable<string> files = GetFileExtensions(path);
                int fileCount = files.Count();
                var extensions = files.Select(element => Path.GetExtension(element)).
                                 GroupBy(element => element).
                                 Select(group => new { extName = group.First().Trim('.'), Count = group.Count() })
                                 .OrderByDescending(element => element.Count);
                foreach (var element in extensions)
                {
                    Console.WriteLine("{0}#{1}#{2:0.0}%", element.extName, element.Count, 100 * (double)element.Count / fileCount);
                    output.WriteLine("файлов {0} количество {1} в процентах  {2:0.0}%", element.extName, element.Count, 100 * (double)element.Count / fileCount);
                }
            }
        }
    }
}
