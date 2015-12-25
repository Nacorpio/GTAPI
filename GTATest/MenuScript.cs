using System;
using System.Windows.Forms;
using GTA;
using mlgthatsme.GUI;

namespace GTATest
{
    public class MenuScript : Script
    {
        public readonly static WindowManager WindowManager = new WindowManager();

        public MenuScript()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            WindowManager.KeyDown(sender, keyEventArgs);
        }

        private void OnTick(object sender, EventArgs eventArgs)
        {
            WindowManager.OnTick(sender, eventArgs);
        }
    }
}
