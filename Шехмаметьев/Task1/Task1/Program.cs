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
        static IEnumerable<String> GetFileExtensions(string pathToDirectory, StreamWriter error_log)
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
                if (e is UnauthorizedAccessException)
                {
                    Console.WriteLine("You do not have authorization to access this directory: {0}", pathToDirectory);
                    error_log.WriteLine("You do not have authorization to access this directory: {0}", pathToDirectory);
                }
                else if (e is DirectoryNotFoundException)
                {
                    Console.WriteLine("Specified directory doesn't exist: {0}", pathToDirectory);
                    error_log.WriteLine("Specified directory doesn't exist: {0}", pathToDirectory);
                    yield break;
                }
                else
                {
                    Console.WriteLine(e.Message);
                    error_log.WriteLine(e.Message);
                    yield break;
                }
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
                    foreach (var rec_action in GetFileExtensions(directory, error_log))
                    {
                        yield return rec_action;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader input = new StreamReader(@"..\..\..\input.txt"))
            using (StreamWriter output = new StreamWriter(@"..\..\..\output.txt"))
            using (StreamWriter error_log = new StreamWriter(@"..\..\..\error_log.txt"))
            {
                string path = input.ReadLine();
                IEnumerable<string> files = GetFileExtensions(path, error_log);
                int fileCount = files.Count();
                var extensions = files.Select(element => Path.GetExtension(element)).
                                 GroupBy(element => element).
                                 Select(group => new { extName = group.First().Trim('.'), Count = group.Count() })
                                 .OrderByDescending(element => element.Count);
                foreach (var element in extensions)
                {
                    Console.WriteLine("{0}#{1}#{2:0.000}%", element.extName, element.Count, 100 * (double)element.Count / fileCount);
                    output.WriteLine("{0}#{1}#{2:0.000}%", element.extName, element.Count, 100 * (double)element.Count / fileCount);
                }
            }
        }
    }
}
