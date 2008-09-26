using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Core
{
    [Serializable]
    public class Transition : IDisposable
    {
        #region Properties

        private PointC startPoint;

        [Browsable(false)]
        public PointC StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        private PointC firstControlPoint;

        [Browsable(false)]
        public PointC FirstControlPoint
        {
            get { return firstControlPoint; }
            set { firstControlPoint = value; }
        }

        private PointC secondControlPoint;

        [Browsable(false)]
        public PointC SecondControlPoint
        {
            get { return secondControlPoint; }
            set { secondControlPoint = value; }
        }

        private PointC endPoint;

        [Browsable(false)]
        public PointC EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        private bool showControlLines;

        [Category("Transition")]
        [DisplayName("Show Control Lines")]
        [Description("Specifies whether the transition will show its control lines.")]
        public bool ShowControlLines
        {
            get { return showControlLines; }
            set { showControlLines = value; }
        }

        private int arrowSize;

        [Category("Transition")]
        [DisplayName("Arrow Size")]
        [Description("The arrow size of the transition.")]
        public int ArrowSize
        {
            get { return arrowSize; }
            set { arrowSize = value; }
        }

        [Category("Transition")]
        [DisplayName("Label")]
        [Description("The label of the transition.")]
        [XmlIgnore]
        public string LabelText
        {
            get { return Label.Value; }
            set { Label.Value = value; }
        }

        private Text label;

        [Browsable(false)]
        public Text Label
        {
            get { return label; }
            set { label = value; }
        }

        [Category("Transition")]
        [Description("The input of the transition, separated by commas.")]
        [XmlIgnore]
        public string Input
        {
            get { return Label.Input; }
            set { Label.Input = value; }
        }

        private bool straight;

        [Category("Transition")]
        [Description("Determines if the transition is straight.")]
        public bool Straight
        {
            get { return straight; }
            set { straight = value; }
        }

        private bool locked = false;

        [Category("Transition")]
        [Description("Determines if the transition is locked.")]
        [XmlIgnore]
        public bool Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                StartPoint.Locked = FirstControlPoint.Locked = value;
                SecondControlPoint.Locked = EndPoint.Locked = value;
                Label.Locked = value;
            }
        }

        #endregion

        #region Public methods

        public Transition()
        {
            this.startPoint = new PointC(10, 10, false);
            this.endPoint = new PointC(110, 10, false);
            this.firstControlPoint = new PointC(30, 50, true);
            this.secondControlPoint = new PointC(90, 50, true);
            this.showControlLines = true;
            this.straight = false;
            this.arrowSize = 8;
            this.label = new Text(new Rectangle(40, 10, 40, 20), string.Empty);
        }

        public bool Contains(Point point)
        {
            int size = ArrowSize * 2;
            Rectangle rectangle = new Rectangle(EndPoint.Position.X - size, EndPoint.Position.Y - size,
                size * 2, size * 2);
            return rectangle.Contains(point);
        }

        #endregion

        #region Graphics methods

        public void Paint(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black))
            {
                if (Straight)
                {
                    graphics.DrawLine(pen, StartPoint.Position, EndPoint.Position);
                }
                else
                {
                    graphics.DrawBezier(pen,
                        StartPoint.Position,
                        FirstControlPoint.Position,
                        SecondControlPoint.Position,
                        EndPoint.Position);
                }
            }
            PaintArrow(graphics);
            Label.Paint(graphics);
        }

        private void PaintArrow(Graphics graphics)
        {
            PointC point;
            if (Straight) point = StartPoint;
            else point = SecondControlPoint;
            float dx = Math.Abs(EndPoint.Position.X - point.Position.X);
            float dy = Math.Abs(EndPoint.Position.Y - point.Position.Y);
            float d = (float)Math.Sqrt(dx * dx + dy * dy);
            if (d == 0) return;
            float angle = (float)(Math.Acos(dy / d) * 180 / Math.PI);
            if (EndPoint.Position.X < point.Position.X) angle = 360 - angle;
            if (EndPoint.Position.Y > point.Position.Y) angle = 180 - angle;
            Brush brush = new SolidBrush(Color.Black);
            GraphicsState graphicsState = graphics.Save();
            graphics.TranslateTransform(EndPoint.Position.X, EndPoint.Position.Y);
            graphics.RotateTransform(angle);
            Point[] points = new Point[4] {
                new Point(0, 0),
                new Point(-ArrowSize, 2 * ArrowSize),
                new Point(0, ArrowSize),
                new Point(ArrowSize, 2 * ArrowSize)
            };
            graphics.FillPolygon(brush, points);
            graphics.Restore(graphicsState);
            brush.Dispose();
        }

        public void PaintControlLine(Graphics graphics)
        {
            if (!Straight)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.Dash;
                    graphics.DrawLine(pen, StartPoint.Position, FirstControlPoint.Position);
                    graphics.DrawLine(pen, EndPoint.Position, SecondControlPoint.Position);
                }
            }
            StartPoint.Paint(graphics);
            if (!Straight)
            {
                FirstControlPoint.Paint(graphics);
                SecondControlPoint.Paint(graphics);
            }
            EndPoint.Paint(graphics);
        }

        #endregion

        #region Serialization

        public void Serialize(TextWriter output)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Transition),
                new Type[] { typeof(Text), typeof(PointC) });
            serializer.Serialize(output, this);
        }

        public static Transition Deserialize(TextReader input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Transition),
                new Type[] { typeof(Text), typeof(PointC) });
            return serializer.Deserialize(input) as Transition;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.label.Dispose();
        }

        #endregion
    }
}
