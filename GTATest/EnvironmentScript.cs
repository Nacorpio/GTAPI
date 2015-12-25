using System;
using System.Windows.Forms;
using GTA;
using Environment = GTATest.Ambience.Environment;

namespace GTATest
{
    public sealed class EnvironmentScript : Script
    {
        //Ammunation: {left: 97297972, right: -8873588}
        //24/7 Supermarket: {left: 1196685123, right: 997554217}
        //Gate: -1184516519
        //Prison gate: 741314661
        //Train gate: -1451925505
        //Auto-repair door: -822900180
        //LSC door: 399362

        public EnvironmentScript()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            Init();
        }

        private void Init()
        {
            Environment.Init();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Environment.OnKeyDown(sender, keyEventArgs);
        }

        private void OnTick(object sender, EventArgs eventArgs)
        {
            Environment.OnTick(sender, eventArgs);
        }
    }
}
