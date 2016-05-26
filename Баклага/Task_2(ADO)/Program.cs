using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    static void Main()
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("XML_File.xml");

            XmlNodeList node = xmlDocument.SelectNodes("Catalog");
            xmlDocument.Schemas.Add(null, @"XMLSchema.xsd");
            xmlDocument.Validate(carsSettingsValidationEventHandler);

            foreach (XmlNode car in node[0].ChildNodes)
            {
                Console.WriteLine(car.Name);

                foreach (XmlNode userInfo in car.ChildNodes)
                {
                    Console.WriteLine(userInfo.Name + " " + userInfo.InnerText);
                }
                Console.WriteLine();
            }
        }

        catch( Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    
        private static void carsSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
        }
    }
}

