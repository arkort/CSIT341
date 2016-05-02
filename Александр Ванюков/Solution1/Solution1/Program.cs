using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Solution1
{
    public class Ans : IComparable
    {
        public int cnt { get; }
        public string format { get; }
        public double procent { get; }
        public Ans(int _cnt,string _format, double _procent)
        {
            this.cnt = _cnt;
            this.format = _format;
            this.procent = _procent;
        }

        public int CompareTo(object obj)
        {
            Ans q = (Ans)obj;
            if (this.cnt > q.cnt)
            {
                return -1;
            }

            if (this.cnt < q.cnt)
            {
                return 1;
            }

            return 0;
        }
    }

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
                List<Ans> ans = new List<Ans>();
                foreach (var i in ExtentionFiles)
                {
                    if (i.Key.Length != 0)
                    {
                        ans.Add(new Ans(i.Value,i.Key.Substring(1),(double)i.Value/(double)countAllFiles*100.0));
                    }
                }

                ans.Sort();
                foreach(Ans i in ans)
                {
                    output.WriteLine($"{i.format}#{i.cnt}#{i.procent}");
                }
            }
            
        }
    }
}
