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
        static void Main(string[] args)
        {
            using (StreamReader input = new StreamReader(@"C:\Users\Rustam\Documents\GitProjects\
                                                AdoNetGit2\CSIT341\Шехмаметьев Р\Task1\input.txt"))
            {
                string[] files = new string[0];
                try
                {
                    files = Directory.GetFiles(input.ReadLine(), "*", SearchOption.AllDirectories);
                }
                catch(Exception e)
                {
                    if (e is UnauthorizedAccessException)
                    {
                        Console.WriteLine("You do not have authorization to access a directory or a subdirectory");
                    }
                    else if(e is DirectoryNotFoundException)
                    {
                        Console.WriteLine("Specified directory doesn't exist");
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                int fileCount = files.Length;
                var extensions = files.Select(element => Path.GetExtension(element)).
                                 GroupBy(element => element.Substring(1)).
                                 Select(group => new {extName = group.First(), Count = group.Count() })
                                 .OrderByDescending(element => element.Count);
                foreach(var element in extensions)
                {
                    Console.WriteLine("{0}#{1}#{2:0.000}%", element.extName, element.Count, 100 * (double)element.Count / fileCount);
                }
            }
        }
    }
}
