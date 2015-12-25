using System;
using System.Windows.Forms;
using GTA;
using GTA.Math;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents an entity that can be controlled in additional ways.
    /// </summary>
    public class ControlledEntity
    {

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledEntity"/> class.
        /// </summary>
        public ControlledEntity()
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public ControlledEntity(Entity entity)
        {
            Entity = entity;
            StartDateTime = DateTime.Now;
        }

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
            get
            {
                Vector3 max, min;
                Entity.Model.GetDimensions(out max, out min);

                var xSize = Math.Max(max.X, min.X) - Math.Min(max.X, min.X);
                var ySize = Math.Max(max.Y, min.Y) - Math.Min(max.Y, min.Y);
                var zSize = Math.Max(max.Z, min.Z) - Math.Min(max.Z, min.Z);

                return new Vector3(xSize, ySize, zSize);
            }
        }

        /// <summary>
        /// Gets whether a Player is nearby this ControlledEntity.
        /// </summary>
        public bool IsPlayerNearby { get; private set; }

        /// <summary>
        /// Gets whether a Player is touching this ControlledEntity.
        /// </summary>
        public bool IsTouchingPlayer { get; private set; }

        /// <summary>
        /// Gets the lifespan of this ControlledEntity.
        /// </summary>
        public TimeSpan LifeSpan => (DateTime.Now - StartDateTime).Duration();

        /// <summary>
        /// Gets the date or time this ControlledEntity was added.
        /// </summary>
        public DateTime StartDateTime { get; }

        /// <summary>
        /// Gets or sets whether this <see cref="ControlledEntity"/> should track interactions.
        /// </summary>
        public bool TrackInteractions { get; protected set; } = true;

        /// <summary>
        /// Gets or sets whether this <see cref="ControlledEntity"/> should track events.
        /// </summary>
        protected bool TrackEvents { get; set; } = true;

        /// <summary>
        /// Gets or sets the sufficient distance for a player to interact with this <see cref="ControlledEntity"/>.
        /// </summary>
        protected float PlayerInteractionDistance { get; set; } = 2f;

        /// <summary>
        /// Gets or sets the sufficient distance for a ped to interact with this <see cref="ControlledEntity"/>.
        /// </summary>
        protected float PedInteractionDistance { get; set; } = 2f;

        /// <summary>
        /// Gets the controlled Entity of this <see cref="ControlledEntity"/>.
        /// </summary>
        public Entity Entity { get; protected set; }

        #endregion

        #region Virtual tick methods

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is in water.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnInWater(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is airborne. 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnInAir(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is dead.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnDead(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is alive.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnAlive(object sender, EventArgs e)
        {}

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is touching a Player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnTouchingPlayer(object sender, EventArgs e)
        {
            IsTouchingPlayer = true;
        }

        /// <summary>
        /// Called every tick this <see cref="ControlledEntity"/> is nearby a player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnPlayerNearby(object sender, EventArgs e)
        {
            IsPlayerNearby = true;
        }

        #endregion

        /// <summary>
        /// Destroys this ControlledEntity.
        /// </summary>
        public void Destroy()
        {
            SpawnScript.Manager.Destroy(Entity.Handle);
        }

        /// <summary>
        /// Updates the frame of this <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public virtual void OnTick(object sender, EventArgs e)
        {
            if (Entity == null || !TrackEvents) {
                return;
            }

            if (Entity.IsAlive) {
                OnAlive(sender, e);
            } else {
                OnDead(sender, e);
            }

            if (Entity.IsInAir) {
                OnInAir(sender, e);
            }

            if (Entity.IsInWater) {
                OnInWater(sender, e);
            }

            if (!Game.Player.IsAlive) {
                return;
            }

            if (Entity.IsTouching(Game.Player.Character)) {
                OnTouchingPlayer(sender, e);
            } else {
                IsTouchingPlayer = false;
            }

            if (Game.Player.Character.Position.DistanceTo(Entity.Position) <= PlayerInteractionDistance) {
                OnPlayerNearby(sender, e);
            } else {
                IsPlayerNearby = false;
            }
        }

        /// <summary>
        /// Simulates a key down in this <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public virtual void KeyDown(object sender, KeyEventArgs e)
        {}
    }
}
