using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Core
{
    [Serializable]
    public class PointC
    {
        #region Properties

        private const int radius = 5;

        private Point position = new Point();

        [Category("Point")]
        [Description("The position of the point.")]
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        private bool controlPoint = true;

        [Browsable(false)]
        public bool ControlPoint
        {
            get { return controlPoint; }
            set { controlPoint = value; }
        }

        private State state = null;

        [Browsable(false)]
        [XmlIgnore]
        public State State
        {
            get { return state; }
            set
            {
                if (controlPoint == false)
                {
                    state = value;
                    if (value == null) stateID = -1;
                    else stateID = value.ID;
                }
            }
        }

        private int stateID = -1;

        [Browsable(false)]
        public int StateID
        {
            get { return stateID; }
            set { stateID = value; }
        }

        private bool locked = false;

        [Browsable(false)]
        [XmlIgnore]
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        #endregion

        #region Public methods

        private PointC() { }

        public PointC(int x, int y, bool controlPoint)
        {
            this.position.X = x;
            this.position.Y = y;
            this.controlPoint = controlPoint;
        }

        public bool Contains(Point point)
        {
            return (point.X - position.X) * (point.X - position.X) +
                (point.Y - position.Y) * (point.Y - position.Y) < radius * radius;
        }

        #endregion

        #region Graphics methods

        public void Paint(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(position.X - radius, position.Y - radius, radius * 2, radius * 2);
            Color color;
            if (state == null) color = Color.Red;
            else color = Color.White;
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, rectangle);
            }
            using (Pen pen = new Pen(Color.Black))
            {
                graphics.DrawEllipse(pen, rectangle);
            }
        }

        #endregion

        #region Serialization

        public void Serialize(TextWriter output)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PointC));
            serializer.Serialize(output, this);
        }

        public static PointC Deserialize(TextReader input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PointC));
            return serializer.Deserialize(input) as PointC;
        }

        #endregion
    }
}
