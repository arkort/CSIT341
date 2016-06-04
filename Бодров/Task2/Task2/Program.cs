using System;
using System.Xml;
using System.Xml.Schema;

class Program
{
    private static void Main()
    {
        try
        {
            var document = new XmlDocument();
            document.Load("Films.xml");

            var a = document.SelectNodes("FilmLibrary");
            document.Schemas.Add("", @"TFilms.xsd");
            document.Validate(FilmsSettingsValidationEventHandler);

            foreach (XmlNode film in a[0].ChildNodes)
            {
                Console.WriteLine(film.Name);

                foreach (XmlNode characteristics in film.ChildNodes)
                {
                    Console.WriteLine(characteristics.Name + " " + characteristics.InnerText);
                }
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void FilmsSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            throw new Exception(e.Message);
        }
    }
}