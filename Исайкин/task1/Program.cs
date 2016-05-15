using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Seach seach = new Seach();

            using (StreamReader input = new StreamReader("input.txt"))
            {
                seach.SeachFiles(input.ReadLine());
            }

            using (StreamWriter output = new StreamWriter("output.txt"))
            {

                foreach (var item in seach.Gettypefiles())
                {
                    output.WriteLine($"{item.Key}:{(double)item.Value / seach.Count}");
                }
            }
        }
    }
}
