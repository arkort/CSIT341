using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Seach seach = new Seach();

            seach.SeachFiles(args[0]);

            foreach (var item in seach.Gettypefiles())
            {
                Console.WriteLine($"{item.Key}:{(double)item.Value/seach.Count}");
            }
       
        }
    }
}
