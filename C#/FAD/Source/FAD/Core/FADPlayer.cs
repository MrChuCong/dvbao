using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Core
{
    public partial class FADPlayer : UserControl
    {
        private RichTextBox textbox = new RichTextBox();
        private Bitmap buffer = null;
        private List<Step> steps = new List<Step>();
        private Queue<State> queue = new Queue<State>();
        private Step resetStep = new Step();
        private int currentStep = 0;
        private Color textColor;
        private Color hightlightColor;
        private Font textFont;
        private Font hightlightFont;
        private int index;
        private bool finish;

        private FA fa = null;

        public FA FA
        {
            get { return fa; }
            set
            {
                fa = value;
                if (fa != null)
                {
                    fa.ShowControlLines(false);
                    fa.LockAllStates(true);
                    fa.LockAllTransitions(true);
                }
            }
        }

        private string input;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public FADPlayer()
        {
            InitializeComponent();
            textColor = Color.Black;
            hightlightColor = Color.Red;
            textFont = new Font("Times New Roman", 12);
            hightlightFont = new Font("Times New Roman", 16, FontStyle.Bold);
        }

        private void FADPlayer_Load(object sender, EventArgs e)
        {
            if (FA != null)
            {
                textbox.Clear();
                AppendInput(-1);
                comment.SetText(textbox.Rtf);
                timer.Interval = FA.AutoplayTime;
                timer.Enabled = false;
                GenerateResetStep();
                GenerateScript();
            }
            btnPrevious.Enabled = false;
        }

        private void GenerateResetStep()
        {
            foreach (State state in FA.States)
                resetStep.Commands.Add(new ChangeStateColor(state, state.BackColor));
            foreach (Transition transition in FA.Transitions)
                resetStep.Commands.Add(new ChangeTextColor(transition.Label, transition.Label.BackColor));
            textbox.Clear();
            AppendInput(-1);
            resetStep.Commands.Add(new SetComment(comment, textbox.Rtf));
        }

        private void GenerateScript()
        {
            steps.Clear();
            queue.Clear();
            finish = false;
            foreach (State state in FA.States)
                if (state.IsStartState)
                {
                    Step step = new Step();
                    queue.Enqueue(state);
                    step.Commands.Add(new SetComment(comment, EnqueueStartStateComment(state)));
                    step.Commands.Add(new ChangeStateColor(state, FA.QueueColor));
                    steps.Add(step);
                    for (index = 0; index < Input.Length; index++)
                    {
                        step = new Step();
                        step.Commands.Add(new SetComment(comment, ProcessInputSymbol(index)));
                        steps.Add(step);
                        Visit(Input[index].ToString());
                        if (finish) return;
                    }
                    while (queue.Count > 0)
                    {
                        State finalState = queue.Dequeue();
                        if (finalState.IsFinalState)
                        {
                            step = new Step();
                            step.Commands.Add(new SetComment(comment, AcceptState(finalState)));
                            steps.Add(step);
                            return;
                        }
                    }
                    step = new Step();
                    step.Commands.Add(new SetComment(comment, NotAcceptState()));
                    steps.Add(step);
                }
        }

        private void Visit(string symbol)
        {
            List<State> visitedState = new List<State>();
            visitedState.Clear();
            Step step;
            while (queue.Count > 0)
            {
                State state = queue.Dequeue();
                Color stateColor;
                if (visitedState.Contains(state)) stateColor = FA.VisitColor;
                else stateColor = state.BackColor;
                step = new Step();
                step.Commands.Add(new SetComment(comment, DequeueState(state)));
                step.Commands.Add(new ChangeStateColor(state, FA.CurrentStateColor));
                steps.Add(step);
                foreach (Transition transition in FA.Transitions)
                    if ((transition.StartPoint.State == state) &&
                        (transition.EndPoint.State != null) &&
                        (transition.Input.Contains(symbol)))
                    {
                        step = new Step();
                        if (!visitedState.Contains(transition.EndPoint.State))
                            visitedState.Add(transition.EndPoint.State);                        
                        step.Commands.Add(new ChangeTextColor(transition.Label, FA.CurrentTransitionColor));
                        if (FA.Type == FA.FAType.NFA)
                        {
                            step.Commands.Add(new ChangeStateColor(transition.EndPoint.State, FA.VisitColor));
                            step.Commands.Add(new SetComment(comment, VisitState(state, transition.EndPoint.State)));
                        }
                        else
                        {
                            step.Commands.Add(new ChangeStateColor(transition.EndPoint.State, FA.QueueColor));
                            step.Commands.Add(new SetComment(comment, VisitAndEnqueueState(state, transition.EndPoint.State)));
                            step.Commands.Add(new ChangeStateColor(state, stateColor));
                        }
                        steps.Add(step);
                        if (FA.Type == FA.FAType.DFA) break;
                    }
                step = new Step();
                foreach (Transition transition in FA.Transitions)
                    if ((transition.StartPoint.State == state) &&
                        (transition.EndPoint.State != null) &&
                        (transition.Input.Contains(symbol)))
                        step.Commands.Add(new ChangeTextColor(transition.Label, transition.Label.BackColor));
                if (FA.Type == FA.FAType.NFA)
                {
                    step.Commands.Add(new SetComment(comment, FinishProcessState(state)));
                    step.Commands.Add(new ChangeStateColor(state, stateColor));
                    steps.Add(step);
                }
                else
                {
                    step.Commands.Add(new SetComment(comment, FinishProcessInputSymbolDFA()));
                    steps.Add(step);
                }
            }
            if (FA.Type == FA.FAType.NFA)
            {
                step = new Step();
                step.Commands.Add(new SetComment(comment, FinishProcessInputSymbolNFA()));
                foreach (State state in visitedState)
                {
                    queue.Enqueue(state);
                    step.Commands.Add(new ChangeStateColor(state, FA.QueueColor));
                }
                steps.Add(step);
            }
            else
                if (visitedState.Count > 0) queue.Enqueue(visitedState[0]);
            if (queue.Count == 0)
            {
                step = new Step();
                step.Commands.Add(new SetComment(comment, EmptyQueue()));
                steps.Add(step);
                finish = true;
            }
        }

        private string FinishProcessInputSymbolDFA()
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Finish the processing of the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string FinishProcessInputSymbolNFA()
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Finish the processing of the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Enqueue all recently visited state.");
            return textbox.Rtf;
        }

        private string VisitAndEnqueueState(State state, State visitedState)
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Enqueue and process the state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Visit and enqueue the state ");
            AppendHightlightText(visitedState.Label);
            if (visitedState.Description.Length != 0) AppendHightlightText(" (" + visitedState.Description + ")");
            AppendNormalText(" with the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string NotAcceptState()
        {
            textbox.Clear();
            AppendInput(index - 1);
            AppendNormalText("Each state in queue is not a final state, so the input string ");
            AppendHightlightText(Input);
            AppendNormalText(" is");
            AppendHightlightText(" NOT ACCEPTED");
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string AcceptState(State state)
        {
            textbox.Clear();
            AppendInput(index-1);
            AppendNormalText("The state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText(" in queue is a final state, so the input string ");
            AppendHightlightText(Input);
            AppendNormalText(" is");
            AppendHightlightText(" ACCEPTED");
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string EmptyQueue()
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("There's no state in the queue, so the input string ");
            AppendHightlightText(Input);
            AppendNormalText(" is");
            AppendHightlightText(" NOT ACCEPTED");
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string FinishProcessState(State state)
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Enqueue and process the state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Finish the processing of the state ");
            AppendHightlightText(state.Label);
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string VisitState(State state, State visitedState)
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Enqueue and process the state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Visit the state ");
            AppendHightlightText(visitedState.Label);
            if (visitedState.Description.Length != 0) AppendHightlightText(" (" + visitedState.Description + ")");
            AppendNormalText(" with the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string DequeueState(State state)
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText("." + Environment.NewLine + Environment.NewLine);
            AppendNormalText("Dequeue and process the state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string EnqueueStartStateComment(State state)
        {
            textbox.Clear();
            AppendInput(-1);
            AppendNormalText("Enqueue the start state ");
            AppendHightlightText(state.Label);
            if (state.Description.Length != 0) AppendHightlightText(" (" + state.Description + ")");
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private string ProcessInputSymbol(int index)
        {
            textbox.Clear();
            AppendInput(index);
            AppendNormalText("Process the input symbol ");
            AppendHightlightText(Input[index].ToString());
            AppendNormalText(".");
            return textbox.Rtf;
        }

        private void AppendInput(int index)
        {
            textbox.SelectionFont = hightlightFont;
            textbox.AppendText(FA.Description + Environment.NewLine + Environment.NewLine);
            textbox.SelectionFont = hightlightFont;
            textbox.AppendText(FA.InputSymbol + Environment.NewLine + Environment.NewLine);
            textbox.SelectionFont = textFont;
            AppendNormalText("Input string: ");
            textbox.SelectionColor = textColor;
            textbox.SelectionFont = hightlightFont;
            if (index < 0) textbox.AppendText(Input + Environment.NewLine + Environment.NewLine);
            else
            {
                textbox.AppendText(Input.Substring(0, index));
                textbox.SelectionColor = hightlightColor;
                textbox.AppendText(Input[index].ToString());
                textbox.SelectionColor = textColor;
                textbox.AppendText(Input.Substring(index + 1) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void AppendNormalText(string text)
        {
            textbox.SelectionColor = textColor;
            textbox.SelectionFont = textFont;
            textbox.AppendText(text);
        }

        private void AppendHightlightText(string text)
        {
            textbox.SelectionColor = hightlightColor;
            textbox.SelectionFont = hightlightFont;
            textbox.AppendText(text);
        }

        private void OnPaint()
        {
            if (buffer == null) return;
            if (fa != null)
            {
                using (Graphics graphics = Graphics.FromImage(buffer))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(fa.BackColor);
                    fa.Paint(graphics);
                }
                using (Graphics graphics = background.CreateGraphics())
                {
                    graphics.DrawImage(buffer, 0, 0);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            steps[currentStep].Run();
            currentStep++;
            OnPaint();
            btnNext.Enabled = currentStep < steps.Count;
            btnPrevious.Enabled = currentStep > 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Reset();
            currentStep--;
            for (int i = 0; i < currentStep; i++) steps[i].Run();
            OnPaint();
            btnNext.Enabled = currentStep < steps.Count;
            btnPrevious.Enabled = currentStep > 0;
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            OnPaint();
        }

        private void background_Resize(object sender, EventArgs e)
        {
            if (buffer != null) buffer.Dispose();
            buffer = new Bitmap(background.Width, background.Height, PixelFormat.Format24bppRgb);
        }

        public void Reset()
        {
            resetStep.Run();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            currentStep = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            timer.Enabled = false;
            OnPaint();            
        }

        private void btnAutoplay_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            if (timer.Enabled)
            {
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnNext.Enabled = currentStep < steps.Count;
                btnPrevious.Enabled = currentStep > 0;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            steps[currentStep].Run();
            currentStep++;
            OnPaint();
            if (currentStep == steps.Count)
            {
                timer.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
        }
    }
}
