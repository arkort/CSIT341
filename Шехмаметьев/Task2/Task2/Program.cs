using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
namespace Task2
{
    abstract class Student
    {
        void hello()
        {
            Console.WriteLine("alsdjaskjdask");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load(@"C:\Users\Rustam\Documents\GitProjects\AdoNetGit2\CSIT341\Шехмаметьев Р\Task2\Task2\XMLFile1.xml");
            var ComicsCollection = doc.SelectSingleNode("ComicsCollection").SelectNodes("Comics");
            doc.Schemas.Add("", @"c:\users\rustam\documents\gitprojects\adonetgit2\csit341\шехмаметьев р\task2\task2\comicslibrary.xsd");
            bool validated = true;
            try
            {
                doc.Validate((o, e) => { if (e.Severity == XmlSeverityType.Error) throw e.Exception; });
            }
            catch(XmlSchemaValidationException e)
            {
                Console.Write("Error in XMLFile: ");
                Console.WriteLine(e.Message);
                return;
            }

            if (validated)
            {
                int counter = 1;
                foreach (XmlElement element in ComicsCollection)
                {
                    Console.WriteLine($"{element.Name} {counter++}:");
                    foreach (XmlAttribute attribute in element.Attributes)
                    {
                        Console.WriteLine(attribute.Name + ": " + attribute.Value);
                    }
                }
            }
        }
    }
}
