using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            XmlReaderSettings BookStoreSettings = new XmlReaderSettings();
            BookStoreSettings.Schemas.Add(null, @"Scheme.xsd");
            BookStoreSettings.ValidationType = ValidationType.Schema;
            BookStoreSettings.ValidationEventHandler += new ValidationEventHandler(bsValidationEventHandler);
            XmlReader books = XmlReader.Create(@"BookStore.xml", BookStoreSettings);

            Print(books);
        }

        public static void Print(XmlReader books)
        {
            try
            {
                while (books.Read())
                {
                    switch (books.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                if (books.Name == "BOOK")
                                {
                                    Console.WriteLine(books.Name);
                                    break;
                                }

                                else if (books.Name != "BookStore")
                                {
                                    Console.Write(" - " + books.Name);
                                }
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                Console.WriteLine(" - " + books.Value);

                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(e.Message);
            }
        }


        static void bsValidationEventHandler(object sender, ValidationEventArgs e)
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