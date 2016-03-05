using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstTaskDB
{
    class Program
    {            
        static void Main(string[] args)
        {
            StreamReader inFile = new StreamReader(@"C:\Users\Виктор\Desktop\Базы данных\FirstTaskDB\input.txt");
            StreamWriter outFile = new StreamWriter(@"C:\Users\Виктор\Desktop\Базы данных\FirstTaskDB\output.txt");
            string path = inFile.ReadToEnd();
            inFile.Close();


            List<string> allExtensions = new List<string>();
            
            if(Directory.Exists(path))
            {
                string[] Data = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach(string file in Data)
                {                
                    allExtensions.Add(Path.GetExtension(file));
                }
            }
            else
            {                
                outFile.Write("this path is incorrect");
            }            

            for(int i = 0; i < allExtensions.Count; i++)
            {
                allExtensions[i] = allExtensions[i].Remove(0, 1);
            }          
                          

            var groups = from extension in allExtensions
                         group extension by extension;

            var sortedGroups = from g in groups
                               orderby g.Count() descending
                               select g;          

            foreach (var el in sortedGroups)
            {                                
                outFile.WriteLine("{0}#{1}#{2:0.00}", el.Key, el.Count(), (float)el.Count() * 100 / allExtensions.Count);         
            }          
              
            outFile.Close();
        }        
    }
}
