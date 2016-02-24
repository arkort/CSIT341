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
            doc.Load(@"..\..\XMLFile1.xml");
            var ComicsCollection = doc.SelectSingleNode("ComicsCollection").SelectNodes("Comics");
            doc.Schemas.Add("", @"..\..\ComicsLibrary.xsd");
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
