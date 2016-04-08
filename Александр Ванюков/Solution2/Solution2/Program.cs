using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.Windows;

namespace Solution2
{
    class Program
    {
        static public void ShowXml(XmlNodeList xmlNodes)
        {
            for(int i=0;i<xmlNodes.Count;i++)
            {
                Console.WriteLine(xmlNodes[i].Name);
                for (int j = 0; xmlNodes[i].Attributes !=null && j < xmlNodes[i].Attributes.Count; j++)
                {
                    Console.WriteLine("Attribute: " + "{0}", xmlNodes[i].Attributes[j].Value);
                }
                for (int j = 0; j < xmlNodes[i].ChildNodes.Count; j++)
                {
                    Console.WriteLine("-"+"{0} {1}",xmlNodes[i].ChildNodes[j].Name, xmlNodes[i].ChildNodes[j].InnerText);
                }
            }
        }
        static void Main()
        {
            XmlDocument file = new XmlDocument();
            file.Load("Data.xml");
            file.Schemas.Add("", "schema.xsd");
            bool exception = false;
            ValidationEventHandler eventHandler = new ValidationEventHandler((object sender, ValidationEventArgs e) => { Console.WriteLine(e.Message); exception = true; });
            file.Validate(eventHandler);
            if(!exception)
            {
                ShowXml(file.DocumentElement.ChildNodes);
            }
        }
    }
}
