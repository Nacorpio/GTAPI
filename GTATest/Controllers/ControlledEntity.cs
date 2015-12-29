using System;
using GTA;
using GTA.Math;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents an entity that can be controlled in additional ways.
    /// </summary>
    public abstract class ControlledEntity : TickableEntity<Entity>
    {
        /// <summary>
        /// Handles all the events of the <see cref="ControlledEntity"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void ControlledEntityEventHandler(object sender, EventArgs e);

        private bool _isAlive, _isDead, _isInAir, _isInWater;

        public event ControlledEntityEventHandler Alive, Dead, InAir, InWater;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public ControlledEntity(Entity entity) : base(entity)
        {}

        #region Operators

        public static explicit operator int(ControlledEntity entity)
        {
            return entity.Entity.Handle;
        }

        public static explicit operator Entity(ControlledEntity entity)
        {
            return entity.Entity;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the height of this <see cref="ControlledEntity"/>.
        /// </summary>
        public float Height => Size.Z;

        /// <summary>
        /// Gets the length of this <see cref="ControlledEntity"/>.
        /// </summary>
        public float Length => Size.Y;

        /// <summary>
        /// Gets the width of this <see cref="ControlledEntity"/>.
        /// </summary>
        public float Width => Size.X;

        /// <summary>
        /// Gets the size of this <see cref="ControlledEntity"/>.
        /// </summary>
        public Vector3 Size
        {
            get {
                Vector3 max, min;
                Entity.Model.GetDimensions(out max, out min);

                var xSize = System.Math.Max(max.X, min.X) - System.Math.Min(max.X, min.X);
                var ySize = System.Math.Max(max.Y, min.Y) - System.Math.Min(max.Y, min.Y);
                var zSize = System.Math.Max(max.Z, min.Z) - System.Math.Min(max.Z, min.Z);

                return new Vector3(xSize, ySize, zSize);
            }
        }

        #endregion

        /// <summary>
        /// Updates the frame of this <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected override void OnTick(object sender, TickEventArgs e)
        {
            base.OnTick(sender, e);

            if (Entity == null || !TrackEvents) {
                return;
            }

            if (Entity.IsDead != _isDead) {
                _isDead = Entity.IsDead;
                Dead?.Invoke(sender, e);
            }

            if (Entity.IsAlive != _isAlive) {
                _isAlive = Entity.IsAlive;
                Alive?.Invoke(sender, e);
            }

            if (Entity.IsInAir != _isInAir) {
                _isInAir = Entity.IsInAir;
                InAir?.Invoke(sender, e);
            }

            if (Entity.IsInWater != _isInWater) {
                _isInWater = Entity.IsInWater;
                InWater?.Invoke(sender, e);
            }
        }
    }
}