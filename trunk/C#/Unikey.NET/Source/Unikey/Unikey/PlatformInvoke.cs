using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Unikey
{
    public class PlatformInvoke
    {
        private PlatformInvoke() { }

        [DllImport("coredll.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("coredll.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
            IntPtr hMod, int dwThreadId);

        [DllImport("coredll.dll")]
        public static extern bool UnhookWindowsHookEx(int hhk);

        [DllImport("coredll.dll")]
        public static extern int CallNextHookEx(int hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("coredll.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("coredll.dll")]
        public static extern void keybd_event(int bVk, int bScan, int dwFlags,
            int dwExtraInfo);
    }
}
