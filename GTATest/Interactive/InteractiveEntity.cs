using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;
using GTATest.Controllers;
using Newtonsoft.Json;

namespace GTATest.Interactive
{
    /// <summary>
    /// Represents a <see cref="ControlledEntity"/> that can interacted with.
    /// </summary>
    public class InteractiveEntity : ControlledEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        protected InteractiveEntity(Model model) : this(model.Hash)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        protected InteractiveEntity(int model)
        {
            Model = model;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected InteractiveEntity(Entity entity) : base(entity)
        {
            TrackEvents = true;
            TrackInteractions = true;
        }

        /// <summary>
        /// Gets the model of this InteractiveProp.
        /// </summary>
        [JsonProperty("modelHash")]
        public int Model
        {
            get;
        }

        /// <summary>
        /// Gets a dictionary of binds, that invokes the bound action.
        /// </summary>
        [JsonProperty("interactionBinds")]
        protected Dictionary<Keys, Action<object, EventArgs>> InteractionBinds { get; } = new Dictionary<Keys, Action<object, EventArgs>>();

        /// <summary>
        /// Simulates a key down in this <see cref="InteractiveEntity"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public override void KeyDown(object sender, KeyEventArgs e)
        {
            base.KeyDown(sender, e);

            if (!IsPlayerNearby) {
                return;
            }

            if (!InteractionBinds.ContainsKey(e.KeyCode)) {
                return;
            }

            InteractionBinds[e.KeyCode].Invoke(sender, e);
        }
    }
}
