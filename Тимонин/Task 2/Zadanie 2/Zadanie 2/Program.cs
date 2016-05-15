using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Text;


namespace Zadanie2
{
    class Program
    {
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
        static void Main(string[] args)
        {


            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add(null, @"XMLFile1.xsd");
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

                            else if (books.Name != "group")
                            {
                                Console.Write("- " + books.Name + " ");
                            }
                            break;
                        }
                    case XmlNodeType.Text:
                        {
                            Console.WriteLine(books.Value);

                        }
                        break;

                }
            }



        }
    }
}
