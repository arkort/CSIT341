using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    static void Main()
    {
        XmlReaderSettings flowersSettings = new XmlReaderSettings();
        flowersSettings.Schemas.Add(null, @"c:\users\dns\documents\visual studio 2015\Projects\T_2\T_2\XML_Schema.xsd");
        flowersSettings.ValidationType = ValidationType.Schema;
        flowersSettings.ValidationEventHandler += new ValidationEventHandler(flowersSettingsValidationEventHandler);
        XmlReader flowers = XmlReader.Create(@"c:\users\dns\documents\visual studio 2015\Projects\T_2\T_2\XML_File.xml", flowersSettings);


        while (flowers.Read())
        {
            switch (flowers.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        if (flowers.Name == "flowers")
                        {
                            Console.Write(flowers.GetAttribute(0));
                            Console.WriteLine();
                            break;
                        }

                        else if (flowers.Name != "Catalog")
                            Console.Write(flowers.Name);
                        break;
                    }
                case XmlNodeType.Text:
                    Console.WriteLine(flowers.Value);
                    break;
            }
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

