using System;
using GTA;
using GTA.Math;

namespace GTATest.Controllers
{
    public abstract class ControlledVehicle : ControlledEntity
    {
        /// <summary>
        /// Initializes an instance of the ControlledEntity class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public ControlledVehicle(Entity entity) : base(entity)
        {}

        /// <summary>
        /// Gets the Vehicle that has been controlled originally.
        /// </summary>
        public Vehicle Vehicle => (GTA.Vehicle) Entity;

        /// <summary>
        /// Called every tick the alarm of this ControlledVehicle is active.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnAlarmActive(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick the sirens of this ControlledVehicle are active.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnSirenActive(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this ControlledVehicle isn't moving.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnStopped(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this ControlledVehicle is driving.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnDriving(object sender, EventArgs e)
        {}

        /// <summary>
        /// Updates the frame of this ControlledEntity.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (Vehicle.AlarmActive) {
                OnAlarmActive(sender, e);
            }

            if (Vehicle.IsStopped) {
                OnStopped(sender, e);
            } else {
                OnDriving(sender, e);
            }

            if (Vehicle.SirenActive) {
                OnSirenActive(sender, e);
            }
        }

        

    }
}
