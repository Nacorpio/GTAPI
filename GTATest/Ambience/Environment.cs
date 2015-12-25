using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace GTATest.Ambience
{
    public static class Environment
    {
        private readonly static Dictionary<Keys, Action<object, KeyEventArgs>> KeyBinds;

        /// <summary>
        /// Initializes an instance of the Environment class.
        /// </summary>
        static Environment()
        {
            KeyBinds = new Dictionary<Keys, Action<object, KeyEventArgs>>();
        }

        /// <summary>
        /// Binds the specified key to the specified action.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        public static void AddBind(Keys key, Action<object, KeyEventArgs> action)
        {
            if (KeyBinds.ContainsKey(key)) {
                return;
            }
            KeyBinds.Add(key, action);
        }

        /// <summary>
        /// Initializes the Environment.
        /// </summary>
        public static void Init()
        {}

        public static void OnTick(object sender, EventArgs e)
        {
            if (!SpawnScript.DoDespawn) {
                return;
            }

            Game.Player.WantedLevel = 0;

            Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0);
            Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0);
            Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0);
            Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0);
            Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0);
        }

        public static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!KeyBinds.ContainsKey(e.KeyCode)) {
                return;
            }
            KeyBinds[e.KeyCode].Invoke(sender, e);
        }
    }
}
