using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
namespace ADO.NET_2
{
    class Program
    {

        static void Main()
        {
            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add(null, @"XSD.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);
            XmlReader books = XmlReader.Create(@"XMLFile1.xml", booksSettings);

            while (books.Read())
            {
                switch (books.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (books.Name == "BOOK")
                            {
                                Console.WriteLine(books.Name);
                                Console.Write("Attribute: Title=" + books.GetAttribute(0));
                                Console.WriteLine();
                                break;
                            }

                            else if  (books.Name != "Bibl")

                            {
                                Console.Write("- " + books.Name);
                            }
                            break;
                        }
                    case XmlNodeType.Text:
                        {
                            Console.WriteLine(" " + books.Value);

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
}
