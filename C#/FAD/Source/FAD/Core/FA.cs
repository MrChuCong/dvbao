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
    public class FA : IDisposable
    {
        #region Properties

        public enum FAType
        {
            DFA = 0,
            NFA = 1
        }

        private List<State> states = new List<State>();

        [Browsable(false)]
        public List<State> States
        {
            get { return states; }
            set { states = value; }
        }

        private List<Transition> transitions = new List<Transition>();

        [Browsable(false)]
        public List<Transition> Transitions
        {
            get { return transitions; }
            set { transitions = value; }
        }

        private Color backColor = Color.White;

        [Category("Finite Automata")]
        [DisplayName("Background Color")]
        [Description("The background color of the automata.")]
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

        private Color queueColor = Color.Violet;

        [Category("Finite Automata")]
        [DisplayName("Queue Color")]
        [Description("The background color of the state in the queue.")]
        [XmlIgnore]
        public Color QueueColor
        {
            get { return queueColor; }
            set { queueColor = value; }
        }

        [Browsable(false)]
        public string XmlQueueColor
        {
            get { return XmlColor.SerializeColor(queueColor); }
            set { queueColor = XmlColor.DeserializeColor(value); }
        }

        private Color currentStateColor = Color.Sienna;

        [Category("Finite Automata")]
        [DisplayName("Current State Color")]
        [Description("The background color of the current state.")]
        [XmlIgnore]
        public Color CurrentStateColor
        {
            get { return currentStateColor; }
            set { currentStateColor = value; }
        }

        [Browsable(false)]
        public string XmlCurrentStateColor
        {
            get { return XmlColor.SerializeColor(currentStateColor); }
            set { currentStateColor = XmlColor.DeserializeColor(value); }
        }

        private Color currentTransitionColor = Color.Yellow;

        [Category("Finite Automata")]
        [DisplayName("Current Transition Color")]
        [Description("The background color of the current transition.")]
        [XmlIgnore]
        public Color CurrentTransitionColor
        {
            get { return currentTransitionColor; }
            set { currentTransitionColor = value; }
        }

        [Browsable(false)]
        public string XmlCurrentTransitionColor
        {
            get { return XmlColor.SerializeColor(currentTransitionColor); }
            set { currentTransitionColor = XmlColor.DeserializeColor(value); }
        }

        private Color visitColor = Color.Blue;

        [Category("Finite Automata")]
        [DisplayName("Visit Color")]
        [Description("The background color of the visited state.")]
        [XmlIgnore]
        public Color VisitColor
        {
            get { return visitColor; }
            set { visitColor = value; }
        }

        [Browsable(false)]
        public string XmlVisitColor
        {
            get { return XmlColor.SerializeColor(visitColor); }
            set { visitColor = XmlColor.DeserializeColor(value); }
        }

        private string description = string.Empty;

        [Category("Finite Automata")]
        [Description("The description of the automata.")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string inputSymbol = "∑ = {}";

        [Category("Finite Automata")]
        [DisplayName("Input Symbol")]
        [Description("The input symbol of the automata.")]
        public string InputSymbol
        {
            get { return inputSymbol; }
            set { inputSymbol = value; }
        }

        private FAType type = FAType.NFA;

        [Category("Finite Automata")]
        [Description("The type of the automata (NFA or DFA).")]
        public FAType Type
        {
            get { return type; }
            set { type = value; }
        }

        private int autoplayTime = 1000;

        [Category("Finite Automata")]
        [DisplayName("Autoplay Time")]
        [Description("The autoplay time in milliseconds of the automata.")]
        public int AutoplayTime
        {
            get { return autoplayTime; }
            set { autoplayTime = value; }
        }

        #endregion

        #region Public methods

        public FA()
        {
            states.Clear();
            transitions.Clear();
        }

        public Object GetObject(Point point)
        {
            foreach (State state in states)
                if (state.Contains(point)) return state;
            foreach (Transition transition in transitions)
                if (transition.ShowControlLines)
                {
                    if (transition.StartPoint.Contains(point)) return transition.StartPoint;
                    if (!transition.Straight && transition.FirstControlPoint.Contains(point))
                        return transition.FirstControlPoint;
                    if (!transition.Straight && transition.SecondControlPoint.Contains(point))
                        return transition.SecondControlPoint;
                    if (transition.EndPoint.Contains(point)) return transition.EndPoint;
                }
            foreach (Transition transition in transitions)
            {
                if (transition.Label.Contains(point)) return transition.Label;
                if (transition.Contains(point)) return transition;
            }
            return null;
        }

        public void UpdateTransitionPoints(State state, int dx, int dy)
        {
            foreach (Transition transition in transitions)
            {
                if (transition.StartPoint.State == state)
                {
                    Point point = new Point(transition.StartPoint.Position.X + dx,
                        transition.StartPoint.Position.Y + dy);
                    transition.StartPoint.Position = point;
                }
                if (transition.EndPoint.State == state)
                {
                    Point point = new Point(transition.EndPoint.Position.X + dx,
                        transition.EndPoint.Position.Y + dy);
                    transition.EndPoint.Position = point;
                }
            }
        }

        public void ShowControlLines(bool showAllControlLines)
        {
            foreach (Transition transition in transitions)
                transition.ShowControlLines = showAllControlLines;
        }

        public void LockAllStates(bool lockAllStates)
        {
            foreach (State state in states) state.Locked = lockAllStates;
        }

        public void LockAllTransitions(bool lockAllTransitions)
        {
            foreach (Transition transition in transitions) transition.Locked = lockAllTransitions;
        }

        #endregion

        #region Graphics methods

        public void Paint(Graphics graphics)
        {
            foreach (Transition transition in transitions) transition.Paint(graphics);
            foreach (State state in states) state.Paint(graphics);
            foreach (Transition transition in transitions)
                if (transition.ShowControlLines) transition.PaintControlLine(graphics);
        }

        #endregion

        #region Serialization

        public void Serialize(TextWriter output)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FA),
                new Type[] { typeof(State), typeof(Transition) });
            serializer.Serialize(output, this);
        }

        public static FA Deserialize(TextReader input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FA),
                new Type[] { typeof(State), typeof(Transition) });
            FA result = serializer.Deserialize(input) as FA;
            result.Refresh();
            return result;
        }

        private void Refresh()
        {
            foreach (State state in states) state.FA = this;
            foreach (State state in states)
                foreach (Transition transition in transitions)
                {
                    if (transition.StartPoint.StateID == state.ID) transition.StartPoint.State = state;
                    if (transition.EndPoint.StateID == state.ID) transition.EndPoint.State = state;
                }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            foreach (State state in states) state.Dispose();
            foreach (Transition transition in transitions) transition.Dispose();
        }

        #endregion
    }
}
