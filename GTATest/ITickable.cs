using System;
using System.Windows.Forms;

namespace GTATest
{
    public interface ITickable
    {
        /// <summary>
        /// Should be called every tick inside a Script.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        void OnTick(object sender, EventArgs e);

        /// <summary>
        /// Should be called every KeyDown event inside a Script.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        void OnKeyDown(object sender, KeyEventArgs e);

        /// <summary>
        /// Should be called every KeyUp event inside a Script.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        void OnKeyUp(object sender, KeyEventArgs e);
    }
}
