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
            booksSettings.Schemas.Add(null, @"C:\Users\Артем\Documents\Visual Studio 2015\Projects\XSD.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader books = XmlReader.Create(@"C:\Users\Артем\Documents\Visual Studio 2015\Projects\XMLFile1.xml", booksSettings);

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
