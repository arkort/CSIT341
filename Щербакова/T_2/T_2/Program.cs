using System;
using System.Xml;
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
            xmlDocument.Schemas.Add(null, @"XML_Schema.xsd");
            xmlDocument.Validate(flowersSettingsValidationEventHandler);

            foreach (XmlNode flowers in node[0].ChildNodes)
            {
                Console.WriteLine(flowers.Name);

                foreach (XmlNode flowersInfo in flowers.ChildNodes)
                {
                    Console.WriteLine(flowersInfo.Name + " " + flowersInfo.InnerText);
                }
                Console.WriteLine();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    static void flowersSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("warning: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("error: ");
            Console.WriteLine(e.Message);
        }
    }
}

