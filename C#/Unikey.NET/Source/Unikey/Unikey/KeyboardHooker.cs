using System;
using System.Collections.Generic;
using System.Text;

namespace Unikey
{
    public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    public delegate bool KeyboardHookedEventHandler(KeyboardInfo keyboardInfo);

    public class KeyboardHooker
    {
        private static KeyboardHooker keyboardHooker = null;
        private int hHook = 0;
        private HookProc keyboardHookerCallback;
        public event KeyboardHookedEventHandler KeyboardHooked;

        private KeyboardHooker()
        {
            keyboardHookerCallback = new HookProc(HookProc);
        }

        public static KeyboardHooker Create()
        {
            if (keyboardHooker == null) keyboardHooker = new KeyboardHooker();
            return keyboardHooker;
        }

        public void Start()
        {
            if (keyboardHooker == null) return;
            Stop();
            KeyboardInfo.ResetCapsLockState();
            InputMethod.Reset();
            hHook = PlatformInvoke.SetWindowsHookEx(20, keyboardHookerCallback,
                PlatformInvoke.GetModuleHandle(null), 0);
        }

        public void Stop()
        {
            if (keyboardHooker == null) return;
            if (hHook != 0) PlatformInvoke.UnhookWindowsHookEx(hHook);
            hHook = 0;
        }

        private int HookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return PlatformInvoke.CallNextHookEx(hHook, nCode, wParam, lParam);
            if (wParam.ToInt32() == 0x0100)
            {
                KBDLLHOOKSTRUCT keyboardInput =
                    KeyboardInfo.GetLowLevelKeyboardInput(lParam);
                KeyboardInfo keyboardInfo = new KeyboardInfo();
                keyboardInfo.vkCode = keyboardInput.vkCode;
                keyboardInfo.scanCode = keyboardInput.scanCode;
                keyboardInfo.flags = keyboardInput.flags;
                keyboardInfo.time = keyboardInput.time;
                if (ProcessKeyboardHooked(keyboardInfo)) return 1;
            }
            return PlatformInvoke.CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        private bool ProcessKeyboardHooked(KeyboardInfo keyboardInfo)
        {
            if (KeyboardHooked != null) return KeyboardHooked(keyboardInfo);
            return false;
        }
    }
}
