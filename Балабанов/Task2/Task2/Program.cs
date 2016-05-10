using System;
using System.Xml;
using System.Xml.Schema;

class Program
{
    static void Main()
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("MyXML.xml");

            XmlNodeList node = xmlDocument.SelectNodes("Users");
            xmlDocument.Schemas.Add("", @"Schema.xsd");
            xmlDocument.Validate(UsersValidationEventHandler);

            foreach (XmlNode user in node[0].ChildNodes)
            {
                Console.WriteLine(user.Name);

                foreach (XmlNode userInfo in user.ChildNodes)
                {
                    Console.WriteLine(userInfo.Name + " " + userInfo.InnerText);
                }
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private static void UsersValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("Error: ");
            Console.WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            throw new Exception(e.Message);
        }
    }
}
