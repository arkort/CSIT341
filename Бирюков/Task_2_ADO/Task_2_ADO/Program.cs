using System;
using System.Xml;
using System.Xml.Schema;

internal class XmlSchemaSetExample
{
    private static void Main()
    {
        try
        {
            var document = new XmlDocument();
            document.Load("footballers.xml");

            var a = document.SelectNodes("group");
            document.Schemas.Add("", @"teplatefootballers.xsd");
            document.Validate(footballersSettingsValidationEventHandler);

            foreach (XmlNode footballer in a[0].ChildNodes)
            {
                Console.WriteLine(footballer.Name);

                foreach (XmlNode characteristics in footballer.ChildNodes)
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

    private static void footballersSettingsValidationEventHandler(object sender, ValidationEventArgs e)
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