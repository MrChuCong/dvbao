using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace Core
{
    [Serializable]
    public class Text : IDisposable
    {
        #region Properties

        private Rectangle layout = new Rectangle();

        [Category("Transition Label")]
        [Description("The layout of the label.")]
        public Rectangle Layout
        {
            get { return layout; }
            set { layout = value; }
        }

        private string value = string.Empty;

        [Category("Transition Label")]
        [Description("The text value of the label.")]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private string input = string.Empty;

        [Category("Transition Label")]
        [Description("The input of the transition, separated by commas.")]
        public string Input
        {
            get { return input; }
            set { input = this.value = value; }
        }

        private Font font = new Font("Arial", 10);

        [Category("Transition Label")]
        [Description("The font used to display text value of the label.")]
        [XmlIgnore]
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        [Browsable(false)]
        public XmlFont XmlFont
        {
            get { return new XmlFont(Font); }
            set { Font = value.GetFont(); }
        }

        private Color backColor = Color.White;

        [Category("Transition Label")]
        [DisplayName("Background Color")]
        [Description("The background color of the label.")]
        [XmlIgnore]
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        [Browsable(false)]
        public string XmlBackColor
        {
            get { return XmlColor.SerializeColor(backColor); }
            set { backColor = XmlColor.DeserializeColor(value); }
        }

        private Color foreColor = Color.Blue;

        [Category("Transition Label")]
        [DisplayName("Foreground Color")]
        [Description("The foreground color of the label, which is used to display text value.")]
        [XmlIgnore]
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        [Browsable(false)]
        public string XmlForeColor
        {
            get { return XmlColor.SerializeColor(foreColor); }
            set { foreColor = XmlColor.DeserializeColor(value); }
        }

        private bool locked = false;

        [Category("Transition Label")]
        [Description("Determines if the label is locked.")]
        [XmlIgnore]
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        #endregion

        #region Public methods

        private Text() { }

        public Text(Rectangle layout, string text)
        {
            this.layout = layout;
            this.value = text;
        }

        public bool Contains(Point point)
        {
            return layout.Contains(point);
        }

        #endregion

        #region Graphics methods

        public void Paint(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                graphics.FillRectangle(brush, Layout);
            }
            using (Pen pen = new Pen(Color.Black))
            {
                graphics.DrawRectangle(pen, Layout);
            }
            using (Brush brush = new SolidBrush(ForeColor))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(Value, Font, brush, Layout, format);
                }
            }
        }

        #endregion

        #region Serialization

        public void Serialize(TextWriter output)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Text));
            serializer.Serialize(output, this);
        }

        public static Text Deserialize(TextReader input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Text));
            return serializer.Deserialize(input) as Text;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.font.Dispose();
        }

        #endregion
    }
}
