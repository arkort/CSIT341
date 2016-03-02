using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{

    static void Main()
    {


        try
        {

            var document = new XmlDocument();
            document.Load("footballers.xml");

            var a = document.SelectNodes("group");
            document.Schemas.Add("", @"c:\users\alexeyb\documents\csit341\бирюков\task_2_ado\task_2_ado\teplatefootballers.xsd");
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

        static void footballersSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
       

        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
        }


        else if (e.Severity == XmlSeverityType.Error)
        {
            //Console.Write("ERROR: ");
            //Console.WriteLine(e.Message);
           
            throw new Exception(e.Message);
        }

        
    }
}