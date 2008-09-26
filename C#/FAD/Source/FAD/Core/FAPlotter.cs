using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace Core
{
    public enum FAPlotterMode
    {
        State,
        Select
    }

    public partial class FAPlotter : UserControl
    {
        public FAPlotter()
        {
            InitializeComponent();
        }

        #region Members

        public delegate void SelectHandler(Object obj);
        public event SelectHandler SelectEvent;
        private FAPlotterMode currentMode = FAPlotterMode.State;
        private Point currentPoint = new Point();
        private FA currentFA = new FA();
        private Object currentObject = null;
        private Bitmap buffer = null;
        private bool moving = false;
        private State selectedState = null;
        private PointC selectedPoint = null;
        private Text selectedLabel = null;
        private bool showAllControlLines = false;
        private bool lockAllStates = false;
        private bool lockAllTransitions = false;

        #endregion

        #region Menu

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
            currentFA.Dispose();
            currentFA = new FA();
            OnPaint();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckPathExists = true;
            dialog.DefaultExt = "xml";
            dialog.Filter = "XML Files | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder s = new StringBuilder();
                StreamReader fi = new StreamReader(dialog.FileName);
                s.Append(fi.ReadToEnd());
                fi.Close();
                Reset();
                currentFA.Dispose();
                currentFA = FA.Deserialize(new StringReader(s.ToString()));
                currentMode = FAPlotterMode.Select;
                SetMode(btnSelect);
                OnPaint();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = "xml";
            dialog.Filter = "XML Files | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder s = new StringBuilder();
                currentFA.Serialize(new StringWriter(s));
                StreamWriter fo = new StreamWriter(dialog.FileName);
                fo.Write(s.ToString());
                fo.Close();
            }
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            currentMode = FAPlotterMode.State;
            SetMode(btnState);
        }

        private void btnTransition_Click(object sender, EventArgs e)
        {
            currentFA.Transitions.Add(new Transition());
            OnPaint();
            currentMode = FAPlotterMode.Select;
            SetMode(btnSelect);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            currentMode = FAPlotterMode.Select;
            SetMode(btnSelect);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentMode == FAPlotterMode.Select)
            {
                if ((currentObject is State) && (MessageBox.Show("Do you want to delete this state?",
                    "Finite Automata Demonstration", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    State state = (State)currentObject;
                    state.Dispose();
                    currentFA.States.Remove(state);
                }
                if ((currentObject is Transition) && (MessageBox.Show("Do you want to delete this transition?",
                    "Finite Automata Demonstration", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    Transition transition = (Transition)currentObject;
                    transition.Dispose();
                    currentFA.Transitions.Remove(transition);
                }
            }
        }

        private void showAllControlLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAllControlLines = !showAllControlLines;
            showAllControlLinesToolStripMenuItem.Checked = showAllControlLines;
            currentFA.ShowControlLines(showAllControlLines);
            OnPaint();
        }

        private void lockAllObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockAllStates = !lockAllStates;
            lockAllStatesToolStripMenuItem.Checked = lockAllStates;
            currentFA.LockAllStates(lockAllStates);
        }

        private void lockAllTransitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockAllTransitions = !lockAllTransitions;
            lockAllTransitionsToolStripMenuItem.Checked = lockAllTransitions;
            currentFA.LockAllTransitions(lockAllTransitions);
        }

        #endregion

        #region Events

        private void FAPlotter_Load(object sender, EventArgs e)
        {
            SetMode(btnState);
        }

        private void SetMode(ToolStripButton button)
        {
            btnState.Checked = false;
            btnSelect.Checked = false;
            button.Checked = true;
        }

        private void Reset()
        {
            currentMode = FAPlotterMode.State;
            SetMode(btnState);
            currentPoint = new Point();
            currentObject = null;
            moving = false;
            selectedState = null;
            selectedPoint = null;
            selectedLabel = null;
        }

        private void background_Resize(object sender, EventArgs e)
        {
            if (buffer != null) buffer.Dispose();
            buffer = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            OnPaint();
        }

        public void OnPaint()
        {
            if (buffer == null) return;
            using (Graphics graphics = Graphics.FromImage(buffer))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(currentFA.BackColor);
                currentFA.Paint(graphics);
            }
            using (Graphics graphics = background.CreateGraphics())
            {
                graphics.DrawImage(buffer, 0, 0);
            }
        }

        public void ReleaseFA()
        {
            currentFA.Dispose();
        }

        #endregion

        #region Mouse Events

        private void GetMouseEventArgs(MouseEventArgs e)
        {
            currentPoint.X = e.X;
            currentPoint.Y = e.Y;
            currentObject = currentFA.GetObject(currentPoint);
        }

        private void background_MouseClick(object sender, MouseEventArgs e)
        {
            GetMouseEventArgs(e);
            if (currentMode == FAPlotterMode.State) MouseClick_State();
            else MouseClick_Select();
        }

        private void background_MouseDown(object sender, MouseEventArgs e)
        {
            GetMouseEventArgs(e);
            if (currentMode == FAPlotterMode.Select) MouseDown_Select();
        }

        private void background_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void background_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                GetMouseEventArgs(e);
                if (currentMode == FAPlotterMode.Select) MouseMove_Select();
            }
        }

        private void MouseClick_State()
        {
            if (currentObject == null)
            {
                State state = new State(currentPoint, currentFA);
                currentFA.States.Add(state);
                OnPaint();
                if (SelectEvent != null) SelectEvent(state);
            }
        }

        private void MouseClick_Select()
        {
            if (SelectEvent != null)
            {
                if (currentObject == null) SelectEvent(currentFA);
                else SelectEvent(currentObject);
            }
        }

        private void MouseDown_Select()
        {
            selectedState = null;
            selectedPoint = null;
            selectedLabel = null;
            if (currentObject is State)
            {
                selectedState = (State)currentObject;
                if (SelectEvent != null) SelectEvent(selectedState);
                moving = true;
                return;
            }
            if (currentObject is PointC)
            {
                selectedPoint = (PointC)currentObject;
                if (SelectEvent != null) SelectEvent(selectedPoint);
                moving = true;
                return;
            }
            if (currentObject is Text)
            {
                selectedLabel = (Text)currentObject;
                if (SelectEvent != null) SelectEvent(selectedLabel);
                moving = true;
                return;
            }
        }

        private void MouseMove_Select()
        {
            if ((selectedState != null) && (!selectedState.Locked))
            {
                int dx = currentPoint.X - selectedState.Position.X;
                int dy = currentPoint.Y - selectedState.Position.Y;
                selectedState.Position = currentPoint;
                currentFA.UpdateTransitionPoints(selectedState, dx, dy);
                OnPaint();
                return;
            }
            if ((selectedPoint != null) && (!selectedPoint.Locked))
            {
                if ((currentObject is State == false) || (selectedPoint.ControlPoint == true))
                {
                    selectedPoint.Position = currentPoint;
                    selectedPoint.State = null;
                    OnPaint();
                }
                else
                {
                    State state = (State)currentObject;
                    if (state.Accept(currentPoint))
                        selectedPoint.State = state;
                    else selectedPoint.State = null;
                    OnPaint();
                }
                return;
            }
            if ((selectedLabel != null) && (!selectedLabel.Locked))
            {
                int width = selectedLabel.Layout.Width;
                int height = selectedLabel.Layout.Height;
                selectedLabel.Layout = new Rectangle(currentPoint.X - width / 2, currentPoint.Y - height / 2,
                    width, height);
                OnPaint();
                return;
            }
        }

        #endregion

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (CheckFA())
            {
                FormInput input = new FormInput();
                if (input.ShowDialog() == DialogResult.OK)
                {
                    FormFADPlayer form = new FormFADPlayer();
                    form.SetFA(currentFA);
                    form.SetInput(input.Input);
                    form.ShowDialog();
                }
            }
        }

        private bool CheckFA()
        {
            if (currentFA.Description.Length == 0)
            {
                MessageBox.Show("The automata must have a description.", "Finite Automata Demonstration");
                return false;
            }
            foreach (State state in currentFA.States)
                if (state.Label.Length == 0)
                {
                    MessageBox.Show("Some states don't have the label.", "Finite Automata Demonstration");
                    return false;
                }
            foreach (Transition transition in currentFA.Transitions)
                if (transition.Input.Length == 0)
                {
                    MessageBox.Show("Some transitions don't have the input.", "Finite Automata Demonstration");
                    return false;
                }
            if (!HasStartState())
            {
                MessageBox.Show("The automata must have a start state.", "Finite Automata Demonstration");
                return false;
            }
            if (!HasFinalState())
            {
                MessageBox.Show("The automata must have at least one final state.", "Finite Automata Demonstration");
                return false;
            }
            return true;
        }

        private bool HasFinalState()
        {
            foreach (State state in currentFA.States)
                if (state.IsFinalState) return true;
            return false;
        }

        private bool HasStartState()
        {
            foreach (State state in currentFA.States)
                if (state.IsStartState) return true;
            return false;
        }
    }
}
