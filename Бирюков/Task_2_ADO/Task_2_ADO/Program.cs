using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaSetExample
{

    static void Main()
    {
        XmlReaderSettings footballersSettings = new XmlReaderSettings();
        footballersSettings.Schemas.Add("", @"c:\users\alexeyb\documents\csit341\бирюков\task_2_ado\task_2_ado\teplatefootballers.xsd");
        footballersSettings.ValidationEventHandler += new ValidationEventHandler(footballersSettingsValidationEventHandler);

        footballersSettings.ValidationType = ValidationType.Schema;

        List<string> list = new List<string>();

        using (XmlReader f = XmlReader.Create("footballers.xml", footballersSettings))
        {
            try
            {
                while (f.Read())
                {
                    if (!string.IsNullOrWhiteSpace(f.Value) || !string.IsNullOrEmpty(f.Name) && !list.Contains(f.Name))
                        list.Add(string.Format("Name = {0}, Value = {1}",f.Name, f.Value));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                list.Clear();
            }
            for (int i = 1; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                //if (i % 3 == 0 && i != 0)
                //    Console.WriteLine(new string('-', 25));
            }
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