using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;

namespace Task2
{
    class Program
    {
        static bool IsValid = true;
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
            IsValid = false;
        }

        static void PrintXmlDoc(XDocument Document)
        {
            foreach (XElement el in Document.Root.Elements())
            {
                Console.WriteLine("{0}", el.Name);
                Console.WriteLine("  Attributes:");
                foreach (XAttribute attribute in el.Attributes())
                    Console.WriteLine("{0}", attribute);
                Console.WriteLine("  Elements:");
                foreach (XElement element in el.Elements())
                    Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            }
        }

        static void Main(string[] args)
        {

            XmlSchemaSet SchemaSet = new XmlSchemaSet();
            SchemaSet.Add(null, "Schema.xsd");

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = SchemaSet;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader reader = XmlReader.Create("MyXML.xml", settings);

            while (reader.Read()) ;

            if (IsValid)
            {
                XDocument Document = XDocument.Load("MyXML.xml");
                PrintXmlDoc(Document);
            }
        }
    }
}

