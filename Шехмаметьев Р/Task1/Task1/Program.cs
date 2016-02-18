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
            using (StreamReader input = new StreamReader("input.txt"))
            {
                string[] files = Directory.GetFiles(input.ReadLine(), "*", SearchOption.AllDirectories);
                int fileCount = files.Length;
                var extensions = files.Select(element => element.Substring(element.LastIndexOf('.'))).
                                 GroupBy(element => element.Substring(1)).
                                 Select(group => new {extName = group.First(), Count = group.Count() })
                                 .OrderByDescending(element => element.Count);
                foreach(var element in extensions)
                {
                    Console.WriteLine("{0}#{1}#{2:0.000}%", element.extName.Remove(0, 1), element.Count, 100 * (double)element.Count / fileCount);
                }
                                 
                                
            }
            
        }
    }
}
