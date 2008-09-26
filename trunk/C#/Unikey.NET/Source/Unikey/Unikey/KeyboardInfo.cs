using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Unikey
{
    public struct KBDLLHOOKSTRUCT
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    public class KeyboardInfo
    {
        public const int KEYEVENTF_KEYUP = 0x0002;
        public const int KEYEVENTF_SILENT = 0x0004;

        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;

        private static bool capsLock;

        public static KBDLLHOOKSTRUCT GetLowLevelKeyboardInput(IntPtr lParam)
        {
            return (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam,
                typeof(KBDLLHOOKSTRUCT));
        }

        public static bool Control
        {
            get
            {
                return Convert.ToBoolean(PlatformInvoke.GetAsyncKeyState(0x11) & 0x8000);
            }
        }

        public static bool Shift
        {
            get
            {
                return Convert.ToBoolean(PlatformInvoke.GetAsyncKeyState(0x10) & 0x8000);
            }
        }

        public static bool CapsLock
        {
            get
            {
                return capsLock;
            }
        }

        public static void ResetCapsLockState()
        {
            capsLock = Convert.ToBoolean(PlatformInvoke.GetAsyncKeyState(0x14) & 0x8000);
        }

        public static void ChangeCapsLockState()
        {
            capsLock = !capsLock;
        }

        public static void SendKey(Keys key)
        {
            PlatformInvoke.keybd_event((int)key, 0, KEYEVENTF_SILENT, 0);
            PlatformInvoke.keybd_event((int)key, 0, KEYEVENTF_KEYUP | KEYEVENTF_SILENT, 0);
        }

        public static void SendKeys(Keys[] keys)
        {
            for (int i = 0; i < keys.Length; i++)
                PlatformInvoke.keybd_event((int)keys[i], 0, KEYEVENTF_SILENT, 0);
            for (int i = 0; i < keys.Length; i++)
                PlatformInvoke.keybd_event((int)keys[keys.Length - 1 - i], 0,
                    KEYEVENTF_KEYUP | KEYEVENTF_SILENT, 0);
        }
    }
}
