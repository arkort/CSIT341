using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    static void Main()
    {
        XmlReaderSettings carSettings = new XmlReaderSettings();
        carSettings.Schemas.Add(null, "XMLSchema.xsd");
        carSettings.ValidationType = ValidationType.Schema;
        carSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

        XmlReader books = XmlReader.Create("XML_File.xml", carSettings);


        while (books.Read())
        {
            switch (books.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        if (books.Name == "Car")
                        {
                            Console.Write(" Cars Features " + books.GetAttribute(0));
                            Console.WriteLine();
                            break;
                        }

                        else if (books.Name != "Catalog")

                        {
                            Console.Write(" - " + books.Name);
                        }
                        break;
                    }
                case XmlNodeType.Text:
                    {
                        Console.WriteLine(":" + books.Value);

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

