using System;
using GTA;

namespace GTATest.Controllers
{
    public class ControlledVehicle : ControlledEntity
    {
        /// <summary>
        /// Handles all events within the ControlledVehicle class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void ControlledVehicleHandler(object sender, EventArgs e);

        public event ControlledVehicleHandler AlarmActivated , Stopped , SirenActivated , Damaged , AllWheels , Burnout , Drivable , Undrivable;
        private bool _isAlarmActive, _isStopped, _isSirenActive, _isDamaged, _isOnAllWheels, _isInBurnout, _isDrivable, _isUndrivable;

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
        /// Updates the frame of this ControlledEntity.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected override void OnTick(object sender, TickEventArgs e)
        {
            base.OnTick(sender, e);

            if (Vehicle == null || !TrackEvents) {
                return;
            }

            if (Vehicle.AlarmActive != _isAlarmActive) {
                _isAlarmActive = Vehicle.AlarmActive;
                AlarmActivated?.Invoke(sender, e);
            }

            if (Vehicle.IsStopped != _isStopped) {
                _isStopped = Vehicle.IsStopped;
                Stopped?.Invoke(sender, e);
            }

            if (Vehicle.SirenActive != _isSirenActive) {
                _isSirenActive = Vehicle.SirenActive;
                SirenActivated?.Invoke(sender, e);
            }

            if (Vehicle.IsDamaged != _isDamaged) {
                _isDamaged = Vehicle.IsDamaged;
                Damaged?.Invoke(sender, e);
            }

            if (Vehicle.IsOnAllWheels != _isOnAllWheels) {
                _isOnAllWheels = Vehicle.IsOnAllWheels;
                AllWheels?.Invoke(sender, e);
            }

            if (Vehicle.IsInBurnout() != _isInBurnout) {
                _isInBurnout = Vehicle.IsInBurnout();
                Burnout?.Invoke(sender, e);
            }

            if (Vehicle.IsDriveable != _isDrivable) {
                _isDrivable = Vehicle.IsDriveable;
                Drivable?.Invoke(sender, e);
            }

            if (!Vehicle.IsDriveable != _isUndrivable) {
                _isUndrivable = !Vehicle.IsDriveable;
                Undrivable?.Invoke(sender, e);
            }
        }
    }
}
