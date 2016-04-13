using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solution1
{
    class Program
    {
        static void Scan(DirectoryInfo current, ref Dictionary<string,int>ExtentionFiles, ref int countAllFiles)
        {
            foreach(FileInfo i in current.EnumerateFiles())
            {
                if(ExtentionFiles.ContainsKey(i.Extension))
                {
                    ExtentionFiles[i.Extension]++;
                }
                else
                {
                    ExtentionFiles.Add(i.Extension,1);
                }
                countAllFiles++;
            }
            foreach(DirectoryInfo i in current.EnumerateDirectories())
            {
                Scan(i,ref ExtentionFiles,ref countAllFiles);
            }

        }
        static void Main()
        {
            int countAllFiles = 0;
            Dictionary<string, int> ExtentionFiles = new Dictionary<string, int>();
            using (StreamReader input = new StreamReader("input.txt"))
            {
                string path = input.ReadLine();
                DirectoryInfo di = new DirectoryInfo(path);
                Scan(di,ref ExtentionFiles,ref countAllFiles);

            }
            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                foreach(var i in ExtentionFiles)
                {
                    output.WriteLine("{0}#{1}#{2}", i.Key.Substring(1), i.Value, (double)i.Value / (double)countAllFiles * 100);
                }
            }
            
        }
    }
}
