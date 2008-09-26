using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public struct XmlFont
    {
        public string FontFamily;
        public GraphicsUnit GraphicsUnit;
        public float Size;
        public FontStyle Style;

        public XmlFont(Font font)
        {
            this.FontFamily = font.FontFamily.Name;
            this.GraphicsUnit = font.Unit;
            this.Size = font.Size;
            this.Style = font.Style;
        }

        public Font GetFont()
        {
            return new Font(FontFamily, Size, Style, GraphicsUnit);
        }
    }
}
