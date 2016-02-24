using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Xml;
using System.Xml.Schema;
namespace ADO.NET_2
{
    class Program
    {

        static void Main()
        {
            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add(null, @"C:\Users\akimovaa\Documents\Visual Studio 2010\Projects\ADO.NET_2\XSD.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader books = XmlReader.Create(@"C:\Users\akimovaa\Documents\Visual Studio 2010\Projects\ADO.NET_2\XMLFile1.xml", booksSettings);

            while (books.Read()) { }
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
