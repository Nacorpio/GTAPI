using System;
using GTA;

namespace GTATest.Utilities
{
    public abstract class ExScript : Script
    {
        /// <summary>
        /// Initializes an instance of the ExScript class.
        /// </summary>
        protected ExScript()
        {
            Tick += OnTick;
        }

        /// <summary>
        /// Called every tick in this ExScript.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        protected virtual void OnTick(object sender, EventArgs eventArgs)
        {
            if (Ticks == 0) {
                Init();
            }
            Ticks++;
        }

        /// <summary>
        /// Called when this ExScript is being initialized.
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// Gets the tick lifespan of this ExScript.
        /// </summary>
        protected int Ticks { get; private set; }
    }
}
