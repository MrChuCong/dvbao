using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace Core
{
    [Serializable]
    public class State : IDisposable
    {
        #region Properties

        private const int FinalSize = 6;
        private static int count = 0;

        private int id = count++;

        [Browsable(false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private Point position = new Point();

        [Category("State")]
        [Description("The position of the state.")]
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        private string description = string.Empty;

        [Category("State")]
        [Description("The description of the state.")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int radius = 20;

        [Category("State")]
        [Description("The radius of the state.")]
        public int Radius
        {
            get { return radius; }
            set
            {
                if (FA != null)
                {
                    foreach (Transition transition in FA.Transitions)
                    {
                        if (transition.StartPoint.State == this) transition.StartPoint.State = null;
                        if (transition.EndPoint.State == this) transition.EndPoint.State = null;
                    }
                }
                radius = value;
            }
        }

        private Color backColor = Color.CadetBlue;

        [Category("State")]
        [DisplayName("Background Color")]
        [Description("The background color of the state.")]
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

        private Color foreColor = Color.Black;

        [Category("State")]
        [DisplayName("Foreground Color")]
        [Description("The foreground color of the state, which is used to display label.")]
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

        private Font font = new Font("Times New Roman", 20, FontStyle.Bold);

        [Category("State")]
        [Description("The font used to display label of the state.")]
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

        private string label = string.Empty;

        [Category("State")]
        [Description("The label of the state.")]
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        private FA fA = null;

        [Browsable(false)]
        [XmlIgnore]
        public FA FA
        {
            get { return fA; }
            set { fA = value; }
        }

        private bool isStartState = false;

        [Category("State")]
        [DisplayName("Is Start State")]
        [Description("Determines if the state is a start state.")]
        public bool IsStartState
        {
            get { return isStartState; }
            set
            {
                if (value && (FA != null))
                {
                    foreach (State state in FA.States)
                        state.IsStartState = false;
                }
                isStartState = value;
            }
        }

        private bool isFinalState = false;

        [Category("State")]
        [DisplayName("Is Final State")]
        [Description("Determines if the state is a final state.")]
        public bool IsFinalState
        {
            get { return isFinalState; }
            set
            {
                if (FA != null)
                {
                    if (!isFinalState && value) radius += FinalSize;
                    if (isFinalState && !value) radius -= FinalSize;
                }
                isFinalState = value;
            }
        }

        private bool locked = false;

        [Category("State")]
        [Description("Determines if the state is locked.")]
        [XmlIgnore]
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        #endregion

        #region Public methods

        private State() { }

        public State(Point point, FA fA)
        {
            this.position = point;
            this.fA = fA;
        }

        public bool Contains(Point point)
        {
            return (point.X - Position.X) * (point.X - Position.X) +
                (point.Y - Position.Y) * (point.Y - Position.Y) < Radius * Radius;
        }

        public bool Accept(Point point)
        {
            return (point.X - Position.X) * (point.X - Position.X) +
                (point.Y - Position.Y) * (point.Y - Position.Y) < (Radius * Radius) / 2;
        }

        #endregion

        #region Graphics methods

        public void Paint(Graphics graphics)
        {
            if (IsFinalState) radius -= FinalSize;
            Rectangle rectangle = new Rectangle(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rectangle);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterPoint = new Point(Position.X - Radius / 2, Position.Y - Radius / 2);
            brush.CenterColor = Color.White;
            brush.SurroundColors = new Color[1] { BackColor };
            graphics.FillEllipse(brush, rectangle);
            brush.Dispose();
            Pen pen = new Pen(BackColor, 2);
            graphics.DrawEllipse(pen, rectangle);
            pen.Dispose();
            using (Brush solidBrush = new SolidBrush(ForeColor))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(Label, Font, solidBrush, rectangle, format);
                }
            }
            if (IsFinalState)
            {
                radius += FinalSize;
                pen = new Pen(Color.Black, 1);
                graphics.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
                pen.Dispose();
            }
            if (IsStartState) PaintStartState(graphics);
        }

        private void PaintStartState(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.DrawLine(pen, Position.X - Radius - 50, position.Y, Position.X - Radius, Position.Y);
            }
            Point[] points = new Point[3] {
                new Point(Position.X-Radius, Position.Y),
                new Point(Position.X-Radius - 10, Position.Y - 8),
                new Point(Position.X-Radius - 10, Position.Y + 8)
            };
            using (Brush brush = new SolidBrush(Color.Black))
            {
                graphics.FillPolygon(brush, points);
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    using (Font font = new Font("Times New Roman", 12, FontStyle.Bold))
                    {
                        graphics.DrawString("start", font, brush, Position.X - Radius - 50, position.Y - 20);
                    }
                }
            }
        }

        #endregion

        #region Serialization

        public void Serialize(TextWriter output)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(State));
            serializer.Serialize(output, this);
        }

        public static State Deserialize(TextReader input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(State));
            return serializer.Deserialize(input) as State;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.font.Dispose();
            if (FA != null)
            {
                foreach (Transition transition in FA.Transitions)
                {
                    if (transition.StartPoint.State == this) transition.StartPoint.State = null;
                    if (transition.EndPoint.State == this) transition.EndPoint.State = null;
                }
            }
        }

        #endregion
    }
}
