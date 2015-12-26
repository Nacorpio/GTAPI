using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTATest.Utilities;

namespace GTATest
{
    public sealed class Main : ExScript
    {
        public Main()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            Init();
        }

        protected override void Init()
        {}

        /// <summary>
        /// Displays a help text in the upper left-hand corner.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void DisplayHelpText(string text)
        {
            Function.Call(Hash._0x8509B634FBE7DA11, "STRING");
            Function.Call(Hash._0x6C188BE134E074AA, text);
            Function.Call(Hash._0x238FFE5C7B0498A6, 0, 0, 1, -1);
        }

        private void OnKeyDown(object sender, KeyEventArgs eventArgs)
        {
            switch (eventArgs.KeyCode) {
                case Keys.O:
                    SpawnScript.Manager.CreateInteractiveVehicle(VehicleHash.Ingot, Game.Player.Character.Position.Around(2f), true);
                    break;
                case Keys.I:
                    MenuScript.WindowManager.AddMenu(SpawnScript.PlayerInventory.Menu);
                    break;
            }
        }

        protected override void OnTick(object sender, EventArgs eventArgs)
        {}
    }
}
