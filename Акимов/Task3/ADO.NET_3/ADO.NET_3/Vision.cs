using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Drawing;
namespace ADO.NET_3
{
    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]
    public class Vision : Form1
    {
        public static List<Figure> figures = new List<Figure>();
        public static void Deserial(string k, Graphics e)
        {

            using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
            {
                //BinaryFormatter formatter = new BinaryFormatter();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                List<Figure> newPerson = (List<Figure>)formatter.Deserialize(fs);
                MessageBox.Show("Объект десериализован");
                foreach (Figure figure in newPerson)
                {
                    Console.WriteLine();
                    figure.ShowInfo(e);

                }
            }



        }
        public static void Serial(string k)
        {

            //BinaryFormatter formatter = new BinaryFormatter();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));

            using (FileStream fs = new FileStream("persons.xml", FileMode.Create))
            {
                formatter.Serialize(fs, figures);

                MessageBox.Show("Объект сериализован");

            }
        }
        public Vision() { }
        public static void ShowOn(string k, Graphics g)
        {

            figures = GetFigures(k);

            foreach (Figure figure in figures)
            {
                figure.ShowInfo(g);

            }

        }

        public static List<Figure> GetFigures(string k)
        {
            string[] s = ReadFile(k);


            int x1, y1, x2, y2, x3, y3, x, y, width, height, i = 0, n = 0;

            while (i < s.Length)
            {
                string[] str = s[i].Split(' ');

                if (str[0] == "rectangle")
                {
                    x1 = Convert.ToInt32(str[1]);
                    y1 = Convert.ToInt32(str[2]);
                    x2 = Convert.ToInt32(str[3]);
                    y2 = Convert.ToInt32(str[4]);
                    figures.Add(new Rectangle(x1, y1, x2, y2));
                    n++;
                }
                if (str[0] == "circle")
                {
                    x = Convert.ToInt32(str[1]);
                    y = Convert.ToInt32(str[2]);
                    width = Convert.ToInt32(str[3]);
                    height = Convert.ToInt32(str[4]);
                    Circle key = new Circle(x, y, width, height);
                    figures.Add(key);
                    n++;
                }
                if (str[0] == "triangle")
                {
                    x1 = Convert.ToInt32(str[1]);
                    y1 = Convert.ToInt32(str[2]);
                    x2 = Convert.ToInt32(str[3]);
                    y2 = Convert.ToInt32(str[4]);
                    x3 = Convert.ToInt32(str[5]);
                    y3 = Convert.ToInt32(str[6]);
                    figures.Add(new Triangle(x1, y1, x2, y2, x3, y3));
                    n++;
                }
                i++;
            }
            return figures;
        }

        public static string[] ReadFile(string k)
        {

            string strin;
            StreamReader fig = new StreamReader(k);
            strin = fig.ReadToEnd();
            string[] str = strin.Split('\n');
            fig.Close();
            return str;
        }

    }
}

