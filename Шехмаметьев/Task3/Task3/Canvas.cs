using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Drawing;

namespace Task3
{
    static class IntExtension
    {
        public static int HexToInt32(this Int32 number, params String[] hexNumber)
        {
            try
            {
                return (int)new System.ComponentModel.Int32Converter().ConvertFromString(hexNumber[0]);
            }
            catch
            {
                return 0;
            }
        }
    }
    [Serializable]
    class Canvas
    {
        List<IFigure> figures;
        
        public Canvas(XmlDocument doc)
        {
            this.figures = new List<IFigure>();
            var children = doc.SelectSingleNode("Figures").ChildNodes;
            
            foreach(XmlElement figure in children)
            {
                #region LineParsing
                if (figure.Name == "Line")
                {
                    Single X = 0;
                    Single Y = 0;
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[0].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF begin = new PointF(X, Y);
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[1].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF end = new PointF(X, Y);
                    Color figureColor = Color.Empty;
                    Single penWidth = 0;
                    foreach (XmlAttribute figureAttribute in figure.Attributes)
                    {
                        if (figureAttribute.Name == "color")
                        {
                            figureColor = Color.FromArgb(new Int32().HexToInt32(figureAttribute.Value));
                        }
                        else
                        {
                            penWidth = Single.Parse(figureAttribute.Value);
                        }
                    }
                    figures.Add(new ULine(begin, end, figureColor, penWidth));
                }
                #endregion
                #region RectangleParsing
                else if (figure.Name == "Rectangle")
                {
                    Single X = 0;
                    Single Y = 0;
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[0].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF leftUpperCorner = new PointF(X, Y);
                    Single height = 0;
                    Single width = 0;
                    Color figureColor = Color.Empty;
                    foreach (XmlAttribute figureAttribute in figure.Attributes)
                    {
                        if (figureAttribute.Name == "height")
                        {
                            height = Single.Parse(figureAttribute.Value);
                        }
                        else if (figureAttribute.Name == "width")
                        {
                            width = Single.Parse(figureAttribute.Value);
                        }
                        else if (figureAttribute.Name == "color")
                        {
                            figureColor = Color.FromArgb(new Int32().HexToInt32(figureAttribute.Value));
                        }
                    }
                    figures.Add(new URectangle(leftUpperCorner, height, width, figureColor));
                }
                #endregion
                #region CircleParsing
                else if (figure.Name == "Circle")
                {
                    Single X = 0;
                    Single Y = 0;
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[0].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF center = new PointF(X, Y);
                    Single radius = 0;
                    Color figureColor = Color.Empty;
                    foreach (XmlAttribute figureAttribute in figure.Attributes)
                    {
                        if (figureAttribute.Name == "radius")
                        {
                            radius = Single.Parse(figureAttribute.Value);
                        }
                        else if (figureAttribute.Name == "color")
                        {
                            figureColor = Color.FromArgb(new Int32().HexToInt32(figureAttribute.Value));
                        }
                    }
                    figures.Add(new UCircle(radius, center, figureColor));
                }
                #endregion
                #region TriangleParsing
                else if (figure.Name == "Triangle")
                {
                    Single X = 0;
                    Single Y = 0;
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[0].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF lowerLeft = new PointF(X, Y);
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[1].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF top = new PointF(X, Y);
                    foreach (XmlAttribute pointCoordinates in figure.ChildNodes[2].Attributes)
                    {
                        if (pointCoordinates.Name == "X")
                        {
                            X = Single.Parse(pointCoordinates.Value);
                        }
                        else
                        {
                            Y = Single.Parse(pointCoordinates.Value);
                        }
                    }
                    PointF lowerRight = new PointF(X, Y);
                    Color figureColor = Color.Empty;
                    foreach (XmlAttribute figureAttribute in figure.Attributes)
                    {
                        if (figureAttribute.Name == "color")
                            figureColor = Color.FromArgb(new Int32().HexToInt32(figureAttribute.Value));
                    }
                    figures.Add(new UTriangle(lowerLeft, top, lowerRight, figureColor));
                }
                #endregion
            }
        }

        public void Draw(Graphics g)
        {
            foreach(var figure in figures)
            {
                figure.Draw(g);
            }
        }
    }
}
