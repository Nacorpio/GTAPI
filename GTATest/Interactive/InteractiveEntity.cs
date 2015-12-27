using GTA;
using GTATest.Controllers;
using Newtonsoft.Json;

namespace GTATest.Interactive
{
    /// <summary>
    /// Represents a <see cref="ControlledEntity"/> that can interacted with.
    /// </summary>
    public abstract class InteractiveEntity : ControlledEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected InteractiveEntity(Entity entity) : base(entity)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        protected InteractiveEntity(int model) : this(null)
        {
            Model = model;
        }

        /// <summary>
        /// Gets the model of this InteractiveProp.
        /// </summary>
        [JsonProperty("modelHash")]
        public int Model
        {
            get;
        }
    }
}
