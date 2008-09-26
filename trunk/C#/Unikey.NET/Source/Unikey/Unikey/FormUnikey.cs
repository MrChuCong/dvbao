using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace Unikey
{
    public partial class FormUnikey : Form
    {
        private Unikey unikey;
        private const string Dll = "dvoraksip.dll";

        public FormUnikey()
        {
            InitializeComponent();
            RegisterInputMethod();
            pbLogo.Image = Properties.Resources.Background;
            Vni.Init();
            Telex.Init();
            unikey = Unikey.Create(this);
        }

        private void RegisterInputMethod()
        {
            Module module =
                System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0];
            string startupPath = module.FullyQualifiedName;
            startupPath = startupPath.Replace(module.Name, "");
            RegistryKey CLSID_Key = Registry.ClassesRoot.CreateSubKey("CLSID");
            RegistryKey VSIP_Key =
                CLSID_Key.CreateSubKey("{42429695-AE04-11D0-A4F8-00AA00A749B9}");
            VSIP_Key.SetValue("Default", "Vietnamese Keyboard");
            RegistryKey DefaultIcon_Key = VSIP_Key.CreateSubKey("DefaultIcon");
            DefaultIcon_Key.SetValue("Default", startupPath + Dll + ",0");
            RegistryKey InprocServer32_Key = VSIP_Key.CreateSubKey("InprocServer32");
            InprocServer32_Key.SetValue("Default", startupPath + Dll);
            RegistryKey IsSIPInputMethod_Key = VSIP_Key.CreateSubKey("IsSIPInputMethod");
            IsSIPInputMethod_Key.SetValue("Default", "1");
        }

        private void FormUnikey_Load(object sender, EventArgs e)
        {
            radVni.Checked = true;
            chkSwitchKey.Checked = true;
            chkActivateKey.Checked = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            unikey.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            unikey.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            unikey.Dispose();
            Application.Exit();
        }

        private void CheckInputMethod()
        {
            if (radVni.Checked) unikey.InputMethod = Vni.Create();
            else unikey.InputMethod = Telex.Create();
        }

        private void radVni_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputMethod();
        }

        private void radTelex_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputMethod();
        }

        private void chkSwitchKey_CheckStateChanged(object sender, EventArgs e)
        {
            unikey.SwitchKey = chkSwitchKey.Checked;
        }

        private void chkActivateKey_CheckStateChanged(object sender, EventArgs e)
        {
            unikey.ActivateKey = chkActivateKey.Checked;
        }
    }
}