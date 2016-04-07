using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    public class Seach
    {
        private Dictionary<string, int> typefiles;

        public int Count
        {
            get
            {
                return typefiles.Count;
            }
        }

        public Seach()
        {
            typefiles = new Dictionary<string, int>();
        }

        public void SeachFiles(string path)
        {
            var directorys = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);

            foreach (var file in files)
            {
                var type = Path.GetExtension(file);

                if (!typefiles.ContainsKey(type))
                {
                    typefiles.Add(type, 1);
                }
                else
                {
                    typefiles[type]++;
                }
            }

            foreach (var directory in directorys)
            {
                SeachFiles(directory);
            }
        }

        public IEnumerable<KeyValuePair<string, int>> Gettypefiles()
        {
            foreach (var temp in typefiles)
            {
                yield return temp;
            }
        }
    }
}
