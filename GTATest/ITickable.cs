using System;
using System.Windows.Forms;

namespace GTATest
{
    /// <summary>
    /// Represents an interface, which should be implemented by all objects that can be updated.
    /// </summary>
    public interface ITickable
    {
        /// <summary>
        /// Updates the tick of this <see cref="ITickable"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        void OnTick(object sender, EventArgs e);

        /// <summary>
        /// Sends a KeyDown event to this <see cref="ITickable"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        void KeyDown(object sender, KeyEventArgs e);

        /// <summary>
        /// Sends a KeyUp event to this <see cref="ITickable"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        void KeyUp(object sender, KeyEventArgs e);

        /// <summary>
        /// Gets the distance of this <see cref="ITickable"/> to interact with a Player.
        /// </summary>
        float PlayerInteractionDistance { get; }

        /// <summary>
        /// Gets the ticks of this <see cref="ITickable"/>.
        /// </summary>
        int Ticks { get; }

        /// <summary>
        /// Gets whether this <see cref="ITickable"/> should track events.
        /// </summary>
        bool TrackEvents { get; }
    }
}
