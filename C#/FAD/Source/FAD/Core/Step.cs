using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Step
    {
        private List<Command> commands = new List<Command>();

        public List<Command> Commands
        {
            get { return commands; }
            set { commands = value; }
        }

        public Step()
        {
            commands.Clear();
        }

        public void Run()
        {
            for (int i = 0; i < Commands.Count; i++) Commands[i].Run();
        }
    }
}
