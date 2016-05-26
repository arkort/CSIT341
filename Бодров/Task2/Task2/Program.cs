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
            XmlReaderSettings FilmLibrarySettings = new XmlReaderSettings();
            FilmLibrarySettings.Schemas.Add(null, @"Film.xsd");
            FilmLibrarySettings.ValidationType = ValidationType.Schema;
            FilmLibrarySettings.ValidationEventHandler += new ValidationEventHandler(bsValidationEventHandler);
            XmlReader films = XmlReader.Create(@"FilmLibrary.xml", FilmLibrarySettings);

            Print(films);
        }

        public static void Print(XmlReader films)
        {
            try
            {
                while (films.Read())
                {
                    switch (films.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                if (films.Name == "FILM")
                                {
                                    Console.WriteLine(films.Name);
                                    break;
                                }

                                else if (films.Name != "FilmLibrary")
                                {
                                    Console.Write(" - " + films.Name);
                                }
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                Console.WriteLine(" - " + films.Value);

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