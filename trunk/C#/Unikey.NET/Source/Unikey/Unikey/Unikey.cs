using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Unikey
{
    public class Unikey
    {
        private static Unikey unikey = null;
        private KeyboardHooker keyboardHooker;
        private InputMethod inputMethod = null;
        private bool started = true;
        private FormUnikey form = null;
        private bool switchKey;
        private bool activateKey;

        public InputMethod InputMethod
        {
            get { return inputMethod; }
            set { inputMethod = value; }
        }

        public bool SwitchKey
        {
            get { return switchKey; }
            set { switchKey = value; }
        }

        public bool ActivateKey
        {
            get { return activateKey; }
            set { activateKey = value; }
        }

        private Unikey(FormUnikey form)
        {
            this.form = form;
            CheckStarted();
            keyboardHooker = KeyboardHooker.Create();
            keyboardHooker.Start();
            keyboardHooker.KeyboardHooked +=
                new KeyboardHookedEventHandler(keyboardHooker_KeyboardHooked);
        }

        private bool keyboardHooker_KeyboardHooked(KeyboardInfo keyboardInfo)
        {
            int vkCode = keyboardInfo.vkCode;
            if (SwitchKey && vkCode == 83 && KeyboardInfo.Control && KeyboardInfo.Shift)
            {
                started = !started;
                CheckStarted();
                return false;
            }
            if (ActivateKey && vkCode == 85 && KeyboardInfo.Control && KeyboardInfo.Shift)
            {
                form.Activate();
                return false;
            }
            if (!started) return false;
            if (vkCode == 0x14)
            {
                KeyboardInfo.ChangeCapsLockState();
                return false;
            }
            if (InputMethod != null)
                return InputMethod.ProcessKeyboardInput(keyboardInfo);
            return false;
        }

        public static Unikey Create(FormUnikey form)
        {
            if (unikey == null) unikey = new Unikey(form);
            return unikey;
        }

        public void Dispose()
        {
            keyboardHooker.Stop();
        }

        public void Start()
        {
            KeyboardInfo.ResetCapsLockState();
            InputMethod.Reset();
            started = true;
            CheckStarted();
        }

        public void Stop()
        {
            started = false;
            CheckStarted();
        }

        private void CheckStarted()
        {
            form.btnStart.Enabled = !started;
            form.btnStop.Enabled = started;
        }
    }
}
