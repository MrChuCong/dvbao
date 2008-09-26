using System;
using System.Collections.Generic;
using System.Text;

namespace Unikey
{
    public class VnCode
    {
        private char markCharacter;

        public char MarkCharacter
        {
            get { return markCharacter; }
        }

        private string unicodeCharacter;

        public string UnicodeCharacter
        {
            get { return unicodeCharacter; }
        }

        public VnCode(char markCharacter, string unicodeCharacter)
        {
            this.markCharacter = markCharacter;
            this.unicodeCharacter = unicodeCharacter;
        }
    }
}
