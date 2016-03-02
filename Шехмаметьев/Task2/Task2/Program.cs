using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            doc.Schemas.Add(null, "ComicsLibrary.xsd");
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
                int counter = 1;
            var ComicsCollection = doc.SelectSingleNode("ComicsCollection").SelectNodes("Comics");
            foreach (XmlElement element in ComicsCollection)
                {
                    Console.WriteLine($"{element.Name} {counter++}:");
                foreach (XmlAttribute attribute in element.Attributes)
                {
                    if (attribute.Name == "Publication_date" || attribute.Name == "Release_date")
                    {
                        Console.WriteLine(attribute.Name.Replace('_', ' ') + ": " + DateTime.Parse(attribute.Value).ToString("dd.MM.yyyy"));
                    }
                    else
                    {
                        Console.WriteLine(attribute.Name.Replace('_', ' ') + ": " + attribute.Value);
                    }
                }
                Console.WriteLine();
                }
        }
    }
}
