using System;
using System.Xml;

namespace Task2
{
    class Program
    {
        static string xmlFile = "db.xml";
        static string xsdFile = "db.xsd";

        static bool isValidXml(XmlDocument xmlDoc)
        {
            bool isValid = true;
            xmlDoc.Schemas.Add(null, xsdFile);
            xmlDoc.Validate((o, e) => { Console.WriteLine(e.Message); isValid = false; });
            return isValid;
        }

        static void PrintXmlContent(XmlDocument xmlDoc)
        {
            XmlNodeList nodes = xmlDoc.SelectNodes("//cd");

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

            if (isValidXml(doc)) PrintXmlContent(doc);
        }
    }
}
