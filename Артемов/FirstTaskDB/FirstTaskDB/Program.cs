using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FirstTaskDB
{
    class Program
    {            
        static void Main(string[] args)
        {
            StreamReader inFile = new StreamReader("input.txt");
            StreamWriter outFile = new StreamWriter("output.txt");
            string path = inFile.ReadToEnd();
            
            // лист для хранения всех всех расширений
            List<string> allExtensions = new List<string>();
            
            if(Directory.Exists(path))  //если директория по данному пути существует
            {
                string[] Data = Directory.GetFiles(path, "*", SearchOption.AllDirectories); //собираем все расширения из корневой папки и подпапок
                foreach(string file in Data)
                {
                    if (Path.HasExtension(file)) //если название файла содержит расширение
                    {                                                
                        allExtensions.Add(Path.GetExtension(file)); //кладем расширение файла в лист хранящий расширения
                    }                                  
                }
            }
            else
            {                
                outFile.Write("this path is incorrect");
                Console.WriteLine("this path is incorrect");
            }            

            //удаляем точки из названия расширений
            for(int i = 0; i < allExtensions.Count; i++)
            {
                allExtensions[i] = allExtensions[i].Remove(0, 1);
            }          
                          
            //группируем все расширения
            var groups = from extension in allExtensions
                         group extension by extension;

            //сортируем группы расширений по убыванию
            var sortedGroups = from g in groups
                               orderby g.Count() descending
                               select g;          

            foreach (var el in sortedGroups)
            {                                
                outFile.WriteLine("{0}#{1}#{2:0.00}", el.Key, el.Count(), (float)el.Count() * 100 / allExtensions.Count);
                Console.WriteLine("{0}#{1}#{2:0.00}", el.Key, el.Count(), (float)el.Count() * 100 / allExtensions.Count);
            }

            inFile.Close();
            outFile.Close();
        }        
    }
}
