using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;

public class Sample
{
    static public bool OK = true;

    public static void Main()
    {       
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add("http://tempuri.org/XMLSchema1.xsd", "XMLSchema1.xsd");

        XDocument doc = XDocument.Load("task_2.xml");               
        if (OK) PrintXml(doc);       
    }
    public static void PrintXml(XDocument doc)
    {
        foreach (XElement el in doc.Root.Elements())
        {
            XAttribute nameAttribute = el.Attribute("name");
            Console.WriteLine("{0} - {1}", el.Name, nameAttribute.Value);

            foreach (XElement element in el.Elements())
            {
                Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            }
        }      
    }
    public static void Validate(String filename, XmlSchemaSet schemaSet)
    {
        XmlSchema compiledSchema = null;
        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            compiledSchema = schema;
        }

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(compiledSchema);
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        settings.ValidationType = ValidationType.Schema;

        XmlReader vreader = XmlReader.Create(filename, settings);
        while (vreader.Read()) { }        
        vreader.Close();

        OK = false;        
    }

    public static void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.WriteLine("\tWarning." + args.Message);
        else
            Console.WriteLine("\tError: " + args.Message);
    }
}