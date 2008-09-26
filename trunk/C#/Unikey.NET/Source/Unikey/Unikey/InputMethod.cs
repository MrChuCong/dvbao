using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Unikey
{
    public abstract class InputMethod
    {
        private static bool locked = false;
        private static int currentCharacter = 0;

        protected abstract string GetVNChar();
        protected abstract Hashtable GetVietnameseCode();

        public static void Reset()
        {
            locked = false;
            currentCharacter = 0;
        }

        public bool ProcessKeyboardInput(KeyboardInfo keyboardInfo)
        {
            int vkCode = keyboardInfo.vkCode;
            if (locked)
            {
                if (vkCode == 8 || vkCode == 17 || vkCode == 86) return false;
                else locked = false;
            }
            string VNChar = GetVNChar();
            Hashtable VietnameseCode = GetVietnameseCode();
            if (VNChar.IndexOf((char)vkCode) >= 0)
            {
                if (VietnameseCode.ContainsKey((char)currentCharacter))
                {
                    VnCode[] codes = (VnCode[])VietnameseCode[(char)currentCharacter];
                    foreach (VnCode code in codes)
                        if (code.MarkCharacter == vkCode)
                        {
                            locked = true;
                            string unicode = code.UnicodeCharacter;
                            currentCharacter = unicode[unicode.Length - 1];
                            KeyboardInfo.SendKey(Keys.Back);
                            Clipboard.SetDataObject(unicode);
                            KeyboardInfo.SendKeys(new Keys[] {
                                Keys.ControlKey, Keys.V
                            });
                            return true;
                        }
                }
                if ('A' <= vkCode && vkCode <= 'Z')
                {
                    if ((KeyboardInfo.Shift && KeyboardInfo.CapsLock) ||
                        (!KeyboardInfo.Shift && !KeyboardInfo.CapsLock))
                        vkCode += 'a' - 'A';
                }
                currentCharacter = vkCode;
            }
            else currentCharacter = 0;
            return false;
        }
    }
}
