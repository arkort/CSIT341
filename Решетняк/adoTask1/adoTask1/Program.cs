using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoTask1
{
    class Program
    {

        public static IEnumerable<string> GetInfoFile(string folder)
        {
            string[] directories, files;
            
            try
            {
                files = Directory.GetFiles(folder);
            }
            catch (UnauthorizedAccessException e)
            {
                files = new string[0];
            }


            foreach (var file in files)
            {
                yield return file;
            }

            try
            {
                directories = Directory.GetDirectories(folder);
            }
            catch (UnauthorizedAccessException e)
            {
                directories = new string[0];
            }


            foreach (var dir in directories)
            {
                foreach (var file in GetInfoFile(dir))
                {
                    yield return file;
                }
            }
        }

        static void Main()
        {
            Dictionary<string, int> extensions = new Dictionary<string, int>();
            string path;            
            int count = 0;
            string temp;

            using (StreamReader inFile = new StreamReader("input.txt"))
            {
                path = inFile.ReadLine();
            }
            IEnumerable<string> files = GetInfoFile(path);
            
            foreach (var file in files)
            {
                count++;
                temp = Path.GetExtension(file).Trim('.');

                if (extensions.Count == 0 || !extensions.Keys.Contains(temp))
                {
                    extensions.Add(temp, 1);
                }
                else
                {
                    extensions[temp]++;
                }
            }

            using (StreamWriter outFile = new StreamWriter("output.txt"))
            {
                foreach (var item in extensions.OrderByDescending(element => element.Value))
                {
                    outFile.WriteLine("{0} - {1:0.####}%", item.Key, 100 * (double)item.Value / count);
                }
            }
        }        
    }
}