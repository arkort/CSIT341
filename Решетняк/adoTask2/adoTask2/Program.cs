using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{
    class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
    static void Main()
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load("XMLFile1.xml");
        XmlReaderSettings booksSettings = new XmlReaderSettings();
        booksSettings.Schemas.Add(null, "XMLSchema1.xsd");
        booksSettings.ValidationType = ValidationType.Schema;
        booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

        XmlReader reader = XmlReader.Create("XMLFile1.xml", booksSettings);

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        if (reader.Name == "PHONE")
                        {
                            Console.WriteLine(reader.Name);                          
                            Console.Write(reader.GetAttribute(0));
                            Console.WriteLine();
                            break;
                        }

                        else if (reader.Name != "PHONES")

                        {
                            Console.Write("- " + reader.Name);
                        }
                        break;
                    }
                case XmlNodeType.Text:
                    {
                        Console.WriteLine(" " + reader.Value);

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
