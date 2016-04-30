using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    static void Main()
    {
        XmlReaderSettings carSettings = new XmlReaderSettings();
        carSettings.Schemas.Add(null, @"C:\Users\Artem\Documents\Visual Studio 2015\Projects\Task_2(ADO)\XMLSchema.xsd");
        carSettings.ValidationType = ValidationType.Schema;
        carSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

        XmlReader cars = XmlReader.Create(@"C:\Users\Artem\Documents\Visual Studio 2015\Projects\Task_2(ADO)\XML_File.xml", carSettings);


        while (cars.Read())
        {
            switch (cars.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        if (cars.Name == "Car")
                        {
                            Console.Write(" Cars Features " + cars.GetAttribute(0));
                            Console.WriteLine();
                            break;
                        }

                        else if (cars.Name != "Catalog")

                        {
                            Console.Write(" - " + cars.Name);
                        }
                        break;
                    }
                case XmlNodeType.Text:
                    {
                        Console.WriteLine(":" + cars.Value);

                    }
                    break;

            }
        }

    }


    static void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
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

