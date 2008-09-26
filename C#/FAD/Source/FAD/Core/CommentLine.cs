using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public class CommentLine
    {
        public static Color DefaultColor = Color.Black;
        public static Font DefaultFont = new Font("Times New Roman", 12);

        private string text = string.Empty;
        private Color color = DefaultColor;
        private Font font = DefaultFont;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Font Font
        {
            get { return font; }
            set { font = value; }
        }
    }
}
