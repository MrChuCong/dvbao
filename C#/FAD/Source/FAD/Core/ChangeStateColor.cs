using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ChangeStateColor : Command
    {
        private State state;

        public State State
        {
            get { return state; }
            set { state = value; }
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

        public ChangeStateColor(State state, Color color)
        {
            this.state = state;
            this.oldColor = state.BackColor;
            this.newColor = color;
        }

        public override void Run()
        {
            State.BackColor = NewColor;
        }
    }
}
