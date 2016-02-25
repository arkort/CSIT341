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
        static public bool flag=true;
        static void Main()
        {
            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add(null, @"XSD.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);
            XmlReader books = XmlReader.Create(@"XMLFile1.xml", booksSettings);

            while (books.Read()) { }
            if (flag == true)
            {
                Console.WriteLine("Файл корректен");
                XmlTextReader reader = new XmlTextReader("XMLFile1.xml");
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {


                        case XmlNodeType.Element:
                            {
                                if (reader.Name == "Bibl")
                                {
                                    continue;
                                }
                                if (reader.Name == "BOOK")
                                {

                                    Console.WriteLine(reader.Name);
                                    Console.Write("Attribute: Title=" + reader.GetAttribute(0));
                                    Console.WriteLine();

                                    break;
                                }
                                else
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
                Console.ReadLine();
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
            flag = false;
        }
    }
}
