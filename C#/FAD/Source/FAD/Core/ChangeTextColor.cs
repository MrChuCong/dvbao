using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ChangeTextColor : Command
    {
        private Text text;

        public Text Text
        {
            get { return text; }
            set { text = value; }
        }

        private Color oldColor;

        public Color OldColor
        {
            get { return oldColor; }
            set { oldColor = value; }
        }

        private Color newColor;

        public Color NewColor
        {
            get { return newColor; }
            set { newColor = value; }
        }

        public ChangeTextColor(Text text, Color color)
        {
            this.text = text;
            this.oldColor = text.BackColor;
            this.newColor = color;
        }

        public override void Run()
        {
            Text.BackColor = NewColor;
        }
    }
}
