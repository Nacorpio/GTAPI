﻿using System;
using System.Windows.Forms;
using GTA;

namespace GTATest.Interactive.Props
{
    public class PropPickup : InteractiveProp
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PropPickup"/> class.
        /// </summary>
        protected PropPickup(Keys pickupKey, int model) : base(model)
        {
            InteractionBinds.Add(pickupKey, Pickup);
        }

        /// <summary>
        /// Initializes an instance of the <see cref="PropPickup"/> class.
        /// </summary>
        /// <param name="prop">The prop.</param>
        protected PropPickup(Prop prop) : base(prop)
        {}

        /// <summary>
        /// Called when this <see cref="PropPickup"/> has been picked up from the ground.
        /// </summary>
        /// <param name="o">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        protected virtual void Pickup(object o, EventArgs eventArgs)
        {}

        /// <summary>
        /// Called every tick this <see cref="PropPickup"/> is nearby a player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void OnPlayerNearby(object sender, EventArgs e)
        {
            base.OnPlayerNearby(sender, e);

            if (!Game.Player.Character.IsInVehicle()) {
                Main.DisplayHelpText("Press ~green~E~white~ to pickup the item");
            }
        }
    }
}
