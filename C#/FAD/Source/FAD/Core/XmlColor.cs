using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public enum ColorFormat
    {
        NamedColor,
        ARGBColor
    }

    public class XmlColor
    {
        public static string SerializeColor(Color color)
        {
            if (color.IsNamedColor) return string.Format("{0}:{1}", ColorFormat.NamedColor, color.Name);
            else return string.Format("{0}:{1}:{2}:{3}:{4}", ColorFormat.ARGBColor,
                color.A, color.R, color.G, color.B);
        }

        public static Color DeserializeColor(string color)
        {
            byte a, r, g, b;
            string[] components = color.Split(new char[] { ':' });
            ColorFormat colorFormat = (ColorFormat)Enum.Parse(typeof(ColorFormat), components[0], true);
            switch (colorFormat)
            {
                case ColorFormat.NamedColor:
                    return Color.FromName(components[1]);
                case ColorFormat.ARGBColor:
                    a = byte.Parse(components[1]);
                    r = byte.Parse(components[2]);
                    g = byte.Parse(components[3]);
                    b = byte.Parse(components[4]);
                    return Color.FromArgb(a, r, g, b);
            }
            return Color.Empty;
        }
    }
}
