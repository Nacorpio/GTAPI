using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTATest.Items;
using GTATest.Storage;

namespace GTATest
{
    public sealed class Main : Script
    {
        private Inventory _inventory;

        public Main()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            Init();
        }

        private void Init()
        {
            var inventory = new Inventory("Inventory");
            inventory.Add(Item.ItemExample);

            _inventory = inventory;
        }

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

        private readonly Dictionary<int, UIText> _texts = new Dictionary<int, UIText>();
        private float _range = 5f;

        public static bool ShowModels = false;

        private void OnTick(object sender, EventArgs eventArgs)
        {
            if (!ShowModels)
                return;

            var props = World.GetNearbyProps(Game.Player.Character.Position, _range).Where(prop => !prop.IsAttachedTo(Game.Player.Character)).ToList();
            props.ForEach(prop =>
            {
                if (_texts.ContainsKey(prop.Handle))
                    return;

                _texts.Add(prop.Handle, new UIText($"Model: ", UI.WorldToScreen(prop.Position), 0.19f));
            });

            _texts.ToList().ForEach(text =>
            {
                var prop = new Prop(text.Key);
                var distance = prop.Position.DistanceTo(Game.Player.Character.Position);

                if (distance > _range) {
                    _texts.Remove(prop.Handle);
                    return;
                }

                text.Value.Caption = $"Model: ~g~{prop.Model.Hash}~w~\n" +
                                     $"Distance: ~g~{distance}";

                text.Value.Position = UI.WorldToScreen(prop.Position);
                text.Value.Draw();
            });

            if (Game.Player.IsTargettingAnything) {
                var prop = Game.Player.GetTargetedEntity() as Prop;
                var msg = $"Model: ~g~{prop?.Model.Hash}~w~\n" +
                          $"Position: ~g~{prop?.Position}";

                UI.Notify(msg);
                Clipboard.SetText(msg);
            }
        }
    }
}
