using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;

namespace GTATest
{
    public abstract class Tickable : ITickable
    {
        #region EventArgs

        /// <summary>
        /// Represents the event arguments which gets passed through during a tick.
        /// </summary>
        public class TickEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes an instance of the TickEventArgs class.
            /// </summary>
            /// <param name="ticks">The ticks.</param>
            public TickEventArgs(int ticks)
            {
                Ticks = ticks;
            }

            /// <summary>
            /// Gets the ticks of this TickEventArgs.
            /// </summary>
            public int Ticks { get; }
        }

        #endregion EventArgs

        #region Delegates

        /// <summary>
        /// Handles the tick events in the <see cref="Tickable"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The tick event arguments.</param>
        public delegate void TickableEventHandler(object sender, TickEventArgs e);

        /// <summary>
        /// Handles the key events in the <see cref="Tickable"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        public delegate void TickableKeyEventHandler(object sender, KeyEventArgs e);

        #endregion Delegates

        #region Events

        /// <summary>
        /// Raised when a tick has been made in this <see cref="Tickable"/>.
        /// </summary>
        protected event TickableEventHandler Tick;

        /// <summary>
        /// Raised when a key on the keyboard goes down in this <see cref="Tickable"/>.
        /// </summary>
        protected event TickableKeyEventHandler KeyDown;

        /// <summary>
        /// Raised when a key on the keyboard goes up in this <see cref="Tickable"/>.
        /// </summary>
        protected event TickableKeyEventHandler KeyUp;

        /// <summary>
        /// Raised on the first tick of this <see cref="Tickable"/>.
        /// </summary>
        protected event TickableEventHandler Init;

        #endregion Events

        private readonly Dictionary<Keys, Action<int>> _keyDownActions, _keyUpActions;

        protected Tickable(dynamic obj)
        {
            Object = obj;

            _keyDownActions = new Dictionary<Keys, Action<int>>();
            _keyUpActions = new Dictionary<Keys, Action<int>>();
        }

        /// <summary>
        /// Adds an action bound to the specified key in the KeyUp event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to invoke.</param>
        protected void AddKeyUpAction(Keys key, Action<int> action)
        {
            if (_keyUpActions.ContainsKey(key))
            {
                return;
            }

            _keyUpActions.Add(key, action);
        }

        /// <summary>
        /// Adds an action bound to the specified key in the KeyDown event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to invoke.</param>
        protected void AddKeyDownAction(Keys key, Action<int> action)
        {
            if (_keyDownActions.ContainsKey(key))
            {
                return;
            }

            _keyDownActions.Add(key, action);
        }

        /// <summary>
        /// Updates the tick of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void OnTick(object sender, EventArgs e)
        {
            Tick?.Invoke(sender, new TickEventArgs(Ticks));

            if (Ticks == 0)
            {
                StartDateTime = DateTime.Now;
                Init?.Invoke(sender, new TickEventArgs(Ticks));
            }

            Ticks++;
        }

        /// <summary>
        /// Sends a KeyDown event to this <see cref="TickableEntity{T}"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(sender, e);
            if (_keyDownActions.ContainsKey(e.KeyCode) && TrackActions)
            {
                _keyDownActions[e.KeyCode].Invoke(Ticks);
            }
        }

        /// <summary>
        /// Sends a KeyUp event to this <see cref="TickableEntity{T}"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            KeyUp?.Invoke(sender, e);
            if (_keyUpActions.ContainsKey(e.KeyCode) && TrackActions)
            {
                _keyUpActions[e.KeyCode].Invoke(Ticks);
            }
        }

        /// <summary>
        /// Gets the object of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public dynamic Object { get; protected set; }

        /// <summary>
        /// Gets the start time/date of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public DateTime StartDateTime { get; private set; }

        /// <summary>
        /// Gets the lifespan of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public TimeSpan Lifespan => (DateTime.Now - StartDateTime).Duration();

        /// <summary>
        /// Gets the distance of this <see cref="TickableEntity{T}"/> to interact with a player.
        /// </summary>
        protected float PlayerInteractionDistance { get; set; } = 2f;

        /// <summary>
        /// Gets the ticks of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public int Ticks { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="TickableEntity{T}"/> should invoke actions.
        /// </summary>
        protected bool TrackActions { get; set; } = true;

        /// <summary>
        /// Gets whether this <see cref="TickableEntity{T}"/> should track events.
        /// </summary>
        protected bool TrackEvents { get; set; } = true;
    }

    /// <summary>
    /// Represents a class, which should be implemented by all objects that can be updated.
    /// </summary>
    public abstract class TickableEntity<T> : Tickable where T : Entity
    {
        protected event TickableEventHandler PlayerNearbyTick , PlayerTouchTick;

        /// <summary>
        /// Initializes a protected instance of the <see cref="TickableEntity{T}"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        protected TickableEntity(T obj) : base(obj)
        {
            Tick += OnTick;
        }

        /// <summary>
        /// Gets called every tick of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="tickEventArgs">The tick event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnTick(object sender, TickEventArgs tickEventArgs)
        {
            if (Entity.Handle == Game.Player.Character.Handle) {
                return;
            }

            if (Game.Player.Character.Position.DistanceTo(Entity.Position) <= PlayerInteractionDistance) {
                IsPlayerNearby = true;
                PlayerNearbyTick?.Invoke(sender, tickEventArgs);
            } else {
                IsPlayerNearby = false;
            }

            if (Game.Player.Character.IsTouching(Entity)) {
                IsPlayerTouching = true;
                PlayerTouchTick?.Invoke(sender, tickEventArgs);
            } else {
                IsPlayerTouching = false;
            }
        }

        /// <summary>
        /// Destroys this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public void Destroy()
        {
            SpawnScript.Manager.Destroy(Entity.Handle);
        }

        /// <summary>
        /// Gets whether the player is nearby this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public bool IsPlayerNearby { get; private set; }

        /// <summary>
        /// Gets whether the player is touching this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public bool IsPlayerTouching { get; private set; }

        /// <summary>
        /// Gets the entity of this <see cref="TickableEntity{T}"/>.
        /// </summary>
        public Entity Entity
        {
            get { return (Entity) Object; }
            set { Object = value; }
        }
    }
}