using System;
using System.Windows.Forms;
using GTA;

namespace GTATest.Interactive.Props
{
    public class PropHealthPack : PropPickup
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PropHealthPack"/> class.
        /// </summary>
        public PropHealthPack(int health = 50) : base(Keys.E, 678958360)
        {
            Health = health;
        }

        /// <summary>
        /// Called when this <see cref="PropPickup"/> has been picked up from the ground.
        /// </summary>
        /// <param name="o">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        protected override void Pickup(object o, EventArgs eventArgs)
        {
            base.Pickup(o, eventArgs);

            if (Game.Player.Character.IsInVehicle()) {
                return;
            }

            Game.Player.Character.Health += Health;
            UI.Notify($"Health: ~green~{Game.Player.Character.Health} / {Game.Player.Character.MaxHealth} hp");

            Destroy();
        }

        /// <summary>
        /// Gets the amount of health points that gets restored from using this <see cref="PropHealthPack"/>.
        /// </summary>
        public int Health { get; }
    }
}
