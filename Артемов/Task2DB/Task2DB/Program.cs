using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;


namespace Task2DB
{
    class Program
    {
        public static bool showInfo = true;

        static void Main()
        {
            XmlReaderSettings legoSettings = new XmlReaderSettings();
            legoSettings.Schemas.Add(null, @"XMLFile1.xsd");
            legoSettings.ValidationType = ValidationType.Schema;
            legoSettings.ValidationEventHandler += new ValidationEventHandler(legoSettingsValidationEventHandler);
            XmlReader lego = XmlReader.Create(@"XML_LEGO.xml", legoSettings);
            
            while (lego.Read()) { }

            if (showInfo)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"XML_LEGO.xml");             
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        if (attr != null)
                            Console.WriteLine(attr.Value);
                    }

                    Console.WriteLine();

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        switch (childnode.Name)
                        {
                            case "MARKING":
                                Console.WriteLine("Маркировка: {0}", childnode.InnerText);
                                break;
                            case "PIECES":
                                Console.WriteLine("Количество деталей: {0}", childnode.InnerText);
                                break;
                            case "PRICE":
                                Console.WriteLine("Цена: {0} рублей", childnode.InnerText);
                                break;
                            case "AGE":
                                Console.WriteLine("Возраст: {0}", childnode.InnerText);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        static void legoSettingsValidationEventHandler(object sender, ValidationEventArgs e)
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
            showInfo = false;
        }
    }
}
