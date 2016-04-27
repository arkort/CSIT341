using System;
using System.Xml;

namespace task2
{
    class Program
    {
        static string xsdFile = "parking.xsd";
        static string xmlFile = "Parking.xml";

        static bool XmlValidation(XmlDocument xmlDoc)
        {
            bool Validation = true;
            xmlDoc.Schemas.Add(null, xsdFile);
            xmlDoc.Validate((o, e) => { Console.WriteLine(e.Message); Validation = false; });
            return Validation;
        }

        static void WriteXML(XmlDocument xmlDoc)
        {
            XmlNodeList nodes = xmlDoc.SelectNodes("//car");

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.Name);
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    Console.WriteLine("\t{0}: {1}", node.ChildNodes[i].Name, node.ChildNodes[i].FirstChild.Value);
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            if (XmlValidation(doc))
                WriteXML(doc);
        }
    }
}
