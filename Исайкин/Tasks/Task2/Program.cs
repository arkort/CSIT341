using System;
using System.Xml;
using System.Xml.Linq;

namespace Task2
{
    internal class Program
    {
        private static string xmlFile = "XMLFile1.xml";
        private static string xsdFile = "XMLSchema1.xsd";

        private static void Main()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            if (IsXml(xmldoc))
            {
                PrintFieXml(xmlFile);
            }
        }

        private static bool IsXml(XmlDocument xmlFile)
        {
            bool flagXml = true;
            xmlFile.Schemas.Add(null, xsdFile);
            xmlFile.Validate((o, e) =>
            {
                Console.WriteLine(e.Message); flagXml = false;
            });

            return flagXml;
        }

        private static void PrintFieXml(string xmlFile)
        {
            string fileName = xmlFile;
            XDocument doc = XDocument.Load(fileName);
            foreach (XElement el in doc.Root.Elements())
            {
                Console.WriteLine($"{el.Name}");
                foreach (XElement element in el.Elements())
                {
                    Console.WriteLine($"{element.Name}: {element.Value}");
                }
            }
        }
    }
}