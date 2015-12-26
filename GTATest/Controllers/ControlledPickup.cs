using System;
using GTA;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents a controlled <see cref="Pickup"/>.
    /// </summary>
    public class ControlledPickup
    {
        /// <summary>
        /// Handles all the events of the <see cref="ControlledPickup"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void ControlledPickupEventHandler(object sender, EventArgs e);

        private bool _collected;

        /// <summary>
        /// Occurs when the <see cref="ControlledPickup"/> has been picked up from the ground.
        /// </summary>
        public event ControlledPickupEventHandler Pickup;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPickup"/> class.
        /// </summary>
        public ControlledPickup()
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPickup"/> class.
        /// </summary>
        /// <param name="pickup">The pickup instance.</param>
        public ControlledPickup(Pickup pickup)
        {
            Object = pickup;
        }

        /// <summary>
        /// Gets the pickup object of this <see cref="ControlledPickup"/>.
        /// </summary>
        public Pickup Object { get; }

        /// <summary>
        /// Gets whether this <see cref="ControlledPickup"/> is nearby a Player.
        /// </summary>
        public bool IsPlayerNearby { get; private set; }

        /// <summary>
        /// Gets the distance required for a Player to interact with this <see cref="ControlledPickup"/>.
        /// </summary>
        public float PlayerInteractionDistance { get; protected set; }

        /// <summary>
        /// Called every tick when this <see cref="ControlledPickup"/> is nearby a Player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnPlayerNearby(object sender, EventArgs e)
        {
            IsPlayerNearby = true;
        }

        /// <summary>
        /// Called every tick of this <see cref="ControlledPickup"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public virtual void OnTick(object sender, EventArgs e)
        {
            if (Pickup == null) {
                return;
            }

            if (Object.IsCollected != _collected) {
                Pickup?.Invoke(sender, e);
                _collected = Object.IsCollected;
            }

            if (Game.Player.Character.Position.DistanceTo(Object.Position) <= PlayerInteractionDistance) {
                OnPlayerNearby(sender, e);
            } else {
                IsPlayerNearby = false;
            }
        }
    }
}
