using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class SetComment : Command
    {
        private Comment comment;

        public Comment Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public SetComment(Comment comment, string text)
        {
            this.comment = comment;
            this.text = text;
        }

        public override void Run()
        {
            Comment.SetText(Text);
        }
    }
}
